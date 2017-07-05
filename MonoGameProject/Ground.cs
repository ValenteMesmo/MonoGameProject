using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class Ground : Thing
    {
        public const int WIDTH = 8000;
        public const int HEIGHT = 5000;

        public Ground(WorldMover WorldMover)
        {
            AddUpdate(t =>
            {
                X -= WorldMover.WorldSpeed;
            });

            AddUpdate(t =>
            {
                if (X < -WIDTH * 2)
                    Destroy();
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
