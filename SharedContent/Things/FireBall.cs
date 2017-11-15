using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public abstract class BaseFireBall : Thing
    {
        private readonly Game1 Game1;
        public readonly Collider collider;
        public Func<Color> ColorGetter = () => Color.White;
        public readonly Thing Owner;

        public BaseFireBall(Thing Owner, Game1 Game1)
        {
            this.Owner = Owner;
            this.Game1 = Game1;

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

            var timeToCreateTrail = 0;
            AddUpdate(() =>
            {
                timeToCreateTrail++;
                if (timeToCreateTrail == 2)
                {
                    timeToCreateTrail = 0;
                    NewMethod();
                }
            });

            var PlayerDamageHandler = new PlayerDamageHandler(
              Game1
              , _ => { }
              , _ => { }
            );
            PlayerDamageHandler.HEALTH = 3;
            collider.AddHandler(PlayerDamageHandler.CollisionHandler);
            AddUpdate(PlayerDamageHandler.Update);
        }

        //TODO: remove? ...
        public override void OnDestroy()
        {
            NewMethod();
            base.OnDestroy();
        }

        private void NewMethod()
        {
            Game1.AddToWorld(new FireballTrail(ColorGetter()) { X=X,Y=Y});
        }
    }

    public class WavedFireBall : BaseFireBall
    {
        public const int SPEED = 100;
        public const int VELOCITY = 8;

        public WavedFireBall(Thing Owner, bool facingRight, Game1 Game1) : base(Owner, Game1)
        {
            Animation animation = FireBall.CreateFireBallAnimation(Color.Pink);
            AddAnimation(animation);

            Animation animationBorder = FireBall.CreateFireballBorderAnimation();
            AddAnimation(animationBorder);


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
                
                VerticalSpeed += vvelocity;
            });
        }
    }

    public class FireBall : BaseFireBall
    {
        public const int SPEED = 150;

        public int duration = 200;

        public FireBall(Thing Owner, int speedX, int speedY, Game1 Game1) : base(Owner, Game1)
        {
            Animation animation = CreateFireBallAnimation(Color.Orange);
            AddAnimation(animation);

            Animation animationBorder = CreateFireballBorderAnimation();
            AddAnimation(animationBorder);

            var bonus = 0;
            if (Owner is Player)
            {
                bonus = 150;
            }
            collider.OffsetX = (MapModule.CELL_SIZE / 2) - 125 - (bonus / 2);
            collider.OffsetY = (MapModule.CELL_SIZE / 2) - 125 - (bonus / 2);
            collider.Width = 250 + bonus;
            collider.Height = 250 + bonus;

            collider.AddHandler((s, t) =>
            {
                if (t is GroundCollider)
                    Destroy();
            });

            HorizontalSpeed = speedX;
            VerticalSpeed = speedY;
            AddUpdate(new DestroyIfLeftBehind(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(DestroyAfterDuration);
        }

        public static Animation CreateFireballBorderAnimation()
        {
            var borderSize = 30;
            var animationBorder = GeneratedContent.Create_knight_fireball(
             -borderSize / 2
            , -borderSize / 2
            , MapModule.CELL_SIZE + borderSize
            , MapModule.CELL_SIZE + borderSize
            );
            animationBorder.RenderingLayer = GlobalSettigns.FIREBALL_BORDER_Z;
            animationBorder.ColorGetter = () => Color.Black;
            return animationBorder;
        }

        public static Animation CreateFireBallAnimation(Color color)
        {
            var animation = GeneratedContent.Create_knight_fireball(
                        0
                        , 0
                        , MapModule.CELL_SIZE
                        , MapModule.CELL_SIZE
                        );
            animation.RenderingLayer = GlobalSettigns.FIREBALL_Z;
            animation.ColorGetter = () => color;
            return animation;
        }

        private void DestroyAfterDuration()
        {
            duration--;
            if (duration <= 0)
                Destroy();
        }
    }

    public class SonicBoom : BaseFireBall
    {
        public SonicBoom(Thing Owner, int speedX, int speedY, Game1 Game1) : base(Owner, Game1)
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
            animation.RenderingLayer = GlobalSettigns.FIREBALL_Z;
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

        public SeekerFireBall(Boss boss, Game1 Game1) : base(boss, Game1)
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

            collider.AddBotCollisionHandler(StopsWhenHitting.Bot<BlockVerticalMovement>());
            collider.AddLeftCollisionHandler(StopsWhenHitting.Left<BlockHorizontalMovement>());
            collider.AddRightCollisionHandler(StopsWhenHitting.Right<BlockHorizontalMovement>());
            collider.AddTopCollisionHandler(StopsWhenHitting.Top<BlockVerticalMovement>());

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
