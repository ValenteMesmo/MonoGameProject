namespace GameCore
{
    public interface IHandleTouchInputs : IHaveDimensions
    {
        void TouchEnded();
        void TouchBegin();
        void TouchContinue();
    }
}
