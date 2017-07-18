using GameCore;

namespace MonoGameProject
{
    public class ChangeToStandingState : UpdateHandler
    {
        private readonly ThingWithState Player;

        public ChangeToStandingState(ThingWithState Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.groundChecker.Colliding
                && !Player.roofChecker.Colliding
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
                    )
                )
                {
                    Player.State = PlayerState.StandingRight;
                }
            }
        }
    }
}
