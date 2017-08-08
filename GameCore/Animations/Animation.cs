﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public interface IHandleAnimation
    {
        int ScaleX { get; }
        int ScaleY { get; }
        float RenderingLayer { get; }
        //Color ColorRed { get;  }
        //Color ColorGreen { get;  }
        //Color ColorBlue { get;  }
        //Color ColorYellow { get;  }
        //Color ColorCyan { get;  }
        //Color ColorMagenta { get;  }
        AnimationFrame GetCurretFrame();
        void Update();
        void Restart();
    }

    public class Animation : IHandleAnimation
    {
        public float RenderingLayer { get; set; }
        private readonly List<AnimationFrame> Frames;
        private int CurrentFrameIndex;
        private int UpdatesUntilNextFrame;
        public bool Ended { get; private set; }
        public bool LoopDisabled { get; set; }
        public int ScaleX { get; set; }
        public int ScaleY { get; set; }

        public int FrameDuration = 3;

        public Animation(params AnimationFrame[] Frames)
        {
            RenderingLayer = 0.5f;
            UpdatesUntilNextFrame = FrameDuration;
            this.Frames = Frames.ToList();
        }

        public void Update()
        {
            if (UpdatesUntilNextFrame > 0)
            {
                UpdatesUntilNextFrame--;
                return;
            }

            CurrentFrameIndex++;
            if (CurrentFrameIndex > Frames.Count - 1)
            {
                Ended = true;
                if (LoopDisabled)
                    CurrentFrameIndex = Frames.Count - 1;
                else
                    CurrentFrameIndex = 0;
            }

            UpdatesUntilNextFrame = FrameDuration;
        }

        public AnimationFrame GetCurretFrame()
        {
            return Frames[CurrentFrameIndex];
        }

        public void Restart()
        {
            CurrentFrameIndex = 0;
            Ended = false;
        }
    }
}