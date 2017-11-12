using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject.Updates.PlayerStates
{
    class ChangeToCrouchState : UpdateHandler
    {
        public readonly Humanoid Player;
        private readonly VibrationCenter VibrationCenter;
        private readonly Camera2d Camera;

        public ChangeToCrouchState(Humanoid Player, Camera2d Camera, VibrationCenter VibrationCenter)
        {
            this.Player = Player;
            this.VibrationCenter = VibrationCenter;
            this.Camera = Camera;
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
                    VibrationCenter.Vibrate(Player.Inputs, 7,0.25f);
                    Camera.ShakeUp(7);

                    Player.LegState = LegState.SweetDreams;
                    Player.TorsoState = TorsoState.Crouch;
                    Player.HeadState = HeadState.Crouching;
                }
            }
        }
    }
}
