using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public interface IHandleAnimation
    {
        int ScaleX { get; }
        int ScaleY { get; }
        float RenderingLayer { get; }
        Color GetColor();
        IEnumerable<AnimationFrame> GetCurretFrame();
        void Update();
        void Restart();
    }

    public class AnimationAutoRewindable : IHandleAnimation
    {
        private readonly List<AnimationFrame> Frames;
        public AnimationAutoRewindable(params AnimationFrame[] Frames)
        {
            RenderingLayer = 0.5f;
            UpdatesUntilNextFrame = FrameDuration;
            this.Frames = Frames.ToList();
        }

        public int FrameDuration = 1;
        int UpdatesUntilNextFrame = 3;
        int CurrentFrameIndex;

        public int ScaleX { get;  set; }

        public int ScaleY { get;  set; }

        public float RenderingLayer { get; set; }

        public Func<Color> ColorGetter = () => Color.White;
        public Color GetColor()
        {
            return ColorGetter();
        }

        public IEnumerable<AnimationFrame> GetCurretFrame()
        {
            if (Frames.Any())
                yield return Frames[CurrentFrameIndex];
        }

        public void Restart()
        {
            rewinding = !rewinding;
        }

        bool rewinding = false;

        public void Update()
        {
            if (UpdatesUntilNextFrame > 0)
            {
                UpdatesUntilNextFrame--;
                return;
            }

            if (rewinding == false)
            {
                CurrentFrameIndex++;
                if (CurrentFrameIndex > Frames.Count - 1)
                {
                    CurrentFrameIndex = Frames.Count - 1;
                    //rewinding = true;
                }
            }

            if (rewinding)
            {
                CurrentFrameIndex--;
                if (CurrentFrameIndex < 0)
                {
                    CurrentFrameIndex = 0;
                }
            }

            UpdatesUntilNextFrame = FrameDuration;
        }
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
        public Func<Color> ColorGetter = () => Color.White;

        public int StartingFrame
        {
            get
            {
                return _startingFrame;
            }
            set
            {
                if (value < Frames.Count)
                    _startingFrame = CurrentFrameIndex = value;
            }
        }
        public int _startingFrame;
        public int FrameDuration = 3;

        public Animation(params AnimationFrame[] Frames)
        {
            RenderingLayer = 0.5f;
            UpdatesUntilNextFrame = FrameDuration;
            this.Frames = Frames.ToList();
        }

        public Color GetColor()
        {
            return ColorGetter();
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

        public IEnumerable<AnimationFrame> GetCurretFrame()
        {
            if (Frames.Any())
                yield return Frames[CurrentFrameIndex];
        }

        public void AddReverseFrames()
        {
            var toAdd = new List<AnimationFrame>();
            for (int i = Frames.Count - 2; i > 0; i--)
            {
                toAdd.Add(Frames[i]);
            }

            Frames.AddRange(toAdd);
        }

        public void Restart()
        {
            CurrentFrameIndex = StartingFrame;
            Ended = false;
        }

        public IHandleAnimation HideWhen(Func<bool> Condition)
        {
            return new Animator(
              new AnimationTransitionOnCondition(this, () => !Condition())
              , new AnimationTransitionOnCondition(Empty, Condition)
            );
        }

        public AnimationAutoRewindable AsAutoRewindable()
        {
            return new AnimationAutoRewindable(Frames.ToArray())
            {
                ColorGetter = ColorGetter,
                RenderingLayer = RenderingLayer,
                FrameDuration = FrameDuration,
                ScaleX = ScaleX,
                ScaleY = ScaleY
            };
        }

        public readonly static Animation Empty = new Animation();
    }
}