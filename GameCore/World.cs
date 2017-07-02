using GameCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameCore
{
    internal class World
    {
        public readonly InputRepository PlayerInputs;
        public const int SPACE_BETWEEN_THINGS = 4;
        public readonly Camera2d Camera2d;
        public bool Stopped { get; set; }

        private int sleep;
        private readonly TouchInputHandler TouchInputHandler;

        internal List<Thing> Things = new List<Thing>();

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

            Things.ForEach(thing =>
                TouchInputHandler.Handle(thing.Touchables)
            );

            if (sleep > 0)
            {
                sleep--;
                return;
            }

            Things.ForEach(thing =>
                thing.Updates.ForEach(update =>
                    update.Update()));

            Things.ForEach(thing =>
                thing.Colliders.ForEach(collider =>
                    collider.MoveHorizontally()));

            //TODO: QuadTree
            //https://github.com/ChevyRay/QuadTree
            //https://gamedevelopment.tutsplus.com/tutorials/quick-tip-use-quadtrees-to-detect-likely-collisions-in-2d-space--gamedev-374

            //TODO: mover esse selectmany tolist para cima. fazer uma vez só
            Things.SelectMany(thing => thing.Colliders)
                .ToList()
                .ForEachCombination(
                    ColliderExtensions.HandleHorizontalCollision);

            Things.ForEach(thing =>
                thing.Colliders.ForEach(collider =>
                    collider.MoveVertically()));

            Things.SelectMany(thing => thing.Colliders)
                .ToList()
                .ForEachCombination(
                    ColliderExtensions.HandleVerticalCollision);
        }

        public void Clear()
        {
            Things.Clear();
        }

    }
}