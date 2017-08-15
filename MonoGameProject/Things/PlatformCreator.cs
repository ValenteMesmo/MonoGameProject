using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameProject
{
    public class PlatformCreator : Thing
    {
        private MapModule lastModule;
        private WorldMover WorldMover;
        private Action<Thing> AddToWOrld;
        private BackBlocker BackBlocker;
        private Game1 Game1;
        private List<MapModuleInfo> CurrentModules;
        private List<MapModuleInfo> Modules;
        private List<MapModuleInfo> CaveModules;
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

            CreateModules();
            CreateCaveModules();

            CurrentModules =
            /*
            CaveModules;
            */
            Modules;
            CreateGroundOnTheRight();
            AddUpdate(OnUpdate);
        }

        private void CreateModules()
        {
            Modules = new List<MapModuleInfo>{
                new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,true
                    ,true
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"00001======10000"//
                    ,"00001======10000"//E
                    ,"00001======10000"//E
                    ,"00001======10000"//
                    ,"00001======10000"//
                    ,"00001======10000"//
                    ,"0000111111110000"//
                    ,"z11110====000000"//E
                    ,"002000====000000"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,false
                    ,true
                    ,true
                    ,false
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"1100000000000001"//E
                    ,"1100000000000a01"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,false
                    ,false
                    ,true
                    ,false
                    ,false
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"1111111111111111"//
                    ,"1100000000000011"//
                    ,"1000000000000001"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000")
                    ,new MapModuleInfo(
                    true
                    ,false
                    ,false
                    ,true
                    ,false
                    ,false
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"1100111001110011"//
                    ,"1100111001110011"//
                    ,"1111111111111111"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,false
                    ,false
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000011"//
                    ,"0000000000000011"//
                    ,"0000000000001111"//
                    ,"0000000000001111"//
                    ,"0000000000111111"//E
                    ,"0000000000111111"//E
                    ,"0000000011111111"//
                    ,"0000000011111111"//
                    ,"0000001111111111"//
                    ,"0000001111111111"//
                    ,"000l111111111111"//E
                    ,"000l111111111111"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,false
                    ,false
                    ,true
                    ,true
                    ,true
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"1100000000000000"//
                    ,"1100000000000000"//
                    ,"1111000000000000"//
                    ,"1111000000000000"//
                    ,"1111110000000000"//E
                    ,"1111110000000000"//E
                    ,"1111111100000000"//
                    ,"1111111100000000"//
                    ,"1111111111000000"//
                    ,"1111111111000000"//
                    ,"111111111111r000"//E
                    ,"111111111111r000"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,true
                    ,false
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000011"//
                    ,"0000000000000011"//
                    ,"0000000000001111"//
                    ,"0000000000001111"//
                    ,"0000000000111111"//E
                    ,"000a000000111111"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,false
                    ,true
                    ,true
                    ,true
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"1100000000000000"//
                    ,"1100000000000000"//
                    ,"1111000000000000"//
                    ,"1111000000000000"//
                    ,"111111r000000000"//E
                    ,"111111r000000000"//E
                    ,"1111111111111111")
            };
        }

        private void CreateCaveModules()
        {
            CaveModules = new List<MapModuleInfo>{
                new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"//
                    ,"================"//E
                    ,"================"//E
                    ,"================"//
                    ,"================"//
                    ,"================"//
                    ,"================"//
                    ,"================"//E
                    ,"================"//E
                    ,"================"//
                    ,"================"//
                    ,"================"//
                    ,"================"//
                    ,"================"//E
                    ,"================"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,false
                    ,true
                    ,true
                    ,false
                    ,"1111111111111111"//
                    ,"================"//E
                    ,"=00==00==00==00="//E
                    ,"=00==00==00==00="//
                    ,"=00==00==00==00="//
                    ,"=00==00==00==00="//
                    ,"=00==00==00==00="//
                    ,"=00==00==00==00="//E
                    ,"================"//E
                    ,"1111111111111111"//
                    ,"1111111111111111"//
                    ,"1111111111111111"//
                    ,"1111111111111111"//
                    ,"1111111111111111"//E
                    ,"1111111111111111"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,false
                    ,false
                    ,true
                    ,false
                    ,false
                    ,"1111111111111111"//
                    ,"================"//E
                    ,"================"//E
                    ,"1111111111111111"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000000")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,false
                    ,false
                    ,"1111111111111111"//
                    ,"====1==========="//E
                    ,"====1==========="//E
                    ,"====1===11111111"//
                    ,"====1==========1"//
                    ,"====1==========1"//
                    ,"====11111111===1"//
                    ,"====1==========1"//E
                    ,"====1==========1"//E
                    ,"====1===11111111"//
                    ,"====1==========1"//
                    ,"====1==========1"//
                    ,"====11111111===1"//
                    ,"===============1"//E
                    ,"===============1"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,false
                    ,false
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"//
                    ,"================"//E
                    ,"================"//E
                    ,"111111111111===="//
                    ,"000000000001===="//
                    ,"000000000001===="//
                    ,"000000000001===="//
                    ,"000000000001===="//E
                    ,"000000000001===="//E
                    ,"000000000001===="//
                    ,"000000000001===="//
                    ,"000000000001===="//
                    ,"000000000001===="//
                    ,"000000000001===="//E
                    ,"000000000001===="//E
                    ,"0000000000011111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,true
                    ,false
                    ,"1111111111111111"//
                    ,"================"//E
                    ,"==00==00==00===="//E
                    ,"==00==00==00===="//
                    ,"==00==00==00===="//
                    ,"==00==00==00===="//
                    ,"==00==00==00===="//
                    ,"==00==00==00===="//E
                    ,"==00==00==00===="//E
                    ,"==00==00==00==11"//
                    ,"==00==00======11"//
                    ,"==00==00====1111"//
                    ,"==00==00====1111"//
                    ,"==========111111"//E
                    ,"==========111111"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,false
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"//
                    ,"====11111111===="//E
                    ,"====11111111===="//E
                    ,"====11111111===="//
                    ,"====11111111===="//
                    ,"====11111111===="//
                    ,"====11111111===="//
                    ,"====11111111===="//E
                    ,"====11111111===="//E
                    ,"1===11111111===1"//
                    ,"1===11111111===1"//
                    ,"1===11111111===1"//
                    ,"1==============1"//
                    ,"1==============1"//E
                    ,"1==============1"//E
                    ,"1111111111111111")
            };
        }

        private void OnUpdate()
        {
            if (lastModule.X < MapModule.WIDTH)
            {
                CreateGroundOnTheRight();
            }
        }

        int stageCount = 10;
        private void CreateGroundOnTheRight()
        {
            var anchorX = 0;
            var anchorY = 1500;


            if (lastModule == null)
            {
                MapModule.ResetColor();
                var newMap = CurrentModules[0];
                lastModule = new
                    MapModule(anchorX, anchorY, BackBlocker, newMap, AddToWOrld, Game1);
            }
            else
            {
                var newMap = CurrentModules[RandomModule.Next(0, CurrentModules.Count)];
                anchorX = lastModule.X + MapModule.WIDTH - WorldMover.WorldHorizontalSpeed;
                while (true)
                {
                    if (
                        lastModule.Info.TopExit == newMap.TopEntry
                        && lastModule.Info.MidExit == newMap.MidEntry
                        && lastModule.Info.BotExit == newMap.BotEntry)
                        break;

                    newMap = CurrentModules[RandomModule.Next(0, CurrentModules.Count)];
                }

                lastModule = new MapModule(anchorX, anchorY, BackBlocker, newMap, AddToWOrld, Game1);
            }

            AddToWOrld(lastModule);
            stageCount--;
            if (stageCount < 0)
            {
                MapModule.ChangeColor();
                stageCount = 10;
                if (CurrentModules == Modules)
                    CurrentModules = CaveModules;
                else
                    CurrentModules = Modules;
            }
        }

    }

    public class Tiles
    {
        public char Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $@"({X}, {Y}, {Width}, {Height}) '{Type}'";
        }
    }

    public class TilesFromStrings
    {
        private List<Tiles> Result = new List<Tiles>();

        public IEnumerable<Tiles> Create(params string[] lines)
        {
            Result.Clear();

            CreateMergedHorizontalTiles(lines);
            MergeVerticallyTilesWithSameWidth();

            return Result.Where(f => f.Height > 0);
        }

        private void MergeVerticallyTilesWithSameWidth()
        {
            foreach (var current in Result)
            {
                foreach (var other in Result)
                {
                    if (other.Y + other.Height == current.Y
                            && other.X == current.X
                            && other.Height > 0
                            && current.Height > 0)
                    {
                        if (other.Type == current.Type)
                        {
                            if (other.Width == current.Width)
                            {
                                current.Height--;
                                current.Y++;
                                other.Height++;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void CreateMergedHorizontalTiles(string[] tiles)
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
                            Width = 1,
                            Height = 1,
                            Type = currentType
                        };

                        continue;
                    }

                    if (columnIndex == lastColumnIndex)
                    {
                        if (currentRect.Type == currentType)
                        {
                            Result.Add(currentRect);
                            currentRect.Width++;
                        }
                        else
                        {
                            Result.Add(currentRect);
                            currentRect = new Tiles
                            {
                                X = columnIndex + 1,
                                Y = rowIndex + 1,
                                Width = 1,
                                Height = 1,
                                Type = currentType
                            };
                            Result.Add(currentRect);
                        }

                        continue;
                    }

                    if (currentRect.Type == currentType)
                    {
                        currentRect.Width++;
                    }
                    else
                    {
                        Result.Add(currentRect);
                        currentRect = new Tiles
                        {
                            X = columnIndex + 1,
                            Y = rowIndex + 1,
                            Width = 1,
                            Height = 1,
                            Type = currentType
                        };
                    }
                }
            }
        }
    }
}
