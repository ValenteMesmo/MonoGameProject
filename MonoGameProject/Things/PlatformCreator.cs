using GameCore;
using System;

namespace MonoGameProject
{
    class PlatformCreator : Thing
    {
        Module lastModule;
        WorldMover WorldMover; Action<Thing> AddToWOrld;
        BackBlocker BackBlocker;
        private Func<int, int, Module>[] Modules;
        private int moduleIndex = 0;

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

            AddToWOrld(new ViewDownBlocker());
            Modules = new Func<int, int, Module>[]
            {
                (x,y) =>
                {
                    return new MapModule(WorldMover, BackBlocker, new[]{
                         "1111111101111111"
                        ,"0000000000000000"
                        ,"0000000000000000"
                        ,"1111100111111111"
                        ,"0000100100000000"
                        ,"0000100100000000"
                        ,"0000100100000000"
                        ,"0000100100000111"
                        ,"0000100100000000"
                        ,"0000100100000000"
                        ,"0000000000000000"
                        ,"0000000000000000"
                        ,"1111111111001111"
                        ,"0000000001000000"
                        ,"0000000001000000"
                        ,"1111111111111111"
                    })
                    {
                        X = x,
                        Y = y
                    };
                },
                (x,y) =>
                {
                    return new MapModule(WorldMover, BackBlocker, new[]{
                         "1111111101111111"
                        ,"1000000000000000"
                        ,"1000000000000000"
                        ,"1111100111111110"
                        ,"0000100100000000"
                        ,"0000100100000000"
                        ,"0000100100000000"
                        ,"0000100100000111"
                        ,"0000100100000000"
                        ,"0000100100000000"
                        ,"0000000000000110"
                        ,"0000000000000000"
                        ,"1111100000001111"
                        ,"0000001001000000"
                        ,"0000001111000000"
                        ,"1111111111111111"
                    })
                    {
                        X = x,
                        Y = y
                    };
                }
            };


            CreateGroundOnTheRight();
            AddUpdate(OnUpdate);

        }

        private void OnUpdate()
        {
            //tODO:  remove Cast
            if ((lastModule as Thing).X  < MapModule.WIDTH)
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
