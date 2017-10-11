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
}
