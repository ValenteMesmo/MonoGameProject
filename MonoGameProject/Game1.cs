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
            return new string[] { };
        }

        public IEnumerable<string> GetTextureNames()
        {
            return new string[] { };
        }
    }

    public class MoveLeftAndRight : UpdateHandler
    {
        private int speed = 5;

        public override void Update()
        {
            if (Parent.X > 6000)
                speed = -5;
            if(Parent.X < 2000)
                speed = 5;

            Parent.X += speed;
        }
    }

    public class Game1 : Game
    {
        public Game1() : base(new ContentLoader())
        {

        }

        public override void OnStart()
        {
            var player = new Thing();
            player.AddCollider(new Collider() {
                X = 4000
                , Y = 4000
                , Width = 4000
                , Height = 4000 });
            player.AddUpdate(new MoveLeftAndRight());


            AddThing(player);
        }
    }
}
