using GameCore;

namespace MonoGameProject
{
    public class ChangeToSlidingState : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeToSlidingState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.TakingDamage)
                return;

            if (Player.groundChecker.Colliding == false
                && Player.VerticalSpeed > 0
                && Player.State != PlayerState.WallJumpingToTheLeft
                && Player.State != PlayerState.WallJumpingToTheRight)
            {
                if (Player.leftWallChecker.Colliding
                    && Player.Inputs.Left)
                {
                    Player.State = PlayerState.SlidingWallLeft;
                }
                else if (Player.rightWallChecker.Colliding
                    && Player.Inputs.Right)
                {
                    Player.State = PlayerState.SlidingWallRight;
                }
            }
        }
    }
}
