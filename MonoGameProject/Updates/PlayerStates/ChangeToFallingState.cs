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
            if (Player.LegState == LegState.TakingDamage)
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
                if (Player.LegState == LegState.Walking
                   || Player.LegState == LegState.Standing
                   || Player.LegState == LegState.SlidingWall
                   || Player.LegState == LegState.HeadBump
                   || Player.LegState == LegState.Crouching
                )
                {
                    FallToTheLeft();
                }
                else if (Player.LegState == LegState.Falling
                    && Player.Inputs.Right
                    && !Player.Inputs.Left)
                {
                    FallToTheLeft();
                }
            }
        }

        private void FallToTheLeft()
        {
            if (Player.TorsoState == TorsoState.Attack)
                return;
            Player.LegState = LegState.Falling;
            Player.TorsoState = TorsoState.Standing;
        }
    }
}
