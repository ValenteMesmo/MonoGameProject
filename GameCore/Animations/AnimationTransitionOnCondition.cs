using System;

namespace GameCore
{
    public class AnimationTransitionOnCondition : AnimationTransition
    {
        public Animation Target { get; }
        public Func<bool> Condition { get; }

        public AnimationTransitionOnCondition(
            Animation Target
            , Func<bool> Condition)
        {
            this.Target = Target;
            this.Condition = Condition;
        }
    }
}
