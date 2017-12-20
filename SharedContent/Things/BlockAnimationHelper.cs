using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContent.Things
{
    public static class BlockAnimationHelper
    {
        private static  Animation GetGroundAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            if (GameState.State.CaveMode)
                return GeneratedContent.Create_knight_ground_2(X,Y,Width,Height,Flipped);
            else
                return GeneratedContent.Create_knight_ground_1(X, Y, Width, Height, Flipped);
        }

        public static void AddAnimation(Thing thing)
        {
            var bonusx = 25;
            var bonusy = 20;

            var offsetx =  - bonusx;
            var offsety =  - bonusy;
            var width = MapModule.CELL_SIZE + bonusx * 2;
            var height = MapModule.CELL_SIZE + bonusy * 2;

            var flipped = false;//MyRandom.Next(0, 1).ToBool();

            var animation_ground = GetGroundAnimation(
                offsetx
                , offsety
                , width
                , height
                , flipped);
            animation_ground.RenderingLayer = 0.52f;//+ 0.001f;
            //var groundcolor = GameState.GetComplimentColor2();
            animation_ground.ColorGetter = ColorsOfTheStage.Main;
            thing.AddAnimation(animation_ground);

            var animation_ground_border = GetGroundAnimation(
                offsetx - bonusx
                , offsety - bonusy
                , width + bonusx * 2
                , height + bonusy * 2,
                flipped);
            animation_ground_border.RenderingLayer = 0.52f + 0.001f;
            animation_ground_border.ColorGetter = () => Color.Black;
            thing.AddAnimation(animation_ground_border);
        }
    }
}
