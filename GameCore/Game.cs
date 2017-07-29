using GameCore;
using Microsoft.Xna.Framework;
using System;

public abstract class Game : IDisposable
{

#if DEBUG
    public static string LOG = "NO logs";
#endif
    public FrameCounter FrameCounter = new FrameCounter();
    private readonly BaseGame BaseGame;
    public Camera2d Camera { get { return BaseGame.Camera; } }
    protected InputRepository InputRepository { get { return BaseGame.World.PlayerInputs; } }
    protected InputRepository2 InputRepository2 { get { return BaseGame.World.PlayerInputs2; } }
    public bool FullScreen { get { return BaseGame.Graphics.IsFullScreen; } set { BaseGame.Graphics.IsFullScreen = value; } }
    public void Sleep() { BaseGame.World.Sleep(); }

    public Game(ILoadContents ContentLoader)
    {
        BaseGame = new BaseGame(ContentLoader, this);
    }

    public void Start()
    {
        Camera.Pos = new Vector2(7000f, 5500f);
        Camera.Zoom =
             0.1f;
        /*
        0.02f;
         */

        OnStart();
    }

    protected abstract void OnStart();

    public T GetService<T>()
    {
        return (T)BaseGame.Services.GetService(typeof(T));
    }

    public Action<long> AndroidVibrate = f=> {};

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