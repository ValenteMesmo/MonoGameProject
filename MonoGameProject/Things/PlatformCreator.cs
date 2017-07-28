using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    ,"1111111111111111"
                    ,"1111111111111111"
                    ,"1110000000000000"
                    ,"1111111111111111"
                    ,"1110000000000000"
                    ,"1110000000000000"
                    ,"1000000000000000"
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



    public class Tiles
    {
        public char Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }

        public override string ToString()
        {
            return $@"({X}, {Y}, {W}, {H}) '{Type}'";
        }
    }

    public class TileMerger
    {
        List<Tiles> Result = new List<Tiles>();
        public IEnumerable<Tiles> getMergedTiles(params string[] tiles)
        {
            Result.Clear();
            CreateHorizontalLines(tiles);
            MergeVerticalLines();

            return Result.Where(f => f.W > 0 && f.H > 0);
        }

        private void MergeVerticalLines()
        {
            foreach (var current in Result)
            {
                foreach (var previous in Result)
                    if (previous.Y + previous.H == current.Y
                            && previous.H > 0
                            && previous.W > 0
                            && current.W > 0
                            && current.H > 0)
                    {
                        if (previous.Type == current.Type)
                        {
                            if (previous.W == current.W)
                            {
                                current.H = 0;
                                previous.H++;
                            }
                        }
                    }
            }
        }

        private void CreateHorizontalLines(string[] tiles)
        {
            Tiles currentRect = null;
            var lastColumnIndex = tiles[0].Length - 1;
            for (int rowIndex = 0; rowIndex < tiles.Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < tiles[rowIndex].Length; columnIndex++)
                {
                    var currentType = tiles[rowIndex][columnIndex];

                    if (columnIndex == 0)
                    {
                        currentRect = new Tiles
                        {
                            X = columnIndex + 1,
                            Y = rowIndex + 1,
                            W = 1,
                            H = 1,
                            Type = currentType
                        };

                        continue;
                    }

                    if (columnIndex == lastColumnIndex)
                    {
                        if (currentRect.Type == currentType)
                        {
                            Result.Add(currentRect);
                            currentRect.W++;
                        }
                        else
                        {
                            Result.Add(currentRect);
                            currentRect = new Tiles
                            {
                                X = columnIndex + 1,
                                Y = rowIndex + 1,
                                W = 1,
                                H = 1,
                                Type = currentType
                            };
                            Result.Add(currentRect);
                        }
                        continue;
                    }

                    if (currentRect.Type == currentType)
                    {
                        currentRect.W++;
                    }
                    else
                    {
                        Result.Add(currentRect);
                        currentRect = new Tiles
                        {
                            X = columnIndex + 1,
                            Y = rowIndex + 1,
                            W = 1,
                            H = 1,
                            Type = currentType
                        };
                    }
                }
            }
        }
    }

}
