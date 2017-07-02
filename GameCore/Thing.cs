using System.Collections.Generic;

namespace GameCore.Interfaces
{
    public class Thing
    {
        public int X { get; set; }
        public int Y { get; set; }

        internal List<object> Animations = new List<object>();
        internal List<string> Sounds = new List<string>();
        internal List<Collider> Colliders = new List<Collider>();
        internal List<UpdateHandler> Updates = new List<UpdateHandler>();
        internal List<IHandleTouchInputs> Touchables = new List<IHandleTouchInputs>();

        internal List<IHandleTopCollisions> TopCollisionHandlers = new List<IHandleTopCollisions>();
        internal List<IHandleBotCollisions> BotCollisionHandlers = new List<IHandleBotCollisions>();
        internal List<IHandleLeftCollisions> LeftCollisionHandlers = new List<IHandleLeftCollisions>();
        internal List<IHandleRightCollisions> RightCollisionHandlers = new List<IHandleRightCollisions>();

        public void AddCollider(Collider collider)
        {
            collider.Parent = this;
            Colliders.Add(collider);
        }

        public void AddUpdate(UpdateHandler Update)
        {
            Update.Parent = this;
            Updates.Add(Update);
        }

        public void PlaySound(string name)
        {
            if (Sounds.Contains(name) == false)
                Sounds.Add(name);
        }
    }
}