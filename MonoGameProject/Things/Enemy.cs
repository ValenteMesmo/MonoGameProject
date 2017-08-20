using GameCore;
using System;

namespace MonoGameProject
{
    public class Boss : Thing
    {
        public Boss()
        {
            var width = 2000;
            var height = 2000;

            var collider = new Collider(width, height);
            collider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            collider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            collider.AddRightCollisionHandler(StopsWhenHitting.Right);
            collider.AddTopCollisionHandler(StopsWhenHitting.Top);

            collider.AddCollisionHandler((s,t)=> {
                if (t is AttackCollider
                && t.Parent is Player)
                {
                    Destroy();
                    GameState.BossMode = false;
                }
            });
            AddCollider(collider);

            var animation = GeneratedContent.Create_knight_block(0, 0, width, height);
            animation.ColorGetter = GameState.GetColor;
            AddAnimation(animation);

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
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