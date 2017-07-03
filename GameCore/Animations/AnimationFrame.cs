using Microsoft.Xna.Framework;

namespace GameCore
{
    public class AnimationFrame
    {
        public readonly Rectangle? PositionOnSpriteSheet;
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }
        public float RenderingLayer { get; set; }
        public string Name { get; }
        public bool Flipped { get; set; }

        public AnimationFrame(
            string Name
            , int X
            , int Y
            , int Width
            , int Height
            , Rectangle? PositionOnSpriteSheet = null)
        {
            RenderingLayer = 1;
            this.Name = Name;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.PositionOnSpriteSheet = PositionOnSpriteSheet;
        }
    }
}