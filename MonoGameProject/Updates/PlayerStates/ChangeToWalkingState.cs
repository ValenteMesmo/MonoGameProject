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
                    if ((Player.LegState == LegState.WalkingLeft
                        || Player.LegState == LegState.StandingLeft
                        || Player.LegState == LegState.CrouchingLeft)
                        &&
                        (Player.TorsoState == TorsoState.AttackLeft
                        || Player.TorsoState == TorsoState.AttackCrouchingLeft))
                    {
                        return;
                    }

                    Player.LegState = LegState.WalkingRight;
                    Player.TorsoState = TorsoState.StandingRight;
                }
                else if (Player.Inputs.Left && !Player.Inputs.Right)
                {
                    if ((Player.LegState == LegState.WalkingRight
                        || Player.LegState == LegState.StandingRight
                        || Player.LegState == LegState.CrouchingRight)
                        &&
                        (Player.TorsoState == TorsoState.AttackRight
                        || Player.TorsoState == TorsoState.AttackCrouchingRight))
                    {
                        return;
                    }

                    Player.LegState = LegState.WalkingLeft;
                    Player.TorsoState = TorsoState.StandingLeft;
                }
            }
        }
    }
}
