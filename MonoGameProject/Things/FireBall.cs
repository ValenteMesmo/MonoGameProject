using GameCore;

namespace MonoGameProject
{
    public class FireBall : Thing
    {
        public const int SPEED = 150;

        public FireBall(int speedX, int speedY)
        {
            var width = 400;
            var height = 400;
            var animation = GeneratedContent.Create_knight_block(
            0
            , 0
            , MapModule.CELL_SIZE
            , MapModule.CELL_SIZE
            );
            animation.RenderingLayer = 0.4f;
            AddAnimation(animation);

            HorizontalSpeed = speedX;
            VerticalSpeed = speedY;
            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            var collider = new Collider() { Width = width, Height = height };
            AddCollider(collider);
        }
    }
}
