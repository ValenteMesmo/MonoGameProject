using GameCore;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class WallJump : UpdateHandler
    {
        int jumpImpulseTime = 0;
        const int JUMP_VALUE = 80;
        private readonly Humanoid Parent;
        private int horizontalSpeed = JUMP_VALUE;

        public WallJump(Humanoid Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (jumpImpulseTime == 0)
            {
                if (Parent.LegState == LegState.WallJumping)
                {
                    Parent.VerticalSpeed = -JUMP_VALUE;
                    if (Parent.FacingRight)
                        horizontalSpeed = JUMP_VALUE / 2;
                    else
                        horizontalSpeed = -JUMP_VALUE / 2;

                    jumpImpulseTime = 10;
                }
            }
            else if (jumpImpulseTime > 0)
            {
                Parent.HorizontalSpeed = horizontalSpeed;
                Parent.VerticalSpeed = -JUMP_VALUE;
                if (Parent.Inputs.JumpDown == false)
                    jumpImpulseTime = 0;
                else
                    jumpImpulseTime--;

                if (jumpImpulseTime == 0)
                {
                    if (Parent.groundChecker.Colliding<SomeKindOfGround>())
                        Parent.LegState = LegState.Walking;
                    else
                        Parent.LegState = LegState.Falling;
                }
            }
        }
    }
}
