using GameCore;

namespace MonoGameProject
{
    public class ChangeToFallingState : UpdateHandler
    {
        private readonly ThingWithState Player;

        public ChangeToFallingState(ThingWithState Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (!Player.State.Is(
                    PlayerState.WallJumpingToTheLeft
                    , PlayerState.WallJumpingToTheRight))
            {
                if (Player.groundChecker.Colliding)
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
                    if (Player.State.Is(
                       PlayerState.WalkingLeft
                       , PlayerState.StandingLeft
                       , PlayerState.SlidingWallLeft
                       , PlayerState.HeadBumpLeft
                       , PlayerState.crouchingLeft
                       )
                    )
                    {
                        Player.State = PlayerState.FallingLeft;
                    }
                    else if (Player.State.Is(
                        PlayerState.WalkingRight
                        , PlayerState.StandingRight
                        , PlayerState.SlidingWallRight
                        , PlayerState.HeadBumpRight
                        , PlayerState.crouchingRight
                        )
                    )
                    {
                        Player.State = PlayerState.FallingRight;
                    }
                    else if (Player.State == PlayerState.FallingLeft
                        && Player.Inputs.RightDown)
                    {
                        Player.State = PlayerState.FallingRight;
                    }
                    else if (Player.State == PlayerState.FallingRight
                        && Player.Inputs.LeftDown)
                    {
                        Player.State = PlayerState.FallingLeft;
                    }
                }
            }
        }
    }
}
