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
        private Func<int, int, Module>[] Modules;
        private int moduleIndex = 0;
        const int width = 12000;
        const int height = 2000;

        public PlatformCreator(WorldMover WorldMover, Action<Thing> AddToWOrld)
        {
            BackBlocker = new BackBlocker(WorldMover)
            {
                X = -BackBlocker.WIDTH,
                Y = 0
            };
            AddToWOrld(BackBlocker);
            this.WorldMover = WorldMover;
            this.AddToWOrld = AddToWOrld;

            AddToWOrld(new ViewDownBlocker()
            {
                Y = MapModule.HEIGHT * 2 - MapModule.CELL_SIZE
                + 3000//botcollider from wolrd mover
            });
            Modules = new Func<int, int, Module>[]
            {
                (x,y) =>
                {
                    return new MapModule(WorldMover, BackBlocker)
                    {
                        X = x,
                        Y = y
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
            var anchorX = 0;
            var anchorY = 9000;
            if (lastModule != null)
            {
                //TODO: remove CAST
                anchorX = (lastModule as Thing).X + MapModule.WIDTH - WorldMover.WorldHorizontalSpeed;
                anchorY = (lastModule as Thing).Y - WorldMover.WorldVerticalSpeed;
            }

            lastModule = Modules[moduleIndex](anchorX, anchorY);
            moduleIndex++;
            if (moduleIndex > Modules.Length - 1)
                moduleIndex = 0;

            //TODO: remove CAST
            AddToWOrld(lastModule as Thing);
        }

    }
}
