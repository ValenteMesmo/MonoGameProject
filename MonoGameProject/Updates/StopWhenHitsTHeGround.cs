using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public static class StopsWhenHitting
    {
        private const int KNOCKBACK = 1;
        //TODO: moveback if your speed is highier
        public static void Top(Collider Parent, Collider other)
        {
            if (other is BlockVerticalMovement)
            {
                //Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Bottom() - Parent.OffsetY + KNOCKBACK;
            }
        }

        public static void Bot(Collider Parent, Collider other)
        {
            if (other is BlockVerticalMovement)
            {
                Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Top() - Parent.Height - Parent.OffsetY - KNOCKBACK;
            }
        }

        public static void Left(Collider Parent, Collider other)
        {
            if (other is BlockHorizontalMovement)
            {
                Parent.Parent.HorizontalSpeed = 0;
                other.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Right() - Parent.OffsetX + KNOCKBACK;
            }
        }

        public static void Right(Collider Parent, Collider other)
        {
            if (other is BlockHorizontalMovement)
            {
                Parent.Parent.HorizontalSpeed = 0;
                other.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Left() - Parent.Width - Parent.OffsetX - KNOCKBACK;
            }
        }
    }
}