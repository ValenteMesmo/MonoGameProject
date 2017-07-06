//using GameCore;
//using Microsoft.Xna.Framework;
//using MonoGameProject.Things;

//namespace MonoGameProject
//{
//    public class MapModule2 : Thing, Module, IBlockPlayerMovement
//    {
//        public const int WIDTH = 18000;
//        public const int HEIGHT = 5000;
//        private BackBlocker Blocker;

//        public MapModule2(WorldMover WorldMover, BackBlocker Blocker)
//        {
//            this.Blocker = Blocker;

//            AddUpdate(t => X -= WorldMover.WorldSpeed);

//            AddUpdate(t =>
//            {
//                if (X < -WIDTH * 2)
//                {
//                    Blocker.X = X + WIDTH - BackBlocker.WIDTH;
//                    Destroy();
//                }
//            });

//            floor();
//        }


//        private void floor()
//        {
//            AddAnimation(new Animation(new AnimationFrame(
//                "block"
//                , 0
//                , 0
//                , WIDTH
//                , HEIGHT
//            ))
//            { Color = Color.Brown });

//            AddCollider(new Collider()
//            {
//                Width = WIDTH,
//                Height = HEIGHT
//            });

//            //-----------------

//            AddAnimation(new Animation(new AnimationFrame(
//              "block"
//              , 0
//              , -10000
//              , WIDTH
//              , HEIGHT
//          ))
//            { Color = Color.Brown });

//            AddCollider(new Collider()
//            {
//                OffsetY= -10000,
//                Width = WIDTH,
//                Height = HEIGHT
//            });
//        }
//    }
//}
