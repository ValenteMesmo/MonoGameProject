using GameCore;
using System;

namespace GameCore
{
    public static class ColliderExtensions
    {
        public static CollisionResult IsCollidingH(
        this Collider a,
        Collider b)
        {
            if (a.Left() <= b.Right()
                && b.Left() <= a.Right()
                && a.Top() <= b.Bottom()
                && b.Top() <= a.Bottom())
            {
                if (a.Right() - b.Right() > 0)
                    return CollisionResult.Left;
                else if (a.Right() - b.Right() < 0)
                    return CollisionResult.Right;
            }

            return CollisionResult.Nope;
        }

        public static CollisionResult IsCollidingV(
        this Collider a,
        Collider b)
        {

            if (a.Left() <= b.Right()
                && b.Left() <= a.Right()
                && a.Top() <= b.Bottom()
                && b.Top() <= a.Bottom())
            {
                if (a.Bottom() - b.Bottom() > 0)
                    return CollisionResult.Top;
                else if (a.Bottom() - b.Bottom() < 0)
                    return CollisionResult.Bottom;
            }

            return CollisionResult.Nope;
        }

        public static int Left(this BaseRectangle a)
        {
            return a.Parent.X + a.OffsetX;
        }

        public static int Right(this BaseRectangle a)
        {
            return a.Parent.X + a.OffsetX + a.Width;
        }

        public static int Top(this BaseRectangle a)
        {
            return a.Parent.Y + a.OffsetY;
        }

        public static int Bottom(this BaseRectangle a)
        {
            return a.Parent.Y + a.OffsetY + a.Height;
        }

        public static float CenterX(this BaseRectangle collider)
        {
            return (collider.Left() + collider.Right()) * 0.5f;
        }

        public static float CenterY(this BaseRectangle collider)
        {
            return (collider.Top() + collider.Bottom()) * 0.5f;
        }

        public static void MoveHorizontally(this Thing a)
        {
            a.X += a.HorizontalSpeed;
        }

        public static void MoveVertically(this Thing a)
        {
            a.Y += a.VerticalSpeed;
        }

        public static void HandleHorizontalCollision(
            this Collider a
            , Collider b)
        {
            if (a.Disabled || b.Disabled)
                return;

            var collision = a.IsCollidingH(b);

            if (collision == CollisionResult.Nope)
                return;

            a.CollidingWith.Add(b);
            b.CollidingWith.Add(a);
            if (collision == CollisionResult.Left)
            {
                a.LeftCollisionHandlers
                    .ForEach(handler => handler(a, b));

                //b.RightCollisionHandlers
                //    .ForEach(handler => handler(b, a));
            }
            else if (collision == CollisionResult.Right)
            {
                a.RightCollisionHandlers
                     .ForEach(handler => handler(a, b));

                //b.LeftCollisionHandlers
                //    .ForEach(handler => handler(b, a));
            }
        }

        public static void HandleVerticalCollision(
            this Collider a
            , Collider b)
        {
            if (a.Disabled || b.Disabled)
                return;

            var collision = a.IsCollidingV(b);

            if (collision == CollisionResult.Nope)
                return;

            a.CollidingWith.Add(b);
            //b.CollidingWith.Add(a);
            if (collision == CollisionResult.Top)
            {
                a.TopCollisionHandlers
                    .ForEach(handler => handler(a, b));

                //b.BotCollisionHandlers
                //    .ForEach(handler => handler(b, a));
            }
            else if (collision == CollisionResult.Bottom)
            {
                a.BotCollisionHandlers
                    .ForEach(handler => handler(a, b));

                //b.TopCollisionHandlers
                //    .ForEach(handler => handler(b, a));
            }
        }
    }
}
