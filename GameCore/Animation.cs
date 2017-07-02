using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public class Animation
    {
        private readonly List<AnimationFrame> Frames;
        private int CurrentFrameIndex;
        private int UpdatesUntilNextFrame;
        public bool Ended { get; private set; }
        public Color Color { get; set; }

        public Animation(params AnimationFrame[] Frames)
        {
            Color = Color.White;
            UpdatesUntilNextFrame = 10;
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
            if (CurrentFrameIndex >= Frames.Count)
            {
                Ended = true;
                CurrentFrameIndex = 0;
            }

            UpdatesUntilNextFrame = 10;
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