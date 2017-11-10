using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public class VibrationStatus
{
    public int Duration { get; set; }
    public int Origin { get; set; }
}

public class VibrationCenter
{
    public Dictionary<int, VibrationStatus> Vibrations = new Dictionary<int, VibrationStatus>();

    public void Update()
    {
        foreach (var index in Vibrations.Keys)
        {
            var vibration_duration = Vibrations[index].Duration;
            var vibration_original = Vibrations[index].Origin;

            if (vibration_duration > 0)
            {
                vibration_duration--;
                GamePad.SetVibration(
                    index
                    , vibration_duration / vibration_original
                    , vibration_duration);
            }

            Vibrations[index].Duration--;
            Vibrations[index].Origin--;
        }
    }

    public void Vibrate(GameInputs inputs, int duration)
    {
        if (Vibrations.ContainsKey(inputs.ControllerIndex))
        {
            Vibrations.Remove(inputs.ControllerIndex);
        }

        Vibrations.Add(
           inputs.ControllerIndex, new VibrationStatus
           {
               Duration = duration,
               Origin = duration
           });
    }
}

public abstract class Game : IDisposable
{
    public VibrationCenter VibrationCenter { get { return BaseGame.VibrationCenter; } }

#if DEBUG
    public static string LOG = "NO logs";
#endif
    public FrameCounter FrameCounter = new FrameCounter();
    public readonly BaseGame BaseGame;
    public Camera2d Camera { get { return BaseGame.Camera; } } 
    public void Sleep() { BaseGame.World.Sleep(); }

    public MusicController MusicController { get { return BaseGame.MusicController; } }

    public Game(ILoadContents ContentLoader, bool RuningOnAndroid)
    {
        BaseGame = new BaseGame(ContentLoader, this, RuningOnAndroid);
        BaseGame.Graphics.IsFullScreen = true;
    }

    public void AddToWorld(Thing thing)
    {
        BaseGame.World.Add(thing);
    }

    public void Start()
    {
        OnStart();
    }

    protected abstract void OnStart();

    public T GetService<T>()
    {
        return (T)BaseGame.Services.GetService(typeof(T));
    }

    public Action<long> AndroidVibrate = f => { };
    private readonly bool RuningOnAndroid;

    protected void AddThing(Thing thing)
    {
        BaseGame.World.Add(thing);
    }

    protected void RemoveThing(Thing thing)
    {
        BaseGame.World.Remove(thing);
    }

    public void Run()
    {
        BaseGame.Run();
    }

    public void Restart()
    {
        BaseGame.World.Clear();
        OnStart();
    }

    public void Dispose()
    {
        BaseGame.Dispose();
    }
}