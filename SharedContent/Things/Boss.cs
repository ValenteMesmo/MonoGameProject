using GameCore;
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

    public class PlayerDamageHandler : UpdateHandler
    {
        private int damageCooldown;
        private readonly Game1 Game1;
        private readonly Action<Player> OnHit;
        private readonly Action<Player> OnKill;
        public int damageTaken = 0;
        public int HEALTH = 4;

        public PlayerDamageHandler(Game1 Game1, Action<Player> OnHit, Action<Player> OnKill)
        {
            this.Game1 = Game1;
            this.OnHit = OnHit;
            this.OnKill = OnKill;
        }

        public void CollisionHandler(Collider source, Collider t)
        {
            if (
                (
                    t is AttackCollider
                    && t.Parent is Player
                )
                ||
                (
                    t.Parent is FireBall
                    && (t.Parent as FireBall).Owner is Player)
                )
            {
                if (t.Parent is FireBall)
                    t.Parent.Destroy();

                if (damageCooldown > 0)
                    return;

                Player player = GetPlayerFromCollider(t);

                Game1.VibrationCenter.Vibrate(player.PlayerIndex, 10);

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

        private BossState _state;
        public BossState state { get { return _state; } set { _state = value; StateChanged(); } }
        private Action StateChanged = () => { };
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
        public readonly Collider mainCollider;
        public readonly CollisionChecker groundDetector;
        public readonly Collider playerFinder;

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
                Height = (height / 2) + 100,
                Width = 500,
                OffsetX = -500,
                OffsetY = 200,
                Disabled = true
            };
            AddCollider(attackCollider);

            mainCollider = new Collider(width, height + 600) { OffsetY = -600 };

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
            PlayerDamageHandler.HEALTH = 20;

            mainCollider.AddHandler(PlayerDamageHandler.CollisionHandler);
            AddUpdate(PlayerDamageHandler.Update);

            AddCollider(mainCollider);

            var headType = MyRandom.Next(1, 3);
            CreateHeadAnimator(headType, HEAD_Z);
            CreateEyeAnimator(MyRandom.Next(1, 3), EYE_Z, Game1);
            CreateBody(MyRandom.Next(1, 3), Game1, headType);

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
                        var newThing = new Thing();
                        var duration = 50;

                        var MAX = 50;
                        var MIN = 4;

                        var hspeed = 0;
                        var vspeed = MAX;
                        var hvelocity = MIN;
                        var vvelocity = -MIN;

                        newThing.AddUpdate(() =>
                        {
                            if (duration % 3 == 0)
                            {
                                Game1.AddToWorld(
                                    new FireBall(
                                        this
                                        , hspeed
                                        , vspeed
                                        , Game1.AddToWorld
                                    )
                                    {
                                        X = X + (facingRight ? 600 : 0),
                                        Y = Y - 600,
                                        ColorGetter = GameState.GetColor
                                    }
                                );
                            }

                            vspeed += vvelocity;
                            hspeed += hvelocity;

                            if (vspeed >= MAX)
                            {
                                vvelocity = -MIN;
                            }
                            if (vspeed <= -MAX)
                            {
                                vvelocity = MIN;
                            }

                            if (hspeed >= MAX)
                            {
                                hvelocity = -MIN;
                            }
                            if (hspeed <= -MAX)
                            {
                                hvelocity = MIN;
                            }

                            duration--;
                            if (duration == 0 || PlayerDamageHandler.Dead())
                            {
                                newThing.Destroy();
                            }
                        });

                        Game1.AddToWorld(newThing);
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
                            Width = size / 2 - (size / 3) / 2
                            ,
                            Height = size / 3 - (size / 6)
                            ,
                            OffsetY = size / 3 + (size / 6)
                            ,
                            OffsetX = (size / 3) / 4
                        };
                        spikeBall.AddCollider(collider);
                        var anim = GeneratedContent.Create_knight_spike_dropped(
                            -size / 4
                            , -size / 6,
                            size,
                            size);
                        anim.RenderingLayer = Boss.RIGHT_ARM_Z - 0.001f;
                        anim.ColorGetter = GameState.GetColor;
                        spikeBall.AddAnimation(anim);
                        spikeBall.X = facingRight ? X + 1000 : X - 200;
                        spikeBall.Y = Y - 1200;
                        collider.AddBotCollisionHandler(StopsWhenHitting.Bot<GroundCollider>());
                        collider.AddTopCollisionHandler(StopsWhenHitting.Top<GroundCollider>());
                        collider.AddLeftCollisionHandler(StopsWhenHitting.Left<GroundCollider>());
                        collider.AddRightCollisionHandler(StopsWhenHitting.Right<GroundCollider>());
                        var speed = 40;

                        var mod = facingRight ? -1 : 1;
                        spikeBall.VerticalSpeed = speed;

                        collider.AddBotCollisionHandler((s, t) =>
                        {
                            if (t is GroundCollider)
                            {
                                spikeBall.VerticalSpeed = 0;
                                spikeBall.HorizontalSpeed = speed * mod;
                            }
                        });
                        collider.AddRightCollisionHandler((s, t) =>
                        {
                            if (t is GroundCollider)
                            {
                                spikeBall.VerticalSpeed = -speed * mod;
                                spikeBall.HorizontalSpeed = 0;
                            }
                        });
                        collider.AddTopCollisionHandler((s, t) =>
                        {
                            if (t is GroundCollider)
                            {
                                spikeBall.VerticalSpeed = 0;
                                spikeBall.HorizontalSpeed = -speed * mod;
                            }
                        });
                        collider.AddLeftCollisionHandler((s, t) =>
                        {
                            if (t is GroundCollider)
                            {
                                spikeBall.VerticalSpeed = speed * mod;
                                spikeBall.HorizontalSpeed = 0;
                            }
                        });

                        //spikeBall.AddUpdate(new AfectedByGravity(spikeBall));
                        spikeBall.AddAfterUpdate(new MoveHorizontallyWithTheWorld(spikeBall));
                        var duration = 1000;
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

            var standing_left = NewMethod(random, z, false, GameState.GetColor, BossAnimationsFactory.EyeAnimation);
            var standing_right = NewMethod(random, z, true, GameState.GetColor, BossAnimationsFactory.EyeAnimation);
            var attack_left = NewMethod(random, z, false, GameState.GetColor, BossAnimationsFactory.EyeAnimation);
            var attack_right = NewMethod(random, z, true, GameState.GetColor, BossAnimationsFactory.EyeAnimation);
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
                new SpiderBossBody(this, Game1.AddToWorld, CreateFireBall);
            }
            else if (bodyType == 2)
            {

                new WolfBossBody(this, Game1.AddToWorld, CreateFireBall);
            }
            else
            {
                new HumanoidBossBody(this, Game1.AddToWorld, CreateFireBall);
            }
        }

        private Action<Boss> CreateFileBallAction(Game1 Game1, int headType)
        {
            if (headType == 1)
                return boss =>
            {
                Game1.AddToWorld(new WavedFireBall(boss.facingRight, Game1.AddToWorld) { X = boss.attackCollider.X, Y = boss.attackCollider.Y });
            };

            if (headType == 2)
                return boss =>
            {
                var speed = -100;
                if (boss.facingRight)
                    speed = -speed;

                var fireball = new SonicBoom(
                        speed
                        , 0
                        , Game1.AddToWorld
                    );
                fireball.ColorGetter = GameState.GetColor;
                fireball.X = boss.mainCollider.X + speed * 10;
                fireball.Y = boss.mainCollider.Y - fireball.collider.Height + 200;
                Game1.AddToWorld(fireball);

            };

            return boss =>
            {
                Game1.AddToWorld(new SeekerFireBall(boss, Game1.AddToWorld) { X = boss.attackCollider.X, Y = boss.attackCollider.Y });
            };
        }

        private void CreateHeadAnimator(int random, float z)
        {
            var standing_left = NewMethod(random, z, false, () => BodyColor, BossAnimationsFactory.HeadAnimation);
            var standing_right = NewMethod(random, z, true, () => BodyColor, BossAnimationsFactory.HeadAnimation);
            var attack_left = NewMethod(random, z, false, () => BodyColor, BossAnimationsFactory.HeadAttackAnimation);
            var attack_right = NewMethod(random, z, true, () => BodyColor, BossAnimationsFactory.HeadAttackAnimation);
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