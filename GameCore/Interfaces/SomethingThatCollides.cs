namespace GameCore.Interfaces
{
    public class Collider : IHaveDimensions
    {
        public Thing Parent { get; internal set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool Disabled { get; set; }

        public int HorizontalSpeed { get; set; }
        public int VerticalSpeed { get; set; }
    }

    public interface IHandleTopCollisions
    {
        void Handle(Collider other);
    }

    public interface IHandleBotCollisions
    {
        void Handle(Collider other);
    }

    public interface IHandleLeftCollisions
    {
        void Handle(Collider other);
    }

    public interface IHandleRightCollisions
    {
        void Handle(Collider other);
    }
}
