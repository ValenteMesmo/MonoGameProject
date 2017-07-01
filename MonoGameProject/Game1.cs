using GameCore;
using GameCore.Interfaces;
using System.Collections.Generic;
using System;

namespace MonoGameProject
{
    class ContentLoader : ILoadContents
    {
        public IEnumerable<string> GetSoundNames()
        {
            return new string[] {  };
        }

        public IEnumerable<string> GetTextureNames()
        {
            return new string[] {  };
        }
    }

    public class Game1 : Game
    {
        public Game1() : base(new ContentLoader())
        {

        }

        public override void OnStart()
        {
            Add(new Player() {X= 2000, Y=2000, Width = 2000, Height = 2000 });
        }
    }

    class Player : ICauseCollisions
    {
        public bool Disabled { get ; set ; }
        public int HorizontalSpeed { get ; set ; }
        public int VerticalSpeed { get ; set ; }
        public int RenderX { get ; set ; }
        public int RenderY { get ; set ; }
        public int X { get ; set ; }
        public int Y { get ; set ; }
        public int Width { get ; set ; }
        public int Height { get ; set ; }
    }
}
