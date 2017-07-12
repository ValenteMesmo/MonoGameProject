using GameCore;
using System;

namespace MonoGameProject
{
    class PlatformCreator : Thing
    {
        MapModule lastModule;
        WorldMover WorldMover; Action<Thing> AddToWOrld;
        BackBlocker BackBlocker;
        private string[][] Modules;
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
            
            //criar tiles gordos(2x2  ancora no canto inferior direito)
            Modules = new string[][]{
                new[]{
                     "1111111111111111"
                    ,"1000000000000000"
                    ,"1000000000000000"
                    ,"1000000000000000"
                    ,"1000000000000000"
                    ,"1000000000000001"
                    ,"1000000000000011"
                    ,"1000000000000101"
                    ,"1000000000001001"
                    ,"1000000000010001"
                    ,"1000000000100001"
                    ,"1000000001000001"
                    ,"1000000010000001"
                    ,"0000000100000001"
                    ,"0000001000000001"
                    ,"1111111111111111"
                }
                ,new[]{
                     "1111111111111111"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"1111111111111111"
                }
                ,new[]{
                     "1111111111111111"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"1111111111111111"
                }
            }
            ;


            CreateGroundOnTheRight();
            AddUpdate(OnUpdate);

        }

        private void OnUpdate()
        {
            if (lastModule.X < MapModule.WIDTH)
            {
                CreateGroundOnTheRight();
            }
        }

        private void CreateGroundOnTheRight()
        {
            var anchorX = 0;
            var anchorY = 1500;
            if (lastModule != null)
            {
                anchorX = lastModule.X + MapModule.WIDTH - WorldMover.WorldHorizontalSpeed;
            }

            lastModule = new MapModule(WorldMover, BackBlocker, Modules[moduleIndex])
            {
                X = anchorX,
                Y = anchorY
            };

            moduleIndex++;
            if (moduleIndex > Modules.Length - 1)
                moduleIndex = 0;

            AddToWOrld(lastModule);
        }

    }
}
