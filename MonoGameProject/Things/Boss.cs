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
        BodyAttack2,
        HeadAttack1
    }

    public class Boss : Thing
    {
        public BossState state;
        public bool MouthOpen;
        public bool facingRight = false;
        //public int state1Duration = 0;
        public int damageTaken = 0;
        public int damageCooldown = 0;
        public bool grounded;

        public MyRandom MyRandom = new MyRandom()
        {
            Seed = GameState.PlatformRandomModule.Seed
        };

        public Color BodyColor;
        private Game1 Game1;
        private Action<Thing> AddToWorld;
        public readonly AttackCollider attackCollider;
        public readonly Collider mainCollider;
        public readonly CollisionChecker groundDetector;

        public Boss(Game1 Game1, Action<Thing> AddToWorld)
        {
            this.Game1 = Game1;
            this.AddToWorld = AddToWorld;
            var width = 1500;
            var height = 1500;

            BodyColor = GameState.GetComplimentColor();

            groundDetector = new CollisionChecker();
            groundDetector.Width = width / 2;
            groundDetector.Height = height / 10;
            groundDetector.OffsetY = height;

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

            mainCollider = new Collider(width, height);

            mainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            mainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            mainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            mainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            mainCollider.AddCollisionHandler(HandlePlayerAttack);

            AddCollider(mainCollider);

            CreateHeadAnimator(0.42f);
            CreateEyeAnimator(0.41f);

            MyRandom.Next();
            var bodyType = MyRandom.Next(1, 3);
            if (bodyType == 1)
            {
                new SpiderBossBody(this);
            }
            else if (bodyType == 2)
            {
                new WolfBossBody(this);
            }
            else
            {
                new HumanoidBossBody(this);
            }

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(MoveAttackCollider);
            AddUpdate(CheckIfGrounded);
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

            attackCollider.Disabled = !MouthOpen;
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
                    AddToWorld(new HitEffect(0.4f)
                    {
                        X = player.AttackRightCollider.X,
                        Y = player.AttackRightCollider.Y,
                        Color = BodyColor,
                        HorizontalSpeed = HorizontalSpeed,
                        VerticalSpeed = VerticalSpeed
                    });
                else
                    AddToWorld(new HitEffect(0.4f)
                    {
                        X = player.AttackLeftCollider.X,
                        Y = player.AttackLeftCollider.Y,
                        Color = BodyColor,
                        HorizontalSpeed = HorizontalSpeed,
                        VerticalSpeed = VerticalSpeed
                    });

                if (damageTaken < 20)
                    return;

                GameState.Save();
                GameState.State.BossMode = false;
                Destroy();
            }
        }

        private void CreateHeadAnimator(float z)
        {
            var width = 1500;
            var height = 1500;

            var standing_left = BossAnimationsFactory.HeadAnimation(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;

            standing_left.ColorGetter = () => BodyColor;

            var standing_right = BossAnimationsFactory.HeadAnimation(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => BodyColor;

            var attack_left = BossAnimationsFactory.HeadAttackAnimation(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            attack_left.RenderingLayer = z;

            attack_left.ColorGetter = () => BodyColor;

            var attack_right = BossAnimationsFactory.HeadAttackAnimation(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            attack_right.RenderingLayer = z;
            attack_right.ColorGetter = () => BodyColor;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !MouthOpen && !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () => !MouthOpen && facingRight)
                    , new AnimationTransitionOnCondition(attack_left, () => MouthOpen && !facingRight)
                    , new AnimationTransitionOnCondition(attack_right, () => MouthOpen && facingRight)
            );
            AddAnimation(animation);
        }

        private void CreateEyeAnimator(float z)
        {
            var width = 1500;
            var height = 1500;

            var standing_left = BossAnimationsFactory.EyeAnimation(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;


            var standing_right = BossAnimationsFactory.EyeAnimation(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;



            var attack_left = BossAnimationsFactory.EyeAttackAnimation(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            attack_left.RenderingLayer = z;


            var attack_right = BossAnimationsFactory.EyeAttackAnimation(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            attack_right.RenderingLayer = z;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !MouthOpen && !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () => !MouthOpen && facingRight)
                    , new AnimationTransitionOnCondition(attack_left, () => MouthOpen && !facingRight)
                    , new AnimationTransitionOnCondition(attack_right, () => MouthOpen && facingRight)
            );
            AddAnimation(animation);
        }

    }
}