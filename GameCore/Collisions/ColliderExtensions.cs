using GameCore;
using System;

namespace GameCore
{
    public static class ColliderExtensions
    {
        public static CollisionResult IsColliding(
            this Collider a,
            Collider b)
        {
            if (a.Right() < b.Left()
            || b.Right() < a.Left()
            || a.Bottom() < b.Top()
            || b.Bottom() < a.Top())
                return CollisionResult.Nope;
            else
            {
                var top_b__bot_a__difference = a.Bottom() - a.Top();
                var top_a__bot_b__difference = a.Bottom() - b.Top();
                var right_a__left_b__difference = a.Right() - b.Left();
                var right_b__left_a__difference = b.Right() - a.Left();

                if (top_a__bot_b__difference < top_b__bot_a__difference
                    && top_a__bot_b__difference < right_a__left_b__difference
                    && top_a__bot_b__difference < right_b__left_a__difference)
                {
                    return CollisionResult.Bottom;
                }

                if (top_b__bot_a__difference < top_a__bot_b__difference
                    && top_b__bot_a__difference < right_a__left_b__difference
                    && top_b__bot_a__difference < right_b__left_a__difference)
                {
                    return CollisionResult.Top;
                }

                if (right_a__left_b__difference < right_b__left_a__difference
                    && right_a__left_b__difference < top_a__bot_b__difference
                    && right_a__left_b__difference < top_b__bot_a__difference)
                {
                    return CollisionResult.Right;
                }

                if (right_b__left_a__difference < right_a__left_b__difference
                    && right_b__left_a__difference < top_a__bot_b__difference
                    && right_b__left_a__difference < top_b__bot_a__difference)
                {
                    return CollisionResult.Left;
                }
            }

            return CollisionResult.Nope;
        }

        public static int Left(this Collider a)
        {
            return a.Parent.X + a.OffsetX;
        }

        public static int Right(this Collider a)
        {
            return a.Parent.X + a.OffsetX + a.Width;
        }

        public static int Top(this Collider a)
        {
            return a.Parent.Y + a.OffsetY;
        }

        public static int Bottom(this Collider a)
        {
            return a.Parent.Y + a.OffsetY + a.Height;
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

            a.CollidingWith.Add(b);
            b.CollidingWith.Add(a);
            if (collision == CollisionResult.Left)
            {
                a.LeftCollisionHandlers
                    .ForEach(handler => handler(a, b));

                b.RightCollisionHandlers
                    .ForEach(handler => handler(b, a));
            }
            else if (collision == CollisionResult.Right)
            {
                a.RightCollisionHandlers
                     .ForEach(handler => handler(a, b));

                b.LeftCollisionHandlers
                    .ForEach(handler => handler(b, a));
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

            a.CollidingWith.Add(b);
            b.CollidingWith.Add(a);
            if (collision == CollisionResult.Top)
            {
                a.TopCollisionHandlers
                    .ForEach(handler => handler(a, b));

                b.BotCollisionHandlers
                    .ForEach(handler => handler(b, a));
            }
            else if (collision == CollisionResult.Bottom)
            {
                a.BotCollisionHandlers
                    .ForEach(handler => handler(a, b));

                b.TopCollisionHandlers
                    .ForEach(handler => handler(b, a));
            }
        }
    }
}
