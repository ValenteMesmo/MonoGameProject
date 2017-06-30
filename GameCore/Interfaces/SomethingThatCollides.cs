namespace GameCore.Interfaces
{
    public interface ICauseCollisions : SomethingWithPosition
    {
        bool Disabled { get; set; }
        int HorizontalSpeed { get; set; }
        int VerticalSpeed { get; set; }
        
        int RenderX { get; set; }
        int RenderY { get; set; }
    }

    public interface IHandleCollisions : SomethingWithPosition
    {
        void RightCollision(ICauseCollisions other);
        void LeftCollision(ICauseCollisions other);
        void TopCollision(ICauseCollisions other);
        void BotCollision(ICauseCollisions other);
    }
}
