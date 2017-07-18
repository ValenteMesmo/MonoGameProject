using GameCore;
using System;

namespace MonoGameProject
{
    public class ChangeToWallJumping : UpdateHandler
    {   
        private readonly ThingWithState Parent;

        public ChangeToWallJumping(ThingWithState Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (Parent.Inputs.ClickedJump
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
