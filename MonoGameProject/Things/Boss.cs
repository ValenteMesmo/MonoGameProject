﻿using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
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
        , BiteOpen
        , Shoot
    }

    public class Boss : Thing
    {
        public const float HEAD_Z = 0.101f;
        public const float TORSO_Z = 0.102f;
        public const float EYE_Z = 0.100f;

        public Player player;

        private BossState _state;
        public BossState state { get { return _state; } set { _state = value; StateChanged(); } }
        private Action StateChanged = () => { };
        public BossMouthState MouthState;
        public bool facingRight = false;
        public int damageTaken = 0;
        public int damageCooldown;
        public bool grounded;

        private const int width = 1500;
        private const int height = 1500;
        private const int offsetY = -height;

        public MyRandom MyRandom = new MyRandom()
        {
            Seed = GameState.PlatformRandomModule.Seed
        };

        public Color BodyColor;
        private Game1 Game1;

        public readonly AttackCollider attackCollider;
        private readonly Collider headCollider;
        public readonly Collider mainCollider;
        public readonly CollisionChecker groundDetector;

        public Boss(Game1 Game1)
        {
            this.Game1 = Game1;
            var width = 1500;
            var height = 1500;

            BodyColor = GameState.GetComplimentColor();

            groundDetector = new CollisionChecker();
            groundDetector.Width = width / 2;
            groundDetector.Height = height / 10;
            groundDetector.OffsetY = height;
            groundDetector.OffsetX = width / 3;

            AddCollider(groundDetector);

            attackCollider = new AttackCollider
            {
                Height = height / 2,
                Width = 500,
                OffsetX = -500,
                OffsetY = 500,
                Disabled = true
            };
            AddCollider(attackCollider);

            headCollider = new Collider
            {
                Height = height / 2,
                Width = 500,
                OffsetX = -500,
                OffsetY = 100//500
            };
            AddCollider(headCollider);

            mainCollider = new Collider(width, height);

            mainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            mainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            mainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            mainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            var playerFinder = new Collider(width * 4, height) { OffsetX = -width * 2 };
            playerFinder.AddHandler(FindPlayer);
            AddCollider(playerFinder);

            mainCollider.AddHandler(HandlePlayerAttack);
            headCollider.AddHandler(HandlePlayerAttack);

            AddCollider(mainCollider);

            var headType = MyRandom.Next(1, 3);
            CreateHeadAnimator(headType, HEAD_Z);
            CreateEyeAnimator(MyRandom.Next(1, 3), EYE_Z, Game1);
            CreateBody(MyRandom.Next(1, 3), Game1, headType);

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(MoveAttackCollider);
            AddUpdate(CheckIfGrounded);
        }

        private void FindPlayer(Collider s, Collider t)
        {
            if (s.Parent is Player)
            {
                player = s.Parent as Player;
            }
            if (t.Parent is Player)
            {
                player = t.Parent as Player;
            }
        }

        private void CheckIfGrounded()
        {
            grounded = groundDetector.Colliding<BlockVerticalMovement>();
        }

        private void MoveAttackCollider()
        {
            if (facingRight)
                attackCollider.OffsetX = mainCollider.Width;
            else
                attackCollider.OffsetX = -attackCollider.Width;

            attackCollider.Disabled =
                MouthState != BossMouthState.BiteOpen;

            if (facingRight)
                headCollider.OffsetX = mainCollider.Width;
            else
                headCollider.OffsetX = -headCollider.Width;
        }

        public const int HEALTH = 20;

        public bool Dead()
        {
            return damageTaken >= HEALTH;
        }

        private void HandlePlayerAttack(Collider s, Collider t)
        {
            if (t is AttackCollider
                && t.Parent is Player)
            {
                if (damageCooldown > 0)
                    return;

                damageCooldown = 20;
                BodyColor = Color.Lerp(BodyColor, Color.Red, 0.05f);
                damageTaken++;
                Game1.Sleep();
                Game1.Camera.ShakeUp(20);

                var player = t.Parent as Player;
                if (player.FacingRight)
                    Game1.AddToWorld(new HitEffect(0.04f)
                    {
                        X = player.AttackRightCollider.Right(),
                        Y = player.AttackRightCollider.Y,
                        Color = BodyColor,
                        HorizontalSpeed = HorizontalSpeed,
                        VerticalSpeed = VerticalSpeed
                    });
                else
                    Game1.AddToWorld(new HitEffect(0.04f)
                    {
                        X = player.AttackLeftCollider.Left(),
                        Y = player.AttackLeftCollider.Y,
                        Color = BodyColor,
                        HorizontalSpeed = HorizontalSpeed,
                        VerticalSpeed = VerticalSpeed
                    });

                if (Dead() == false)
                    return;

                GameState.Save();
                GameState.State.BossMode = false;
                Destroy();
            }
        }

        private void CreateEyeAnimator(int random, float z, Game1 Game1)
        {
            if (random == 1)
            {
                StateChanged = () =>
                {
                    if (state == BossState.EyeAttack)
                    {
                        Game1.AddToWorld(new LeafShieldCell(this));
                    }
                };
            }
            else if (random == 2)
            {
                StateChanged = () =>
                {
                    if (state == BossState.EyeAttack)
                    {
                        var pilar = new Thing();
                        var size = 2000;
                        var collider = new AttackCollider
                        {
                            OffsetX = 0,
                            OffsetY = -size / 2,
                            Width = size,
                            Height = size / 2,
                            Disabled = true
                        };
                        pilar.AddCollider(collider);
                        var anim = GeneratedContent.Create_knight_pilar(
                             -width / 2 + BossAnimationsFactory.GetHeadBonusX(facingRight)
                            , offsetY
                            , width * 2
                            , height * 2
                            , facingRight);

                        anim.ColorGetter = GameState.GetColor;
                        anim.LoopDisabled = true;
                        anim.RenderingLayer = Boss.EYE_Z - 0.0001f;
                        pilar.AddAnimation(anim);
                        pilar.X = X;
                        pilar.Y = Y;
                        var duration = 50;
                        pilar.AddUpdate(new MoveHorizontallyWithTheWorld(pilar));
                        pilar.AddUpdate(() =>
                        {
                            if (Dead() == false)
                            {
                                pilar.X = X;
                                pilar.Y = Y;
                            }

                            if (duration < 45)
                                collider.Disabled = false;

                            if (duration < 25)
                                collider.Disabled = true;

                            duration--;
                            if (duration <= 0)
                            {
                                pilar.Destroy();
                            }
                        });
                        Game1.AddToWorld(pilar);
                    }
                };
            }
            else
            {
                StateChanged = () =>
                {
                    if (state == BossState.EyeAttack)
                    {
                        var size = 1500;
                        var spikeBall = new Thing();
                        var collider = new AttackCollider
                        {
                            Width = size / 2 - (size / 3)/2
                            ,
                            Height = size / 3  - (size / 6)
                            ,
                            OffsetY = size / 3 + (size / 6)
                            ,
                            OffsetX = (size / 3)/4
                        };
                        spikeBall.AddCollider(collider);
                        var anim = GeneratedContent.Create_knight_spike_dropped(
                            -size / 4
                            , -size / 3, 
                            size, 
                            size);
                        anim.RenderingLayer = Boss.HEAD_Z;
                        anim.ColorGetter = GameState.GetColor;
                        spikeBall.AddAnimation(anim);
                        spikeBall.X = facingRight ? X : (int)mainCollider.CenterX();
                        spikeBall.Y = Y;
                        collider.AddBotCollisionHandler(StopsWhenHitting.Bot);
                        spikeBall.AddUpdate(new AfectedByGravity(spikeBall));
                        spikeBall.AddUpdate(new MoveHorizontallyWithTheWorld(spikeBall));
                        var duration = 500;
                        spikeBall.AddUpdate(() =>
                        {
                            duration--;
                            if (duration <= 0)
                            {
                                spikeBall.Destroy();
                            }
                        });
                        Game1.AddToWorld(spikeBall);
                    }
                };
            }

            var standing_left = BossAnimationsFactory.EyeAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , false
            );
            standing_left.RenderingLayer = z;

            var standing_right = BossAnimationsFactory.EyeAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , true
            );
            standing_right.RenderingLayer = z;

            var attack_left = BossAnimationsFactory.EyeAttackAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , false
            );
            attack_left.RenderingLayer = z;

            var attack_right = BossAnimationsFactory.EyeAttackAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , true
            );
            attack_right.RenderingLayer = z;

            var shoot_left = BossAnimationsFactory.EyeAttackAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , false
            );
            shoot_left.LoopDisabled = true;
            shoot_left.RenderingLayer = z;

            var shoot_right = BossAnimationsFactory.EyeAttackAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , true
            );
            shoot_right.LoopDisabled = true;
            shoot_right.RenderingLayer = z;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () =>
                        MouthState == BossMouthState.Idle
                        && !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () =>
                        MouthState == BossMouthState.Idle
                        && facingRight)
                    , new AnimationTransitionOnCondition(attack_left, () =>
                        MouthState == BossMouthState.BiteOpen
                        && !facingRight)
                    , new AnimationTransitionOnCondition(attack_right, () =>
                        MouthState == BossMouthState.BiteOpen
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

        private void CreateBody(int bodyType, Game1 Game1, int headType)
        {
            Action<Boss> CreateFireBall = CreateFileBallAction(Game1, headType);

            Action ShakeCamera = () => Game1.Camera.ShakeUp(10);
            if (bodyType == 1)
            {
                new SpiderBossBody(this, Game1.AddToWorld, ShakeCamera, CreateFireBall);
            }
            else if (bodyType == 2)
            {

                new WolfBossBody(this, Game1.AddToWorld, ShakeCamera, CreateFireBall);
            }
            else
            {
                new HumanoidBossBody(this, Game1.AddToWorld, ShakeCamera, CreateFireBall);
            }
        }

        private static Action<Boss> CreateFileBallAction(Game1 Game1, int headType)
        {
            if (headType == 1)
                return boss =>
            {
                Game1.AddToWorld(new WavedFireBall(boss.facingRight, Game1.AddToWorld) { X = boss.attackCollider.X, Y = boss.attackCollider.Y });
            };

            if (headType == 2)
                return boss =>
            {
                var speed = -FireBall.SPEED;
                if (boss.facingRight)
                    speed = -speed;
                Game1.AddToWorld(new FireBall(speed, 0, Game1.AddToWorld) { X = boss.attackCollider.X, Y = boss.attackCollider.Y });
            };

            return boss =>
            {
                Game1.AddToWorld(new SeekerFireBall(boss, Game1.AddToWorld) { X = boss.attackCollider.X, Y = boss.attackCollider.Y });
            };
        }

        private void CreateHeadAnimator(int random, float z)
        {
            var standing_left = BossAnimationsFactory.HeadAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , false
            );
            standing_left.RenderingLayer = z;

            standing_left.ColorGetter = () => BodyColor;

            var standing_right = BossAnimationsFactory.HeadAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => BodyColor;

            var attack_left = BossAnimationsFactory.HeadAttackAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , false
            );
            attack_left.RenderingLayer = z;

            attack_left.ColorGetter = () => BodyColor;

            var attack_right = BossAnimationsFactory.HeadAttackAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , true
            );
            attack_right.RenderingLayer = z;
            attack_right.ColorGetter = () => BodyColor;

            var shoot_left = BossAnimationsFactory.HeadShootAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , false
            );
            shoot_left.RenderingLayer = z;

            shoot_left.ColorGetter = () => BodyColor;

            var shoot_right = BossAnimationsFactory.HeadShootAnimation(
                random
                , -width / 2
                , offsetY
                , width * 2
                , height * 2
                , true
            );
            shoot_right.RenderingLayer = z;
            shoot_right.ColorGetter = () => BodyColor;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () =>
                        MouthState == BossMouthState.Idle
                        && !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () =>
                        MouthState == BossMouthState.Idle
                        && facingRight)
                    , new AnimationTransitionOnCondition(attack_left, () =>
                        MouthState == BossMouthState.BiteOpen
                        && !facingRight)
                    , new AnimationTransitionOnCondition(attack_right, () =>
                        MouthState == BossMouthState.BiteOpen
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
    }
}