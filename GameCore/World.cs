using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    internal class World
    {
        internal List<Thing> Things = new List<Thing>();
        public readonly Camera2d Camera2d;
        public bool Stopped { get; set; }

        private int sleep;

        public World(
            Camera2d Camera2d
            )
        {
            this.Camera2d = Camera2d;
        }

        public bool Sleeping()
        {
            return sleep > 0;
        }

        public void Sleep()
        {
            sleep = 9;
        }

        public void Add(Thing thing)
        {
            thing.OnDestroyInternal = Remove;
            Things.Add(thing);
        }

        public void Remove(Thing thing)
        {
            Things.Remove(thing);
        }

        //int aaa = 0;
        public void Update()
        {
            //TODO: Auto play on x4 speed.....   using recorded inputs
            //NewMethod();
            //NewMethod();
            //NewMethod();
            //if (aaa >= 5)
            {
                //aaa = 0;
                NewMethod();
            }
            //aaa++;
        }

        private IEnumerable<Vector2> GetTouches()
        {
            var touchCollection = TouchPanel.GetState();

            var touches = new List<Vector2>();
            foreach (TouchLocation tl in touchCollection)
            {
                if ((tl.State == TouchLocationState.Pressed)
                    || (tl.State == TouchLocationState.Moved))
                {
                    touches.Add(
                        Camera2d.ToWorldLocation(tl.Position));
                }
            }

            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                touches.Add(
                      Camera2d.ToWorldLocation(mouseState.Position.ToVector2()));
            }

            return touches;
        }

        private void NewMethod()
        {
            if (Stopped)
                return;

            Things.ForEach(thing =>
            {
                thing.Animations.ForEach(f => f.Update());
            });

            if (sleep > 0)
            {
                sleep--;
                return;
            }

            Things.ToList().ForEach(thing =>
                thing.Updates.ForEach(update =>
                    update()));

            var touches = GetTouches();

            var passiveColliders = new List<Collider>();
            var activeColliders = new List<Collider>();
            Things.ForEach(thing =>
            {
                thing.TouchAreas.ForEach(area =>
                {
                    //var touching = false;
                    Vector2? selectedTouch = null;

                    foreach (var touch in touches)
                    {
                        if (area.Left() <= touch.X
                            && area.Right() >= touch.X
                            && area.Top() <= touch.Y
                            && area.Bottom() >= touch.Y)
                        {
                            //touching = true;
                            selectedTouch = touch;
                            break;
                        }
                    }

                    area.SetTouch(selectedTouch);
                });

                thing.Colliders.ForEach(collider =>
                {
                    collider.CollidingWith.Clear();

                    if (collider.Disabled)
                        return;

                    if (collider.BotCollisionHandlers.Any()
                        || collider.TopCollisionHandlers.Any()
                        || collider.LeftCollisionHandlers.Any()
                        || collider.RightCollisionHandlers.Any())
                    {
                        activeColliders.Add(collider);
                        //passiveColliders.Add(collider);
                    }
                    else
                        passiveColliders.Add(collider);

                    collider.CollectiveMass_Bot = collider.Mass;
                    collider.CollectiveMass_Left = collider.Mass;
                    collider.CollectiveMass_Right = collider.Mass;
                    collider.CollectiveMass_Top = collider.Mass;
                });
            });

            //TODO: QuadTree
            //https://github.com/ChevyRay/QuadTree
            //https://gamedevelopment.tutsplus.com/tutorials/quick-tip-use-quadtrees-to-detect-likely-collisions-in-2d-space--gamedev-374
            Things.ForEach(thing => thing.MoveHorizontally());
            activeColliders.ForEach(source =>
            {
                activeColliders.ForEach(target =>
                {
                    if (source != target)
                        ColliderExtensions.HandleHorizontalCollision(source, target);
                });
                passiveColliders.ForEach(target =>
                {
                    //if (source != target)
                    ColliderExtensions.HandleHorizontalCollision(source, target);
                });
            });

            Things.ForEach(thing => thing.MoveVertically());
            activeColliders.ForEach(source =>
            {
                activeColliders.ForEach(target =>
                {
                    if (source != target)
                        ColliderExtensions.HandleVerticalCollision(source, target);
                });
                passiveColliders.ForEach(target =>
                {
                    //if (active != passive)
                    ColliderExtensions.HandleVerticalCollision(source, target);
                });
            });

            //gambiarra
            //  player pisando no boss ativava colisão horizontal em vez da vertical
            //  isso no update o boss entrava na terra (gravidade) e nas colisões ele saia...
            //  no fim do ciclo, o player acabava ficando dentro do boss
            //  prar resolver isso nas coxas, verifico se tem mais alguma colisão vertical entre os
            //  colliders ativos
            activeColliders.ForEach(source =>
            {
                activeColliders.ForEach(target =>
                {
                    if (source != target)
                        ColliderExtensions.HandleVerticalCollision(source, target);
                });
            });

            Things.ToList().ForEach(thing =>
                thing.AfterUpdates.ForEach(update =>
                    update()));
        }

        public void Clear()
        {
            Things.Clear();
        }
    }
}