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

        public Boss()
        {
            var width = 1500;
            var height = 1500;

            var attackCollider = new AttackCollider
            {
                Height = 1500,
                Width = 500,
                OffsetX = -500,
                Disabled = false
            };
            AddCollider(attackCollider);

            var mainCollider = new Collider(width, height);

            //var velocity = 100;
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
                    damageTaken++;

                    if (damageTaken < 5)
                        return;

                    Destroy();
                    GameState.BossMode = false;
                }
            });

            AddCollider(mainCollider);

            asdsasd(GeneratedContent.Create_knight_wolf_body, 0.42f);
            asdsasd(GeneratedContent.Create_knight_wolf_head, 0.41f);
            asdsasd(GeneratedContent.Create_knight_wolf_eye, 0.4f, Color.Red);

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            //AddUpdate(() => HorizontalSpeed = velocity);
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
            });
        }
        private void asdsasd(Func<int, int, int?, int?, bool, Animation> createAnimation, float z, Color? color = null)
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
                standing_left.ColorGetter = () => damageCooldown > 0 ? Color.Red : GameState.GetComplimentColor();

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
                standing_right.ColorGetter = () => damageCooldown > 0 ? Color.Red : GameState.GetComplimentColor();

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () => facingRight)
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
                    VerticalSpeed = -150;
                    state = 0;
                }
            }
        }

        public override void OnDestroy()
        {
            GameState.BossMode = false;
        }
    }

    public class Enemy : Humanoid
    {
        private const int width = 1000;
        private const int height = 900;

        public Enemy(Game1 WorldMover, Action<Thing> AddToWorld) : base(
            new GameInputs(
                new InputCheckerAggregation(
                        //new MirroredKeyboardChecker()
                        new PatrolAiInputs()
                    )
                ), WorldMover.Camera)
        {
            AddUpdate(new TakesDamage(this, WorldMover, AddToWorld));

            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            new HumanoidAnimatorFactory().CreateAnimator(this);
        }
    }
}