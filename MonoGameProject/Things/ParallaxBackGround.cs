using GameCore;
using System;

namespace MonoGameProject
{
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
            , float zIndex
            , Func<int, int, int, int, Animation> imgName)
        {
            var animation = imgName(x, y, width, height);
            animation.RenderingLayer = zIndex;
            animation.ScaleX = 10;
            animation.ScaleY = 10;
            var color = GameState.GetComplimentColor2();
            animation.ColorGetter = () => color;
            AddAnimation(animation);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this, parallax));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }
}

