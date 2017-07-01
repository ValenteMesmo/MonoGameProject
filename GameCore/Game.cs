using GameCore;
using GameCore.Interfaces;
using System;

public abstract class Game : IDisposable
{
    private readonly BaseGame BaseGame;

    public Game(ILoadContents ContentLoader)
    {
        BaseGame = new BaseGame(ContentLoader, this);
    }

    public abstract void OnStart();

    protected void Add(Something Something)
    {
        BaseGame.World.Add(Something);
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