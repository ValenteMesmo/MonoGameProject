using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class ChangeToWalkingState : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeToWalkingState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.LegState == LegState.TakingDamage)
                return;

            if (Player.groundChecker.Colliding<BlockVerticalMovement>()
                && !Player.roofChecker.Colliding<BlockVerticalMovement>()
                && Player.VerticalSpeed >= 0)
            {
                if (Player.Inputs.Right && !Player.Inputs.Left)
                {
                    Player.LegState = LegState.WalkingRight;
                    Player.TorsoState = TorsoState.StandingRight;
                }
                else if (Player.Inputs.Left && !Player.Inputs.Right)
                {
                    Player.LegState = LegState.WalkingLeft;
                    Player.TorsoState = TorsoState.StandingLeft;
                }
            }
        }
    }
}
