﻿using GameCore;

namespace MonoGameProject
{
    class LeafShieldCell : Thing
    {
        public LeafShieldCell(Boss boss)
        {
            var size = 1500;
            var bonus = 300;
            var collider = new AttackCollider()
            {
                OffsetX = (size / 3) + bonus/2,
                OffsetY = (size / 3) + bonus/2,
                Width =  (size/3) - bonus,
                Height = (size/3) - bonus
            };
            AddCollider(collider);

            var ballAnimation = GeneratedContent.Create_knight_leaf_shield(
                0, 0, size, size);
            ballAnimation.ColorGetter = GameState.GetColor;
            ballAnimation.RenderingLayer = 0;
            AddAnimation(ballAnimation);

            X = boss.X;
            Y = boss.Y;

            var max = 600;
            var speed = 30;

            var horizontalSpeed = max;
            var verticalSpeed = 0;
            var velocityVertical = speed;
            var velocityHorizontal = -speed;

            var duration = 500;
            //rotatingBall.AddUpdate(new MoveHorizontallyWithTheWorld(rotatingBall));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(() =>
            {
                duration--;
                if (duration <= 0)
                    Destroy();

                if (horizontalSpeed < -max)
                    velocityHorizontal = speed;
                if (horizontalSpeed > max)
                    velocityHorizontal = -speed;

                if (verticalSpeed < -max)
                    velocityVertical = speed;
                if (verticalSpeed > max)
                    velocityVertical = -speed;

                horizontalSpeed += velocityHorizontal;
                verticalSpeed += velocityVertical;

                if (boss.Dead() == false)
                {
                    X = horizontalSpeed + boss.X;
                    Y = verticalSpeed + boss.Y-250;
                }
            });

        }
    }
}