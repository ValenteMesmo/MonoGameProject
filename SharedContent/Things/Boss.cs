﻿using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using SharedContent;
using SharedContent.Things.BossSkills;
using System;

namespace MonoGameProject
{
    public enum BossState
    {
        Idle,
        BodyAttack1,
        EyeAttack,
        HeadAttack1
    }

    public enum BossMouthState
    {
        Idle
        , Shoot
        , Tired
    }

    public class PlayerDamageHandler : UpdateHandler
    {
        public int damageCooldown;
        private readonly Game1 Game1;
        private readonly Action<Player> OnHit;
        private readonly Action<Player> OnKill;
        public int damageTaken = 0;
        public int HEALTH = 3;

        public PlayerDamageHandler(Game1 Game1, Action<Player> OnHit, Action<Player> OnKill)
        {
            this.Game1 = Game1;
            this.OnHit = OnHit;
            this.OnKill = OnKill;
        }

        public void CollisionHandler(Collider source, Collider t)
        {
            var sourceIsNotPlayerFireball =
                    (
                        (source.Parent is FireBall) == false
                        || ((source.Parent as FireBall).Owner is Player) == false
                    );

            if (
                (
                    t is AttackCollider
                    && t.Parent is Player
                    && sourceIsNotPlayerFireball
                )
                ||
                (
                    t.Parent is FireBall
                    && (t.Parent as FireBall).Owner is Player
                    && sourceIsNotPlayerFireball
                )
            )
            {
                if (t.Parent is FireBall)
                    t.Parent.Destroy();

                if (damageCooldown > 0)
                    return;

                Player player = GetPlayerFromCollider(t);

                Game1.VibrationCenter.Vibrate(player.Inputs, 10, 0.25f);

                damageCooldown = 20;
                //BodyColor = Color.Lerp(BodyColor, Color.Red, 0.05f);

                if (player.weaponType == WeaponType.Sword)
                    damageTaken += 4;
                else if (player.weaponType == WeaponType.Whip)
                    damageTaken += 2;
                else if (player.weaponType == WeaponType.Wand)
                    damageTaken += 1;

                Game1.Sleep();
                Game1.Camera.ShakeUp(20);

                Game1.AddToWorld(new HitEffect(0.04f)
                {
                    X = (int)source.CenterX(),
                    Y = t.Y,
                    //Color = BodyColor,
                    HorizontalSpeed = source.Parent.HorizontalSpeed,
                    VerticalSpeed = source.Parent.VerticalSpeed
                });

                if (Dead())
                {
                    OnKill(player);
                    source.Parent.Destroy();
                }
                else
                {
                    OnHit(player);
                }
            }

        }

        public bool Dead()
        {
            return damageTaken >= HEALTH;
        }

        private Player GetPlayerFromCollider(Collider t)
        {
            if (t.Parent is Player)
                return t.Parent as Player;
            else if (t.Parent is FireBall && (t.Parent as FireBall).Owner is Player)
                return (t.Parent as FireBall).Owner as Player;
            return null;
        }

        public void Update()
        {
            if (damageCooldown > 0)
                damageCooldown--;
        }
    }


    public class Boss : Thing
    {
        public const float RIGHT_ARM_Z = 0.100f;
        public const float EYE_Z = 0.101f;
        public const float HEAD_Z = 0.102f;
        public const float RIGHT_FEET_Z = 0.103f;
        public const float TORSO_Z = 0.104f;
        public const float BACK_Z = 0.105f;
        public const float LEFT_ARM_Z = 0.106f;
        public const float LEFT_FEET_Z = 0.107f;

        public Player player;

        public BossState state;
        public BossMouthState MouthState;
        public bool facingRight = false;
        public bool grounded;

        private const int width = 1500;
        private const int height = 1500;
        private const int offsetY = -height - height / 2;
        private const int offsetX = -width / 4;
        private const int offsetX_flipped = -width / 2 - width / 4;

        public MyRandom MyRandom = new MyRandom()
        {
            Seed = GameState.PlatformRandomModule.Seed
        };

        public Color BodyColor;
        private Game1 Game1;

        public readonly AttackCollider attackCollider;
        public readonly SolidCollider mainCollider;
        public readonly CollisionChecker groundDetector;
        public readonly Collider playerFinder;

