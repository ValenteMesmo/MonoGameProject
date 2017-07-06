using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public static class StopsWhenHitting
    {
        public static void Bot(Collider Parent, Collider other)
        {
            if (other.Parent is IBlockPlayerMovement)
            {
                Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Top() - Parent.Height - 1;
            }
        }

        public static void Left(Collider Parent, Collider other)
        {
            if (other.Parent is IBlockPlayerMovement)
            {
                Parent.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Right() - Parent.OffsetX + 1;
            }
        }

        public static void Right(Collider Parent, Collider other)
        {
            if (other.Parent is IBlockPlayerMovement)
            {
                Parent.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Left() - Parent.Width  - Parent.OffsetX - 1;
            }
        }
    }
}