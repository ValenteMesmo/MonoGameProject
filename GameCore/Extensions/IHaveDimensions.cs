using GameCore.Interfaces;

namespace GameCore
{
    public interface IHaveDimensions
    {
        Thing Parent { get; }
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }
}
