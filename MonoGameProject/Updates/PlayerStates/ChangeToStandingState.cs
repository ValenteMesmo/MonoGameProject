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
            if (Player.LegState == LegState.TakingDamage)
                return;

            if (Player.groundChecker.Colliding<BlockVerticalMovement>()
                && !Player.roofChecker.Colliding<BlockVerticalMovement>()
                &&
                (
                    (
                        !Player.Inputs.Left
                        && !Player.Inputs.Right
                    )
                    ||
                    (
                        Player.Inputs.Left
                        && Player.Inputs.Right
                    )
                )
                && !Player.Inputs.Down
                )
            {
                if (Player.LegState == LegState.WalkingLeft
                     || Player.LegState == LegState.FallingLeft
                     || Player.LegState == LegState.SlidingWallLeft
                     || Player.LegState == LegState.HeadBumpLeft
                 )
                {
                    Player.LegState = LegState.StandingLeft;
                }
                else if (Player.LegState == LegState.WalkingRight
                    || Player.LegState == LegState.FallingRight
                    || Player.LegState == LegState.SlidingWallRight
                    || Player.LegState == LegState.HeadBumpRight
                )
                {
                    Player.LegState = LegState.StandingRight;
                }
                else if (Player.Inputs.Down == false)
                {
                    if (Player.LegState == LegState.CrouchingLeft
                        )
                    {
                        Player.LegState = LegState.StandingLeft;
                        Player.TorsoState = TorsoState.StandingLeft;
                    }
                    else if (Player.LegState == LegState.CrouchingRight
                        )
                    {
                        Player.LegState = LegState.StandingRight;
                        Player.TorsoState = TorsoState.StandingRight;
                    }
                }
            }
        }
    }
}
