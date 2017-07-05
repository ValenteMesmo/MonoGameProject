using GameCore;
using System;

public abstract class Game : IDisposable
{
    private readonly BaseGame BaseGame;
    protected Camera2d Camera { get { return BaseGame.Camera; } }
    protected InputRepository InputRepository { get { return BaseGame.World.PlayerInputs; } }
    public bool FullScreen { get { return BaseGame.Graphics.IsFullScreen; } set { BaseGame.Graphics.IsFullScreen = value; } }

    public Game(ILoadContents ContentLoader)
    {
        BaseGame = new BaseGame(ContentLoader, this);
    }

    public abstract void OnStart();

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