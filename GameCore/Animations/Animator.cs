using Microsoft.Xna.Framework;
using System;

namespace GameCore
{
    public class Animator : IHandleAnimation
    {
        private readonly AnimationTransition[] Transitions;
        private Animation CurrentAnimation;

        public Color Color { get; set; }

        public Animator(params AnimationTransition[] Transitions)
        {
            Color = Color.White;
            this.Transitions = Transitions;
            CurrentAnimation = Transitions[0].Target;
        }

        public void Update()
        {
            CurrentAnimation.Update();

            foreach (var item in Transitions)
            {
                if (CurrentAnimation != item.Target 
                    && item.Condition())
                {
                    CurrentAnimation.Restart();

                    CurrentAnimation = item.Target;

                    break;
                }
            }
        }

        public AnimationFrame GetCurretFrame()
        {
            return CurrentAnimation.GetCurretFrame();
        }
    }
}
