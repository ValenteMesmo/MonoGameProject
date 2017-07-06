using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class BackBlocker : Thing, IBlockPlayerMovement
    {
        public const int WIDTH = 2000;
        public BackBlocker(WorldMover WorldMover) 
        {
            AddCollider(new Collider
            {
                Width = WIDTH,
                Height = 3000
            });
            AddUpdate(t => X -= WorldMover.WorldSpeed);

            AddAnimation(new Animation(new AnimationFrame("walk0", 0, 0, WIDTH, 3000)) { Color = Color.Yellow });
        }
    }
}
