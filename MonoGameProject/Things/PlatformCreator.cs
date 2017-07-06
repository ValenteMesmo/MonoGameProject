using GameCore;
using System;
using System.Collections.Generic;

namespace MonoGameProject
{
    class PlatformCreator : Thing
    {
        Module ground;
        WorldMover WorldMover; Action<Thing> AddToWOrld;
        BackBlocker BackBlocker;
        private Func<int, Module>[] Modules;
        private int moduleIndex = 0;

        public PlatformCreator(WorldMover WorldMover, Action<Thing> AddToWOrld)
        {
            BackBlocker = new BackBlocker(WorldMover) {
                X = -BackBlocker.WIDTH,
                Y = 6000 };
            AddToWOrld(BackBlocker);
            this.WorldMover = WorldMover;
            this.AddToWOrld = AddToWOrld;

            Modules = new Func<int, Module>[] 
            {
                x =>
                {
                    return new MapModule(WorldMover, BackBlocker)
                    {
                        X = x,
                        Y = 9000
                    };
                },
                x =>
                {
                    return new MapModule2(WorldMover, BackBlocker)
                    {
                        X = x,
                        Y = 9000
                    };
                }
            };
        
            
                CreateGround();
            AddUpdate(OnUpdate);

        }

        private void OnUpdate(Thing obj)
        {
            //tODO:  remove Cast
            if ((ground as Thing).X + MapModule.WIDTH < MapModule.WIDTH )
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
                //TODO: remove CAST
                anchor = (ground as Thing).X + MapModule.WIDTH - WorldMover.WorldSpeed;
            }

            ground = Modules[moduleIndex](anchor);
            moduleIndex++;
            if (moduleIndex > Modules.Length - 1)
                moduleIndex = 0;

            //TODO: remove CAST
            AddToWOrld(ground as Thing);
        }

    }
}
