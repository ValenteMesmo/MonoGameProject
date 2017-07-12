using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class ViewDownBlocker : Thing
    {
        //use camera dimensions?
        public const int HEIGHT = MapModule.CELL_SIZE * 4;
        public const int WIDTH = 8 * 1000 * 2;
        public ViewDownBlocker()
        {
            Y = MapModule.HEIGHT * 2+ MapModule.CELL_SIZE * 2;
            AddCollider(new Collider
            {
                Width = WIDTH,
                Height = HEIGHT
            });
            AddUpdate(new MoveVerticallyWithTheWorld(this));

            AddAnimation(
                new Animation(
                    new AnimationFrame("block", 0, 0, WIDTH, HEIGHT))
                { Color = Color.Yellow });
        }
    }

    public class BackBlocker : Thing, IBlockPlayerMovement
    {
        public const int WIDTH = 2000;
        public const int HEIGHT = 8 * 1000 * 2;
        public BackBlocker(WorldMover WorldMover)
        {
            AddCollider(new Collider
            {
                Width = WIDTH,
                Height = HEIGHT
            });
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            AddAnimation(
                new Animation(
                    new AnimationFrame("block", 0, 0, WIDTH, HEIGHT))
                { Color = Color.Yellow });
        }
    }
}
