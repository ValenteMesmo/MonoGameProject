using GameCore;
using System;

namespace MonoGameProject
{
    public abstract class BaseFireBall : Thing
    {
        private readonly Action<Thing> AddToWorld;

        public BaseFireBall(Action<Thing> AddToWorld)
        {
            this.AddToWorld = AddToWorld;
        }

        public override void OnDestroy()
        {
            AddToWorld(new HitEffect() { X = X, Y = Y });
            base.OnDestroy();
        }
    }

    public class WavedFireBall : BaseFireBall
    {
        public const int SPEED = 100;
        public const int VELOCITY = 10;

        public WavedFireBall(bool facingRight, Action<Thing> AddToWorld) : base(AddToWorld)
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

    public class FireBall : BaseFireBall
    {
        public const int SPEED = 150;

        public FireBall(int speedX, int speedY, Action<Thing> AddToWorld):base(AddToWorld)
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

    public class SeekerFireBall : BaseFireBall
    {
        public const int MAX_SPEED = 50;
        public int duration = 300;

        public SeekerFireBall(Boss boss, Action<Thing> AddToWorld):base(AddToWorld)
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

            HorizontalSpeed = 0;
            VerticalSpeed = 0;

            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            AddUpdate(() =>
            {
                if (duration <= 0)
                    Destroy();

                duration--;

                var velocity = 1;
                if (boss.player != null)
                {
                    if (boss.player.X > X)
                        HorizontalSpeed += velocity;
                    if (boss.player.X < X)
                        HorizontalSpeed -= velocity;

                    if (boss.player.Y > Y)
                        VerticalSpeed += velocity;
                    if (boss.player.Y < Y)
                        VerticalSpeed -= velocity;

                    if (HorizontalSpeed > MAX_SPEED)
                        HorizontalSpeed = MAX_SPEED;

                    if (HorizontalSpeed < -MAX_SPEED)
                        HorizontalSpeed = -MAX_SPEED;

                    if (VerticalSpeed > MAX_SPEED)
                        VerticalSpeed = MAX_SPEED;

                    if (VerticalSpeed < -MAX_SPEED)
                        VerticalSpeed = -MAX_SPEED;
                }
            });

            var collider = new Collider() { Width = width, Height = height };
            AddCollider(collider);
        }
    }
}
