namespace GameCore.Interfaces
{
    public interface IHandleTouchInputs : IHaveDimensions
    {
        void TouchEnded();
        void TouchBegin();
        void TouchContinue();
    }
}
