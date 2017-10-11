using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameProject
{
    public class PlatformCreator : Thing
    {
        private const int STAGE_LENGTH = 3;
        int stageCount = STAGE_LENGTH;
        private MapModule lastModule;
        private WorldMover WorldMover;
        private Action<Thing> AddToWOrld;
        private BackBlocker BackBlocker;
        private Game1 Game1;
        private List<MapModuleInfo> CurrentModules;
        private List<MapModuleInfo> Modules;
        private List<MapModuleInfo> CaveModules;
        private MapModuleInfo BossStage1 = new MapModuleInfo(
                    true
                    , false
                    , false
                    , true
                    , true
                    , false
                    , "1111111111111111"//
                    , "======y========="//E
                    , "================"//E
                    , "2222222========="//
                    , "1111111@========"//
                    , "1111111========="//
                    , "1111111========="//
                    , "1111111========="//E
                    , "1111111========="//E
                    , "1111111222222222"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//E
                    , "1111111111111111"//E
                    , "1111111111111111");

        private MapModuleInfo BossStage2 = new MapModuleInfo(
                    true
                    , true
                    , true
                    , false
                    , true
                    , false
                    , "1111111111111111"//
                    , "=========1111111"//E
                    , "======m==1111111"//E
                    , "=========1111111"//
                    , "=========1111111"//
                    , "=========1111111"//
                    , "=========1111111"//
                    , "=========y======"//E
                    , "x==============="//E
                    , "2222222222222222"//E
                    , "1111111111111111"//E
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111"//
                    , "1111111111111111");

        public PlatformCreator(WorldMover WorldMover, Action<Thing> AddToWOrld, Game1 Game1)
        {
            this.Game1 = Game1;
            BackBlocker = new BackBlocker(WorldMover)
            {
                X = -BackBlocker.WIDTH,
                Y = 0
            };
            AddToWOrld(BackBlocker);
            AddToWOrld(new DownBlocker());

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
                    ,"11111======10000"//
                    ,"00001======10000"//E
                    ,"00001======10000"//E
                    ,"00001======10000"//
                    ,"00001======10000"//
                    ,"00001======10000"//
                    ,"0000111111110000"//
                    ,"z00000====000000"//E
                    ,"000000====000000"//E
                    ,"11111^^^^11111^^")
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
                    false
                    ,true
                    ,false
                    ,true
                    ,true
                    ,false
                    ,"1000000000000000"//
                    ,"1000000000000000"//E
                    ,"1000000000000000"//E
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"1111111111111111"//
                    ,"1111111111111111"//
                    ,"1111111111111111"//
                    ,"1111111111111111"//
                    ,"1111111111111111"//E
                    ,"1111111111111111"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,false
                    ,true
                    ,false
                    ,false
                    ,"0000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"0000000000000001"//
                    ,"0000000000000001"//
                    ,"0000000000000001"//
                    ,"0000000000000001"//
                    ,"0000000000000001"//E
                    ,"0000000000000001"//E
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"1100000000000001"//E
                    ,"1100000000000a01"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    false
                    ,false
                    ,true
                    ,true
                    ,false
                    ,false
                    ,"1100000000000000"//
                    ,"1100000000000000"//E
                    ,"1100000000000000"//E
                    ,"1100000000000001"//
                    ,"1100000000000001"//
                    ,"1100000000000001"//
                    ,"1100000000000001"//
                    ,"1100000000000001"//E
                    ,"1100000000000001"//E
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"1100011111111111"//
                    ,"0000000000000001"//E
                    ,"0000000000000a01"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,false
                    ,false
                    ,false
                    ,true
                    ,"0000000000000001"//
                    ,"0000000000000001"//E
                    ,"0000000000000001"//E
                    ,"0000000000000001"//
                    ,"0000000000000001"//
                    ,"0000000000000001"//
                    ,"0000000000000001"//
                    ,"0000000000000001"//E
                    ,"0000000000000001"//E
                    ,"1000000000000001"//
                    ,"1000000000000001"//
                    ,"1000000000000001"//
                    ,"1000000000000001"//
                    ,"1000000000000000"//E
                    ,"1000000000000000"//E
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
                    ,new MapModuleInfo(
                    false
                    ,false
                    ,true
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"//
                    ,"1000000000000000"//E
                    ,"1000000000000000"//E
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//E
                    ,"1000000000000000"//E
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    false
                    ,true
                    ,false
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"//
                    ,"1000000000000000"//E
                    ,"1000000000000000"//E
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"0000000000000000"//E
                    ,"0000000000000000"//E
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//
                    ,"1000000000000000"//E
                    ,"1000000000000000"//E
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
                    false
                    ,false
                    ,true
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"//
                    ,"1==============="//E
                    ,"1====00===00===="//E
                    ,"1====00===00===="//
                    ,"1====00===00===="//
                    ,"1====00===00===="//
                    ,"1====00===00===="//
                    ,"1====00===00===="//E
                    ,"1====00===00===="//E
                    ,"1====00===00===="//
                    ,"1====00===00===="//
                    ,"1====00===00===="//
                    ,"1====00===00===="//
                    ,"================"//E
                    ,"================"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,true
                    ,false
                    ,true
                    ,false
                    ,false
                    ,"1111111111111111"//
                    ,"================"//E
                    ,"=====00===00===="//E
                    ,"=====00===00===1"//
                    ,"=====00===00===1"//
                    ,"=====00===00===1"//
                    ,"=====00===00===1"//
                    ,"1====00===00===1"//E
                    ,"1====00===00===1"//E
                    ,"1====00===00===1"//
                    ,"1====00===00===1"//
                    ,"1====00===00===1"//
                    ,"1====00===00===1"//
                    ,"1==============1"//E
                    ,"1==============1"//E
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
                    ,new MapModuleInfo(
                    false
                    ,true
                    ,false
                    ,false
                    ,false
                    ,true
                    ,"1111111111111111"//
                    ,"1==============1"//E
                    ,"1==============1"//E
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"===============1"//E
                    ,"==a=a==========1"//E
                    ,"111111=========1"//
                    ,"111111=========1"//
                    ,"111111=a=a=====1"//
                    ,"11111111111====1"//
                    ,"1=====11111====0"//E
                    ,"1=====11111=a=a0"//E
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    false
                    ,false
                    ,true
                    ,true
                    ,false
                    ,false
                    ,"1111111111111111"//
                    ,"1==============="//E
                    ,"1==============="//E
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"1==============1"//E
                    ,"1==============1"//E
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"1==============1"//
                    ,"===============1"//E
                    ,"===============1"//E
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

        private void CreateGroundOnTheRight()
        {
            if (GameState.State.CaveMode)
                CurrentModules = CaveModules;
            else
                CurrentModules = Modules;

            var anchorX = 0;
            var anchorY = 1500;

            var newMap = CurrentModules[GameState.PlatformRandomModule.Next(0, CurrentModules.Count - 1)];
            if (lastModule != null)
            {
                anchorX = lastModule.X + MapModule.WIDTH - WorldMover.WorldHorizontalSpeed;
                anchorY = lastModule.Y;
            }

            while (true)
            {
                if (stageCount == 2)
                {
                    if (GameState.State.TopExit == newMap.TopEntry
                    && GameState.State.MidExit == newMap.MidEntry
                    && GameState.State.BotExit == newMap.BotEntry
                    && newMap.TopExit
                    && !newMap.MidExit
                    && !newMap.BotExit)
                        break;
                }
                else if (stageCount == 1)
                {
                    newMap = BossStage1;
                    break;
                }
                else if (stageCount == 0)
                {
                    newMap = BossStage2;
                    break;
                }
                else if (
                    GameState.State.TopExit == newMap.TopEntry
                    && GameState.State.MidExit == newMap.MidEntry
                    && GameState.State.BotExit == newMap.BotEntry)
                    break;

                newMap = CurrentModules[GameState.PlatformRandomModule.Next(0, CurrentModules.Count - 1)];
            }

            lastModule = new MapModule(anchorX, anchorY, BackBlocker, newMap, Game1);

            GameState.State.TopExit = lastModule.Info.TopExit;
            GameState.State.MidExit = lastModule.Info.MidExit;
            GameState.State.BotExit = lastModule.Info.BotExit;

            AddToWOrld(lastModule);
            stageCount--;
            if (stageCount < 0)
            {
                GameState.State.ShowStageNumber = true;
                GameState.State.StageNumber++;
                GameState.State.CaveMode = !GameState.State.CaveMode;
                GameState.ChangeColor();
                GameState.PreSave();
                stageCount = STAGE_LENGTH;
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
