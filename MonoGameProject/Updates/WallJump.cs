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
                if (Parent.LegState == LegState.WallJumpingToTheRight)
                {
                    Parent.VerticalSpeed = -JUMP_VALUE;
                    horizontalSpeed = JUMP_VALUE / 2;
                    jumpImpulseTime = 10;
                }
                else if (Parent.LegState == LegState.WallJumpingToTheLeft)
                {
                    Parent.VerticalSpeed = -JUMP_VALUE;
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
                    if (Parent.LegState == LegState.WallJumpingToTheLeft)
                    {
                        if (Parent.groundChecker.Colliding<SomeKindOfGround>())
                            Parent.LegState = LegState.WalkingRight;
                        else
                            Parent.LegState = LegState.FallingRight;
                    }
                    else
                    {
                        if (Parent.groundChecker.Colliding<SomeKindOfGround>())
                            Parent.LegState = LegState.WalkingLeft;
                        else
                            Parent.LegState = LegState.FallingLeft;
                    }
                }
            }
        }
    }
}
