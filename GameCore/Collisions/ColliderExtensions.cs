using GameCore;
using System;

namespace GameCore
{
    public static class ColliderExtensions
    {
        public static CollisionResult IsColliding(this Collider A, Collider B)
        {
            var w = 0.5f * (A.Width + B.Width);
            var h = 0.5f * (A.Height + B.Height);
            var dx = A.CenterX() - B.CenterX();
            var dy = A.CenterY() - B.CenterY();

            if (Math.Abs(dx) <= w && Math.Abs(dy) <= h)
            {
                /* collision! */
                var wy = w * dy;
                var hx = h * dx;

                if (wy > hx)
                {
                    if (wy > -hx)
                    {
                        /* collision at the top */
                        return CollisionResult.Top;
                    }
                    else
                    {
                        /* on the left */
                        return CollisionResult.Right;
                    }
                }
                else if (wy > -hx)
                {
                    /* on the right */
                    return CollisionResult.Left;
                }
                else
                {
                    /* at the bottom */
                    return CollisionResult.Bottom;
                }
            }

            return CollisionResult.Nope;
        }

        public static int Left(this Collider a)
        {
            return a.Parent.X + a.X;
        }

        public static int Right(this Collider a)
        {
            return a.Parent.X + a.X + a.Width;
        }

        public static int Top(this Collider a)
        {
            return a.Parent.Y + a.Y;
        }

        public static int Bottom(this Collider a)
        {
            return a.Parent.Y + a.Y + a.Height;
        }

        public static float CenterX(this Collider collider)
        {
            return (collider.Left() + collider.Right()) * 0.5f;
        }

        public static float CenterY(this Collider collider)
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

            var collision = a.IsColliding(b);

            if (collision == CollisionResult.Nope)
                return;

            if (collision == CollisionResult.Left)
            {
                a.LeftCollisionHandlers
                    .ForEach(handler => handler.Handle(b));

                b.RightCollisionHandlers
                    .ForEach(handler => handler.Handle(a));
            }
            else if (collision == CollisionResult.Right)
            {
                a.RightCollisionHandlers
                     .ForEach(handler => handler.Handle(b));

                b.LeftCollisionHandlers
                    .ForEach(handler => handler.Handle(a));
            }
        }

        public static void HandleVerticalCollision(
            this Collider a
            , Collider b)
        {
            if (a.Disabled || b.Disabled)
                return;

            var collision = a.IsColliding(b);

            if (collision == CollisionResult.Nope)
                return;

            if (collision == CollisionResult.Top)
            {
                a.TopCollisionHandlers
                    .ForEach(handler => handler.Handle(b));

                b.BotCollisionHandlers
                    .ForEach(handler => handler.Handle(a));
            }
            else if (collision == CollisionResult.Bottom)
            {
                a.BotCollisionHandlers
                    .ForEach(handler => handler.Handle(b));

                b.TopCollisionHandlers
                    .ForEach(handler => handler.Handle(a));
            }
        }
    }
}
