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
                    FallToTheLeft();
                }
                else if (Player.LegState == LegState.HeadBumpRight)
                {
                    FallToTheRight();
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
                    FallToTheLeft();
                }
                else if (Player.LegState == LegState.WalkingRight
                    || Player.LegState == LegState.StandingRight
                    || Player.LegState == LegState.SlidingWallRight
                    || Player.LegState == LegState.HeadBumpRight
                    || Player.LegState == LegState.CrouchingRight
                )
                {
                    FallToTheRight();
                }
                else if (Player.LegState == LegState.FallingLeft
                    && Player.Inputs.Right
                    && !Player.Inputs.Left)
                {
                    FallToTheRight();
                }
                else if (Player.LegState == LegState.FallingRight
                    && Player.Inputs.Left
                    && !Player.Inputs.Right)
                {
                    FallToTheLeft();
                }
            }
        }

        private void FallToTheRight()
        {
            if (Player.TorsoState == TorsoState.AttackLeft)
                return;
            Player.LegState = LegState.FallingRight;
            Player.TorsoState = TorsoState.StandingRight;
        }

        private void FallToTheLeft()
        {
            if (Player.TorsoState == TorsoState.AttackRight)
                return;
            Player.LegState = LegState.FallingLeft;
            Player.TorsoState = TorsoState.StandingLeft;
        }
    }
}
