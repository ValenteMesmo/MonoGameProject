using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class MapModule : Thing, Module, IBlockPlayerMovement
    {
        //public const int WIDTH = 18000;
        //public const int HEIGHT = 5000;
        public const int CELL_SIZE = 1000;
        private BackBlocker Blocker;
        public const int WIDTH = CELL_SIZE * 8;
        public const int HEIGHT = CELL_SIZE * 8;
        string[] map = new[]{
            "11101011"
            ,"00000000"
            ,"11111111"
            ,"00000000"
            ,"00000000"
            ,"00000000"
            ,"00000000"
            ,"00000000"
        };

        public MapModule(WorldMover WorldMover, BackBlocker Blocker)
        {
            this.Blocker = Blocker;

            AddUpdate(t => X -= WorldMover.WorldSpeed);

            AddUpdate(t =>
            {
                if (X < -WIDTH * 2)
                {
                    Blocker.X = X + WIDTH - BackBlocker.WIDTH;
                    Destroy();
                }
            });

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var type = map[j][i];
                    if (type == '1')
                    {
                        AddAnimation(new Animation(new AnimationFrame(
                            "block"
                            , i * CELL_SIZE
                            , j * CELL_SIZE
                            , CELL_SIZE
                            , CELL_SIZE
                        ))
                        { Color = Color.Brown });

                        AddCollider(new Collider()
                        {
                            OffsetX = i * CELL_SIZE,
                            OffsetY = j * CELL_SIZE,
                            Width = CELL_SIZE,
                            Height = CELL_SIZE
                        });
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
