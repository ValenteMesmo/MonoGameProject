using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public interface SlidableWall { }

    public class ChangeToSlidingState : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeToSlidingState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.HeadState == HeadState.Bump
                || Player.TorsoState == TorsoState.Attack)
                return;

            if (Player.groundChecker.Colliding<SlidableWall>() == false
                && Player.VerticalSpeed > 0
                && Player.LegState != LegState.WallJumping)
            {
                if (Player.leftWallChecker.Colliding<SlidableWall>()
                    && Player.Inputs.Left)
                {
                    Player.LegState = LegState.SlidingWall;
                    Player.FacingRight = true;
                }
                else if (Player.rightWallChecker.Colliding<SlidableWall>()
                    && Player.Inputs.Right)
                {
                    Player.LegState = LegState.SlidingWall;
                    Player.FacingRight = false;
                }
            }
        }
    }
}
