using GameCore;
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
            return new string[] { "a", "b", "c" };
        }
    }

    public class MoveLeftAndRight : UpdateHandler
    {
        private int speed = 5;

        public override void Update()
        {
            if (Parent.X > 6000)
                speed = -5;
            if (Parent.X < 2000)
                speed = 5;

            Parent.X += speed;
        }
    }

    public class Game1 : Game
    {
        public Game1() : base(new ContentLoader()) { }

        public override void OnStart()
        {
            CreateGround();
            CreatePlayer();
        }

        private void CreateGround()
        {
            var ground = new Thing()
            {
                X = 2000,
                Y = 6000
            };

            ground.AddCollider(new Collider()
            {
                Width = 6000,
                Height = 2000
            });

            AddThing(ground);
        }

        private void CreatePlayer()
        {
            var player = new Thing()
            {
                X = 2000,
                Y = 2000
            };

            var collider = new Collider()
            {
                Width = 1000,
                Height = 1000
            };
            collider.Add(new StopWhenHitsTHeGround());

            player.AddCollider(collider);
            player.AddUpdate(new AfectedByGravity());

            AddThing(player);
        }
    }

    public class StopWhenHitsTHeGround : BotCollisionHandler
    {
        public override void Handle(Collider other)
        {
            Parent.Parent.Y = other.Top() - Parent.Height;
        }
    }

    public class AfectedByGravity : UpdateHandler
    {
        public const int FORCE = 25;

        public override void Update()
        {
            Parent.AddVerticalForce(FORCE);
        }
    }
}
