using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class Spikes : Thing
    {
        public Spikes(Color Color, int width, int height)
        {
            var collider = new Collider();
            collider.OffsetY = 100;
            collider.Width = width * MapModule.CELL_SIZE;
            collider.Height = height * MapModule.CELL_SIZE;
            AddCollider(collider);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var animation = GeneratedContent.Create_knight_spikes(
                        i * MapModule.CELL_SIZE
                        , j * MapModule.CELL_SIZE
                        , MapModule.CELL_SIZE
                        , MapModule.CELL_SIZE);
                    animation.RenderingLayer = 0.49f;
                    animation.ColorGetter = () => Color;
                    AddAnimation(animation);
                }
            }


            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }

    public class Armor : Thing
    {
        private static Color[] Colors = new Color[] { Color.OrangeRed, Color.Olive, Color.Orchid, Color.PapayaWhip };
        private static Random Random = new Random(1);
        public Color Color;
        public Armor()
        {
            var collider = new Collider();
            collider.Width = MapModule.CELL_SIZE;
            collider.Height = MapModule.CELL_SIZE;
            AddCollider(collider);

            var animation = GeneratedContent.Create_knight_head_armor1(-400, -200);
            animation.RenderingLayer = 0.49f;
            animation.ScaleX = animation.ScaleY = 5;
            Color = Colors[Random.Next(0, Colors.Length - 1)];
            animation.ColorGetter = () => Color;
            AddAnimation(animation);

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }
}
