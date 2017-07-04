using System;

namespace GameCore
{
    public abstract class IHandleTouchInputs : Collider
    {
        public abstract void TouchEnded();
        public abstract void TouchBegin();
        public abstract void TouchContinue();
    }
}
