﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public interface IHandleAnimation
    {
        Color Color { get; set; }
        AnimationFrame GetCurretFrame();
        void Update();
    }

    public class Animation : IHandleAnimation
    {
        private readonly List<AnimationFrame> Frames;
        private int CurrentFrameIndex;
        private int UpdatesUntilNextFrame;
        public bool Ended { get; private set; }
        public Color Color { get; set; }
        public bool LoopDisabled { get; set; }

        private const int ANIMATION_DURATION = 3;

        public Animation(params AnimationFrame[] Frames)
        {
            Color = Color.White;
            UpdatesUntilNextFrame = ANIMATION_DURATION;
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

            UpdatesUntilNextFrame = ANIMATION_DURATION;
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