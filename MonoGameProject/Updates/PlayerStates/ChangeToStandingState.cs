using GameCore;

namespace MonoGameProject
{
    public class ChangeToStandingState : UpdateHandler
    {
        private readonly ThingWithState Player;

        public ChangeToStandingState(ThingWithState Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.TakingDamage)
                return;

            if (Player.groundChecker.Colliding
                && !Player.roofChecker.Colliding
                && !Player.Inputs.LeftDown
                && !Player.Inputs.RightDown
                && !Player.Inputs.DownDown
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
