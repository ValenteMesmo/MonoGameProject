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
        //Color ColorRed { get;  }
        //Color ColorGreen { get;  }
        //Color ColorBlue { get;  }
        //Color ColorYellow { get;  }
        //Color ColorCyan { get;  }
        //Color ColorMagenta { get;  }
        IEnumerable<AnimationFrame> GetCurretFrame();
        void Update();
        void Restart();
    }

    class MusicalAnimation : IHandleAnimation
    {
        public int ScaleX { get; set; }

        public int ScaleY { get; set; }

        public float RenderingLayer { get; set; }

        public Func<Color> ColorGetter = () => Color.White;
        private readonly MusicController MusicController;
        private readonly List<AnimationFrame> Frames;

        public MusicalAnimation(MusicController MusicController, params AnimationFrame[] Frames)
        {
            this.MusicController = MusicController;
            this.Frames = Frames.ToList();
        }

        public Color GetColor()
        {
            return ColorGetter();
        }

        //receber o frameindex do beat pelo ctor
        public IEnumerable<AnimationFrame> GetCurretFrame()
        {
            var index = 0;
            if (Frames.Count > 1)
            {
                int currentBeat = MusicController.beatCell;
                while (currentBeat > 32)
                    currentBeat -= 32;
                index = (currentBeat * (Frames.Count - 1)) / 32;
            }

            if (Frames.Any())
                yield return Frames[index];
        }

        public void Restart()
        {
        }

        public void Update()
        {
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

        public IHandleAnimation AsMusical(MusicController controller)
        {
            return new MusicalAnimation(controller, Frames.ToArray())
            {
                ScaleX = ScaleX,
                ScaleY = ScaleY,
                RenderingLayer = RenderingLayer,
                ColorGetter = ColorGetter
            };
        }

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

        public readonly static Animation Empty = new Animation();
    }
}