using System;

namespace GameCore
{
    public abstract class IHandleTouchInputs : IHaveDimensions
    {
        public Thing Parent { get; internal set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void TouchEnded();
        public abstract void TouchBegin();
        public abstract void TouchContinue();
    }
}
