using GameCore;
using System;
using System.Collections.Generic;

namespace MonoGameProject
{
    public class PlatformCreator : Thing
    {
        MapModule lastModule;
        WorldMover WorldMover;
        Action<Thing> AddToWOrld;
        BackBlocker BackBlocker;
        Game1 Game1;
        private List<MapModuleInfo> Modules;

        private Random RandomModule = new Random(1);

        public PlatformCreator(WorldMover WorldMover, Action<Thing> AddToWOrld, Game1 Game1)
        {
            this.Game1 = Game1;
            BackBlocker = new BackBlocker(WorldMover)
            {
                X = -BackBlocker.WIDTH,
                Y = 0
            };
            AddToWOrld(BackBlocker);
            this.WorldMover = WorldMover;
            this.AddToWOrld = AddToWOrld;

            //criar tiles gordos(2x2  ancora no canto inferior direito)
            //indoor and outdoor render.... indoor the "2"s are windows
            Modules = new List<MapModuleInfo>{
                new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
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
                    ,"0000000000000000"
                    ,"1111111111111111")
                ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0a00000000000000"
                    ,"0a00000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"1111111111111111"
                    ,"1000000000000001"
                    ,"1000000000000001")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"1111111111111111"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"000z000000z00000"
                    ,"1111111111111111"
                    ,"1111111111111111"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"1111111111111111")

            };

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

            var newMap = Modules[RandomModule.Next(0, Modules.Count)];
            if (lastModule != null)
            {
                while (true)
                {
                    if (lastModule.Info.TopExit && newMap.TopEntry)
                        break;

                    if (lastModule.Info.BotExit && newMap.BotEntry)
                        break;

                    newMap = Modules[RandomModule.Next(0, Modules.Count)];
                }
            }

            lastModule = new MapModule(anchorX, anchorY, BackBlocker, newMap, AddToWOrld, Game1);


            AddToWOrld(lastModule);
        }

    }
}
