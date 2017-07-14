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
            if (Player.HorizontalSpeed == 0
                && Player.groundChecker.Colliding)
            {
                if (Player.State.Is(
                     PlayerState.WalkingLeft
                     , PlayerState.FallingLeft
                     , PlayerState.SlidingWallLeft
                     , PlayerState.HeadBumpLeft
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
                    )
                )
                {
                    Player.State = PlayerState.StandingRight;
                }
            }
        }
    }
}