        public Boss(Game1 Game1)
        {
            this.Game1 = Game1;
            var width = 1500;
            var height = 1500;

            //AddCollider(new GroundCollider(1000, 1000) {OffsetX=-2000 });

            BodyColor = GameState.GetComplimentColor();

            groundDetector = new CollisionChecker();
            groundDetector.Width = width / 2;
            groundDetector.Height = height / 10;
            groundDetector.OffsetY = height;
            groundDetector.OffsetX = width / 3;

            AddCollider(groundDetector);

            attackCollider = new AttackCollider
            {
                Height = (height / 2) + 100,
                Width = 500,
                OffsetX = -500,
                OffsetY = 200,
                Disabled = true
            };
            AddCollider(attackCollider);

            mainCollider = new SolidCollider(width, height) { };

            mainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot<GroundCollider>());
            mainCollider.AddTopCollisionHandler(StopsWhenHitting.Top<GroundCollider>());
            mainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left<GroundCollider>());
            mainCollider.AddRightCollisionHandler(StopsWhenHitting.Right<GroundCollider>());

            playerFinder = new Collider(
                attackCollider.Width * 2
                , height * 3
            )
            {
                OffsetX = -width,
                OffsetY = -height
            };
            playerFinder.AddHandler(FindPlayer);
            AddCollider(playerFinder);

            PlayerDamageHandler = new PlayerDamageHandler(
                Game1
                , _ => { }
                , _ =>
                    {
                        GameState.Save();
                        GameState.State.BossMode = false;
                    }
            );
            PlayerDamageHandler.HEALTH = 30;

            mainCollider.AddHandler(PlayerDamageHandler.CollisionHandler);
            AddUpdate(PlayerDamageHandler.Update);
            AddUpdate(() =>
            {
                //prevent player from killing boss without entering the arena
                if (!GameState.State.BossMode)
                    PlayerDamageHandler.damageTaken = 2;
            });

            AddCollider(mainCollider);

            var headType = MyRandom.Next(1, 3);
            var eyeType = MyRandom.Next(1, 3);
            CreateHeadAnimator(headType, HEAD_Z);
            CreateEyeAnimator(eyeType, EYE_Z, Game1);
            CreateBody(MyRandom.Next(1, 3), Game1, headType, eyeType);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(MoveAttackCollider);
            AddUpdate(CheckIfGrounded);

            AddAnimation(CreateFlippableAnimation(GameState.GetComplimentColor, BACK_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Back));
            AddAnimation(CreateFlippableAnimation(GameState.GetComplimentColor2, TORSO_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Front));

