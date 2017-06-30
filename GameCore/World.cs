using GameCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameCore
{
    public class World
    {
        public readonly InputRepository PlayerInputs;
        public const int SPACE_BETWEEN_THINGS = 4;
        public readonly Camera2d Camera2d;
        public bool Stopped { get; set; }

        private int sleep;

        private List<ICauseCollisions> CollidersToUseOnRenderThread;

        private List<SomethingThatUpdates> Updates;
        private List<ICauseCollisions> Colliders;
        private List<TouchableThing> Touchables;
        private readonly TouchInputHandler TouchInputHandler;

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

        public void Add(Something thing)
        {
            if (thing is SomethingThatUpdates)
                Updates.Add(thing as SomethingThatUpdates);
            if (thing is ICauseCollisions)
                Colliders.Add(thing as ICauseCollisions);
            if (thing is TouchableThing)
                Touchables.Add(thing as TouchableThing);
        }

        public void Remove(Something thing)
        {
            if (thing is SomethingThatUpdates)
                Updates.Remove(thing as SomethingThatUpdates);
            if (thing is ICauseCollisions)
                Colliders.Remove(thing as ICauseCollisions);
            if (thing is TouchableThing)
                Touchables.Remove(thing as TouchableThing);
        }

        public IEnumerable<ICauseCollisions> GetColliders()
        {
            return CollidersToUseOnRenderThread;
        }

        internal IEnumerable<string> GetAudios()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<object> GetAnimations()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            lock (CollidersToUseOnRenderThread)
            {
                //Destination array was not long enough. Check destIndex and length, and the array's lower bounds.'
                CollidersToUseOnRenderThread = Colliders.ToList();
            }

            if (Stopped)
                return;

            foreach (var item in Colliders)
            {
                item.RenderX = item.X;
                item.RenderY = item.Y;
            }

            PlayerInputs.Update();
            TouchInputHandler.Handle(Touchables);

            if (sleep > 0)
            {
                sleep--;
                return;
            }

            {
                var currentUpdates = Updates.ToList();
                foreach (var item in currentUpdates)
                {
                    item.Update();
                }
            }

            foreach (var item in Colliders)
            {
                item.MoveHorizontally();
            }

            //TODO: QuadTree
            //https://github.com/ChevyRay/QuadTree
            //https://gamedevelopment.tutsplus.com/tutorials/quick-tip-use-quadtrees-to-detect-likely-collisions-in-2d-space--gamedev-374

            var currentColliders = Colliders.ToList();

            currentColliders.ForEachCombination(
                IColliderExtensions
                    .HandleHorizontalCollision);

            foreach (var item in currentColliders)
            {
                item.MoveVertically();
            }

            currentColliders.ForEachCombination(
                IColliderExtensions
                    .HandleVerticalCollision);
        }

        public void Clear()
        {
            Updates.Clear();
            Colliders.Clear();
            Touchables.Clear();
        }
    }
}
