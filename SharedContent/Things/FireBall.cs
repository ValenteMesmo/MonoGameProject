using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class LeaveasTrail : UpdateHandler
    {
        int timeToCreateTrail = 0;
        private readonly Thing Parent;
        private readonly Game1 Game1;
        private readonly int width;
        private readonly Func<int, int, int?, int?, bool, Animation> Animation;
        private readonly Func<Color> color;
        private readonly int height;
        private readonly int x;
        private readonly int y;
        private readonly bool flipped;

        public LeaveasTrail(
            Thing Parent
            , Game1 Game1
            , int width
            , int height
            , Func<Color> color
            , Func<int, int, int?, int?, bool, Animation> Animation
            , int x=0
            , int y=0
            , bool flipped = false
            )
        {
            this.Game1 = Game1;
            this.Parent = Parent;
            this.width = width;
            this.height = height;
            this.color = color;
            this.Animation = Animation;
            this.x = x;
            this.y = y;
            this.flipped = flipped;
        }

        public void Update()
        {
            timeToCreateTrail++;
            var xFactor = (Math.Abs(Parent.HorizontalSpeed) + Math.Abs(Parent.VerticalSpeed));
            if (timeToCreateTrail == 350 / xFactor)
            {
                timeToCreateTrail = 0;

                Game1.AddToWorld(new FireballTrail(x,y,width, height, color(), Animation, flipped)
                {
                    X = Parent.X,
                    Y = Parent.Y
                });
            }
        }
    }

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
                        
            AddUpdate(
                new LeaveasTrail(
                    this
                    , Game1
                    , MapModule.CELL_SIZE
                    , MapModule.CELL_SIZE
                    , ()=>ColorGetter()
                    , GeneratedContent.Create_knight_fireball_trail
                )
            );

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
            Game1.AddToWorld(new HitEffect() { X = X, Y = Y });
            base.OnDestroy();
        }
    }

    public class WavedFireBall : BaseFireBall
    {
        public const int SPEED = 100;
        public const int VELOCITY = 8;

        public WavedFireBall(Thing Owner, bool facingRight, Game1 Game1) : base(Owner, Game1)
        {
            Animation animation = FireBall.CreateFireBallAnimation(this);
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
            Animation animation = CreateFireBallAnimation(this);
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
            animationBorder.RenderingLayer = GlobalSettigns.FIREBALL_TRAIL_BORDER_Z;// GlobalSettigns.FIREBALL_BORDER_Z;
            animationBorder.ColorGetter = () => Color.Black;
            return animationBorder;
        }

        public static Animation CreateFireBallAnimation(BaseFireBall parent)
        {
            var animation = GeneratedContent.Create_knight_fireball(
                        0
                        , 0
                        , MapModule.CELL_SIZE
                        , MapModule.CELL_SIZE
                        );
            animation.RenderingLayer = GlobalSettigns.FIREBALL_Z;
            animation.ColorGetter = () => parent.ColorGetter();
            return animation;
        }

        private void DestroyAfterDuration()
        {
            duration--;
            if (duration <= 0)
                Destroy();
        }
    }

    public class SonicBoom : Thing
    {
        public Func<Color> ColorGetter = () => Color.White;
        public readonly AttackCollider collider;

        public SonicBoom(Thing Owner, int speedX, Game1 Game1)
        {
            var animation = GeneratedContent.Create_knight_SoniicBoom(
            speedX > 0 ? -800 : -400
            , 0
            , (int)(MapModule.CELL_SIZE * 3f)
            , (int)(MapModule.CELL_SIZE * 3f)
            , speedX > 0
            );
            animation.ColorGetter = GameState.GetColor;
            animation.LoopDisabled = true;
            animation.RenderingLayer = GlobalSettigns.FIREBALL_Z;
            AddAnimation(animation);

            AddUpdate(
                new LeaveasTrail(
                    this
                    , Game1
                    , (int)(MapModule.CELL_SIZE * 3f)
                    , (int)(MapModule.CELL_SIZE * 3f)
                    , GameState.GetColor
                    , GeneratedContent.Create_knight_SoniicBoom
                    , speedX > 0 ? -800 : -400
                    ,0
                    , speedX > 0
                )
            );

            collider = new AttackCollider { Width = 400, Height = 1500 };

            AddCollider(collider);

            HorizontalSpeed = speedX;
            VerticalSpeed = 0;
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

            AddAnimation(FireBall.CreateFireBallAnimation(this));
            AddAnimation(FireBall.CreateFireballBorderAnimation());

            HorizontalSpeed = 0;
            VerticalSpeed = 0;

            AddUpdate(new DestroyIfLeftBehind(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));

            collider.AddBotCollisionHandler(StopsWhenHitting.Bot<SomeKindOfGround>());
            collider.AddLeftCollisionHandler(StopsWhenHitting.Left<SomeKindOfGround>());
            collider.AddRightCollisionHandler(StopsWhenHitting.Right<SomeKindOfGround>());
            collider.AddTopCollisionHandler(StopsWhenHitting.Top<SomeKindOfGround>());

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
