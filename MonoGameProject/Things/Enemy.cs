using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class Enemy : Humanoid
    {
        private const int width = 1000;
        private const int height = 900;

        public Enemy(AIInput inputs, Game1 WorldMover) : base(inputs, WorldMover)
        {
            X = 2000;
            Y = 7000;

            var time = 0;
            inputs.RightDown = true;
            AddUpdate(() =>
            {
                time++;

                if (time >= 50)
                {
                    time = 0;
                    inputs.JumpDown = true;
                    inputs.LeftDown = inputs.RightDown;
                    inputs.RightDown = !inputs.LeftDown;
                }
                else
                    inputs.JumpDown = false;
            });

            AddUpdate(inputs);

            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            new HumanoidAnimatorFactory().CreateAnimator(width, height, this);
        }
    }
}