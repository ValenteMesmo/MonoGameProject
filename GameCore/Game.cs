using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public class VibrationInfo
{
    public int Duration { get; set; }
    public float PowerPercentage { get; set; }
}

public class VibrationCenter
{
    public Dictionary<GameInputs, VibrationInfo> Vibrations = new Dictionary<GameInputs, VibrationInfo>();

    public void Update()
    {
        foreach (var index in Vibrations.Keys)
        {
            var vibration_duration = Vibrations[index].Duration;
            var vibration_power = Vibrations[index].PowerPercentage;

            if (vibration_duration > 0)
            {
                vibration_duration--;
                index.Vibrate(Vibrations[index]);
            }

            Vibrations[index].Duration--;
        }
    }

    public void Vibrate(GameInputs inputs, int duration, float powerPercentage)
    {
        if (powerPercentage > 1f)
            powerPercentage = 1f;
        if (powerPercentage < 0)
            powerPercentage = 0;

        if (Vibrations.ContainsKey(inputs))
        {
            Vibrations.Remove(inputs);
        }

        Vibrations.Add(
           inputs, new VibrationInfo
           {
               Duration = duration,
               PowerPercentage = powerPercentage
           });
    }
}

public abstract class Game : IDisposable
{
    public VibrationCenter VibrationCenter { get { return BaseGame.VibrationCenter; } }

    public static string LOG = "NO logs";
    public FrameCounter FrameCounter = new FrameCounter();
    public readonly BaseGame BaseGame;
    public Camera2d Camera { get { return BaseGame.Camera; } }
    public void Sleep() { BaseGame.World.Sleep(); }

    public MusicController MusicController { get { return BaseGame.MusicController; } }

    public Game(ILoadContents ContentLoader)
    {
        BaseGame = new BaseGame(ContentLoader, this);
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

    public Action<int> AndroidVibrate = f => { };

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