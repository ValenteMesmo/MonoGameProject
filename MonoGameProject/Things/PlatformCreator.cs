﻿using GameCore;
using System;
using System.Collections.Generic;

namespace MonoGameProject
{
    public class ParalaxBackgroundCreator : Thing
    {
        ParallaxBackGround lastModule;
        WorldMover WorldMover;
        Action<Thing> AddToWOrld;
        Game1 Game1;

        private Random RandomModule = new Random(1);
        private readonly string imgName;
        private readonly int parallax;

        public ParalaxBackgroundCreator(
            WorldMover WorldMover
            , Action<Thing> AddToWOrld
            , Game1 Game1
            , string imgName
            , int parallax)
        {
            this.parallax = parallax;
            this.imgName = imgName;
            this.Game1 = Game1;
            this.WorldMover = WorldMover;
            this.AddToWOrld = AddToWOrld;

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
            var anchorY = 1500 ;
            if (lastModule != null)
            {
                anchorX = lastModule.X + MapModule.WIDTH*2 -( WorldMover.WorldHorizontalSpeed/ parallax);
            }

            lastModule = new ParallaxBackGround(
                0
                , 0
                , MapModule.WIDTH*2
                , MapModule.HEIGHT 
                , parallax
                , imgName);
            lastModule.X = anchorX;
            lastModule.Y = anchorY;
            AddToWOrld(lastModule);
        }

    }

    public class PlatformCreator : Thing
    {
        MapModule lastModule;
        WorldMover WorldMover; Action<Thing> AddToWOrld;
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
                    false
                    ,true
                    ,true
                    ,false
                    ,"1111111111111111"
                    ,"1000000000000000"
                    ,"1000000000000000"
                    ,"1000000000000000"
                    ,"1000000000000001"
                    ,"100000000z000000"
                    ,"1000000000000000"
                    ,"1000011111111111"
                    ,"1000011111000001"
                    ,"1a00000000000001"
                    ,"1a00000000000001"
                    ,"1111111111100001"
                    ,"0000000000000001"
                    ,"00000z0000000001"
                    ,"0000000000000001"
                    ,"1111111111111111")
                ,new MapModuleInfo(
                    true
                    ,false
                    ,false
                    ,true
                    ,"1111111111111111"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"0000000000000001"
                    ,"1100000000000001"
                    ,"1000000000000001"
                    ,"1000000000000001"
                    ,"1000011111111111"
                    ,"1000000000000001"
                    ,"1000000000000001"
                    ,"1000000000000001"
                    ,"1111111111100001"
                    ,"1000000000000000"
                    ,"1000000000000000"
                    ,"1090000000000000"
                    ,"1111111111111111")
                ,new MapModuleInfo(
                    true
                    ,false
                    ,true
                    ,false
                    ,"1111111111111111"
                    ,"0000000100000000"
                    ,"0000000100000000"
                    ,"0000000100000000"
                    ,"0010000100011100"
                    ,"0010000100001000"
                    ,"0010000100001000"
                    ,"0010000100001000"
                    ,"1110000100001111"
                    ,"1000000100000001"
                    ,"1000000100000001"
                    ,"1001111111111001"
                    ,"100000z000000001"
                    ,"1000000000000001"
                    ,"1000111111110001"
                    ,"1111111111111111")
                ,new MapModuleInfo(
                    false
                    ,true
                    ,false
                    ,true
                    ,"1111111111111111"
                    ,"1000000000000001"
                    ,"10000000000000b1"
                    ,"1000000000000001"
                    ,"1000100000100001"
                    ,"1000100100100001"
                    ,"1000100000100001"
                    ,"1000100000100001"
                    ,"1000111111100001"
                    ,"1000000100000001"
                    ,"1000000100000001"
                    ,"1000000100000001"
                    ,"1111100100111111"
                    ,"1000000100000000"
                    ,"0000000100000000"
                    ,"1111111111111111")
                ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000110001100000"
                    ,"0000101110100000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"0000111111100000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000011111000000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"1111111111111111")
                ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"0000111111100000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000111111100000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"0000100000100000"
                    ,"1111111111111111")
                ,new MapModuleInfo(
                    true
                    ,false
                    ,true
                    ,false
                    ,"1111111111111111"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"0000000000000000"
                    ,"1111110001000000"
                    ,"1000010001000000"
                    ,"1000010001000000"
                    ,"1900010001111111"
                    ,"1100010000000001"
                    ,"1000010000000001"
                    ,"1000010000000001"
                    ,"1000011111100001"
                    ,"1000000000000001"
                    ,"10000000000000b1"
                    ,"1a00000000000001"
                    ,"1111111111111111")
                 ,new MapModuleInfo(
                    true
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"
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
                    ,false
                    ,true
                    ,false
                    ,"1111111111111111"
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
                    ,"1111000000001111"
                    ,"1111000000001111"
                    ,"1111111001111111"
                    ,"1111111001111111"
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    true
                    ,false
                    ,true
                    ,false
                    ,"1111111111111111"
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
                    ,"1000000000000001"
                    ,"1000000000000001"
                    ,"1000000000000001"
                    ,"1111111111111111")
                    ,new MapModuleInfo(
                    false
                    ,true
                    ,true
                    ,true
                    ,"1111111111111111"
                    ,"1000000000000000"
                    ,"1000000000000000"
                    ,"1000000000000000"
                    ,"1090000000000001"
                    ,"1111111100000001"
                    ,"0000000000000001"
                    ,"0000000000000111"
                    ,"0000000000000001"
                    ,"0000001110000001"
                    ,"0000000000000001"
                    ,"1110000000000001"
                    ,"0000000000000000"
                    ,"0000011100000000"
                    ,"0000011100000000"
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
