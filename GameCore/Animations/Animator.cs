using System.Linq;
using Microsoft.Xna.Framework;

namespace GameCore
{
    public class Animator : IHandleAnimation
    {
        private readonly AnimationTransition[] Transitions;
        private Animation CurrentAnimation;

        public Color Color { get ; set ; }

        public Animator(params AnimationTransition[] Transitions)
        {
            Color = Color.White;
            this.Transitions = Transitions;
            CurrentAnimation = Transitions[0].Sources[0];
        }

        public void Update()
        {
            CurrentAnimation.Update();

            foreach (var item in Transitions)
            {
                if (item.Sources.Contains(CurrentAnimation))
                {
                    if (item.Condition())
                    {
                        CurrentAnimation.Restart();

                        CurrentAnimation = item.Target;

                        item.AfterTransition();

                        break;
                    }
                }
            }
        }

        public AnimationFrame GetCurretFrame()
        {
            return CurrentAnimation.GetCurretFrame();
        }
    }
}
