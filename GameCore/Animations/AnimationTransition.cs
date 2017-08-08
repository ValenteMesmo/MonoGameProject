using System;

namespace GameCore
{
    public interface AnimationTransition
    {
        IHandleAnimation Target { get; }
        Func<bool> Condition { get; }
    }
}
