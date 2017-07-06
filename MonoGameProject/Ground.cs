using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class BackBlocker : Thing
    {
        public const int WIDTH = 2000;
        public BackBlocker(WorldMover WorldMover)
        {
            AddCollider(new Collider {
                Width = WIDTH,
                Height = 3000
            });
            AddUpdate(t =>
            {
                X -= WorldMover.WorldSpeed;
            });

            AddAnimation(new Animation(new AnimationFrame("walk0", 0, 0, WIDTH, 3000)) {Color= Color.Yellow });
        }
    }

    public class Ground : Thing
    {
        public const int WIDTH = 18000;
        public const int HEIGHT = 5000;

        BackBlocker Blocker;
        public Ground(WorldMover WorldMover, BackBlocker Blocker)
        {
            this.Blocker = Blocker;
            AddUpdate(t =>
            {
                X -= WorldMover.WorldSpeed;
            });

            AddUpdate(t =>
            {
                if (X < -WIDTH * 2)
                {
                    Blocker.X = X + WIDTH - BackBlocker.WIDTH;
                    Destroy();
                }
            });

            AddAnimation(new Animation(new AnimationFrame(
                "walk0"
                , 0
                , 0
                , WIDTH
                , HEIGHT
            ))
            { Color = Color.Brown });


            AddCollider(new Collider()
            {
                Width = WIDTH,
                Height = HEIGHT
            });
        }
    }
}
