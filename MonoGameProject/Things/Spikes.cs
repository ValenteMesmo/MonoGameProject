using GameCore;
using Microsoft.Xna.Framework;

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
}
