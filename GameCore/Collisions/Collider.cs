using System;
using System.Collections.Generic;

namespace GameCore
{
    public class Collider
    {
        public Collider()
        {

        }

        public Collider(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public Thing Parent { get; internal set; }

        public int X { get { return Parent.X + OffsetX; } }
        public int Y { get { return Parent.Y + OffsetY; } }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool Disabled { get; set; }

        public List<Collider> CollidingWith = new List<Collider>();

        internal List<Action<Collider, Collider>> TopCollisionHandlers = new List<Action<Collider, Collider>>();
        internal List<Action<Collider, Collider>> BotCollisionHandlers = new List<Action<Collider, Collider>>();
        internal List<Action<Collider, Collider>> LeftCollisionHandlers = new List<Action<Collider, Collider>>();
        internal List<Action<Collider, Collider>> RightCollisionHandlers = new List<Action<Collider, Collider>>();

        public void AddTopCollisionHandler(Action<Collider, Collider> TopCollisionHandler)
        {
            TopCollisionHandlers.Add(TopCollisionHandler);
        }

        public void AddBotCollisionHandler(Action<Collider, Collider> BotCollisionHandler)
        {
            BotCollisionHandlers.Add(BotCollisionHandler);
        }

        public void AddLeftCollisionHandler(Action<Collider, Collider> LeftCollisionHandler)
        {
            LeftCollisionHandlers.Add(LeftCollisionHandler);
        }

        public void AddRightCollisionHandler(Action<Collider, Collider> RightCollisionHandler)
        {
            RightCollisionHandlers.Add(RightCollisionHandler);
        }

        public void AddHandler(Action<Collider, Collider> CollisionHandler)
        {
            TopCollisionHandlers.Add(CollisionHandler);
            LeftCollisionHandlers.Add(CollisionHandler);
            RightCollisionHandlers.Add(CollisionHandler);
            BotCollisionHandlers.Add(CollisionHandler);
        }
    }
}
