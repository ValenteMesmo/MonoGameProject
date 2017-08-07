using Microsoft.Xna.Framework;
using System;

namespace GameCore
{
    public class Animator : IHandleAnimation
    {
        private readonly AnimationTransition[] Transitions;
        private Animation CurrentAnimation;
        public int ScaleX
        {
            get
            {
                return CurrentAnimation.ScaleX;
            }
        }

        public int ScaleY {
            get
            {
                return CurrentAnimation.ScaleY;
            }
        }
        public Color ColorRed { get; set; }
        public Color ColorGreen { get; set; }
        public Color ColorBlue { get; set; }
        public Color ColorYellow { get; set; }
        public Color ColorCyan { get; set; }
        public Color ColorMagenta { get; set; }

        public Animator(params AnimationTransition[] Transitions)
        {
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
