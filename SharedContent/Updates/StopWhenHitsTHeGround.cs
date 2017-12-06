using GameCore;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public static class StopsWhenHitting
    {
        public const int KNOCKBACK = 1;
        //TODO: moveback if your speed is highier
        public static Action<BaseRectangle, BaseRectangle> Top<T>()
        {
            return TopHandler<T>;
        }

        private static void TopHandler<T>(BaseRectangle Parent, BaseRectangle other)
        {
            if (other is T)
            {
                //Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Bottom() - Parent.OffsetY + KNOCKBACK;
            }
        }

        public static Action<BaseRectangle, BaseRectangle> Bot<T>()
        {
            return BotHandler<T>;
        }

        private static void BotHandler<T>(BaseRectangle Parent, BaseRectangle other)
        {
            if (other is T)
            {
                Parent.Parent.VerticalSpeed = other.Parent.VerticalSpeed ;

                Parent.Parent.Y = other.Top() - Parent.Height - Parent.OffsetY - KNOCKBACK;

                Parent.Parent.X += other.Parent.HorizontalSpeed;
            }
        }

        public static Action<BaseRectangle, BaseRectangle> Left<T>()
        {
            return LeftHandler<T>;
        }

        private static void LeftHandler<T>(BaseRectangle Parent, BaseRectangle other)
        {
            if (other is T)
            {
                Parent.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Right() - Parent.OffsetX + KNOCKBACK;
            }
        }

        public static Action<BaseRectangle, BaseRectangle> Right<T>()
        {
            return RightHandler<T>;
        }

        public static void RightHandler<T>(BaseRectangle Parent, BaseRectangle other)
        {
            if (other is T)
            {
                Parent.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Left() - Parent.Width - Parent.OffsetX - KNOCKBACK;
            }
        }
    }
}