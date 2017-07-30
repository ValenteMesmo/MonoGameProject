using GameCore;

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
            if (Player.State == PlayerState.TakingDamage)
                return;

            if (Player.groundChecker.Colliding
                && !Player.roofChecker.Colliding
                && !Player.Inputs.Left
                && !Player.Inputs.Right
                && !Player.Inputs.Down
                )
            {
                if (Player.State == PlayerState.WalkingLeft
                     || Player.State == PlayerState.FallingLeft
                     || Player.State == PlayerState.SlidingWallLeft
                     || Player.State == PlayerState.HeadBumpLeft
                     || Player.State == PlayerState.CrouchingLeft
                 )
                {
                    Player.State = PlayerState.StandingLeft;
                }
                else if (Player.State == PlayerState.WalkingRight
                    || Player.State == PlayerState.FallingRight
                    || Player.State == PlayerState.SlidingWallRight
                    || Player.State == PlayerState.HeadBumpRight
                    || Player.State == PlayerState.CrouchingRight
                )
                {
                    Player.State = PlayerState.StandingRight;
                }
            }
        }
    }
}
