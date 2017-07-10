using System;

namespace GameCore
{
    public interface AnimationTransition
    {
        Animation Target { get; }
        Func<bool> Condition { get; }
        Action AfterTransition { get; }
    }
}
