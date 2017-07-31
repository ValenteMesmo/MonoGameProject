using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class ChangeToFallingState : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeToFallingState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.TakingDamage)
                return;

            if (Player.State != PlayerState.WallJumpingToTheLeft
                && Player.State != PlayerState.WallJumpingToTheRight)
            {
                if (Player.groundChecker.Colliding< BlockVerticalMovement>())
                {
                    if (Player.State == PlayerState.HeadBumpLeft)
                    {
                        Player.State = PlayerState.FallingLeft;
                    }
                    else if (Player.State == PlayerState.HeadBumpRight)
                    {
                        Player.State = PlayerState.FallingRight;
                    }
                }
                else
                {
                    if (Player.State == PlayerState.WalkingLeft
                       || Player.State == PlayerState.StandingLeft
                       || Player.State == PlayerState.SlidingWallLeft
                       || Player.State == PlayerState.HeadBumpLeft
                       || Player.State == PlayerState.CrouchingLeft
                    )
                    {
                        Player.State = PlayerState.FallingLeft;
                    }
                    else if (Player.State == PlayerState.WalkingRight
                        || Player.State == PlayerState.StandingRight
                        || Player.State == PlayerState.SlidingWallRight
                        || Player.State == PlayerState.HeadBumpRight
                        || Player.State == PlayerState.CrouchingRight
                    )
                    {
                        Player.State = PlayerState.FallingRight;
                    }
                    else if (Player.State == PlayerState.FallingLeft
                        && Player.Inputs.Right)
                    {
                        Player.State = PlayerState.FallingRight;
                    }
                    else if (Player.State == PlayerState.FallingRight
                        && Player.Inputs.Left)
                    {
                        Player.State = PlayerState.FallingLeft;
                    }
                }
            }
        }
    }
}
