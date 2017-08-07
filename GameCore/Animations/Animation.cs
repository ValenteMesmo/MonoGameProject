using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public interface IHandleAnimation
    {
        int ScaleX { get; }
        int ScaleY { get; }
        Color ColorRed { get; set; }
        Color ColorGreen { get; set; }
        Color ColorBlue { get; set; }
        Color ColorYellow { get; set; }
        Color ColorCyan { get; set; }
        Color ColorMagenta { get; set; }
        AnimationFrame GetCurretFrame();
        void Update();
    }

    public class Animation : IHandleAnimation
    {
        private readonly List<AnimationFrame> Frames;
        private int CurrentFrameIndex;
        private int UpdatesUntilNextFrame;
        public bool Ended { get; private set; }
        public Color ColorRed { get; set; }
        public Color ColorGreen { get; set; }
        public Color ColorBlue { get; set; }
        public Color ColorYellow { get; set; }
        public Color ColorCyan { get; set; }
        public Color ColorMagenta { get; set; }
        public bool LoopDisabled { get; set; }
        public int ScaleX { get; set; }
        public int ScaleY { get; set; }

        public int FrameDuration = 3;

        public Animation(params AnimationFrame[] Frames)
        {            
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