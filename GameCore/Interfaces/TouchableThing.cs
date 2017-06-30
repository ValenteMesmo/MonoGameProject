namespace GameCore.Interfaces
{
    public interface TouchableThing : SomethingWithPosition
    {
        void TouchEnded();
        void TouchBegin();
        void TouchContinue();
    }
}
