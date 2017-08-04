using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject.Updates.PlayerStates
{
    class ChangeToCrouchState : UpdateHandler
    {
        public readonly Humanoid Player;

        public ChangeToCrouchState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.LegState == LegState.TakingDamage)
                return;
            if (Player.TorsoState == TorsoState.AttackRight)
                return;
            if (Player.TorsoState == TorsoState.AttackLeft)
                return;

            if (Player.Inputs.Down
                && Player.groundChecker.Colliding<BlockVerticalMovement>())
            {
                if (Player.LegState == LegState.StandingRight
                    || Player.LegState == LegState.WalkingRight
                    || Player.LegState == LegState.FallingRight)
                {
                    Player.LegState = LegState.CrouchingRight;
                    Player.TorsoState = TorsoState.CrouchRight;
                    return;
                }

                if (Player.LegState == LegState.StandingLeft
                    || Player.LegState == LegState.WalkingLeft
                    || Player.LegState == LegState.FallingLeft)
                {
                    Player.LegState = LegState.CrouchingLeft;
                    Player.TorsoState = TorsoState.CrouchLeft;
                    return;
                }
            }
        }
    }
}
