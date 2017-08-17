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
        
        private readonly Func<int, int, int, int, Animation> imgName;
        private readonly int parallax;
        private readonly float zindex;        

        public ParalaxBackgroundCreator(
            WorldMover WorldMover
            , Action<Thing> AddToWOrld
            , Game1 Game1
            , Func<int, int, int, int, Animation> imgName
            , int parallax
            , float zindex)
        {
            this.zindex = zindex;
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
                anchorX = (int)(
                    lastModule.X 
                    + MapModule.WIDTH/2 
                    - (WorldMover.WorldHorizontalSpeed / parallax));
            }

            lastModule = new ParallaxBackGround(
                0
                , MapModule.HEIGHT/2
                , MapModule.WIDTH 
                , MapModule.HEIGHT
                , parallax
                , zindex
                , imgName);
            lastModule.X = anchorX;
            lastModule.Y = anchorY;
            AddToWOrld(lastModule);
        }
    }
}
