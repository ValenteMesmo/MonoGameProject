﻿using System;
using GameCore;

namespace MonoGameProject
{
    public class WorldMover : Thing
    {
        public static int WorldHorizontalSpeed;
        private Thing MovingRightBy;
        private Thing MovingLeftBy;
        private bool BackBlocking;
        private bool ShouldDrawBorders = false;

        public WorldMover(Camera2d Camera)
        {
            X = (int)Camera.Pos.X;
            Y = (int)Camera.Pos.Y;

            AddUpdate(() =>
            {
                if (MovingRightBy == null && MovingLeftBy == null)
                    WorldHorizontalSpeed = 0;
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

            AddUpdate(() =>
            {
                if (MovingRightBy != null && MovingRightBy.HorizontalSpeed > 0)
                    WorldHorizontalSpeed = MovingRightBy.HorizontalSpeed;
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

            AddUpdate(() =>
            {
                if (
                MovingLeftBy != null
                && MovingLeftBy.HorizontalSpeed < 0
                )
                    WorldHorizontalSpeed = MovingLeftBy.HorizontalSpeed;
                if (BackBlocking)
                    WorldHorizontalSpeed = 0;

            });
            AddUpdate(() => MovingLeftBy = null);
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
