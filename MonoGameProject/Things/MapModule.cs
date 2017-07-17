using System;
using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public struct MapModuleInfo
    {
        public readonly bool TopEntry;
        public readonly bool BotEntry;
        public readonly bool TopExit;
        public readonly bool BotExit;
        public readonly string[] Tiles;

        public MapModuleInfo(
            bool TopEntry
            , bool BotEntry
           , bool TopExit
           , bool BotExit
           , params string[] Tiles
            )
        {
            this.TopEntry = TopEntry;
            this.BotEntry = BotEntry;
            this.TopExit = TopExit;
            this.BotExit = BotExit;
            this.Tiles = Tiles;
        }
    }

    public class MapModule : Thing, IBlockPlayerMovement
    {
        public const int CELL_SIZE = 500;
        public const int CELL_NUMBER = 16;
        public const int WIDTH = CELL_SIZE * CELL_NUMBER;
        public const int HEIGHT = CELL_SIZE * CELL_NUMBER;

        static Color Color = Color.LightCyan;
        public readonly MapModuleInfo Info;

        private static Random RandomTresure;
        private static Random RandomMonster;
        private readonly Action<Thing> AddToWorld;

        static MapModule()
        {
            RandomTresure = new Random(666);
            RandomMonster = new Random(999);
        }

        public MapModule(int X, int Y, BackBlocker Blocker, MapModuleInfo Info, Action<Thing> AddToWorld)
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


            if (Color == Color.LightCyan)
                Color = Color.LightCoral;
            else
                Color = Color.LightCyan;


            for (int i = 0; i < CELL_NUMBER; i++)
            {
                for (int j = 0; j < CELL_NUMBER; j++)
                {
                    var type = Info.Tiles[i][j];
                    if (type == '1')
                    {
                        CreateSolid(i, j);
                    }
                    if (type == '0')
                    {
                        CreateBackground(i, j);
                    }
                    if (type == '9')
                    {
                        if (RandomTresure.Next(0, 3) > 0)
                        {
                            CreateBackground(i, j);
                        }
                        else
                            AddAnimation(new Animation(
                                new AnimationFrame(
                                    "block"
                                    , j * CELL_SIZE + 1
                                    , i * CELL_SIZE + 1
                                    , CELL_SIZE
                                    , CELL_SIZE
                                )
                                { RenderingLayer = 1 })
                            { Color = Color.Yellow }
                            );
                    }
                    if (type == 'a')
                    {
                        AddToWorld(new LeftFireBallTrap(AddToWorld, i % 2 == 0 ? 50 : 0)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                    }
                    if (type == 'b')
                    {
                        AddToWorld(new RightFireBallTrap(AddToWorld, i % 2 == 0 ? 50 : 0)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                    }
                }
            }
        }

        private void CreateBackground(int i, int j)
        {
            AddAnimation(new Animation(
                new AnimationFrame(
                    "block"
                    , j * CELL_SIZE + 1
                    , i * CELL_SIZE + 1
                    , CELL_SIZE
                    , CELL_SIZE
                )
                { RenderingLayer = 1 })
            { Color = Color }
            );
        }

        private void CreateSolid(int i, int j)
        {
            AddAnimation(new Animation(
                new AnimationFrame(
                    "block"
                    , (j) * CELL_SIZE + 1
                    , i * CELL_SIZE + 1
                    , CELL_SIZE
                    , CELL_SIZE
                ))
            { Color = Color.Brown }
            );

            AddCollider(new Collider()
            {
                OffsetX = (j) * CELL_SIZE + 1,
                OffsetY = i * CELL_SIZE + 1,
                Width = CELL_SIZE,
                Height = CELL_SIZE
            });
        }
    }
}
