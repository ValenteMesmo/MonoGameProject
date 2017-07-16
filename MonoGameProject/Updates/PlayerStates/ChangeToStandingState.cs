using GameCore;

namespace MonoGameProject
{
    public class ChangeToStandingState : UpdateHandler
    {
        private readonly Player Player;

        public ChangeToStandingState(Player Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.groundChecker.Colliding
                && !Player.Inputs.LeftDown
                && !Player.Inputs.RightDown
                && !Player.Inputs.DownDown
                )
            {
                if (Player.State.Is(
                     PlayerState.WalkingLeft
                     , PlayerState.FallingLeft
                     , PlayerState.SlidingWallLeft
                     , PlayerState.HeadBumpLeft
                     , PlayerState.crouchingLeft
                     , PlayerState.crouchWalkingLeft
                     )
                 )
                {
                    Player.State = PlayerState.StandingLeft;
                }
                else if (Player.State.Is(
                    PlayerState.WalkingRight
                    , PlayerState.FallingRight
                    , PlayerState.SlidingWallRight
                    , PlayerState.HeadBumpRight
                    , PlayerState.crouchingRight
                     , PlayerState.crouchWalkingRight
                    )
                )
                {
                    Player.State = PlayerState.StandingRight;
                }
            }
        }
    }
}
