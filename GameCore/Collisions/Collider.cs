namespace GameCore
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
}
