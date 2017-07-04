using GameCore;

namespace MonoGameProject
{
    public class HorizontalFriction : UpdateHandler
    {
        private readonly int velocity = 1;

        public override void Update()
        {
            if (Parent.HorizontalSpeed > 0)
            {
                Parent.HorizontalSpeed -= velocity;
            }
            else if (Parent.HorizontalSpeed < 0)
            {
                Parent.HorizontalSpeed += velocity;
            }
        }

    }
}
