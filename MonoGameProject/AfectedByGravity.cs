using GameCore;

namespace MonoGameProject
{
    public class AfectedByGravity : UpdateHandler
    {
        public const int FORCE = 2;
        public const int MAX_SPEED = 80;

        public override void Update()
        {
            Parent.VerticalSpeed += FORCE;
            if (Parent.VerticalSpeed > MAX_SPEED)
                Parent.VerticalSpeed = MAX_SPEED;
        }
    }
}
