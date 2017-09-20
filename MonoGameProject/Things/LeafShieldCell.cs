﻿using GameCore;

namespace MonoGameProject
{
    class LeafShieldCell : Thing
    {
        public LeafShieldCell(Boss boss)
        {
            var ballAnimation = GeneratedContent.Create_knight_leaf_shield(0, 0, 1500, 1500);
            ballAnimation.ColorGetter = () => boss.BodyColor;
            ballAnimation.RenderingLayer = 0;
            AddAnimation(ballAnimation);

            X = boss.X;
            Y = boss.Y;

            var max = 1000;
            var speed = 50;

            var horizontalSpeed = max;
            var verticalSpeed = 0;
            var velocityVertical = speed;
            var velocityHorizontal = -speed;

            var duration = 500;
            //rotatingBall.AddUpdate(new MoveHorizontallyWithTheWorld(rotatingBall));
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

                X = horizontalSpeed + boss.X;
                Y = verticalSpeed + boss.Y;
                //+ (player.groundChecker.Colliding<SomeKindOfGround>() ? 0 : player.VerticalSpeed);
            });

        }
    }
}