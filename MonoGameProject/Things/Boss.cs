using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    class BossBodyFactory2
    {
        private readonly Boss boss;
        private int patience;
        private Player player;

        public BossBodyFactory2(Boss boss)
        {
            this.boss = boss;
            boss.state = -1;
            boss.mainCollider.AddCollisionHandler(FindPlayer);

            CreateBodyAnimator(0.43f);

            boss.AddUpdate(UpdateBasedOnState);
        }

        private void FindPlayer(Collider s, Collider t)
        {
            if (s.Parent is Player)
            {
                player = s.Parent as Player;
                boss.state = 0;
            }
            if (t.Parent is Player)
            {
                player = t.Parent as Player;
                boss.state = 0;
            }
        }

        private void UpdateBasedOnState()
        {
            if (boss.state == -1)
                return;

            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (SameHightOfPlayer())
            {
                if (player.MainCollider.Left() > boss.mainCollider.Right())
                    boss.facingRight = true;
                else
                    boss.facingRight = false;
            }

            if (SameHightOfPlayer())
                boss.state = 0;
            else
                boss.state = 1;

            if (boss.state == 0)
            {
                if (SameHightOfPlayer())
                {
                    if (boss.facingRight)
                        boss.HorizontalSpeed = 25 + (boss.damageTaken > 5 ? 25 : 0);
                    else
                        boss.HorizontalSpeed = -25 - (boss.damageTaken > 5 ? 25 : 0);
                }
                else
                {
                    boss.HorizontalSpeed = 0;
                }
            }

            if (boss.state == 0)
                patience = 80 - (boss.damageTaken > 10 ? 30 : 0);
            else
                patience--;

            if (patience <= 0)
            {
                if (boss.MyRandom.Next(0, 100) > 50)
                    boss.VerticalSpeed = -150;
                patience = 80 - (boss.damageTaken > 10 ? 30 : 0);
            }

            boss.attackCollider.Disabled = boss.state != 0;
        }

        private bool SameHightOfPlayer()
        {
            return player != null
                && Math.Abs(
                    player.MainCollider.Bottom()
                    - boss.mainCollider.Bottom()
                ) < MapModule.CELL_SIZE * 2;
        }

        private void CreateBodyAnimator(float z)
        {
            var width = 1500;
            var height = 1500;

            var standing_left = GeneratedContent.Create_knight_wolf_body(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;
            standing_left.ColorGetter = () => boss.BodyColor;

            var standing_right = GeneratedContent.Create_knight_wolf_body(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => boss.BodyColor;

            var jump_left = GeneratedContent.Create_knight_wolf_body_jump(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            jump_left.RenderingLayer = z;
            jump_left.ColorGetter = () => boss.BodyColor;

            var jump_right = GeneratedContent.Create_knight_wolf_body_jump(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            jump_right.RenderingLayer = z;
            jump_right.ColorGetter = () => boss.BodyColor;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !boss.facingRight && boss.grounded)
                    , new AnimationTransitionOnCondition(standing_right, () => boss.facingRight && boss.grounded)
                    , new AnimationTransitionOnCondition(jump_left, () => !boss.facingRight && !boss.grounded)
                    , new AnimationTransitionOnCondition(jump_right, () => boss.facingRight && !boss.grounded)
            );
            boss.AddAnimation(animation);
        }
    }

    class BossBodyFactory
    {
        private readonly Boss boss;

        public BossBodyFactory(Boss boss)
        {
            this.boss = boss;

            boss.mainCollider.AddLeftCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    boss.facingRight = true;
                    boss.state = 1;
                    boss.state1Duration = boss.MyRandom.Next(0, 100) > 50 ? 50 : 10;
                }
            });

            boss.mainCollider.AddRightCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    boss.facingRight = false;
                    boss.state = 1;
                    boss.state1Duration = boss.MyRandom.Next(0, 100) > 50 ? 50 : 10;
                }
            });

            CreateBodyAnimator(0.43f);

            boss.AddUpdate(UpdateBasedOnState);
        }

        private void UpdateBasedOnState()
        {
            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (boss.state == 0)
            {
                if (boss.facingRight)
                    boss.HorizontalSpeed = 100;
                else
                    boss.HorizontalSpeed = -100;
            }
            if (boss.state == 1)
            {
                boss.state1Duration--;
                boss.HorizontalSpeed = 0;
                if (boss.state1Duration <= 0)
                {
                    if (boss.MyRandom.Next(0, 100) > 50)
                        boss.VerticalSpeed = -150;
                    boss.state = 0;
                }
            }

            boss.attackCollider.Disabled = boss.state != 0;
        }

        private void CreateBodyAnimator(float z)
        {
            var width = 1500;
            var height = 1500;

            var standing_left = GeneratedContent.Create_knight_wolf_body(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;
            standing_left.ColorGetter = () => boss.BodyColor;

            var standing_right = GeneratedContent.Create_knight_wolf_body(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => boss.BodyColor;

            var jump_left = GeneratedContent.Create_knight_wolf_body_jump(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            jump_left.RenderingLayer = z;
            jump_left.ColorGetter = () => boss.BodyColor;

            var jump_right = GeneratedContent.Create_knight_wolf_body_jump(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            jump_right.RenderingLayer = z;
            jump_right.ColorGetter = () => boss.BodyColor;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !boss.facingRight && boss.grounded)
                    , new AnimationTransitionOnCondition(standing_right, () => boss.facingRight && boss.grounded)
                    , new AnimationTransitionOnCondition(jump_left, () => !boss.facingRight && !boss.grounded)
                    , new AnimationTransitionOnCondition(jump_right, () => boss.facingRight && !boss.grounded)
            );
            boss.AddAnimation(animation);
        }
    }

    public class Boss : Thing
    {
        public int state = 0;
        public bool facingRight = false;
        public int state1Duration = 0;
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
            if (MyRandom.Next(0, 100) > 50)
            {
                new BossBodyFactory2(this);
            }
            else
            {
                new BossBodyFactory(this);
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
                    new AnimationTransitionOnCondition(standing_left, () => state == 1 && !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () => state == 1 && facingRight)
                    , new AnimationTransitionOnCondition(attack_left, () => state == 0 && !facingRight)
                    , new AnimationTransitionOnCondition(attack_right, () => state == 0 && facingRight)
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
                    new AnimationTransitionOnCondition(standing_left, () => state == 1 && !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () => state == 1 && facingRight)
                    , new AnimationTransitionOnCondition(attack_left, () => state == 0 && !facingRight)
                    , new AnimationTransitionOnCondition(attack_right, () => state == 0 && facingRight)
            );
            AddAnimation(animation);
        }

    }
}