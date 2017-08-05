using GameCore;
using System;

namespace MonoGameProject
{
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
            X = 2000;
            Y = 7000;

            AddUpdate(new TakesDamage(this, WorldMover, AddToWorld));

            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            //Action<Collider, Collider> damageHandler = (s, t) =>
            //{
            //    if (t is AttackCollider)
            //    {
            //        Destroy();
            //    }
            //};

            //MainCollider.AddBotCollisionHandler(damageHandler);
            //MainCollider.AddLeftCollisionHandler(damageHandler);
            //MainCollider.AddRightCollisionHandler(damageHandler);
            //MainCollider.AddTopCollisionHandler(damageHandler);

            new HumanoidAnimatorFactory().CreateAnimator(width, height, this);
        }
    }
}