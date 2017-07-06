using GameCore;
using System;

namespace MonoGameProject
{
    class PlatformCreator : Thing
    {
        MapModule ground;
        WorldMover WorldMover; Action<Thing> AddToWOrld;
        BackBlocker BackBlocker;

        //verifica se a ultima plataforma está a x de distancia, e cria outra
        public PlatformCreator(WorldMover WorldMover, Action<Thing> AddToWOrld)
        {
            BackBlocker = new BackBlocker(WorldMover) {
                X = -BackBlocker.WIDTH,
                Y =6000};
            AddToWOrld(BackBlocker);
            this.WorldMover = WorldMover;
            this.AddToWOrld = AddToWOrld;
            CreateGround();
            AddUpdate(OnUpdate);
        }

        private void OnUpdate(Thing obj)
        {
            if (ground.X + MapModule.WIDTH < MapModule.WIDTH )
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
            {
                anchor = ground.X + MapModule.WIDTH - WorldMover.WorldSpeed;
            }

            ground = new MapModule(WorldMover, BackBlocker)
            {
                X = anchor,
                Y = 9000
            };

            AddToWOrld(ground);
        }
    }
}
