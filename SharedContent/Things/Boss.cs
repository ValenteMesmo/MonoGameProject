using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using SharedContent;
using SharedContent.Things.BossSkills;
using System;
using System.Linq;

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

    public class Boss : Thing
    {
        public const float RIGHT_WING_Z = 0.100f;
        public const float RIGHT_ARM_Z = 0.101f;
        public const float EYE_Z = 0.102f;
        public const float HEAD_Z = 0.103f;
        public const float JAIL_Z = 0.1035f;
        public const float RIGHT_FEET_Z = 0.104f;
        public const float TORSO_Z = 0.105f;
        public const float BACK_Z = 0.106f;
        public const float LEFT_ARM_Z = 0.107f;
        public const float LEFT_FEET_Z = 0.108f;
        public const float LEFT_WING_Z = 0.109f;

        public Player player;

        public BossState state;
        public BossMouthState MouthState;
        public bool facingRight = false;
        public bool grounded;

        private const int width = 1500;
        private const int height = 1500;
        private const int offsetY = -height - height / 2;
        private const int offsetX = (-width / 4);
        private const int offsetX_flipped = (-width / 2 - width / 4) - 200;

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

        public const int HEALTH = 25;
        internal bool AttackingWithTheHand;
        public readonly PlayerDamageHandler PlayerDamageHandler;
        private readonly Color BodyColorTakingDamate;
        private readonly Color BodyColorNormal;

        public Boss(Game1 Game1)
        {
            this.Game1 = Game1;
            var width = 1000;
            var height = 1300;

            BodyColorTakingDamate = GameState.GetPreviousColor2();
            BodyColorNormal = GameState.GetComplimentColor();
            BodyColor = BodyColorNormal;

            groundDetector = new CollisionChecker();
            groundDetector.Width = width / 2;
            groundDetector.Height = height / 10;
            groundDetector.OffsetY = height + 50;
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

            var headSize = 600;
            mainCollider = new SolidCollider(width, height) { };
            var headCollider = new Collider(width, headSize)
            {
                OffsetY = -mainCollider.OffsetY - headSize
            };
            AddCollider(headCollider);

            mainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot<GroundCollider>());
            mainCollider.AddTopCollisionHandler(StopsWhenHitting.Top<GroundCollider>());
            mainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left<GroundCollider>());
            mainCollider.AddRightCollisionHandler(StopsWhenHitting.Right<GroundCollider>());

            playerFinder = new Collider(
                attackCollider.Width * 2
                , height
            )
            {
                OffsetX = -width
            };

            playerFinder.AddHandler(FindPlayer);
            headCollider.AddHandler(FindPlayer);
            mainCollider.AddHandler(FindPlayer);

            AddCollider(playerFinder);

            PlayerDamageHandler = new PlayerDamageHandler(
                Game1
                , BodyColor
                , (p, s, t) =>
                {
                    Game1.AddToWorld(new BloodHitEffect
                    {
                        X = (int)(s.CenterX() + t.CenterX()) / 2,
                        Y = t.Y,
                        Color = BodyColorNormal
                    });
                }
                , (p, s, t) =>
                {
                    GameState.State.BossMode = false;
                }
            );
            PlayerDamageHandler.HEALTH = HEALTH + (5 * Game1.GetNumberOfActivePlayers());

            mainCollider.AddHandler(PlayerDamageHandler.CollisionHandler);
            headCollider.AddHandler(PlayerDamageHandler.CollisionHandler);
            AddUpdate(PlayerDamageHandler.Update);
            AddUpdate(() =>
            {
                //prevent player from killing boss without entering the arena
                if (!GameState.State.BossMode)
                    PlayerDamageHandler.damageTaken = 0;

                BodyColor = Color.Lerp(
                    BodyColor
                    , PlayerDamageHandler.damageCooldown > 0 ? BodyColorTakingDamate : BodyColorNormal
                    , 0.15f
                );
            });

            AddCollider(mainCollider);

            var headType = MyRandom.Next(1, 3);
            var eyeType = MyRandom.Next(1, 3);
            var bodyType = MyRandom.Next(1, 2);
            CreateHeadAnimator(headType, HEAD_Z);
            CreateEyeAnimator(eyeType, EYE_Z, Game1);
            CreateBody(bodyType, Game1, headType, eyeType);

            AddUpdate(CheckIfGrounded);
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(MoveAttackCollider);

            if (bodyType == 1)
            {
                CreateTorso();
                CreateFeet();
            }
            if (bodyType == 2)
            {
                CreateTorso();
                CreateFeet();
                CreateWings();
            }

            var arm = CreateFlippableAnimation(() => BodyColor, RIGHT_ARM_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Arm);
            var arm_attack = CreateFlippableAnimation(() => BodyColor, RIGHT_ARM_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Arm_attack, false, false);

            AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(
                        arm
                        , () => !AttackingWithTheHand
                    )
                    , new AnimationTransitionOnCondition(
                        arm_attack
                        , () => AttackingWithTheHand
                    )
                )
            );
            AddAnimation(CreateFlippableAnimation(() => BodyColor, LEFT_ARM_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Arm, true));


        }

        private void CreateWings()
        {
            AddAnimation(CreateFlippableAnimation2(() => BodyColor, RIGHT_WING_Z, GeneratedContent.Create_knight_Ice_Wing, 2000, 600, -1200, -1500, () => facingRight));
            AddAnimation(CreateFlippableAnimation2(() => BodyColor, LEFT_WING_Z, GeneratedContent.Create_knight_Ice_Wing, 2000, 600, -1200, -1500, () => !facingRight));
        }

        private void CreateTorso()
        {
            var type = MyRandom.Next(1, 4);
            if (type == 1)
                AddAnimation(CreateFlippableAnimation(() => BodyColor, TORSO_Z, GeneratedContent.Create_knight_Torso_Wolf_Front));
            else if (type == 2)
                AddAnimation(CreateFlippableAnimation(() => BodyColor, TORSO_Z, GeneratedContent.Create_knight_Torso_Snake_Front));
            else if (type == 3)
                AddAnimation(CreateFlippableAnimation(() => BodyColor, TORSO_Z, GeneratedContent.Create_knight_Torso_Humanoid_Shell_Front));
            else if (type == 4)
                AddAnimation(CreateFlippableAnimation(() => BodyColor, TORSO_Z, GeneratedContent.Create_knight_Torso_Strong_Front));
        }

        private void CreateFeet()
        {
            AddAnimation(CreateFlippableAnimation(() => BodyColor, RIGHT_FEET_Z, GeneratedContent.Create_knight_Torso_Humanoid_turtle_feet));
            AddAnimation(CreateFlippableAnimation(() => BodyColor, LEFT_FEET_Z, GeneratedContent.Create_knight_Torso_Humanoid_turtle_feet, true));
        }

        private Animator CreateFlippableAnimation2(
            Func<Color> green
            , float z
            , Func<int, int, int?, int?, bool, Animation> AutoGeneratedMethod
            , int size
            , int x
            , int y
            , int flippedX
            , Func<bool> FlipCondition
        )
        {
            var wingAnimation = GeneratedContent.Create_knight_Ice_Wing(x, y, size, size);
            wingAnimation.RenderingLayer = z;
            wingAnimation.ColorGetter = green;
            var wingAnimationFlipped = GeneratedContent.Create_knight_Ice_Wing(flippedX, y, size, size, true);
            wingAnimationFlipped.RenderingLayer = z;
            wingAnimationFlipped.ColorGetter = green;

            return new Animator(
                    new AnimationTransitionOnCondition(wingAnimation, () => !FlipCondition())
                     , new AnimationTransitionOnCondition(wingAnimationFlipped, () => FlipCondition())
                );
        }

        private IHandleAnimation CreateFlippableAnimation(
            Func<Color> green
            , float z
            , Func<int, int, int?, int?, bool, Animation> AutoGeneratedMethod
            , bool pair = false
            , bool loop = true
            )
        {
            var size = 1200;

            var x = -size / 2 - size / 3;
            if (pair)
                x += x / 2;

            var flippedx = (-size / 4 + size / 8) - 250;
            if (pair)
                flippedx -= (flippedx) * 2 + 200;

            var y = (-size + size / 10) + 100;
            var width = size * 2;

            var back = AutoGeneratedMethod(
                x
                , y
                , width
                , width
                , false);
            back.LoopDisabled = !loop;
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
            flipped.LoopDisabled = !loop;
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
            Func<Boss, int> CreateFireBall = CreateFileBallActionAndReturnCooldown(Game1, headType);
            Func<int> UseEyeSkill = CreateEyeSkillAndReturnCooldown(Game1, eyeType);

            var stateController = new BossStateController(this, Game1.AddToWorld, CreateFireBall, UseEyeSkill);
            Action ShakeCamera = () => Game1.Camera.ShakeUp(10);
            if (bodyType == 1)
            {
                BossMovementTypes.Wolf(this, stateController);
            }
            else if (bodyType == 2)
            {
                BossMovementTypes.Bird(this, stateController);
            }
        }

        private Func<int> CreateEyeSkillAndReturnCooldown(Game1 Game1, int eyeType)
        {
            if (eyeType == 1)
            {
                return () =>
                {
                    Game1.AddToWorld(new LeafShieldCell(Game1, this));
                    return 70;
                };
            }
            else if (eyeType == 2)
            {
                return () =>
                {
                    Game1.AddToWorld(new BulletStorm(Game1, this));
                    return 70;
                };
            }
            else
            {
                return () =>
                {
                    Game1.AddToWorld(new SpikeBall(Game1, this, GameState.GetColor(), true));
                    Game1.AddToWorld(new SpikeBall(Game1, this, GameState.GetColor(), false));
                    return 70;
                };
            }
        }

        private Func<Boss, int> CreateFileBallActionAndReturnCooldown(Game1 Game1, int headType)
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

                return 40;
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

                return 40;
            };

            return boss =>
            {
                Game1.AddToWorld(
                    new SeekerFireBall(boss, Game1, GameState.GetColor())
                    {
                        X = boss.attackCollider.X,
                        Y = boss.attackCollider.Y
                    });

                return 40;
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