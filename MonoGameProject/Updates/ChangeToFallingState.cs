using GameCore;

namespace MonoGameProject
{
    public class ChangeToFallingState : UpdateHandler
    {
        private readonly Player Player;

        public ChangeToFallingState(Player Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.groundChecker.Colliding == false)
            {
                if (Player.State.Is(
                   PlayerState.WalkingLeft
                   , PlayerState.StandingLeft
                   , PlayerState.SlidingWallLeft
                   )
                )
                {
                    Player.State = PlayerState.FallingLeft;
                }
                else if (Player.State.Is(
                    PlayerState.WalkingRight
                    , PlayerState.StandingRight
                    , PlayerState.SlidingWallRight
                    )
                )
                {
                    Player.State = PlayerState.FallingRight;
                }
            }
        }
    }
}
