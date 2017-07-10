using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class ViewDownBlocker : Thing
    {
        public const int HEIGHT = 2000;
        public const int WIDTH = 8 * 1000 * 2;
        public ViewDownBlocker()
        {
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
        public const int HEIGHT = 8 * 1000*2;
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
