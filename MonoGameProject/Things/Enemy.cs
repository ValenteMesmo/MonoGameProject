using System;
using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class PatrolAiInputs : InputChecker
    {
        int time;

        public PatrolAiInputs()
        {
            time = 0;
            Right = true;
        }

        public bool Left { get; set; }

        public bool Right { get; set; }

        public bool Up { get; set; }

        public bool Down { get; set; }

        public bool Action { get; set; }

        public bool Jump { get; set; }

        public void Update()
        {
            time++;

            if (time >= 100)
            {
                time = 0;
                Jump = true;
                Left = Right;
                Right = !Left;
            }
            else if(time > 20)
                Jump = false;
        }
    }

    public class Enemy : Humanoid
    {
        private const int width = 1000;
        private const int height = 900;

        public Enemy(GameInputs inputs, Game1 WorldMover) : base(inputs, WorldMover)
        {
            X = 2000;
            Y = 7000;
            
            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            new HumanoidAnimatorFactory().CreateAnimator(width, height, this);
        }
    }
}