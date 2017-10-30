using GameCore;
using System;
using System.Collections.Generic;

namespace MonoGameProject
{
    public class WorldMover : Thing
    {
        private readonly Game1 Game1;
        public readonly Camera2d Camera;
        public static int WorldHorizontalSpeed;
        public static int WorldVerticalSpeed;
        private bool BackBlocking;
        private bool DownBlocking;
        private const int VELOCITY = 6;
        private const int FRICTION = 8;
        internal Thing camlocker;
        private bool AllGoingBot;
        private bool AllGoingTop;
        private bool AllGoingLeft;
        private bool AllGoingRight;
        private bool UpBlocking;
        private Collider leftCollider;
        private Collider rightCollider;
        private Collider BotCollider;
        private Collider TopCollider;

        public WorldMover(Game1 Game1)
        {
            this.Game1 = Game1;
            this.Camera = Game1.Camera;

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
            AddUpdate(() => UpBlocking = false);
        }

        private void LockIfBossMode()
        {
            if (GameState.State.BossMode)
            {
                {
                    var expected = 5000;

                    if (camlocker.X > expected)
                    {
                        if (camlocker.X - 100 < expected)
                            WorldHorizontalSpeed = camlocker.X - expected;
                        else
                            WorldHorizontalSpeed = 100;
                    }
                    else if (camlocker.X < expected)
                    {
                        WorldHorizontalSpeed = -100;
                    }
                    else
                        WorldHorizontalSpeed = 0;
                }

                {
                    var expected = 5500;

                    if (camlocker.Y > expected)
                    {
                        if (camlocker.Y - 100 < expected)
                            WorldVerticalSpeed = camlocker.Y - expected;
                        else
                            WorldVerticalSpeed = 100;
                    }
                    else if (camlocker.Y < expected)
                    {
                        WorldVerticalSpeed = -100;
                    }
                    else
                        WorldVerticalSpeed = 0;
                }
            }
        }

        private void GraduallyReduceHorizontalSpeed()
        {
            if (!AllGoingRight && !AllGoingLeft)
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
            if (!AllGoingTop && !AllGoingBot)
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
            rightCollider = new Collider
            {
                OffsetX = 1000,
                OffsetY = -5000,
                Width = 6000,
                Height = 10000
            };

            //rightCollider.AddHandler(StoreTheRightMovementCause);
            AddCollider(rightCollider);

            AddUpdate(() =>
            {
                if (GameState.State.BossMode)
                    return;

                AllGoingRight = false;
                var horizontalSpeed = 0;
                foreach (var player in Game1.Players)
                {
                    if (rightCollider.CollidingWith.Contains(player.MainCollider))
                    {
                        if (player.HorizontalSpeed > horizontalSpeed)
                        {
                            horizontalSpeed = player.HorizontalSpeed;
                            AllGoingRight = true;
                        }
                    }
                    else if (leftCollider.CollidingWith.Contains(player.MainCollider))
                    {
                        AllGoingRight = false;
                        break;
                    }
                }

                if (AllGoingRight && horizontalSpeed > 0)
                    WorldHorizontalSpeed = horizontalSpeed;

                //if (BackBlocking)
                //    WorldHorizontalSpeed = 0;
            });
        }

        private void CreateLeftCollider()
        {
            leftCollider = new Collider
            {
                OffsetX = -5000,
                OffsetY = -5000,
                Width = 4000,
                Height = 10000
            };

            leftCollider.AddHandler(StoreTheLeftMovementCause);

            AddCollider(leftCollider);

            AddUpdate(() =>
            {
                if (GameState.State.BossMode)
                    return;

                AllGoingLeft = false;
                var horizontalSpeed = 0;
                foreach (var player in Game1.Players)
                {
                    if (leftCollider.CollidingWith.Contains(player.MainCollider))
                    {
                        if (player.HorizontalSpeed < horizontalSpeed)
                        {
                            horizontalSpeed = player.HorizontalSpeed;
                            AllGoingLeft = true;
                        }
                    }
                    else if (rightCollider.CollidingWith.Contains(player.MainCollider))
                    {
                        AllGoingLeft = false;
                        break;
                    }
                }

                if (AllGoingLeft && horizontalSpeed < 0)
                    WorldHorizontalSpeed = horizontalSpeed;

                if (BackBlocking)
                    WorldHorizontalSpeed = 0;
            });
        }

        private void CreateBotCollider()
        {
            BotCollider = new Collider
            {
                OffsetX = -6000,
                OffsetY = 2000,
                Width = 12000,
                Height = MapModule.CELL_SIZE * 2
            };

            BotCollider.AddHandler(StoreTheBotMovementCause);

            AddCollider(BotCollider);

            AddUpdate(() =>
            {
                if (GameState.State.BossMode)
                    return;

                AllGoingBot = false;
                var verticalSpeed = 0;
                foreach (var player in Game1.Players)
                {
                    if (BotCollider.CollidingWith.Contains(player.MainCollider))
                    {
                        if (player.VerticalSpeed > verticalSpeed)
                        {
                            verticalSpeed = player.VerticalSpeed;
                            AllGoingBot = true;
                        }
                    }
                    else if (TopCollider.CollidingWith.Contains(player.MainCollider))
                    {
                        AllGoingBot = false;
                        break;
                    }
                }

                if (AllGoingBot && verticalSpeed > 0)
                    WorldVerticalSpeed = verticalSpeed;

                if (DownBlocking && WorldVerticalSpeed > 0)
                    WorldVerticalSpeed = 0;
            });
        }

        private void CreateTopCollider()
        {
            TopCollider = new Collider
            {
                OffsetX = -6000,
                OffsetY = -5000,
                Width = 12000,
                Height = 5000
            };

            TopCollider.AddHandler(StoreTheTopMovementCause);

            AddCollider(TopCollider);

            AddUpdate(() =>
            {
                if (GameState.State.BossMode)
                    return;

                AllGoingTop = false;
                var verticalSpeed = 0;
                foreach (var player in Game1.Players)
                {
                    if (TopCollider.CollidingWith.Contains(player.MainCollider))
                    {
                        if (player.VerticalSpeed < verticalSpeed)
                        {
                            verticalSpeed = player.VerticalSpeed;
                            AllGoingTop = true;
                        }
                    }
                    else if (BotCollider.CollidingWith.Contains(player.MainCollider))
                    {
                        AllGoingTop = false;
                        break;
                    }
                }

                if (AllGoingTop && verticalSpeed < 0)
                    WorldVerticalSpeed = verticalSpeed;

                if (UpBlocking && WorldVerticalSpeed < 0)
                    WorldVerticalSpeed = 0;
            });
        }

        private void StoreTheTopMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is UpBlocker)
                UpBlocking = true;
        }

        private void StoreTheBotMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is DownBlocker)
                DownBlocking = true;
        }

        //private void StoreTheRightMovementCause(Collider c1, Collider c2)
        //{
        //    if (c2.Parent is Player && (c2.Parent as Player).MainCollider == c2)
        //        MovingRightBy = c2.Parent;
        //}

        private void StoreTheLeftMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is BackBlocker)
            {
                BackBlocking = true;
            }
        }
    }
}
