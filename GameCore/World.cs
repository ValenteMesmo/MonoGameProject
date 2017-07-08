﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    internal class World
    {
        public readonly InputRepository PlayerInputs;
        private readonly TouchInputHandler TouchInputHandler;

        internal List<Thing> Things = new List<Thing>();
        //public const int SPACE_BETWEEN_THINGS = 1;
        public readonly Camera2d Camera2d;
        public bool Stopped { get; set; }

        private int sleep;

        public World(
            Camera2d Camera2d
            )
        {
            this.Camera2d = Camera2d;
            PlayerInputs = new InputRepository(Camera2d);
            TouchInputHandler = new TouchInputHandler(PlayerInputs);
        }

        public bool Sleeping()
        {
            return sleep > 0;
        }

        public void Sleep()
        {
            sleep = 6;
        }

        public void Add(Thing thing)
        {
            thing.OnDestroy = Remove;
            Things.Add(thing);
        }

        public void Remove(Thing thing)
        {
            Things.Remove(thing);
        }

        public void Update()
        {
            if (Stopped)
                return;

            PlayerInputs.Update();

            List<Vector2> touches = TouchInputHandler.GetTouches();
            Things.ForEach(thing =>
            {
                thing.Animations.ForEach(f => f.Update());
                TouchInputHandler.Handle(thing.Touchables, touches);
            });

            if (sleep > 0)
            {
                sleep--;
                return;
            }

            Things.ToList().ForEach(thing =>
                thing.Updates.ForEach(update =>
                    update(thing)));

            Things.ForEach(thing => thing.MoveHorizontally());

            //TODO: QuadTree
            //https://github.com/ChevyRay/QuadTree
            //https://gamedevelopment.tutsplus.com/tutorials/quick-tip-use-quadtrees-to-detect-likely-collisions-in-2d-space--gamedev-374


            var passiveColliders = new List<Collider>();
            var activeColliders = new List<Collider>();
            Things.ForEach(thing =>
            {
                thing.Colliders.ForEach(collider =>
                {
                    if (collider.BotCollisionHandlers.Any()
                        || collider.TopCollisionHandlers.Any()
                        || collider.LeftCollisionHandlers.Any()
                        || collider.RightCollisionHandlers.Any())
                    {
                        activeColliders.Add(collider);
                        passiveColliders.Add(collider);
                    }
                    else
                        passiveColliders.Add(collider);
                });
            });

            activeColliders.ForEach(active =>
            {
                passiveColliders.ForEach(passive =>
                {
                    if (active != passive)
                        ColliderExtensions.HandleHorizontalCollision(active, passive);
                });
            });
            //TODO: mover esse selectmany tolist para cima. fazer uma vez só
            //Things.SelectMany(thing => thing.PassiveColliders)
            //    .ToList()
            //    .ForEachCombination(
            //        ColliderExtensions.HandleHorizontalCollision);

            Things.ForEach(thing => thing.MoveVertically());

            //Things.SelectMany(thing => thing.PassiveColliders)
            //    .ToList()
            //    .ForEachCombination(
            //        ColliderExtensions.HandleVerticalCollision);
            activeColliders.ForEach(active =>
            {
                passiveColliders.ForEach(passive =>
                {
                    if (active != passive)
                        ColliderExtensions.HandleVerticalCollision(active, passive);
                });
            });
        }

        public void Clear()
        {
            Things.Clear();
        }

    }
}