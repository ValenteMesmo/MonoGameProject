using GameCore;

namespace MonoGameProject
{
    public class AfectedByGravity : UpdateHandler
    {
        public const int FORCE = 5;
        public const int MAX_SPEED = 150;

        public void Update(Thing Parent)
        {
            Parent.VerticalSpeed += FORCE;
            if (Parent.VerticalSpeed > MAX_SPEED)
                Parent.VerticalSpeed = MAX_SPEED;
        }
    }
}
