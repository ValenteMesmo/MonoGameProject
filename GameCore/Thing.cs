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
        internal List<Collider> Colliders = new List<Collider>();
        internal List<Action> Updates = new List<Action>();
        internal List<Action> AfterUpdates = new List<Action>();
        internal List<TouchAreas> TouchAreas = new List<TouchAreas>();

        public void AddTouchArea(TouchAreas touchHandler)
        {
            touchHandler.Parent = this;
            TouchAreas.Add(touchHandler);
        }

        public void AddCollider(Collider collider)
        {
            collider.Parent = this;
            Colliders.Add(collider);
        }

        public void AddUpdate(Action Update)
        {
            Updates.Add(Update);
        }

        public void AddUpdate(UpdateHandler Update)
        {
            Updates.Add(Update.Update);
        }

        public void AddAfterUpdate(AfterUpdateHandler Update)
        {
            AfterUpdates.Add(Update.Update);
        }

        public void AddAnimation(IHandleAnimation Animation)
        {
            Animations.Add(Animation);
        }

        internal Action<Thing> OnDestroyInternal = t => { };

        public void Destroy()
        {
            OnDestroy();
            OnDestroyInternal(this);
        }

        public virtual void OnDestroy()
        {
        }
    }
}