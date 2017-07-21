using GameCore;
using System;

namespace MonoGameProject
{
    public class ChangeToWallJumping : UpdateHandler
    {
        private readonly Humanoid Parent;

        public ChangeToWallJumping(Humanoid Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (Parent.Inputs.ClickedJump
                && 
                (
                    Parent.State == PlayerState.SlidingWallLeft
                    || Parent.State == PlayerState.SlidingWallRight)
                )
            {
                if (Parent.State == PlayerState.SlidingWallLeft)
                    Parent.State = PlayerState.WallJumpingToTheRight;
                else
                    Parent.State = PlayerState.WallJumpingToTheLeft;
            }
        }
    }
}
