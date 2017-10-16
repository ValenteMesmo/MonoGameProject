using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public abstract class BaseFireBall : Thing
    {
        private readonly Action<Thing> AddToWorld;
        public readonly Collider collider;
        public Func<Color> ColorGetter = () => Color.White;

        public BaseFireBall(Action<Thing> AddToWorld)
        {
            this.AddToWorld = AddToWorld;

            var size = 400;
            var bonus = size / 3;

            collider = new Collider
            {
                OffsetX = bonus,
                OffsetY = bonus,
                Width = size - bonus,
                Height = size - bonus
            };
            AddCollider(collider);
        }

        //TODO: remove? ...
        public override void OnDestroy()
        {
            AddToWorld(new HitEffect(0.4f, 0, -collider.Height / 2, collider.Width * 3, collider.Height * 3)
            {
                X = X,
                Y = Y,
                Color = ColorGetter()
            });
            base.OnDestroy();
        }
    }

    public class WavedFireBall : BaseFireBall
    {
        public const int SPEED = 100;
        public const int VELOCITY = 8;

        public WavedFireBall(bool facingRight, Action<Thing> AddToWorld) : base(AddToWorld)
        {
            var animation = GeneratedContent.Create_knight_block(
            0
            , 0
            , MapModule.CELL_SIZE
            , MapModule.CELL_SIZE
            );
            animation.RenderingLayer = 0f;
            AddAnimation(animation);

            AddUpdate(new DestroyIfLeftBehind(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));

            HorizontalSpeed = facingRight ? 50 : -50;
            VerticalSpeed = -SPEED;
            var vvelocity = VELOCITY;

            AddUpdate(() =>
            {
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

        }
    }

    public class FireBall : BaseFireBall
    {
        public const int SPEED = 150;

        public FireBall(int speedX, int speedY, Action<Thing> AddToWorld) : base(AddToWorld)
        {
            var animation = GeneratedContent.Create_knight_block(
            0
            , 0
            , MapModule.CELL_SIZE
            , MapModule.CELL_SIZE
            );
            animation.RenderingLayer = Boss.RIGHT_ARM_Z - 0.001f;
            animation.ColorGetter = () => ColorGetter();
            AddAnimation(animation);

            collider.OffsetX = (MapModule.CELL_SIZE/2) -50;
            collider.OffsetY = (MapModule.CELL_SIZE/2) -50;
            collider.Width = 50;
            collider.Height= 50;


            HorizontalSpeed = speedX;
            VerticalSpeed = speedY;
            AddUpdate(new DestroyIfLeftBehind(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }

    public class SonicBoom : BaseFireBall
    {
        public SonicBoom(int speedX, int speedY, Action<Thing> AddToWorld) : base(AddToWorld)
        {
            var animation = GeneratedContent.Create_knight_SoniicBoom(
            0
            , 0
            , (int)(MapModule.CELL_SIZE * 4f)
            , (int)(MapModule.CELL_SIZE * 4f)
            , speedX > 0
            );
            animation.ColorGetter = () => ColorGetter();
            animation.LoopDisabled = true;
            animation.RenderingLayer = Boss.EYE_Z;
            AddAnimation(animation);

            collider.OffsetX *= 5;
            collider.OffsetY *= 5;
            collider.Width *= 2;
            collider.Height *= 5;

            HorizontalSpeed = speedX;
            VerticalSpeed = speedY;
            AddUpdate(new DestroyIfLeftBehind(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }

    public class SeekerFireBall : BaseFireBall
    {
        public const int MAX_SPEED = 50;
        public int duration = 300;

        public SeekerFireBall(Boss boss, Action<Thing> AddToWorld) : base(AddToWorld)
        {
            var target = boss.player;

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
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));

            AddUpdate(() =>
            {
                if (duration <= 0)
                    Destroy();

                duration--;

                var velocity = 1;
                if (target != null)
                {
                    if (target.X > X)
                        HorizontalSpeed += velocity;
                    if (target.X < X)
                        HorizontalSpeed -= velocity;

                    if (target.Y > Y)
                        VerticalSpeed += velocity;
                    if (target.Y < Y)
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
        }
    }
}
