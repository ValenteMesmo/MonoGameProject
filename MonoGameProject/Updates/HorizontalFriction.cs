using System;
using GameCore;

namespace MonoGameProject
{
    public class HitEffectFriction : UpdateHandler
    {
        private const int VELOCITY = 3;
        private readonly Thing Parent;

        public HitEffectFriction(Thing Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (Parent.HorizontalSpeed > 0)
            {
                Parent.HorizontalSpeed -= VELOCITY;
                if (Parent.HorizontalSpeed < 0)
                    Parent.HorizontalSpeed = 0;
            }
            else if (Parent.HorizontalSpeed < 0)
            {
                Parent.HorizontalSpeed += VELOCITY;
                if (Parent.HorizontalSpeed > 0)
                    Parent.HorizontalSpeed = 0;
            }

            if (Parent.VerticalSpeed > 0)
            {
                Parent.VerticalSpeed -= VELOCITY;
                if (Parent.VerticalSpeed > 100)
                    Parent.VerticalSpeed /= 2;

                if (Parent.VerticalSpeed < 0)
                    Parent.VerticalSpeed = 0;
            }
            else if (Parent.VerticalSpeed < 0)
            {
                Parent.VerticalSpeed += VELOCITY;
                if (Parent.VerticalSpeed < -100)
                    Parent.VerticalSpeed /= 2;

                if (Parent.VerticalSpeed > 0)
                    Parent.VerticalSpeed = 0;
            }
        }
    }

    public class HorizontalFriction : UpdateHandler
    {
        private const int VELOCITY = 3;
        private const int CROUCH_VELOCITY = 1;
        private readonly Humanoid Parent;

        public HorizontalFriction(Humanoid Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (Parent.LegState == LegState.Standing)
            {
                NewMethod(VELOCITY);
            }
            else if (Parent.LegState == LegState.Crouching)
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
