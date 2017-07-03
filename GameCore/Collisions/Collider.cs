using System.Collections.Generic;

namespace GameCore
{
    public class Collider : IHaveDimensions
    {
        public Thing Parent { get; internal set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool Disabled { get; set; }

        internal List<TopCollisionHandler> TopCollisionHandlers = new List<TopCollisionHandler>();
        internal List<BotCollisionHandler> BotCollisionHandlers = new List<BotCollisionHandler>();
        internal List<LeftCollisionHandler> LeftCollisionHandlers = new List<LeftCollisionHandler>();
        internal List<RightCollisionHandler> RightCollisionHandlers = new List<RightCollisionHandler>();

        public void Add(TopCollisionHandler TopCollisionHandler)
        {
            TopCollisionHandler.Parent = this;
            TopCollisionHandlers.Add(TopCollisionHandler);
        }

        public void Add(BotCollisionHandler BotCollisionHandler)
        {
            BotCollisionHandler.Parent = this;
            BotCollisionHandlers.Add(BotCollisionHandler);
        }

        public void Add(LeftCollisionHandler LeftCollisionHandler)
        {
            LeftCollisionHandler.Parent = this;
            LeftCollisionHandlers.Add(LeftCollisionHandler);
        }

        public void Add(RightCollisionHandler RightCollisionHandler)
        {
            RightCollisionHandler.Parent = this;
            RightCollisionHandlers.Add(RightCollisionHandler);
        }
    }
}
