using GameCore;

namespace MonoGameProject
{
    class LeafShieldCell : Thing
    {
        public LeafShieldCell(Boss boss)
        {
            var size = 1500;
            var collider = new AttackCollider()
            {
                OffsetX = size / 3,
                OffsetY = size / 3,
                Width = size/3,
                Height = size/3
            };
            AddCollider(collider);

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
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
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
                    Y = verticalSpeed + boss.Y;
                }
            });

        }
    }
}