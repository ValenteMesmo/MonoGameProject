﻿using GameCore;
using System;

namespace MonoGameProject
{
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
            player.AddUpdate(new HorizontalFriction());
            player.AddUpdate(new AfectedByGravity());
            player.AddUpdate(new MoveLeftOrRight(InputRepository));
            player.AddUpdate(new Jump(InputRepository));
            player.AddUpdate(new SpeedLimit());
            AddThing(player);
        }
    }
}
