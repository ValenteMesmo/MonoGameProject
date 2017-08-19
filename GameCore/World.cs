using Microsoft.Xna.Framework;
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
            sleep = 4;
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

            var passiveColliders = new List<Collider>();
            var activeColliders = new List<Collider>();
            Things.ForEach(thing =>
            {
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
        }

        public void Clear()
        {
            Things.Clear();
        }
    }
}