using System;

namespace GameCore
{
    public class AnimationTransitionOnCondition : AnimationTransition
    {
        public IHandleAnimation Target { get; }
        public Func<bool> Condition { get; }

        public AnimationTransitionOnCondition(
            IHandleAnimation Target
            , Func<bool> Condition)
        {
            this.Target = Target;
            this.Condition = Condition;
        }
    }
}
