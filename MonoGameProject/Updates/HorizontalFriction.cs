using GameCore;

namespace MonoGameProject
{
    public class HorizontalFriction : UpdateHandler
    {
        private const int VELOCITY = 3;
        private const int CROUCH_VELOCITY = 1;
        private readonly ThingWithState Parent;

        public HorizontalFriction(ThingWithState Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (Parent.State == PlayerState.StandingLeft
                || Parent.State == PlayerState.StandingRight)
            {
                NewMethod(VELOCITY);
            }
            else if (Parent.State == PlayerState.crouchingLeft
                || Parent.State == PlayerState.crouchingRight)
            {
                NewMethod(CROUCH_VELOCITY);
            }
        }

        private void NewMethod(int value)
        {
            if (Parent.HorizontalSpeed > 0)
            {
                Parent.HorizontalSpeed -= value;
                if (Parent.HorizontalSpeed < 0)
                    Parent.HorizontalSpeed = 0;
            }
            else if (Parent.HorizontalSpeed < 0)
            {
                Parent.HorizontalSpeed += value;
                if (Parent.HorizontalSpeed > 0)
                    Parent.HorizontalSpeed = 0;
            }
        }
    }
}
