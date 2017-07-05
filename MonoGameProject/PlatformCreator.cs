using GameCore;
using System;

namespace MonoGameProject
{
    class PlatformCreator : Thing
    {
        Ground ground;
        WorldMover WorldMover; Action<Thing> AddToWOrld;

        //verifica se a ultima plataforma está a x de distancia, e cria outra
        public PlatformCreator(WorldMover WorldMover, Action<Thing> AddToWOrld)
        {
            this.WorldMover = WorldMover;
            this.AddToWOrld = AddToWOrld;
            CreateGround();
            AddUpdate(OnUpdate);
        }

        private void OnUpdate(Thing obj)
        {
            if (ground.X + Ground.WIDTH <= Ground.WIDTH * 2)
            {
                CreateGround();
            }
        }
        const int width = 12000;
        const int height = 2000;
        private void CreateGround()
        {
            var anchor = 0;
            if (ground != null)
                anchor = ground.X + Ground.WIDTH - WorldMover.WorldSpeed;
            ground = new Ground(WorldMover)
            {
                X = anchor,
                Y = 9000
            };


            AddToWOrld(ground);
        }
    }
}
