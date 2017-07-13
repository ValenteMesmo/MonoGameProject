using GameCore;
using System;

namespace MonoGameProject
{
    public class WallJump : UpdateHandler
    {
        int jumpImpulseTime = 0;
        const int JUMP_VALUE = 80;
        private readonly Func<bool> JumpButtonClicked;
        private readonly Func<bool> JumpButtonReleased;
        private readonly Player Parent;
        private int horizontalSpeed = JUMP_VALUE;

        public WallJump(
            Player Parent
            , Func<bool> JumpButtonClicked
            , Func<bool> JumpButtonReleased
            )
        {
            this.Parent = Parent;
            this.JumpButtonClicked = JumpButtonClicked;
            this.JumpButtonReleased = JumpButtonReleased;
        }

        public void Update()
        {
            if (jumpImpulseTime == 0)
            {
                if (Parent.State == PlayerState.WallJumpingToTheRight)
                {
                    Parent.VerticalSpeed = -JUMP_VALUE;
                    horizontalSpeed = JUMP_VALUE/2;
                    jumpImpulseTime = 10;
                }
                else if (Parent.State == PlayerState.WallJumpingToTheLeft)
                {
                    Parent.VerticalSpeed = -JUMP_VALUE;
                    horizontalSpeed = -JUMP_VALUE/2;
                    jumpImpulseTime = 10;
                }
            }
            else if (jumpImpulseTime > 0)
            {
                Parent.HorizontalSpeed = horizontalSpeed;
                Parent.VerticalSpeed = -JUMP_VALUE;
                if (JumpButtonReleased())
                    jumpImpulseTime = 0;
                else
                    jumpImpulseTime--;

                if (jumpImpulseTime == 0)
                {
                    if (Parent.State == PlayerState.WallJumpingToTheLeft)
                    {
                        if (Parent.groundChecker.Colliding)
                            Parent.State = PlayerState.WalkingLeft;
                        else
                            Parent.State = PlayerState.FallingLeft;
                    }
                    else
                    {
                        if (Parent.groundChecker.Colliding)
                            Parent.State = PlayerState.WalkingRight;
                        else
                            Parent.State = PlayerState.FallingRight;
                    }
                }
            }
        }
    }
}
