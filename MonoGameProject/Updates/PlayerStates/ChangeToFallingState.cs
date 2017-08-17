using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class ChangeToFallingState : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeToFallingState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.LegState == LegState.TakingDamage
                || Player.LegState == LegState.WallJumping)
                return;

            if (Player.groundChecker.Colliding<BlockVerticalMovement>())
            {
                if (Player.LegState == LegState.HeadBump)
                {
                    FallToTheLeft();
                }
            }
            else
            {
                FallToTheLeft();
            }
        }

        private void FallToTheLeft()
        {
            Player.HeadState = HeadState.Standing;
            Player.LegState = LegState.Falling;

            if (Player.TorsoState == TorsoState.Attack)
                return;
            Player.TorsoState = TorsoState.Standing;
        }
    }
}
