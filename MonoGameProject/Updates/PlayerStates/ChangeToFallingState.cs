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
                if (Player.LegState == LegState.HeadBumpLeft)
                {
                    Player.LegState = LegState.FallingLeft;
                    Player.TorsoState = TorsoState.StandingLeft;
                }
                else if (Player.LegState == LegState.HeadBumpRight)
                {
                    Player.LegState = LegState.FallingRight;
                    Player.TorsoState = TorsoState.StandingRight;
                }
            }
            else
            {
                if (Player.LegState == LegState.WalkingLeft
                   || Player.LegState == LegState.StandingLeft
                   || Player.LegState == LegState.SlidingWallLeft
                   || Player.LegState == LegState.HeadBumpLeft
                   || Player.LegState == LegState.CrouchingLeft
                )
                {
                    Player.LegState = LegState.FallingLeft;
                    Player.TorsoState = TorsoState.StandingLeft;
                }
                else if (Player.LegState == LegState.WalkingRight
                    || Player.LegState == LegState.StandingRight
                    || Player.LegState == LegState.SlidingWallRight
                    || Player.LegState == LegState.HeadBumpRight
                    || Player.LegState == LegState.CrouchingRight
                )
                {
                    Player.LegState = LegState.FallingRight;
                    Player.TorsoState = TorsoState.StandingRight;
                }
                else if (Player.LegState == LegState.FallingLeft
                    && Player.Inputs.Right
                    && !Player.Inputs.Left)
                {
                    Player.LegState = LegState.FallingRight;
                    Player.TorsoState = TorsoState.StandingRight;
                }
                else if (Player.LegState == LegState.FallingRight
                    && Player.Inputs.Left
                    && !Player.Inputs.Right)
                {
                    Player.LegState = LegState.FallingLeft;
                    Player.TorsoState = TorsoState.StandingLeft;
                }
            }
        }
    }
}
