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
            if (Player.TorsoState == TorsoState.Attack)
                return;

            if (Player.Inputs.Down
                && Player.groundChecker.Colliding<BlockVerticalMovement>())
            {
                if (Player.LegState == LegState.Standing
                    || Player.LegState == LegState.Walking)
                {
                    Player.LegState = LegState.Crouching;
                    Player.TorsoState = TorsoState.Crouch;
                    Player.HeadState = HeadState.Crouching;
                }
                else if (Player.LegState == LegState.Falling)
                {
                    Player.LegState = LegState.SweetDreams;
                    Player.TorsoState = TorsoState.Crouch;
                    Player.HeadState = HeadState.Crouching;
                }
            }
        }
    }
}
