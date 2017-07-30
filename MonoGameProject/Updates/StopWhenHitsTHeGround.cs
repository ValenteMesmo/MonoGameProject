using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public static class StopsWhenHitting
    {
        private const int KNOCKBACK = 10;

        public static void Top(Collider Parent, Collider other)
        {
            if (other is IBlockPlayerMovement)
            {
                //Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Bottom() - Parent.OffsetY + KNOCKBACK;
            }
        }

        public static void Bot(Collider Parent, Collider other)
        {
            if (other is IBlockPlayerMovement)
            {
                Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Top() - Parent.Height - Parent.OffsetY - KNOCKBACK;
            }
        }

        public static void Left(Collider Parent, Collider other)
        {
            if (other is IBlockPlayerMovement)
            {
                Parent.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Right() - Parent.OffsetX + KNOCKBACK;
            }
        }

        public static void Right(Collider Parent, Collider other)
        {
            if (other is IBlockPlayerMovement)
            {
                Parent.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Left() - Parent.Width - Parent.OffsetX - KNOCKBACK;
            }
        }
    }
}