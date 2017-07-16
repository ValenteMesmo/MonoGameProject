using GameCore;

namespace MonoGameProject
{
    public class ChangeToFallingState : UpdateHandler
    {
        private readonly Player Player;
        private readonly PlayerInputs Input;

        public ChangeToFallingState(Player Player, PlayerInputs Input)
        {
            this.Player = Player;
            this.Input = Input;
        }

        public void Update()
        {
            if (Player.groundChecker.Colliding == false
                && !Player.State.Is(
                    PlayerState.WallJumpingToTheLeft
                    , PlayerState.WallJumpingToTheRight))
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
                    && Input.RightDown)
                {
                    Player.State = PlayerState.FallingRight;
                }
                else if (Player.State == PlayerState.FallingRight
                    && Input.LeftDown)
                {
                    Player.State = PlayerState.FallingLeft;
                }
            }
        }
    }
}
