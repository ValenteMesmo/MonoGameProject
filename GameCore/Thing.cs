using System;
using System.Collections.Generic;

namespace GameCore
{
    public class Thing
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int VerticalSpeed;
        public int HorizontalSpeed;

        internal List<IHandleAnimation> Animations = new List<IHandleAnimation>();
        internal List<string> Sounds = new List<string>();
        internal List<Collider> Colliders = new List<Collider>();
        internal List<Action<Thing>> Updates = new List<Action<Thing>>();
        internal List<IHandleTouchInputs> Touchables = new List<IHandleTouchInputs>();

        public void AddTouchHandler(IHandleTouchInputs touchHandler)
        {
            touchHandler.Parent = this;
            Touchables.Add(touchHandler);
        }

        public void AddCollider(Collider collider)
        {
            collider.Parent = this;
            Colliders.Add(collider);
        }

        public void AddUpdate(Action<Thing> Update)
        {
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

        internal Action<Thing> OnDestroy = t => { };

        public void Destroy()
        {
            OnDestroy(this);
        }
    }
}