using GameCore;

namespace MonoGameProject
{
    public class HorizontalFriction : UpdateHandler
    {
        private const int VELOCITY = 1;
        private readonly Player Parent;

        public HorizontalFriction(Player Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (
                (Parent.State == PlayerState.crouchingLeft
                || Parent.State == PlayerState.crouchingRight)
                && Parent.roofChecker.Colliding
                )
                return;

            if (Parent.HorizontalSpeed > 0)
            {
                Parent.HorizontalSpeed -= VELOCITY;
            }
            else if (Parent.HorizontalSpeed < 0)
            {
                Parent.HorizontalSpeed += VELOCITY;
            }
        }
    }
}
