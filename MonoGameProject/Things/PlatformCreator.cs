using GameCore;
using System;
using System.Collections.Generic;

namespace MonoGameProject
{
    class PlatformCreator : Thing
    {
        Module lastModule;
        WorldMover WorldMover; Action<Thing> AddToWOrld;
        BackBlocker BackBlocker;
        private Func<int, Module>[] Modules;
        private int moduleIndex = 0;
        const int width = 12000;
        const int height = 2000;

        public PlatformCreator(WorldMover WorldMover, Action<Thing> AddToWOrld)
        {
            BackBlocker = new BackBlocker(WorldMover)
            {
                X = -BackBlocker.WIDTH,
                Y = 6000
            };
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
                //x =>
                //{
                //    return new MapModule2(WorldMover, BackBlocker)
                //    {
                //        X = x,
                //        Y = 9000
                //    };
                //}
            };


            CreateGroundOnTheRight();
            AddUpdate(OnUpdate);

        }

        private void OnUpdate(Thing obj)
        {
            //tODO:  remove Cast
            if ((lastModule as Thing).X + MapModule.WIDTH < MapModule.WIDTH * 2)
            {
                CreateGroundOnTheRight();
            }
        }

        private void CreateGroundOnTheRight()
        {
            var anchor = 0;
            if (lastModule != null)
            {
                //TODO: remove CAST
                anchor = (lastModule as Thing).X + MapModule.WIDTH - WorldMover.WorldSpeed;
            }

            lastModule = Modules[moduleIndex](anchor);
            moduleIndex++;
            if (moduleIndex > Modules.Length - 1)
                moduleIndex = 0;

            //TODO: remove CAST
            AddToWOrld(lastModule as Thing);
        }

    }
}
