using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class BackBlocker : Thing
    {
        public const int WIDTH = 2000;
        public const int HEIGHT = 8 * 1000 * 2;
        public BackBlocker(WorldMover WorldMover)
        {
            AddCollider(new SolidCollider
            {
                Width = WIDTH,
                Height = HEIGHT
            });
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            var block = GeneratedContent.Create_knight_block(0, 0, 1.5f, WIDTH, HEIGHT);
            AddAnimation(block);
        }
    }
}
