using GameCore.Interfaces;
using System;

namespace GameCore
{
    //TODO:
    public enum CollisionResult
    {
        Nope
       , Left
       , Right
       , Top
       , Bottom
    }

    //TODO: rename
    public static class IColliderExtensions
    {
        public static CollisionResult IsColliding(this ICauseCollisions A, ICauseCollisions B)
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

        public static int Left(this SomethingWithPosition a)
        {
            return a.X;
        }

        public static int Right(this SomethingWithPosition a)
        {
            return a.X + a.Width;
        }

        public static int Top(this SomethingWithPosition a)
        {
            return a.Y;
        }

        public static int Bottom(this SomethingWithPosition a)
        {
            return a.Y + a.Height;
        }

        public static float CenterX(this SomethingWithPosition collider)
        {
            return (collider.Left() + collider.Right()) * 0.5f;
        }

        public static float CenterY(this SomethingWithPosition collider)
        {
            return (collider.Top() + collider.Bottom()) * 0.5f;
        }

        public static void MoveHorizontally(this ICauseCollisions a)
        {
            a.X += a.HorizontalSpeed;
        }

        public static void MoveVertically(this ICauseCollisions a)
        {
            a.Y += a.VerticalSpeed;
        }

        public static void HandleHorizontalCollision(
            this ICauseCollisions a
            , ICauseCollisions b)
        {
            if (a.Disabled || b.Disabled)
                return;

            var collision = a.IsColliding(b);

            if (collision == CollisionResult.Nope)
                return;

            if (collision == CollisionResult.Left)
            {
                if (a is IHandleCollisions)
                    (a as IHandleCollisions).LeftCollision(b);

                if (b is IHandleCollisions)
                    (b as IHandleCollisions).RightCollision(a);
            }
            else if (collision == CollisionResult.Right)
            {
                if (a is IHandleCollisions)
                    (a as IHandleCollisions).RightCollision(b);

                if (b is IHandleCollisions)
                    (b as IHandleCollisions).LeftCollision(a);
            }
        }

        public static void HandleVerticalCollision(
            this ICauseCollisions a
            , ICauseCollisions b)
        {
            if (a.Disabled || b.Disabled)
                return;

            var collision = a.IsColliding(b);

            if (collision == CollisionResult.Nope)
                return;

            if (collision == CollisionResult.Top)
            {
                if (a is IHandleCollisions)
                    (a as IHandleCollisions).TopCollision(b);

                if (b is IHandleCollisions)
                    (b as IHandleCollisions).BotCollision(a);
            }
            else if (collision == CollisionResult.Bottom)
            {
                if (a is IHandleCollisions)
                    (a as IHandleCollisions).BotCollision(b);

                if (b is IHandleCollisions)
                    (b as IHandleCollisions).TopCollision(a);
            }
        }
    }
}
