using GameCore;
using System;

namespace MonoGameProject
{
    public class ParalaxBackgroundCreator : Thing
    {
        ParallaxBackGround lastModule;
        WorldMover WorldMover;
        Action<Thing> AddToWOrld;
        Game1 Game1;

        private Random RandomModule = new Random(1);
        private readonly Func<int, int, int, int, Animation> imgName;
        private readonly int parallax;

        public ParalaxBackgroundCreator(
            WorldMover WorldMover
            , Action<Thing> AddToWOrld
            , Game1 Game1
            , Func<int, int, int, int, Animation> imgName
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
            var anchorY = 1500;
            if (lastModule != null)
            {
                anchorX = 
                    lastModule.X 
                    + MapModule.WIDTH/2 
                    - (WorldMover.WorldHorizontalSpeed / parallax);
            }

            lastModule = new ParallaxBackGround(
                0
                , MapModule.HEIGHT/2
                , MapModule.WIDTH 
                , MapModule.HEIGHT
                , parallax
                , imgName);
            lastModule.X = anchorX;
            lastModule.Y = anchorY;
            AddToWOrld(lastModule);
        }
    }
}
