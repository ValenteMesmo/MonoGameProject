using GameCore;
using System;

namespace MonoGameProject
{
    public class WorldMover : Thing
    {
        public readonly Camera2d Camera;
        public static int WorldHorizontalSpeed;
        private Thing MovingRightBy;
        private Thing MovingLeftBy;
        private bool BackBlocking;
        private const int VELOCITY = 6;
        private const int FRICTION = 8;
        internal Thing camlocker;

        public WorldMover(Camera2d Camera)
        {
            this.Camera = Camera;
            X = (int)Camera.Pos.X;
            Y = (int)Camera.Pos.Y;

            AddUpdate(() =>
            {
                if (MovingRightBy == null && MovingLeftBy == null)
                {
                    if (WorldHorizontalSpeed > 0)
                    {
                        WorldHorizontalSpeed -= FRICTION;
                        if (WorldHorizontalSpeed < 0)
                            WorldHorizontalSpeed = 0;
                    }
                    else if (WorldHorizontalSpeed < 0)
                    {
                        WorldHorizontalSpeed += FRICTION;
                        if (WorldHorizontalSpeed > 0)
                            WorldHorizontalSpeed = 0;
                    }
                }
                if (GameState.BossMode)
                {
                    var expected = -MapModule.WIDTH;

                    //-8001   -8000
                    if (camlocker.X < expected && Math.Abs(camlocker.X - expected) > 100)
                    {
                        WorldHorizontalSpeed = -100;
                        if (camlocker.X > expected)
                        {
                            WorldHorizontalSpeed = 0;
                        }
                    }
                    //-7999   -8000
                    else if (camlocker.X > expected && Math.Abs(expected - camlocker.X) > 100)
                    {
                        WorldHorizontalSpeed = 100;
                        if (camlocker.X < expected)
                        {
                            WorldHorizontalSpeed = 0;
                        }
                    }
                    else
                        WorldHorizontalSpeed = 0;
                }
            });

            CreateLeftCollider();
            CreateRightCollider();

            AddUpdate(() => BackBlocking = false);
        }

        private void CreateRightCollider()
        {
            var rightCollider = new Collider
            {
                OffsetX = 1000,
                OffsetY = -5000,
                Width = 6000,
                Height = 10000
            };

            rightCollider.AddLeftCollisionHandler(StoreTheRightMovementCause);
            rightCollider.AddRightCollisionHandler(StoreTheRightMovementCause);
            rightCollider.AddTopCollisionHandler(StoreTheRightMovementCause);
            rightCollider.AddBotCollisionHandler(StoreTheRightMovementCause);

            AddCollider(rightCollider);

            AddUpdate(() =>
            {
                if (GameState.BossMode == false
                && MovingRightBy != null
                && MovingRightBy.HorizontalSpeed > 0)
                {
                    if (WorldHorizontalSpeed < MovingRightBy.HorizontalSpeed)
                        WorldHorizontalSpeed += VELOCITY;
                }
            });
            AddUpdate(() => MovingRightBy = null);

        }

        private void CreateLeftCollider()
        {
            var leftCollider = new Collider
            {
                OffsetX = -7000,
                OffsetY = -5000,
                Width = 6000,
                Height = 10000
            };

            leftCollider.AddLeftCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddRightCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddTopCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddBotCollisionHandler(StoreTheLeftMovementCause);

            AddCollider(leftCollider);

            AddUpdate(() =>
            {
                if (GameState.BossMode == false
                    && MovingLeftBy != null
                    && MovingLeftBy.HorizontalSpeed < 0
                )
                    if (WorldHorizontalSpeed > MovingLeftBy.HorizontalSpeed)
                        WorldHorizontalSpeed -= VELOCITY;

                if (BackBlocking)
                    WorldHorizontalSpeed = 0;
            });
            AddUpdate(() => MovingLeftBy = null);
        }


        private void StoreTheRightMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is Player && (c2.Parent as Player).MainCollider == c2)
                MovingRightBy = c2.Parent;
        }

        private void StoreTheLeftMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is Player && (c2.Parent as Player).MainCollider == c2)
            {
                MovingLeftBy = c2.Parent;
            }
            if (c2.Parent is BackBlocker)
            {
                BackBlocking = true;
            }
        }
    }
}
