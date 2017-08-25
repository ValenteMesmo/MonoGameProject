using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class Boss : Thing
    {
        private int state = 0;
        private bool facingRight = false;
        private int state1Duration = 0;
        private int damageTaken = 0;
        private int damageCooldown = 0;
        private bool grounded;
        private MyRandom MyRandom = new MyRandom()
        {
            Seed = GameState.PlatformRandomModule.Next()
        };
        private Color BodyColor
        {
            get
            {
                //if (damageCooldown > 0)
                //    return Color.Red;
                //else
                    return _actualBodyColor;
            }
            set
            {
                _actualBodyColor = value;
            }
        }
        private Color _actualBodyColor;


        public Boss(Game1 Game1, Action<Thing> AddToWorld)
        {
            var width = 1500;
            var height = 1500;

            BodyColor = GameState.GetComplimentColor();

            var groundDetector = new CollisionChecker();
            groundDetector.Width = width / 2;
            groundDetector.Height = height / 10;
            groundDetector.OffsetY = height;

            AddCollider(groundDetector);

            var attackCollider = new AttackCollider
            {
                Height = height / 2,
                Width = 500,
                OffsetX = -500,
                OffsetY = 500,
                Disabled = false
            };
            AddCollider(attackCollider);

            var mainCollider = new Collider(width, height);

            mainCollider.AddLeftCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    facingRight = true;
                    state = 1;
                    state1Duration = 50;
                }
            });
            mainCollider.AddRightCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    facingRight = false;
                    state = 1;
                    state1Duration = 50;
                }
            });

            mainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            mainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            mainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            mainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            mainCollider.AddCollisionHandler((s, t) =>
            {
                if (t is AttackCollider
                && t.Parent is Player
                )
                {
                    if (damageCooldown > 0)
                        return;

                    damageCooldown = 20;
                    _actualBodyColor = Color.Lerp(_actualBodyColor, Color.Red, 0.05f);
                    damageTaken++;
                    Game1.Sleep();
                    Game1.Camera.ShakeUp(20);

                    var player = t.Parent as Player;
                    if (player.FacingRight)
                        AddToWorld(new HitEffect() { X = player.AttackRightCollider.X, Y = player.AttackRightCollider.Y , Color = _actualBodyColor });
                    else
                        AddToWorld(new HitEffect() { X = player.AttackLeftCollider.X, Y = player.AttackLeftCollider.Y, Color = _actualBodyColor });

                    if (damageTaken < 20)
                        return;

                    GameState.Save();
                    Destroy();
                    GameState.BossMode = false;
                }
            });

            AddCollider(mainCollider);

            CreateBodyAnimator(0.42f);
            CreateHeadAnimator(0.41f);
            CreateAnimator(GeneratedContent.Create_knight_wolf_eye, 0.4f, Color.Red);

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(UpdateBasedOnState);
            AddUpdate(() =>
            {
                if (facingRight)
                    attackCollider.OffsetX = mainCollider.Width;
                else
                    attackCollider.OffsetX = -attackCollider.Width;
            });
            AddUpdate(() =>
            {
                attackCollider.Disabled = state != 0;
                grounded = groundDetector.Colliding<BlockVerticalMovement>();
            });
        }
        private void CreateAnimator(Func<int, int, int?, int?, bool, Animation> createAnimation, float z, Color? color = null)
        {
            var width = 1500;
            var height = 1500;

            var standing_left = createAnimation(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;
            if (color != null)
                standing_left.ColorGetter = () => color.Value;
            else
                standing_left.ColorGetter = () => BodyColor;

            var standing_right = createAnimation(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            if (color != null)
                standing_right.ColorGetter = () => color.Value;
            else
                standing_right.ColorGetter = () => BodyColor;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () => facingRight)
            );
            AddAnimation(animation);
        }
        private void CreateHeadAnimator(float z)
        {
            var width = 1500;
            var height = 1500;

            var standing_left = GeneratedContent.Create_knight_wolf_head(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;

            standing_left.ColorGetter = () => BodyColor;

            var standing_right = GeneratedContent.Create_knight_wolf_head(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => BodyColor;



            var attack_left = GeneratedContent.Create_knight_wolf_head_attack(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            attack_left.RenderingLayer = z;

            attack_left.ColorGetter = () => BodyColor;

            var attack_right = GeneratedContent.Create_knight_wolf_head_attack(
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
            standing_left.ColorGetter = () => BodyColor;

            var standing_right = GeneratedContent.Create_knight_wolf_body(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => BodyColor;

            var jump_left = GeneratedContent.Create_knight_wolf_body_jump(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            jump_left.RenderingLayer = z;
            jump_left.ColorGetter = () => BodyColor;

            var jump_right = GeneratedContent.Create_knight_wolf_body_jump(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            jump_right.RenderingLayer = z;
            jump_right.ColorGetter = () => BodyColor;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !facingRight && grounded)
                    , new AnimationTransitionOnCondition(standing_right, () => facingRight && grounded)
                    , new AnimationTransitionOnCondition(jump_left, () => !facingRight && !grounded)
                    , new AnimationTransitionOnCondition(jump_right, () => facingRight && !grounded)
            );
            AddAnimation(animation);
        }

        private void UpdateBasedOnState()
        {
            if (damageCooldown >= 0)
                damageCooldown--;

            if (state == 0)
            {
                if (facingRight)
                    HorizontalSpeed = 100;
                else
                    HorizontalSpeed = -100;
            }
            if (state == 1)
            {
                state1Duration--;
                HorizontalSpeed = 0;
                if (state1Duration <= 0)
                {
                    if (MyRandom.Next(0, 100) > 50)
                        VerticalSpeed = -150;
                    state = 0;
                }
            }
        }

    }
}