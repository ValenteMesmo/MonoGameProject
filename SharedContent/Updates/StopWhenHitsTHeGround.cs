using GameCore;
using MonoGameProject.Things;
using SharedContent.Things;
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
                SetBelow(Parent, other);
            }
        }

        public static void SetBelow(BaseRectangle source, BaseRectangle target)
        {
            source.Parent.Y = target.Bottom() - source.OffsetY + KNOCKBACK;
        }

        public static void SetOnTop(BaseRectangle source, BaseRectangle target)
        {
            source.Parent.Y = target.Top() - source.Height - source.OffsetY - KNOCKBACK;
        }
        
        public static void SetOnTheRight(BaseRectangle source, BaseRectangle target)
        {
            source.Parent.X = target.Right() - source.OffsetX + KNOCKBACK;
        }

        public static void SetOnTheLeft(BaseRectangle source, BaseRectangle target)
        {
            source.Parent.X = target.Left() - source.Width - source.OffsetX - KNOCKBACK;
        }

        public static Action<BaseRectangle, BaseRectangle> Bot<T>()
        {
            return BotHandler<T>;
        }

        private static void BotHandler<T>(BaseRectangle Parent, BaseRectangle other)
        {
            if (other is T)
            {
                if (other.Parent.VerticalSpeed > 0)
                    Parent.Parent.VerticalSpeed = other.Parent.VerticalSpeed;
                else
                    Parent.Parent.VerticalSpeed = 0;

                SetOnTop(Parent, other);
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
                var parentVSpeed = Parent.Parent.VerticalSpeed;
                var otherVSpeed = other.Parent.VerticalSpeed;
                if (otherVSpeed != 0 && parentVSpeed > 0)
                {
                    if (otherVSpeed > 0 && parentVSpeed < otherVSpeed)
                        Parent.Parent.VerticalSpeed = otherVSpeed + AfectedByGravity.FORCE;
                }

                var parentHSpeed = Parent.Parent.HorizontalSpeed;
                var otherHSpeed = other.Parent.HorizontalSpeed;
                if (
                    (parentHSpeed > 0 && otherHSpeed > 0)
                    ||
                    (parentHSpeed < 0 && otherHSpeed < 0)
                    )
                    Parent.Parent.HorizontalSpeed = other.Parent.HorizontalSpeed;
                else
                    Parent.Parent.HorizontalSpeed = 0;

                SetOnTheRight(Parent, other);
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
                var parentVSpeed = Parent.Parent.VerticalSpeed;
                var otherVSpeed = other.Parent.VerticalSpeed;
                if (otherVSpeed != 0 && parentVSpeed > 0)
                {
                    if (otherVSpeed > 0 && parentVSpeed < otherVSpeed)
                        Parent.Parent.VerticalSpeed = otherVSpeed + AfectedByGravity.FORCE;
                }

                var parentHSpeed = Parent.Parent.HorizontalSpeed;
                var otherHSpeed = other.Parent.HorizontalSpeed;
                if (
                    (parentHSpeed > 0 && otherHSpeed > 0)
                    ||
                    (parentHSpeed < 0 && otherHSpeed < 0)
                    )
                    Parent.Parent.HorizontalSpeed = other.Parent.HorizontalSpeed;
                else
                    Parent.Parent.HorizontalSpeed = 0;

                SetOnTheLeft(Parent, other);
            }
        }
    }
}