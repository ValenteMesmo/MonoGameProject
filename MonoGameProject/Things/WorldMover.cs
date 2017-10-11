using GameCore;
using System;

namespace MonoGameProject
{
    public class WorldMover : Thing
    {
        public readonly Camera2d Camera;
        public static int WorldHorizontalSpeed;
        public static int WorldVerticalSpeed;
        private Thing MovingRightBy;
        private Thing MovingLeftBy;
        private Thing MovingBotBy;
        private Thing MovingTopBy;
        private bool BackBlocking;
        private bool DownBlocking;
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
                GraduallyReduceHorizontalSpeed();
                GraduallyReduceVerticalSpeed();
                LockIfBossMode();
            });

            CreateLeftCollider();
            CreateRightCollider();
            CreateBotCollider();
            CreateTopCollider();

            AddUpdate(() => BackBlocking = false);
            AddUpdate(() => DownBlocking = false);
        }

        private void LockIfBossMode()
        {
            if (GameState.State.BossMode)
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
        }

        private void GraduallyReduceHorizontalSpeed()
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
        }

        private void GraduallyReduceVerticalSpeed()
        {
            if (MovingBotBy == null && MovingTopBy == null)
            {
                if (WorldVerticalSpeed > 0)
                {
                    WorldVerticalSpeed -= FRICTION;
                    if (WorldVerticalSpeed < 0)
                        WorldVerticalSpeed = 0;
                }
                else if (WorldVerticalSpeed < 0)
                {
                    WorldVerticalSpeed += FRICTION;
                    if (WorldVerticalSpeed > 0)
                        WorldVerticalSpeed = 0;
                }
            }
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
                if (GameState.State.BossMode == false
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
                OffsetX = -5000,
                OffsetY = -5000,
                Width = 4000,
                Height = 10000
            };

            leftCollider.AddLeftCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddRightCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddTopCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddBotCollisionHandler(StoreTheLeftMovementCause);

            AddCollider(leftCollider);

            AddUpdate(() =>
            {
                if (GameState.State.BossMode == false
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

        private void CreateBotCollider()
        {
            var BotCollider = new Collider
            {
                OffsetX = -6000,
                OffsetY = 2000,
                Width = 12000,
                Height = MapModule.CELL_SIZE * 2
            };

            BotCollider.AddLeftCollisionHandler(StoreTheBotMovementCause);
            BotCollider.AddRightCollisionHandler(StoreTheBotMovementCause);
            BotCollider.AddTopCollisionHandler(StoreTheBotMovementCause);
            BotCollider.AddBotCollisionHandler(StoreTheBotMovementCause);

            AddCollider(BotCollider);

            AddUpdate(() =>
            {
                if (
                MovingBotBy != null
                && MovingBotBy.VerticalSpeed > 0
                )
                    WorldVerticalSpeed = MovingBotBy.VerticalSpeed;

                if (DownBlocking)
                    WorldVerticalSpeed = 0;
            });
            AddUpdate(() => MovingBotBy = null);
        }

        private void CreateTopCollider()
        {
            var TopCollider = new Collider
            {
                OffsetX = -6000,
                OffsetY = -5000,
                Width = 12000,
                Height = 4000
            };

            TopCollider.AddLeftCollisionHandler(StoreTheTopMovementCause);
            TopCollider.AddRightCollisionHandler(StoreTheTopMovementCause);
            TopCollider.AddTopCollisionHandler(StoreTheTopMovementCause);
            TopCollider.AddBotCollisionHandler(StoreTheTopMovementCause);

            AddCollider(TopCollider);

            AddUpdate(() =>
            {
                if (
                MovingTopBy != null
                && MovingTopBy.VerticalSpeed < 0
                )
                    WorldVerticalSpeed = MovingTopBy.VerticalSpeed;

            });
            AddUpdate(() => MovingTopBy = null);
        }

        private void StoreTheTopMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is Player)
                MovingTopBy = c2.Parent;
        }

        private void StoreTheBotMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is Player)
                MovingBotBy = c2.Parent;
            if (c2.Parent is DownBlocker)
            {
                DownBlocking = true;
            }
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
