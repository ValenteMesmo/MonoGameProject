using GameCore;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public static class StopsWhenHitting
    {
        public const int KNOCKBACK = 1;
        //TODO: moveback if your speed is highier
        public static Action<Collider, Collider> Top<T>()
        {
            return TopHandler<T>;
        }

        private static void TopHandler<T>(Collider Parent, Collider other)
        {
            if (other is T)
            {
                //Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Bottom() - Parent.OffsetY + KNOCKBACK;
            }
        }

        public static Action<Collider, Collider> Bot<T>()
        {
            return BotHandler<T>;
        }

        private static void BotHandler<T>(Collider Parent, Collider other)
        {
            if (other is T)
            {
                Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Top() - Parent.Height - Parent.OffsetY - KNOCKBACK;
            }
        }

        public static Action<Collider, Collider> Left<T>()
        {
            return LeftHandler<T>;
        }

        private static void LeftHandler<T>(Collider Parent, Collider other)
        {
            if (other is T)
            {
                Parent.Parent.HorizontalSpeed = 0;
                //other.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Right() - Parent.OffsetX + KNOCKBACK;
            }
        }

        public static Action<Collider, Collider> Right<T>()
        {
            return RightHandler<T>;
        }

        public static void RightHandler<T>(Collider Parent, Collider other)
        {
            if (other is T)
            {
                Parent.Parent.HorizontalSpeed = 0;
                //other.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Left() - Parent.Width - Parent.OffsetX - KNOCKBACK;
            }
        }
    }
}