using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class MapModule : Thing, Module, IBlockPlayerMovement
    {
        public const int CELL_SIZE = 600;
        private BackBlocker Blocker;
        public const int CELL_NUMBER = 16;
        public const int WIDTH = CELL_SIZE * CELL_NUMBER;
        public const int HEIGHT = CELL_SIZE * CELL_NUMBER;
        string[] map = new[]{
             "1110001011100010"
            ,"0000000000000000"
            ,"0000000000000000"
            ,"1110011111100111"
            ,"0000000000000000"
            ,"0000000000000000"
            ,"0000000000000000"
            ,"1110111011111111"
            ,"1110001011100010"
            ,"0000000000000000"
            ,"0000000000000000"
            ,"1110011111100111"
            ,"0000000000000000"
            ,"0000000000000000"
            ,"0000000000000000"
            ,"1111111111111111"
        };

        public MapModule(WorldMover WorldMover, BackBlocker Blocker)
        {
            this.Blocker = Blocker;

            AddUpdate(WorldHelper.MoveWithTheWord);

            AddUpdate(t =>
            {
                if (X < -WIDTH * 2)
                {
                    Blocker.X = X + WIDTH - BackBlocker.WIDTH;
                    Destroy();
                }
            });

            for (int i = 0; i < CELL_NUMBER; i++)
            {
                for (int j = 0; j < CELL_NUMBER; j++)
                {
                    var type = map[i][j];
                    if (type == '1')
                    {
                        var combo = 1;
                        while (true)
                        {
                            if (j + 1 >= CELL_NUMBER)
                                break;
                            type = map[i][j + 1];
                            if (type != '1')
                                break;
                            combo++;
                            j++;
                        }

                        AddAnimation(new Animation(new AnimationFrame(
                            "block"
                            , (j - combo + 1) * CELL_SIZE
                            , i * CELL_SIZE
                            , CELL_SIZE * combo
                            , CELL_SIZE
                        ))
                        { Color = Color.Brown });

                        AddCollider(new Collider()
                        {
                            OffsetX = (j - combo + 1) * CELL_SIZE,
                            OffsetY = i * CELL_SIZE,
                            Width = CELL_SIZE * combo,
                            Height = CELL_SIZE
                        });
                    }
                    if (type == '0')
                    {
                        AddAnimation(new Animation(new AnimationFrame(
                            "block"
                            , j * CELL_SIZE
                            , i * CELL_SIZE
                            , CELL_SIZE
                            , CELL_SIZE
                        ))
                        { Color = Color.LightGray });
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
