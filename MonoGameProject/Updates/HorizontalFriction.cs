using GameCore;

namespace MonoGameProject
{
    public class HorizontalFriction : UpdateHandler
    {
        private readonly int velocity = 1;

        public void Update(Thing Parent)
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