            var arm = CreateFlippableAnimation(() => BodyColor, RIGHT_ARM_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Arm);
            var arm_attack = CreateFlippableAnimation(() => BodyColor, RIGHT_ARM_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Arm_attack);
            AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(
                        arm
                        , () => state != BossState.BodyAttack1 || !AttackingWithTheHand
                    )
                    , new AnimationTransitionOnCondition(
                        arm_attack
                        , () => state == BossState.BodyAttack1 && AttackingWithTheHand
                    )
                )
            );
            AddAnimation(CreateFlippableAnimation(() => BodyColor, LEFT_ARM_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Arm, true));
            AddAnimation(CreateFlippableAnimation(() => BodyColor, RIGHT_FEET_Z, GeneratedContent.Create_knight_Torso_Humanoid_turtle_feet));
            AddAnimation(CreateFlippableAnimation(() => BodyColor, LEFT_FEET_Z, GeneratedContent.Create_knight_Torso_Humanoid_turtle_feet, true));

        }

        private IHandleAnimation CreateFlippableAnimation(
            Func<Color> green
            , float z
            , Func<int, int, int?, int?, bool, Animation> AutoGeneratedMethod
            , bool pair = false)
        {
            var size = 1500;

            var x = -size / 2 - size / 3;
            if (pair)
                x += x / 2;

            var flippedx = -size / 4 + size / 8;
            if (pair)
                flippedx -= flippedx * 3;

            var y = -size + size / 10;
            var width = size * 2;

            var back = AutoGeneratedMethod(
                x
                , y
                , width
                , width
                , false);

            back.RenderingLayer = z;
            back.ColorGetter = green;
            if (pair)
                back.StartingFrame = 3;

            var flipped = AutoGeneratedMethod(
                flippedx
                , y
                , width
                , width
                , true);

            flipped.RenderingLayer = z;
            flipped.ColorGetter = green;
            if (pair)
                flipped.StartingFrame = 3;

            return new Animator(
                new AnimationTransitionOnCondition(back, () => !facingRight)
                , new AnimationTransitionOnCondition(flipped, () => facingRight)
            );
        }

        private void FindPlayer(Collider s, Collider t)
        {
            //if (s.Parent is Player)
            //{
            //    player = s.Parent as Player;
            //}

            //if (t.Parent is Player)
            //{
            //    player = t.Parent as Player;
            //}
            player = GetPlayerFromCollider(t);
        }

        private void CheckIfGrounded()
        {
            grounded = groundDetector.Colliding<BlockVerticalMovement>();
        }

        private void MoveAttackCollider()
        {
            if (facingRight)
            {
                attackCollider.OffsetX = mainCollider.Width;
                playerFinder.OffsetX = mainCollider.Width;
            }
            else
            {
                attackCollider.OffsetX = -attackCollider.Width;
                playerFinder.OffsetX = -playerFinder.Width;
            }

            attackCollider.Disabled = !AttackingWithTheHand;
        }

        public const int HEALTH = 20;
        internal bool AttackingWithTheHand;
        public readonly PlayerDamageHandler PlayerDamageHandler;

        private Player GetPlayerFromCollider(Collider t)
        {
            Player player = this.player;
            if (t.Parent is Player)
                player = t.Parent as Player;
            else if (t.Parent is FireBall && (t.Parent as FireBall).Owner is Player)
                player = (t.Parent as FireBall).Owner as Player;
            return player;
        }

        private void CreateEyeAnimator(int random, float z, Game1 Game1)
        {
            var standing_left = NewMethod(random, z, false, GameState.GetColor, BossAnimationsFactory.EyeAnimation);
            var standing_right = NewMethod(random, z, true, GameState.GetColor, BossAnimationsFactory.EyeAnimation);
            var attack_left = NewMethod(random, z, false, GameState.GetComplimentColor, BossAnimationsFactory.EyeAnimation);
            var attack_right = NewMethod(random, z, true, GameState.GetComplimentColor, BossAnimationsFactory.EyeAnimation);
            var shoot_left = NewMethod(random, z, false, GameState.GetColor, BossAnimationsFactory.EyeAnimation);
            var shoot_right = NewMethod(random, z, true, GameState.GetColor, BossAnimationsFactory.EyeAnimation);

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () =>
                        MouthState == BossMouthState.Idle
                        && !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () =>
                        MouthState == BossMouthState.Idle
                        && facingRight)
                    , new AnimationTransitionOnCondition(attack_left, () =>
                        MouthState == BossMouthState.Tired
                        && !facingRight)
                    , new AnimationTransitionOnCondition(attack_right, () =>
                        MouthState == BossMouthState.Tired
                        && facingRight)
                    , new AnimationTransitionOnCondition(shoot_left, () =>
                        MouthState == BossMouthState.Shoot
                        && !facingRight)
                    , new AnimationTransitionOnCondition(shoot_right, () =>
                        MouthState == BossMouthState.Shoot
                        && facingRight)
            );

            AddAnimation(animation);
        }

        private void CreateBody(int bodyType, Game1 Game1, int headType, int eyeType)
        {
            Action<Boss> CreateFireBall = CreateFileBallAction(Game1, headType);
            Action UseEyeSkill = CreateEyeSkill(Game1, eyeType);

            //Action ShakeCamera = () => Game1.Camera.ShakeUp(10);
            //if (bodyType == 1)
            //{
            //    new SpiderBossBody(this, Game1.AddToWorld, CreateFireBall);
            //}
            //else if (bodyType == 2)
            //{

            new WolfBossBody(this, Game1.AddToWorld, CreateFireBall, UseEyeSkill);
            //}
            //else
            //{
            //    new HumanoidBossBody(this, Game1.AddToWorld, CreateFireBall);
            //}
        }

        private Action CreateEyeSkill(Game1 Game1, int eyeType)
        {
            if (eyeType == 1)
            {
                return () => Game1.AddToWorld(new LeafShieldCell(this));
            }
            else if (eyeType == 2)
            {
                return () => Game1.AddToWorld(new BulletStorm(Game1, this));
            }
            else
            {
                return () => Game1.AddToWorld(new SpikeBall(Game1, this));
            }
        }

        private Action<Boss> CreateFileBallAction(Game1 Game1, int headType)
        {
            var random = new MyRandom(GameState.RandomMonster.Seed);

            if (headType == 1)
                return boss =>
            {
                var rnd = random.Next(1, 3);
                if (rnd == 1)
                    Game1.AddToWorld(
                        new WavedFireBall(
                            boss
                            , boss.facingRight
                            , Game1
                            , GameState.GetColor())
                        {
                            X = boss.attackCollider.X,
                            Y = boss.attackCollider.Y
                        });
                else if (rnd == 2)
                    Game1.AddToWorld(
                    new WavedFireBall(
                        boss
                        , boss.facingRight
                        , Game1
                        , GameState.GetColor()
                        , true)
                    {
                        X = boss.attackCollider.X,
                        Y = boss.attackCollider.Y
                    });
                else
                {
                    Game1.AddToWorld(
                    new WavedFireBall(
                        boss
                        , boss.facingRight
                        , Game1
                        , GameState.GetColor())
                    {
                        X = boss.attackCollider.X,
                        Y = boss.attackCollider.Y
                    });
                    Game1.AddToWorld(
                   new WavedFireBall(
                       boss
                       , boss.facingRight
                       , Game1
                       , GameState.GetColor()
                       , true)
                   {
                       X = boss.attackCollider.X,
                       Y = boss.attackCollider.Y
                   });
                }
            };

            if (headType == 2)
                return boss =>
            {
                var speed = -100;
                if (boss.facingRight)
                    speed = -speed;

                new SonicBoom(
                    boss
                    , Game1
                    , speed
                    , boss.facingRight ? boss.mainCollider.Right() + 700 : boss.mainCollider.Left() - 700
                    , boss.mainCollider.Y - 600);
            };

            return boss =>
            {
                Game1.AddToWorld(
                    new SeekerFireBall(boss, Game1, GameState.GetColor())
                    {
                        X = boss.attackCollider.X,
                        Y = boss.attackCollider.Y
                    });
            };
        }

        private void CreateHeadAnimator(int random, float z)
        {
            var standing_left = NewMethod(random, z, false, () => BodyColor, BossAnimationsFactory.HeadAnimation);
            var standing_right = NewMethod(random, z, true, () => BodyColor, BossAnimationsFactory.HeadAnimation);
            var attack_left = NewMethod(random, z, false, GameState.GetColor, BossAnimationsFactory.HeadAttackAnimation);
            var attack_right = NewMethod(random, z, true, GameState.GetColor, BossAnimationsFactory.HeadAttackAnimation);
            var shoot_left = NewMethod(random, z, false, () => BodyColor, BossAnimationsFactory.HeadShootAnimation);
            var shoot_right = NewMethod(random, z, true, () => BodyColor, BossAnimationsFactory.HeadShootAnimation);

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () =>
                        MouthState == BossMouthState.Idle
                        && !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () =>
                        MouthState == BossMouthState.Idle
                        && facingRight)
                    , new AnimationTransitionOnCondition(attack_left, () =>
                        MouthState == BossMouthState.Tired
                        && !facingRight)
                    , new AnimationTransitionOnCondition(attack_right, () =>
                        MouthState == BossMouthState.Tired
                        && facingRight)
                    , new AnimationTransitionOnCondition(shoot_left, () =>
                        MouthState == BossMouthState.Shoot
                        && !facingRight)
                    , new AnimationTransitionOnCondition(shoot_right, () =>
                        MouthState == BossMouthState.Shoot
                        && facingRight)
            );

            AddAnimation(animation);
        }

        private Animation NewMethod(int random, float z, bool flipped, Func<Color> color, Func<int, int, int, int?, int?, bool, Animation> CreateAnimation)
        {
            var animation = CreateAnimation(
                random
                , flipped ? offsetX_flipped : offsetX
                , offsetY
                , width * 2
                , height * 2
                , flipped
            );
            animation.RenderingLayer = z;
            animation.ColorGetter = color;
            return animation;
        }
    }
}