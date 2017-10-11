using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class BackBlocker : Thing
    {
        public const int WIDTH = 2000;
        public const int HEIGHT = 8 * 1000 * 2;
        public readonly WorldMover WorldMover;

        public BackBlocker(WorldMover WorldMover)
        {
            this.WorldMover = WorldMover;
            AddCollider(new SolidCollider
            {
                Width = WIDTH,
                Height = HEIGHT
            });
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));

            var block = GeneratedContent.Create_knight_block(0, 0, WIDTH, HEIGHT);
            block.RenderingLayer = 1.5f;
            AddAnimation(block);
        }
    }

    public class DownBlocker : Thing
    {
        public DownBlocker()
        {
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddCollider(new Collider(8000, 4000)
            {
                OffsetX = 4000,
                OffsetY = 9500
            });
        }
    }
}
