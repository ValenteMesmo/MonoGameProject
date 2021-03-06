﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GameCore
{
    public class Animator : IHandleAnimation
    {
        public Color GetColor()
        {
            return CurrentAnimation.GetColor();
        }

        public float RenderingLayer
        {
            get
            {
                return CurrentAnimation.RenderingLayer;
            }
        }

        private readonly AnimationTransition[] Transitions;
        private IHandleAnimation CurrentAnimation;
        public int ScaleX
        {
            get
            {
                return CurrentAnimation.ScaleX;
            }
        }

        public int ScaleY
        {
            get
            {
                return CurrentAnimation.ScaleY;
            }
        }

        public Animator(params AnimationTransition[] Transitions)
        {
            this.Transitions = Transitions;
            CurrentAnimation = Transitions[0].Target;
        }

        public void Update()
        {
            CurrentAnimation.Update();

            foreach (var item in Transitions)
            {
                if (CurrentAnimation != item.Target
                    && item.Condition())
                {
                    CurrentAnimation.Restart();

                    CurrentAnimation = item.Target;

                    //ops!
                    CurrentAnimation.Update();
                    CurrentAnimation.Restart();
                    break;
                }
            }
        }

        public IEnumerable<AnimationFrame> GetCurretFrame()
        {
            return CurrentAnimation.GetCurretFrame();
        }

        public void Restart()
        {
            CurrentAnimation.Restart();
        }
    }
}
