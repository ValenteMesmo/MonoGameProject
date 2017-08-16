using GameCore;
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

        
        public readonly MapModuleInfo Info;        
        private readonly Action<Thing> AddToWorld;        

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

            var tiles = new TilesFromStrings().Create(Info.Tiles);
            foreach (var tile in tiles.Where(f => f.Type == '1'))
            {
                AddCollider(new GroundCollider
                {
                    OffsetX = (tile.X - 1) * CELL_SIZE + 1,
                    OffsetY = (tile.Y - 1) * CELL_SIZE + 1,
                    Width = tile.Width * CELL_SIZE,
                    Height = tile.Height * CELL_SIZE
                });
            }
            foreach (var tile in tiles.Where(f => f.Type == '^'))
            {
                AddToWorld(new Spikes(
                    Color.Red,
                    tile.Width ,
                    tile.Height)
                {
                    X = X + ((tile.X - 1) * CELL_SIZE + 1),
                    Y = Y + ((tile.Y - 1) * CELL_SIZE +  1)
                });
            }

            var sky = new Animation(new AnimationFrame("pixel",
                                0
                               , 0
                               , CELL_SIZE * CELL_NUMBER
                               , (CELL_SIZE * CELL_NUMBER)));
            
            sky.ColorGetter = () => new Color(0.5f, 0.8f, 0.8f);//Color.Crimson;
            sky.RenderingLayer = 1f;
            AddAnimation(sky);

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
                               j * CELL_SIZE - 5
                               , i * CELL_SIZE - 5
                               , MapModule.CELL_SIZE + 10
                               , MapModule.CELL_SIZE + 10);
                        animation.RenderingLayer = 0.5f;
                        var color = GameState.GetColor();
                        animation.ColorGetter = () => color;
                        AddAnimation(animation);

                        var animationborder = GeneratedContent.Create_knight_block(
                               j * CELL_SIZE - 25
                               , i * CELL_SIZE - 25
                               , MapModule.CELL_SIZE + 50
                               , MapModule.CELL_SIZE + 50);
                        animationborder.RenderingLayer = 0.51f;
                        animationborder.ColorGetter = () => Color.Black;//Colors[ColorIndex];
                        AddAnimation(animationborder);
                    }

                    if (type == '=')
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
                        AddToWorld(new Enemy(Game1, AddToWorld)
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
            var animation = GeneratedContent.Create_knight_block(
                               (j * CELL_SIZE) - 5
                               , (i * CELL_SIZE) - 5
                               , MapModule.CELL_SIZE + 10
                               , MapModule.CELL_SIZE + 10);
            animation.RenderingLayer = 0.52f;
            var oColor = GameState.GetColor();
            var color = new Color(
                oColor.R - 100
                , oColor.G - 100
                , oColor.B - 100
                , oColor.A
            );
            animation.ColorGetter = () => color;
            AddAnimation(animation);


            var animationborder = GeneratedContent.Create_knight_block(
                               j * CELL_SIZE - 25
                               , i * CELL_SIZE - 25
                               , MapModule.CELL_SIZE + 50
                               , MapModule.CELL_SIZE + 50);
            animationborder.RenderingLayer = 0.521f;
            animationborder.ColorGetter = () => Color.Black;//Colors[ColorIndex];
            AddAnimation(animationborder);
        }

        //private void CreateSolid(int i, int j)
        //{
        //    var animation = GeneratedContent.Create_knight_block(
        //        (j) * CELL_SIZE + 1
        //        , i * CELL_SIZE + 1
        //        , MapModule.CELL_SIZE
        //        , MapModule.CELL_SIZE
        //    );
        //    animation.ScaleX = MapModule.SCALE;
        //    animation.ScaleY = MapModule.SCALE;
        //    animation.RenderingLayer = 0.5f;
        //    animation.Color = Colors[ColorIndex];
        //    AddAnimation(animation);

        //    AddCollider(new GroundCollider()
        //    {
        //        OffsetX = (j) * CELL_SIZE + 1,
        //        OffsetY = i * CELL_SIZE + 1,
        //        Width = CELL_SIZE,
        //        Height = CELL_SIZE
        //    });
        //}
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
            , Func<int, int, int, int, Animation> imgName)
        {
            var animation = imgName(x, y, width, height);
            animation.RenderingLayer = 0.9f + parallax / 1000f;
            animation.ScaleX = 10;
            animation.ScaleY = 10;
            AddAnimation(animation);

            AddUpdate(new MoveHorizontallyWithTheWorld(this, parallax));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }
}

