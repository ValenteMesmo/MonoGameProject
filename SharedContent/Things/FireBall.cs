﻿using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class SmokeTrail : Thing
    {
        public SmokeTrail(Thing Parent, MyRandom random, Color Color)
        {
            var xValue = Math.Abs(Parent.VerticalSpeed);
            var yValue = Math.Abs(Parent.HorizontalSpeed);

            var speedSum = xValue + yValue;
            var xFactor = 62f / speedSum;

            xValue = (int)(xValue * xFactor);
            yValue = (int)(yValue * xFactor);

            var x = random.Next(-xValue, xValue);
            var y = random.Next(-yValue, yValue);

            var sizeBonus = -100;
            var offSetBonus = -sizeBonus / 2;

            var animationFrameDuration =
                3//150 / speedSum
                ;

            var smokeAnimation = GeneratedContent.Create_knight_fireball_trail(
                x + FireBall.FIREBALL_OFFSET + offSetBonus
                , y + FireBall.FIREBALL_OFFSET + offSetBonus
                , FireBall.FIREBALL_SIZE + sizeBonus
                , FireBall.FIREBALL_SIZE + sizeBonus);
            smokeAnimation.LoopDisabled = true;
            smokeAnimation.FrameDuration = animationFrameDuration;
            smokeAnimation.RenderingLayer = GlobalSettigns.FIREBALL_TRAIL_Z;
            smokeAnimation.ColorGetter = () => Color;

            var smokeAnimationBorder = GeneratedContent.Create_knight_fireball_trail(
                x + FireBall.FIREBALL_BORDER_OFFSET + offSetBonus
                , y + FireBall.FIREBALL_BORDER_OFFSET + offSetBonus
                , FireBall.FIREBALL_BORDER_SIZE + sizeBonus
                , FireBall.FIREBALL_BORDER_SIZE + sizeBonus);
            smokeAnimationBorder.LoopDisabled = true;
            smokeAnimationBorder.FrameDuration = animationFrameDuration;
            smokeAnimationBorder.ColorGetter = () => Color.Black;
            smokeAnimationBorder.RenderingLayer = GlobalSettigns.FIREBALL_TRAIL_BORDER_Z;

            AddAnimation(smokeAnimation);
            AddAnimation(smokeAnimationBorder);
            X = Parent.X;
            Y = Parent.Y;

            var duration = 100;
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));

            var colorSpeed = (5 * speedSum) / 50;

            AddUpdate(() =>
            {
                Color = new Color(Color.R + colorSpeed, Color.G + colorSpeed, Color.B + colorSpeed);
                duration--;
                if (duration == 0)
                    Destroy();
            });
        }
    }

    public class CreatesSmokeTrail : UpdateHandler
    {
        private readonly Thing Parent;
        private readonly Game1 Game1;
        private readonly MyRandom random;
        private readonly Color Color;

        public CreatesSmokeTrail(Thing Parent, Game1 Game1, Color Color)
        {
            this.Parent = Parent;
            this.Game1 = Game1;
            random = new MyRandom(999);
            this.Color = Color;

            //var speed = Math.Abs(Parent.HorizontalSpeed) + Math.Abs(Parent.VerticalSpeed);
            Duration = 2;//(50 * speed) / 5;

        }

        int cooldown = 0;
        private readonly int Duration;

        public void Update()
        {
            if (cooldown > 0)
            {
                cooldown--;
                return;
            }
            cooldown = Duration;

            Game1.AddToWorld(new SmokeTrail(Parent, random, Color));
        }
    }

    public abstract class BaseFireBall : Thing, MagicProjectile
    {
        private readonly Game1 Game1;
        public readonly Color Color;
        public readonly AttackCollider collider;
        public readonly Thing Owner;
        public readonly PlayerDamageHandler DamageHandler;

        public BaseFireBall(Thing Owner, Game1 Game1, Color Color)
        {
            this.Owner = Owner;
            this.Game1 = Game1;
            this.Color = Color;

            var size = 400;
            var bonus = size / 3;

            collider = new AttackCollider
            {
                OffsetX = bonus,
                OffsetY = bonus,
                Width = size - bonus,
                Height = size - bonus
            };
            AddCollider(collider);

            DamageHandler = new PlayerDamageHandler(
                Game1
                , Color
                , (p, s, t) => { }
                , (p, s, t) => { }
            );
            DamageHandler.HEALTH = GlobalSettigns.FIREBALL_HEALTH;
            DamageHandler.CausesSleep = false;
            collider.AddHandler(DamageHandler.CollisionHandler);
            AddUpdate(DamageHandler.Update);
            OnDestroy += () =>
            {
                Game1.AddToWorld(new SmokeHitEffect(GlobalSettigns.FIREBALL_Z) { X = X, Y = Y, Color = Color });
            };
        }
    }

    public class WavedFireBall : BaseFireBall
    {
        public const int SPEED = 100;
        public const int VELOCITY = 3;

        public WavedFireBall(Thing Owner, bool facingRight, Game1 Game1, Color Color, bool up = false) : base(Owner, Game1, Color)
        {
            Animation animation = FireBall.CreateFireBallAnimation(this);
            AddAnimation(animation);

            Animation animationBorder = FireBall.CreateFireballBorderAnimation();
            AddAnimation(animationBorder);

            AddUpdate(new DestroyIfLeftBehind(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new CreatesSmokeTrail(this, Game1, Color));

            HorizontalSpeed = facingRight ? 50 : -50;
            VerticalSpeed = -SPEED;
            if (up)
                VerticalSpeed *= -1;

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

    public class FireballDefault : FireBall
    {
        public FireballDefault(Thing Owner, int speedX, int speedY, Game1 Game1, Color Color) : base(Owner, speedX, speedY, Game1, Color)
        {
            int offset = 0;
            if (speedX > 0)
                offset = -FIREBALL_SIZE;

            var animation = GeneratedContent.Create_knight_fireball3(offset, 0, FIREBALL_SIZE * 2, FIREBALL_SIZE, speedX < 0);
            animation.ColorGetter = () => Color;
            AddAnimation(animation);
        }
    }

    public class BoneFireball : FireBall
    {
        public BoneFireball(Thing Owner, bool facingRight, Color Color) : base(Owner, 0, 0, Game1.Instance, Color)
        {
            //int offset = 0;
            //if (speedX > 0)
            //    offset = -FIREBALL_SIZE;
            if (facingRight)
                HorizontalSpeed = SPEED / 2;
            else
                HorizontalSpeed = -SPEED / 2;

            var animation = GeneratedContent.Create_knight_Bone(0, 0, FIREBALL_SIZE, FIREBALL_SIZE, facingRight);
            animation.ColorGetter = () => Color;
            AddAnimation(animation);
        }
    }

    public interface MagicProjectile
    {
    }

    public class SlimeRainDrop : Thing, MagicProjectile
    {
        public SlimeRainDrop(BaseEnemy Owner, int xSpeed)
        {
            X = (int)Owner.mainCollider.CenterX() - 300;
            Y = Owner.mainCollider.Top();

            var animationSize = FireBall.FIREBALL_SIZE;
            var animation = GeneratedContent.Create_knight_Bone(0, 0, animationSize, animationSize);
            animation.ColorGetter = () => Color.White;
            animation.RenderingLayer = 0f;
            AddAnimation(animation);
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));

            VerticalSpeed = -100;
            HorizontalSpeed = xSpeed;
            var duration = 200;

            var collider = new AttackCollider();
            collider.Width = collider.Height = 100;
            collider.OffsetX = 200;
            collider.OffsetY = 200;
            AddCollider(collider);

            var DamageHandler = new PlayerDamageHandler(Game1.Instance, Color.White, (a, b, c) => { }, (a, b, c) => { });
            DamageHandler.HEALTH = 2 + (1 * Game1.Instance.GetNumberOfActivePlayers());
            collider.AddHandler(DamageHandler.CollisionHandler);
            AddUpdate(DamageHandler.Update);
            AddUpdate(() =>
            {
                VerticalSpeed += 2;
                if (xSpeed > 0)
                    xSpeed--;
                if (xSpeed < 0)
                    xSpeed++;

                duration--;
                if (duration == 0)
                    Destroy();
            });
        }
    }

    public class FireballCloud : FireBall
    {
        public FireballCloud(Thing Owner, int speedX, int speedY, Game1 Game1, Color Color) : base(Owner, speedX, speedY, Game1, Color)
        {
            Animation animation = CreateFireBallAnimation(this);
            AddAnimation(animation);

            Animation animationBorder = CreateFireballBorderAnimation();
            AddAnimation(animationBorder);

        }
    }

    public class FireballSpinner : FireBall
    {
        public FireballSpinner(Thing Owner, int speedX, int speedY, Game1 Game1, Color Color) : base(Owner, speedX, speedY, Game1, Color)
        {
            var animation = GeneratedContent.Create_knight_fireball2(FIREBALL_OFFSET, FIREBALL_OFFSET, FIREBALL_SIZE, FIREBALL_SIZE);
            animation.RenderingLayer = GlobalSettigns.FIREBALL_Z;
            animation.ColorGetter = () => Color;
            AddAnimation(animation);

            var animationBorder = GeneratedContent.Create_knight_fireball2(FIREBALL_BORDER_OFFSET, FIREBALL_BORDER_OFFSET, FIREBALL_BORDER_SIZE, FIREBALL_BORDER_SIZE);
            animationBorder.RenderingLayer = GlobalSettigns.FIREBALL_BORDER_Z;
            animationBorder.ColorGetter = () => Color.Black;
            AddAnimation(animationBorder);
        }
    }

    public abstract class FireBall : BaseFireBall
    {
        public const int SPEED = 150;
        public const int FIREBALL_OFFSET = 0;
        public const int FIREBALL_SIZE = MapModule.CELL_SIZE;
        public const int FIREBALL_BORDER_OFFSET = -30 / 2;
        public const int FIREBALL_BORDER_SIZE = MapModule.CELL_SIZE + 30;

        public int duration = 200;

        public FireBall(Thing Owner, int speedX, int speedY, Game1 Game1, Color Color) : base(Owner, Game1, Color)
        {
            //Animation animation = CreateFireBallAnimation(this);
            //AddAnimation(animation);

            //Animation animationBorder = CreateFireballBorderAnimation();
            //AddAnimation(animationBorder);

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
            var animationBorder = GeneratedContent.Create_knight_fireball(
             FIREBALL_BORDER_OFFSET
            , FIREBALL_BORDER_OFFSET
            , FIREBALL_BORDER_SIZE
            , FIREBALL_BORDER_SIZE
            );
            animationBorder.RenderingLayer = GlobalSettigns.FIREBALL_BORDER_Z;
            animationBorder.ColorGetter = () => Color.Black;
            return animationBorder;
        }

        public static Animation CreateFireBallAnimation(BaseFireBall parent)
        {
            var animation = GeneratedContent.Create_knight_fireball(
                        FIREBALL_OFFSET
                        , FIREBALL_OFFSET
                        , FIREBALL_SIZE
                        , FIREBALL_SIZE
                        );
            animation.RenderingLayer = GlobalSettigns.FIREBALL_Z;
            animation.ColorGetter = () => parent.Color;
            return animation;
        }

        private void DestroyAfterDuration()
        {
            duration--;
            if (duration <= 0)
                Destroy();
        }
    }

    public class SonicBoom
    {
        public readonly AttackCollider collider;
        private readonly Game1 Game1;

        public SonicBoom(Thing Owner, Game1 Game1, int speedx, int x, int y)
        {
            this.Game1 = Game1;
            var vspeed = 50;
            var distanceLimit = 800;

            var color = GameState.GetColor();
            var darkerColor = new Color(color.R - 20, color.G - 20, color.B - 20);
            var fireball1 = new FireballCloud(Owner, speedx, -vspeed, Game1, color)
            {
                X = x,
                Y = y
            };

            AddTrail2(fireball1, 4, speedx, GlobalSettigns.FIRERING_FRONT_Z, () => color);
            AddTrail2(fireball1, 4, -speedx / 2, GlobalSettigns.FIRERING_BACK_Z, () => darkerColor);

            fireball1.AddUpdate(() =>
            {
                if (fireball1.Y < y - distanceLimit - 200)
                    fireball1.VerticalSpeed = 0;
            });

            var fireball3 = new FireballCloud(Owner, speedx, vspeed, Game1, color)
            {
                X = x,
                Y = y
            };

            fireball3.AddUpdate(() =>
            {
                if (fireball3.Y > y + distanceLimit)
                    fireball3.VerticalSpeed = 0;
            });

            //AddTrail(fireball3, 4);
            AddTrail2(fireball3, 4, speedx, GlobalSettigns.FIRERING_FRONT_Z, () => color);
            AddTrail2(fireball3, 4, -speedx / 2, GlobalSettigns.FIRERING_BACK_Z, () => darkerColor);


            Game1.AddToWorld(fireball1);
            //Game1.AddToWorld(fireball2);
            Game1.AddToWorld(fireball3);

            fireball1.OnDestroy += () => fireball3.Destroy();
            fireball3.OnDestroy += () => fireball1.Destroy();
        }

        private void AddTrail2(Thing parent, int count, int speedx, float z, Func<Color> color)
        {
            var chain = new Thing();
            chain.X = parent.X;
            chain.Y = parent.Y;

            var anim = GeneratedContent.Create_knight_fireball(FireBall.FIREBALL_OFFSET, FireBall.FIREBALL_OFFSET, FireBall.FIREBALL_SIZE, FireBall.FIREBALL_SIZE);
            anim.ColorGetter = color;
            anim.RenderingLayer = z;
            chain.AddAnimation(anim);
            var animBorder = GeneratedContent.Create_knight_fireball(FireBall.FIREBALL_BORDER_OFFSET, FireBall.FIREBALL_BORDER_OFFSET, FireBall.FIREBALL_BORDER_SIZE, FireBall.FIREBALL_BORDER_SIZE);
            animBorder.ColorGetter = () => Color.Black;
            animBorder.RenderingLayer = z + 0.001f;
            chain.AddAnimation(animBorder);

            Game1.AddToWorld(chain);

            parent.OnDestroy += () => chain.Destroy();
            chain.OnDestroy += () => Game1.AddToWorld(new SmokeHitEffect(z)
            {
                X = chain.X,
                Y = chain.Y,
                Color = color()
            });

            var magicNumber = 200;
            parent.AddUpdate(() =>
            {
                chain.X = parent.X + speedx * count;
                if (chain.Y > parent.Y + magicNumber)
                {
                    chain.Y = parent.Y + magicNumber;
                }
                else if (chain.Y < parent.Y - magicNumber)
                {
                    chain.Y = parent.Y - magicNumber;
                }
            });

            if (count > 0)
                AddTrail2(chain, --count, speedx, z, color);
        }
    }

    public class SeekerFireBall : BaseFireBall
    {
        public const int MAX_SPEED = 50;
        public int duration = 240;

        public SeekerFireBall(Boss boss, Game1 Game1, Color Color) : base(boss, Game1, Color)
        {
            var target = boss.player;
            var colliderToDeflect = new Collider {
                OffsetX = -250,
                OffsetY = -250,
                Width = 1000,
                Height = 1000
            };
            colliderToDeflect.AddHandler((s, t) =>
            {
                if (t is AttackCollider && t.Parent is Player)
                {
                    HorizontalSpeed = 0;
                    VerticalSpeed = 0;
                    DamageHandler.CollisionHandler(s, t);
                }
            });
            AddCollider(colliderToDeflect);

            AddAnimation(FireBall.CreateFireBallAnimation(this));
            AddAnimation(FireBall.CreateFireballBorderAnimation());

            HorizontalSpeed = 0;
            VerticalSpeed = 0;
            DamageHandler.HEALTH = GlobalSettigns.FIREBALL_HEALTH + (1 * Game1.GetNumberOfActivePlayers());

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
