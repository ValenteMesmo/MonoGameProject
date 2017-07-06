using System;
using GameCore;

namespace MonoGameProject
{
    public class WorldMover : Thing
    {
        public static int WorldHorizontalSpeed;
        public static int WorldVerticalSpeed;
        private Thing MovingRightBy;
        private Thing MovingBotBy;
        private Thing MovingTopBy;
        private Thing MovingLeftBy;
        private bool BackBlocking;
        private bool ShouldDrawBorders = false;

        public WorldMover(Camera2d Camera)
        {
            X = (int)Camera.Pos.X;
            Y = (int)Camera.Pos.Y;

            AddUpdate(_ =>
            {
                if (MovingRightBy == null && MovingLeftBy == null)
                    WorldHorizontalSpeed = 0;
                if (MovingBotBy == null)
                    WorldVerticalSpeed = 0;
            });

            CreateLeftCollider();
            CreateRightCollider();
            CreateBotCollider();
            CreateTopCollider();

            AddUpdate(t => BackBlocking = false);
        }

        private void CreateRightCollider()
        {
            var rightCollider = new Collider
            {
                OffsetX = 1000,
                OffsetY = -2000,
                Width = 6000,
                Height = 10000
            };

            if (ShouldDrawBorders)
                AddAnimation(new Animation(new AnimationFrame(
                  "block",
                  rightCollider.OffsetX,
                  rightCollider.OffsetY,
                  rightCollider.Width,
                  rightCollider.Height)));

            rightCollider.AddLeftCollisionHandler(StoreTheRightMovementCause);
            rightCollider.AddRightCollisionHandler(StoreTheRightMovementCause);
            rightCollider.AddTopCollisionHandler(StoreTheRightMovementCause);
            rightCollider.AddBotCollisionHandler(StoreTheRightMovementCause);

            AddCollider(rightCollider);

            AddUpdate(t =>
            {
                if (MovingRightBy != null && MovingRightBy.HorizontalSpeed > 0)
                    WorldHorizontalSpeed = MovingRightBy.HorizontalSpeed;
            });
            AddUpdate(t => MovingRightBy = null);

        }

        private void CreateLeftCollider()
        {
            var leftCollider = new Collider
            {
                OffsetX = -7000,
                OffsetY = -2000,
                Width = 6000,
                Height = 10000
            };

            if (ShouldDrawBorders)
                AddAnimation(new Animation(new AnimationFrame(
              "block",
              leftCollider.OffsetX,
              leftCollider.OffsetY,
              leftCollider.Width,
              leftCollider.Height)));

            leftCollider.AddLeftCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddRightCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddTopCollisionHandler(StoreTheLeftMovementCause);
            leftCollider.AddBotCollisionHandler(StoreTheLeftMovementCause);

            AddCollider(leftCollider);

            AddUpdate(t =>
            {
                if (
                MovingLeftBy != null
                && MovingLeftBy.HorizontalSpeed < 0
                )
                    WorldHorizontalSpeed = MovingLeftBy.HorizontalSpeed;
                if (BackBlocking)
                    WorldHorizontalSpeed = 0;

            });
            AddUpdate(t => MovingLeftBy = null);
        }

        private void CreateBotCollider()
        {
            var BotCollider = new Collider
            {
                OffsetX = -6000,
                OffsetY = 3000,
                Width = 12000,
                Height = 4000
            };

            if (ShouldDrawBorders)
                AddAnimation(new Animation(new AnimationFrame(
                "block",
                BotCollider.OffsetX,
                BotCollider.OffsetY,
                BotCollider.Width,
                BotCollider.Height)));

            BotCollider.AddLeftCollisionHandler(StoreTheBotMovementCause);
            BotCollider.AddRightCollisionHandler(StoreTheBotMovementCause);
            BotCollider.AddTopCollisionHandler(StoreTheBotMovementCause);
            BotCollider.AddBotCollisionHandler(StoreTheBotMovementCause);

            AddCollider(BotCollider);

            AddUpdate(t =>
            {
                if (
                MovingBotBy != null
                && MovingBotBy.VerticalSpeed > 0
                )
                    WorldVerticalSpeed = MovingBotBy.VerticalSpeed;

            });
            AddUpdate(t => MovingBotBy = null);
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

            if (ShouldDrawBorders)
                AddAnimation(new Animation(new AnimationFrame(
                "block",
                TopCollider.OffsetX,
                TopCollider.OffsetY,
                TopCollider.Width,
                TopCollider.Height)));

            TopCollider.AddLeftCollisionHandler(StoreTheTopMovementCause);
            TopCollider.AddRightCollisionHandler(StoreTheTopMovementCause);
            TopCollider.AddTopCollisionHandler(StoreTheTopMovementCause);
            TopCollider.AddBotCollisionHandler(StoreTheTopMovementCause);

            AddCollider(TopCollider);

            AddUpdate(t =>
            {
                if (
                MovingTopBy != null
                && MovingTopBy.VerticalSpeed < 0
                )
                    WorldVerticalSpeed = MovingTopBy.VerticalSpeed;

            });
            AddUpdate(t => MovingTopBy = null);
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
        }

        private void StoreTheRightMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is Player)
                MovingRightBy = c2.Parent;
        }

        private void StoreTheLeftMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is Player)
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
