using System;
using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class MyClass : MapModule
    {
        public MyClass(WorldMover WorldMover, BackBlocker Blocker) : base(WorldMover, Blocker)
        {

        }

        protected override string[] map()
        {
            //return new[]{
            //     "1110011111111111"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"0010010000000000"
            //    ,"1110011111111111"
            //    ,"0000000000000000"
            //    ,"0000000000000000"
            //    ,"1111111111111111"
            //};
            return new[]{
                 "1111111101111111"
                ,"0000000000000000"
                ,"0000000000000000"
                ,"1111100111111110"
                ,"0000100100000000"
                ,"0000100100000000"
                ,"0000100100000000"
                ,"0000100100000000"
                ,"1111100111111110"
                ,"0000000000000000"
                ,"0000000000000000"
                ,"1111111111001111"
                ,"0000000000000000"
                ,"0000000000000000"
                ,"0000000000000000"
                ,"1111111111111111"
            };
        }
    }

    public abstract class MapModule : Thing, Module, IBlockPlayerMovement
    {
        public const int CELL_SIZE = 1000;
        private BackBlocker Blocker;
        public const int CELL_NUMBER = 16;
        public const int WIDTH = CELL_SIZE * CELL_NUMBER;
        public const int HEIGHT = CELL_SIZE * CELL_NUMBER;
        protected abstract string[] map();


        static Color Color = Color.LightCyan;

        public MapModule(WorldMover WorldMover, BackBlocker Blocker)
        {
            this.Blocker = Blocker;

            AddUpdate(WorldHelper.MoveWithTheWord);

            AddUpdate(t =>
            {
                if (X <= -WIDTH )
                {
                    Blocker.X = X + WIDTH - BackBlocker.WIDTH;
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
                    var type = map()[i][j];
                    if (type == '1')
                    {
                        var combo = 1;
                        //while (true)
                        //{
                        //    if (j + 1 >= CELL_NUMBER)
                        //        break;
                        //    type = map()[i][j + 1];
                        //    if (type != '1')
                        //        break;
                        //    combo++;
                        //    j++;
                        //}

                        AddAnimation(new Animation(new AnimationFrame(
                            "block"
                            , (j - combo + 1) * CELL_SIZE + 1
                            , i * CELL_SIZE + 1
                            , CELL_SIZE * combo
                            , CELL_SIZE
                        ))
                        { Color = Color.Brown });

                        AddCollider(new Collider()
                        {
                            OffsetX = (j - combo + 1) * CELL_SIZE + 1,
                            OffsetY = i * CELL_SIZE + 1,
                            Width = CELL_SIZE * combo,
                            Height = CELL_SIZE
                        });
                    }
                    if (type == '0')
                    {
                        AddAnimation(new Animation(new AnimationFrame(
                            "block"
                            , j * CELL_SIZE + 1
                            , i * CELL_SIZE + 1
                            , CELL_SIZE
                            , CELL_SIZE
                        )
                        { RenderingLayer = 1 })
                        { Color = Color });
                    }
                }


            }
        }

        //private void floor2()
        //{
        //    AddAnimation(new Animation(new AnimationFrame(
        //        "block"
        //        , 1000
        //        , -1000
        //        , 1000
        //        , 1000
        //    ))
        //    { Color = Color.Brown });

        //    AddCollider(new Collider()
        //    {
        //        OffsetX = 1000,
        //        OffsetY = -1000,
        //        Width = 1000,
        //        Height = 1000
        //    });
        //}

        //private void floor()
        //{
        //    AddAnimation(new Animation(new AnimationFrame(
        //        "block"
        //        , 0
        //        , 0
        //        , WIDTH
        //        , HEIGHT
        //    ))
        //    { Color = Color.Brown });

        //    AddCollider(new Collider()
        //    {
        //        Width = WIDTH,
        //        Height = HEIGHT
        //    });
        //}
    }
}
