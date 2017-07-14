using GameCore;

namespace MonoGameProject
{
    public class ChangeToSlidingState : UpdateHandler
    {
        private readonly Player Player;
        private readonly PlayerInputs Input;

        public ChangeToSlidingState(Player Player, PlayerInputs Input)
        {
            this.Player = Player;
            this.Input = Input;
        }

        public void Update()
        {
            if (Player.groundChecker.Colliding == false
                && Player.VerticalSpeed > 0
                && !Player.State.Is(PlayerState.WallJumpingToTheLeft, PlayerState.WallJumpingToTheRight))
            {
                if (Player.leftWallChecker.Colliding
                    && Input.LeftDown)
                {
                    Player.State = PlayerState.SlidingWallLeft;
                }
                else if (Player.rightWallChecker.Colliding
                    && Input.RightDown)
                {
                    Player.State = PlayerState.SlidingWallRight;
                }
            }
        }
    }
}
