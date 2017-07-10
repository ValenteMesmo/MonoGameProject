using GameCore;
using System;

namespace MonoGameProject
{
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
