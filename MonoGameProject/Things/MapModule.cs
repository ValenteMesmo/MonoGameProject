﻿using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;
using System.Linq;

namespace MonoGameProject
{
    public struct MapModuleInfo
    {
        public readonly bool TopEntry;
        public readonly bool MidEntry;
        public readonly bool BotEntry;
        public readonly bool TopExit;
        public readonly bool MidExit;
        public readonly bool BotExit;
        public readonly string[] Tiles;

        public MapModuleInfo(
            bool TopEntry
            , bool MidEntry
            , bool BotEntry
           , bool TopExit
           , bool MidExit
           , bool BotExit
           , params string[] Tiles
            )
        {
            this.TopEntry = TopEntry;
            this.MidEntry = MidEntry;
            this.BotEntry = BotEntry;
            this.TopExit = TopExit;
            this.MidExit = MidExit;
            this.BotExit = BotExit;
            this.Tiles = Tiles;
        }
    }

    public class MapModule : Thing
    {
        public const int SCALE = 5;
        public const int CELL_SIZE = 500;
        public const int CELL_NUMBER = 16;
        public const int WIDTH = CELL_SIZE * CELL_NUMBER;
        public const int HEIGHT = CELL_SIZE * CELL_NUMBER;

        private static Color[] Colors = new Color[] { Color.Red, Color.LightGreen, Color.LightBlue };
        private static int ColorIndex = 0;
        public static void ChangeColor()
        {
            ColorIndex++;
            if (ColorIndex >= Colors.Length)
                ColorIndex = 0;
        }
        public static void ResetColor()
        {
            ColorIndex = 0;
        }
        public readonly MapModuleInfo Info;

        private static Random RandomTresure;
        private static Random RandomMonster;
        private readonly Action<Thing> AddToWorld;

        static MapModule()
        {
            RandomTresure = new Random(666);
            RandomMonster = new Random(999);
        }

        public MapModule(int X, int Y, BackBlocker Blocker, MapModuleInfo Info, Action<Thing> AddToWorld, Game1 Game1)
        {
            this.X = X;
            this.Y = Y;
            this.Info = Info;
            this.AddToWorld = AddToWorld;

            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            AddUpdate(() =>
            {
                if (this.X <= -WIDTH * 2)
                {
                    Blocker.X = this.X + WIDTH - BackBlocker.WIDTH;
                    Destroy();
                }
            });

            var tiles = new TileMerger().getMergedTiles(Info.Tiles);
            foreach (var tile in tiles.Where(f => f.Type == '1'))
            {
                AddCollider(new GroundCollider
                {
                    OffsetX = (tile.X - 1) * CELL_SIZE + 1,
                    OffsetY = (tile.Y - 1) * CELL_SIZE + 1,
                    Width = tile.W * CELL_SIZE,
                    Height = tile.H * CELL_SIZE
                });
            }

                //var sky = new Animation(new AnimationFrame("pixel",
                //                    0
                //                   , 0
                //                   , CELL_SIZE * CELL_NUMBER
                //                   , (CELL_SIZE * CELL_NUMBER)));
                ////sky.Color = new Color(
                ////    Colors[ColorIndex].R - 100
                ////    , Colors[ColorIndex].G - 100
                ////    , Colors[ColorIndex].B + 100
                ////    , Colors[ColorIndex].A 
                ////);
                //AddAnimation(sky);

                //}
                //{
                //    var sky = GeneratedContent.Create_knight_sky(
                //                      0
                //                      , 0
                //                      , 0.6f
                //                      , CELL_SIZE * CELL_NUMBER
                //                      , (CELL_SIZE * CELL_NUMBER)/3);
                //    sky.Color = new Color(
                //        Colors[ColorIndex].R - 100
                //        , Colors[ColorIndex].G + 100
                //        , Colors[ColorIndex].B - 100
                //        , Colors[ColorIndex].A - 200
                //    );
                //    AddAnimation(sky);
                //}
                for (int i = 0; i < CELL_NUMBER; i++)
            {
                for (int j = 0; j < CELL_NUMBER; j++)
                {
                    var type = Info.Tiles[i][j];
                    if (type == '1')
                    {
                        var animation = GeneratedContent.Create_knight_block(
                               j * CELL_SIZE
                               , i * CELL_SIZE
                               , 0.5f
                               , MapModule.CELL_SIZE
                               , MapModule.CELL_SIZE);
                        animation.ColorRed = Colors[ColorIndex];
                        animation.ColorGreen = Colors[ColorIndex];
                        animation.ColorBlue = Colors[ColorIndex];
                        AddAnimation(animation);
                    }

                    if (type == '0')
                    {
                        CreateBackground(i, j);
                    }

                    if (type == 'r')
                    {
                        AddToWorld(new LeftFireBallTrap(AddToWorld, i % 2 == 0 ? 50 : 0)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                        CreateBackground(i, j);
                    }
                    if (type == 'l')
                    {
                        AddToWorld(new RightFireBallTrap(AddToWorld, i % 2 == 0 ? 50 : 0)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                        CreateBackground(i, j);
                    }
                    if (type == 'z')
                    {
                        AddToWorld(new Enemy(Game1,AddToWorld)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                        CreateBackground(i, j);
                    }
                    if (type == 'a')
                    {
                        AddToWorld(new Armor()
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                        CreateBackground(i, j);
                    }
                }
            }
        }

        private void CreateBackground(int i, int j)
        {
            var animation = GeneratedContent.Create_knight_sky(
                               (j * CELL_SIZE)   - 5
                               , (i * CELL_SIZE) - 5
                               , 0.5f
                               , MapModule.CELL_SIZE + 10
                               , MapModule.CELL_SIZE + 10);
            
            //animation.Color = new Color(
            //    Colors[ColorIndex].R - 100
            //    , Colors[ColorIndex].G - 100
            //    , Colors[ColorIndex].B - 100
            //    , Colors[ColorIndex].A 
            //);

            //AddAnimation(animation);
        }

        private void CreateSolid(int i, int j)
        {
            var animation = GeneratedContent.Create_knight_block(
                (j) * CELL_SIZE + 1
                , i * CELL_SIZE + 1
                , 0.5f
                , MapModule.CELL_SIZE
                , MapModule.CELL_SIZE
            );
            animation.ScaleX = MapModule.SCALE;
            animation.ScaleY = MapModule.SCALE;
            AddAnimation(
                animation
            );

            AddCollider(new GroundCollider()
            {
                OffsetX = (j) * CELL_SIZE + 1,
                OffsetY = i * CELL_SIZE + 1,
                Width = CELL_SIZE,
                Height = CELL_SIZE
            });
        }
    }
    public class ParallaxBackGround : Thing
    {
        //static Color[] Colors = new Color[] { Color.Yellow, Color.Orange, Color.Blue };
        //static int index = 0;
        public ParallaxBackGround(
            int x
            , int y
            , int width
            , int height
            , int parallax
            , Func<int, int, float, int, int, Animation> imgName)
        {
            AddAnimation(imgName(x, y, 0.9f + parallax / 1000f, width, height));

            AddUpdate(new MoveHorizontallyWithTheWorld(this, parallax));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }
}

