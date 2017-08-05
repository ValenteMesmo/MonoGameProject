using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class ChangeToStandingState : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeToStandingState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.LegState == LegState.TakingDamage
                || Player.TorsoState == TorsoState.AttackCrouching)
                return;

            if (Player.Inputs.Down)
                return;

            if (Player.groundChecker.Colliding<BlockVerticalMovement>()
                //&& !Player.roofChecker.Colliding<BlockVerticalMovement>()
                )
            {
                if ((!Player.Inputs.Left && !Player.Inputs.Right)
                    || (Player.Inputs.Left && Player.Inputs.Right))
                {   
                    Player.LegState = LegState.Standing;
                    Player.TorsoState = TorsoState.Standing;
                }
            }
        }
    }
}
