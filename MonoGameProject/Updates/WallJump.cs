using GameCore;
using System;

namespace MonoGameProject
{
    public class WallJump : UpdateHandler
    {
        int jumpImpulseTime = 0;
        const int JUMP_VALUE = 100;
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
                    horizontalSpeed = JUMP_VALUE;
                    jumpImpulseTime = 50;
                }
                else if (Parent.State == PlayerState.WallJumpingToTheLeft)
                {
                    Parent.VerticalSpeed = -JUMP_VALUE;
                    horizontalSpeed = -JUMP_VALUE;
                    jumpImpulseTime = 50;
                }
            }
            else if (jumpImpulseTime > 0)
            {
                Parent.HorizontalSpeed = horizontalSpeed;
                if (JumpButtonReleased())
                    jumpImpulseTime = 0;
                else
                    jumpImpulseTime--;

                if (jumpImpulseTime == 0)
                {
                    if (Parent.State == PlayerState.WallJumpingToTheLeft)
                        Parent.State = PlayerState.FallingLeft;
                    else
                        Parent.State = PlayerState.FallingRight;
                }
            }
        }
    }

    public class ChangeToWallJumping : UpdateHandler
    {
        private readonly Func<bool> JumpButtonClicked;
        private readonly Player Parent;

        public ChangeToWallJumping(
            Player Parent
            , Func<bool> JumpButtonClicked
            )
        {
            this.Parent = Parent;
            this.JumpButtonClicked = JumpButtonClicked;
        }

        public void Update()
        {
            if (JumpButtonClicked()
                && Parent.State.Is(
                    PlayerState.SlidingWallLeft
                    , PlayerState.SlidingWallRight))
            {
                if (Parent.State == PlayerState.SlidingWallLeft)
                    Parent.State = PlayerState.WallJumpingToTheRight;
                else
                    Parent.State = PlayerState.WallJumpingToTheLeft;
            }
        }
    }
}
