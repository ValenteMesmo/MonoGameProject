﻿using System;
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
        internal List<Action> Updates = new List<Action>();
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

        public void AddUpdate(Action Update)
        {
            Updates.Add(Update);
        }

        public void AddUpdate(UpdateHandler Update)
        {
            Updates.Add(Update.Update);
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