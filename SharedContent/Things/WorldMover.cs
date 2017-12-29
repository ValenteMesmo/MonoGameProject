using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private bool UpBlocking;
        private Collider leftCollider;
        private Collider rightCollider;
        private Collider BotCollider;
        private Collider TopCollider;
        private int playersOnTheRight;
        private int playersOnTheLeft;
        private int playersOnTheTop;
        private int playersOnTheBot;
        private int rightSpeed;
        private int leftSpeed;
        private int topSpeed;
        private int botSpeed;

        public WorldMover(Game1 Game1)
        {
            this.Game1 = Game1;
            this.Camera = Game1.Camera;

            X = (int)Camera.Pos.X;
            Y = (int)Camera.Pos.Y;

            AddUpdate(() =>
            {
                playersOnTheRight = 0;
                playersOnTheLeft = 0;
                rightSpeed = 0;
                leftSpeed = 0;
                playersOnTheBot = 0;
                playersOnTheTop = 0;
                var previousBotSpeed = botSpeed / 3;
                botSpeed = 0;
                topSpeed = 0;
                {
                    foreach (var player in Game1.Players)
                    {
                        if (rightCollider.CollidingWith.Contains(player.MainCollider))
                        {
                            if (player.HorizontalSpeed > rightSpeed)
                                rightSpeed = player.HorizontalSpeed;
                            playersOnTheRight++;
                        }
                        else if (leftCollider.CollidingWith.Contains(player.MainCollider))
                        {
                            if (player.HorizontalSpeed < leftSpeed)
                                leftSpeed = player.HorizontalSpeed;
                            playersOnTheLeft++;
                        }

                        if (BotCollider.CollidingWith.Contains(player.MainCollider))
                        {
                            if (player.VerticalSpeed > 0
                                && player.VerticalSpeed < 20
                                && previousBotSpeed > player.VerticalSpeed)
                            {
                                botSpeed = previousBotSpeed;
                            }

                            if (player.VerticalSpeed > botSpeed)
                            {
                                botSpeed = player.VerticalSpeed;
                            }

                            if (player.groundChecker.CollidingWith.Any(f =>
                                        f.Parent is ElevatorPlatform
                                        && f.Parent.VerticalSpeed > 0
                                    )
                                )
                            {
                                botSpeed = ElevatorPlatform.speed;
                            }

                            playersOnTheBot++;
                        }
                        else if (TopCollider.CollidingWith.Contains(player.MainCollider))
                        {
                            if (player.VerticalSpeed < topSpeed)
                                topSpeed = player.VerticalSpeed;

                            if (
                                botSpeed > -ElevatorPlatform.speed
                                && player.groundChecker.CollidingWith.Any(f =>
                                        f.Parent is ElevatorPlatform
                                        && f.Parent.VerticalSpeed < 0
                                    )
                                )
                            {
                                topSpeed = -ElevatorPlatform.speed;
                            }

                            playersOnTheTop++;
                        }
                    }
                }

                if (GameState.State.BossMode)
                    LockIfBossMode();
                else
                {
                    {
                        if (playersOnTheLeft == 0 && playersOnTheRight > 0)
                        {
                            if (rightSpeed > 0)
                                WorldHorizontalSpeed = rightSpeed;
                            else
                                WorldHorizontalSpeed = EasyTo(WorldHorizontalSpeed, 1, 50);
                        }
                        else if (playersOnTheLeft > 0 && playersOnTheRight == 0)
                        {
                            if (leftSpeed < 0)
                                WorldHorizontalSpeed = leftSpeed;
                            else
                                WorldHorizontalSpeed = EasyTo(WorldHorizontalSpeed, 1, -50);
                        }
                        else
                            WorldHorizontalSpeed = EasyTo(WorldHorizontalSpeed, 10, 0);

                        if (WorldHorizontalSpeed < 0 && BackBlocking)
                            WorldHorizontalSpeed = 0;
                    }

                    {
                        if (playersOnTheBot > 0 && playersOnTheTop == 0)
                        {
                            if (botSpeed > 0)
                                WorldVerticalSpeed = botSpeed;
                            else
                                WorldVerticalSpeed = 0;// EasyTo(WorldVerticalSpeed, 1, 0);
                        }
                        else if (playersOnTheTop > 0 && playersOnTheBot == 0)
                        {
                            if (topSpeed < 0)
                                WorldVerticalSpeed = topSpeed;
                            else
                                WorldVerticalSpeed = 0;//EasyTo(WorldVerticalSpeed, 1, 0);
                        }
                        else if (WorldVerticalSpeed > 0)
                            WorldVerticalSpeed = EasyTo(WorldVerticalSpeed, 1, 25);
                        else if (WorldVerticalSpeed < 0)
                            WorldVerticalSpeed = EasyTo(WorldVerticalSpeed, 1, -25);
                        else
                            WorldVerticalSpeed = EasyTo(WorldVerticalSpeed, 1, 0);

                        if (WorldVerticalSpeed < 0 && UpBlocking)
                            WorldVerticalSpeed = 0;
                        if (WorldVerticalSpeed > 0 && DownBlocking)
                            WorldVerticalSpeed = 0;
                    }
                }
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

        private void CreateRightCollider()
        {
            rightCollider = new Collider
            {
                OffsetX = 1000,
                OffsetY = -5000,
                Width = 6000,
                Height = 10000
            };

            AddCollider(rightCollider);
        }

        public int EasyTo(int value, int speed, int limit)
        {
            if (value > limit)
            {
                value -= speed;
                if (value < limit)
                    value = limit;
            }
            else if (value < limit)
            {
                value += speed;
                if (value > limit)
                    value = limit;
            }

            return value;
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
        }

        private void CreateBotCollider()
        {
            BotCollider = new Collider
            {
                OffsetX = -6000,
                OffsetY = 1600,
                Width = 12000,
                Height = (MapModule.CELL_SIZE * 4) + 500
            };

            BotCollider.AddHandler(StoreTheBotMovementCause);

            AddCollider(BotCollider);
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

        private void StoreTheLeftMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is BackBlocker)
            {
                BackBlocking = true;
            }
        }
    }
}
