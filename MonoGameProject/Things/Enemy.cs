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

        public Boss()
        {
            var width = 1500;
            var height = 1500;

            var collider = new Collider(width, height);

            //var velocity = 100;
            collider.AddLeftCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    facingRight = true;
                    state = 1;
                    state1Duration = 50;
                }
            });
            collider.AddRightCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    facingRight = false;
                    state = 1;
                    state1Duration = 50;
                }
            });

            collider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            collider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            collider.AddRightCollisionHandler(StopsWhenHitting.Right);
            collider.AddTopCollisionHandler(StopsWhenHitting.Top);

            collider.AddCollisionHandler((s, t) =>
            {
                if (t is AttackCollider
                && t.Parent is Player
                //&& state == 2
                )
                {
                    Destroy();
                    GameState.BossMode = false;
                }
            });

            AddCollider(collider);

            asdsasd(GeneratedContent.Create_knight_wolf_body, 0.42f);
            asdsasd(GeneratedContent.Create_knight_wolf_head, 0.41f);
            asdsasd(GeneratedContent.Create_knight_wolf_eye, 0.4f, Color.Red);

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            //AddUpdate(() => HorizontalSpeed = velocity);
            AddUpdate(UpdateBasedOnState);

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
                standing_left.ColorGetter = ()=> color.Value;
            else
                standing_left.ColorGetter = GameState.GetComplimentColor;

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
                standing_right.ColorGetter =  GameState.GetComplimentColor;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !facingRight)
                    , new AnimationTransitionOnCondition(standing_right, () => facingRight)
            );
            AddAnimation(animation);
        }


        private void UpdateBasedOnState()
        {
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
            //if (state == 2)
            //{
            //    state1Duration--;
            //    HorizontalSpeed = 0;
            //    if (state1Duration <= 0)
            //        state = 0;
            //}
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