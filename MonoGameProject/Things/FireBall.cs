using GameCore;

namespace MonoGameProject
{
    public class WavedFireBall : Thing
    {
        public const int SPEED = 100;
        public const int VELOCITY = 10;

        public WavedFireBall(bool facingRight)
        {
            var width = 400;
            var height = 400;
            var animation = GeneratedContent.Create_knight_block(
            0
            , 0
            , MapModule.CELL_SIZE
            , MapModule.CELL_SIZE
            );
            animation.RenderingLayer = 0f;
            AddAnimation(animation);

            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            HorizontalSpeed = facingRight ? SPEED : -SPEED;
            VerticalSpeed = 0;
            //var hvelocity = -VELOCITY;
            var vvelocity = VELOCITY;

            AddUpdate(() =>
            {
                //if (HorizontalSpeed >= SPEED)
                //{
                //    hvelocity = -VELOCITY;
                //}
                //else if (HorizontalSpeed <= 0)
                //{
                //    hvelocity = VELOCITY;
                //}

                if (VerticalSpeed >= SPEED)
                {
                    vvelocity = -VELOCITY;
                }
                else if (VerticalSpeed <= -SPEED)
                {
                    vvelocity = VELOCITY;
                }

                //HorizontalSpeed += hvelocity;
                VerticalSpeed += vvelocity;
            });

            var collider = new Collider { Width = width, Height = height };
            AddCollider(collider);
        }
    }

    public class FireBall : Thing
    {
        public const int SPEED = 150;

        public FireBall(int speedX, int speedY)
        {
            var width = 400;
            var height = 400;
            var animation = GeneratedContent.Create_knight_block(
            0
            , 0
            , MapModule.CELL_SIZE
            , MapModule.CELL_SIZE
            );
            animation.RenderingLayer = 0.4f;
            AddAnimation(animation);

            HorizontalSpeed = speedX;
            VerticalSpeed = speedY;
            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            var collider = new Collider() { Width = width, Height = height };
            AddCollider(collider);
        }
    }


    public class SeekerFireBall : Thing
    {
        public const int SPEED = 20;
        public int duration = 500;

        public SeekerFireBall(Boss boss)
        {
            var width = 400;
            var height = 400;
            var animation = GeneratedContent.Create_knight_block(
            0
            , 0
            , MapModule.CELL_SIZE
            , MapModule.CELL_SIZE
            );
            animation.RenderingLayer = 0.4f;
            AddAnimation(animation);

            HorizontalSpeed = 0;
            VerticalSpeed = 0;

            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            AddUpdate(() =>
            {
                if (duration <= 0)
                    Destroy();

                duration--;

                if (boss.player != null)
                {
                    if (boss.player.X > X)
                        HorizontalSpeed = SPEED;
                    if (boss.player.X < X)
                        HorizontalSpeed = -SPEED;

                    if (boss.player.Y > Y)
                        VerticalSpeed = SPEED;
                    if (boss.player.Y < Y)
                        VerticalSpeed = -SPEED;
                }
            });

            var collider = new Collider() { Width = width, Height = height };
            AddCollider(collider);
        }
    }
}
