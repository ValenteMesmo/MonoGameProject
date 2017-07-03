using System;
using System.Collections.Generic;

namespace GameCore
{
    public class Thing
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        internal List<int> VerticalForces = new List<int>();
        internal List<int> HorizontalForces = new List<int>();

        internal List<IHandleAnimation> Animations = new List<IHandleAnimation>();
        internal List<string> Sounds = new List<string>();
        internal List<Collider> Colliders = new List<Collider>();
        internal List<UpdateHandler> Updates = new List<UpdateHandler>();
        internal List<IHandleTouchInputs> Touchables = new List<IHandleTouchInputs>();

        public void AddVerticalForce(int value)
        {
            VerticalForces.Add(value);
        }

        public void AddHorizontalForce(int value)
        {
            HorizontalForces.Add(value);
        }

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

        public void AddAnimation(IHandleAnimation Animation)
        {
            Animations.Add(Animation);
        }

        public void PlaySound(string name)
        {
            if (Sounds.Contains(name) == false)
                Sounds.Add(name);
        }
    }
}