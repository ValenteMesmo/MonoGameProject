using GameCore;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace MonoGameProject
{
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

            AddStageNumber();

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
                    tile.Width,
                    tile.Height)
                {
                    X = X + ((tile.X - 1) * CELL_SIZE + 1),
                    Y = Y + ((tile.Y - 1) * CELL_SIZE + 1)
                });
            }
            {
                var sky = new Animation(new AnimationFrame("pixel",
                                  0
                                 , 0
                                 , CELL_SIZE * CELL_NUMBER
                                 , (CELL_SIZE * CELL_NUMBER)));

                var color = GameState.GetPreviousColor2();
                sky.ColorGetter = () => color; //new Color(0.5f, 0.8f, 0.8f);//Color.Crimson;
                sky.RenderingLayer = 1f;
                AddAnimation(sky);
            }
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
                        //TODO: manter o esquema de bloco e borda
                        //repetir esse esquema para cobertura

                        //fazer uns tiles com olhos e bocas, que abrem quando player da as costas

                        {
                            var animation_ground_top = GeneratedContent.Create_knight_ground_top(
                               j * CELL_SIZE - 125
                               , i * CELL_SIZE - 125
                               , MapModule.CELL_SIZE + 250
                               , MapModule.CELL_SIZE + 250);
                            animation_ground_top.RenderingLayer = 0.501f;
                            var groundcolor = GameState.GetComplimentColor2();
                            animation_ground_top.ColorGetter = () => groundcolor;
                            AddAnimation(animation_ground_top);

                            var animation_ground_top_border = GeneratedContent.Create_knight_ground_top(
                                   j * CELL_SIZE - 150
                                   , i * CELL_SIZE - 140
                                   , MapModule.CELL_SIZE + 300
                                   , MapModule.CELL_SIZE + 300);
                            animation_ground_top_border.RenderingLayer = 0.5011f;
                            animation_ground_top_border.ColorGetter = () => Color.Black;//Colors[ColorIndex];
                            AddAnimation(animation_ground_top_border);
                        }
                        

                        var animation = GeneratedContent.Create_knight_ground(
                               j * CELL_SIZE - 125
                               , i * CELL_SIZE - 125
                               , MapModule.CELL_SIZE + 250
                               , MapModule.CELL_SIZE + 250);
                        animation.RenderingLayer = 0.51f;
                        var color = GameState.GetColor();
                        animation.ColorGetter = () => color;
                        AddAnimation(animation);

                        var animationborder = GeneratedContent.Create_knight_block(
                               j * CELL_SIZE - 25
                               , i * CELL_SIZE - 25
                               , MapModule.CELL_SIZE + 50
                               , MapModule.CELL_SIZE + 50);
                        animationborder.RenderingLayer = 0.511f;
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
                    if (type == '@')
                    {
                        AddToWorld(new BossBattleTrigger
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                    }
                    if (type == 'x')
                    {
                        var camlocker = new Thing();
                        camlocker.AddUpdate(new MoveHorizontallyWithTheWorld(camlocker));
                        AddToWorld(camlocker);
                        Blocker
                            .WorldMover.camlocker = camlocker;
                    }
                    if (type == 'y')
                    {
                        var locker = new Thing();
                        locker.X = X + j * CELL_SIZE;
                        locker.Y = (Y + i * CELL_SIZE);

                        var animation = GeneratedContent.Create_knight_block(
                                -5
                               , -5
                               , MapModule.CELL_SIZE + 10
                               , (MapModule.CELL_SIZE + 10) * 2);
                        animation.RenderingLayer = 0.5f;
                        var color = GameState.GetColor();
                        animation.ColorGetter = () => color;
                        locker.AddAnimation(animation);

                        var animationborder = GeneratedContent.Create_knight_block(
                               -25
                               , -25
                               , MapModule.CELL_SIZE + 50
                               , (MapModule.CELL_SIZE + 50) * 2);
                        animationborder.RenderingLayer = 0.51f;
                        animationborder.ColorGetter = () => Color.Black;//Colors[ColorIndex];
                        locker.AddAnimation(animationborder);

                        locker.AddUpdate(new MoveHorizontallyWithTheWorld(locker));
                        AddToWorld(locker);
                        var originalY = locker.Y;
                        locker.AddUpdate(() =>
                        {
                            if (GameState.State.BossMode)
                                locker.Y = originalY;
                            else
                                locker.Y = originalY - CELL_SIZE * 2;
                        });
                        var collider = new GroundCollider()
                        {
                            OffsetX = 1,
                            OffsetY = 1,
                            Width = CELL_SIZE,
                            Height = CELL_SIZE * 2
                        };
                        locker.AddCollider(collider);
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
                    if (type == 'm')
                    {//This game1 dependency is ugly
                        AddToWorld(new Boss(Game1, AddToWorld)
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

        private void AddStageNumber()
        {
            if (GameState.State.ShowStageNumber == false)
                return;

            GameState.State.ShowStageNumber = false;

            var number = GameState.State.StageNumber.ToString();
            var i = 1;
            foreach (var n in number)
            {
                Func<int, int, int?, int?, bool, Animation> create = null;

                if (n == '0')
                    create = GeneratedContent.Create_knight_number0;
                else if (n == '1')
                    create = GeneratedContent.Create_knight_number1;
                else if (n == '2')
                    create = GeneratedContent.Create_knight_number2;
                else if (n == '3')
                    create = GeneratedContent.Create_knight_number3;
                else if (n == '4')
                    create = GeneratedContent.Create_knight_number4;
                else if (n == '5')
                    create = GeneratedContent.Create_knight_number5;
                else if (n == '6')
                    create = GeneratedContent.Create_knight_number6;
                else if (n == '7')
                    create = GeneratedContent.Create_knight_number7;
                else if (n == '8')
                    create = GeneratedContent.Create_knight_number8;
                else if (n == '9')
                    create = GeneratedContent.Create_knight_number9;
                else
                    return;

                var stageNumber = create(
                                              CELL_SIZE * i
                                             , CELL_SIZE
                                             , CELL_SIZE
                                             , CELL_SIZE
                                             , false);
                stageNumber.RenderingLayer = 0f;
                stageNumber.ColorGetter = () => new Color(0, 0, 0, 0.5f);
                AddAnimation(stageNumber);

                i++;
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
                oColor.R - 50
                , oColor.G - 50
                , oColor.B - 50
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
}