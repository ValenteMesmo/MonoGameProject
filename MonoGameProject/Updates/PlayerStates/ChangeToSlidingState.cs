using GameCore;

namespace MonoGameProject
{
    public class ChangeToSlidingState : UpdateHandler
    {
        private readonly ThingWithState Player;

        public ChangeToSlidingState(ThingWithState Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.groundChecker.Colliding == false
                && Player.VerticalSpeed > 0
                && !Player.State.Is(PlayerState.WallJumpingToTheLeft, PlayerState.WallJumpingToTheRight))
            {
                if (Player.leftWallChecker.Colliding
                    && Player.Inputs.LeftDown)
                {
                    Player.State = PlayerState.SlidingWallLeft;
                }
                else if (Player.rightWallChecker.Colliding
                    && Player.Inputs.RightDown)
                {
                    Player.State = PlayerState.SlidingWallRight;
                }
            }
        }
    }
}
