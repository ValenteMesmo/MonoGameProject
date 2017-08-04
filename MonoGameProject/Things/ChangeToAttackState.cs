using GameCore;

namespace MonoGameProject
{
    public class ChangeToAttackState : UpdateHandler
    {
        private readonly Humanoid Humanoid;
        private int AttackDuration = 0;

        public ChangeToAttackState(Humanoid Humanoid)
        {
            this.Humanoid = Humanoid;
        }

        public void Update()
        {
            if (Humanoid.Inputs.ClickedAction1
                && AttackDuration <= 0)
            {
                AttackDuration = 20;
            }

            Humanoid.AttackLeftCollider.Disabled = true;
            Humanoid.AttackRightCollider.Disabled = true;

            if (AttackDuration > 0)
            {
                ChangeToAttackMode();
                AttackDuration--;
                if (AttackDuration <= 0)
                {
                    ChangeToNotAttackMode();
                }
            }
        }

        private void ChangeToNotAttackMode()
        {
            if (Humanoid.TorsoState == TorsoState.AttackLeft)
            {
                Humanoid.TorsoState = TorsoState.StandingLeft;
                return;
            }

            if (Humanoid.TorsoState == TorsoState.AttackRight)
            {
                Humanoid.TorsoState = TorsoState.StandingRight;
                return;
            }

            if (Humanoid.TorsoState == TorsoState.AttackCrouchingLeft)
            {
                Humanoid.TorsoState = TorsoState.CrouchLeft;
                return;
            }

            if (Humanoid.TorsoState == TorsoState.AttackCrouchingRight)
            {
                Humanoid.TorsoState = TorsoState.CrouchRight;
                return;
            }
        }

        private void ChangeToAttackMode()
        {
            var enableDuration = 15;

            if (Humanoid.LegState == LegState.FallingLeft
                || Humanoid.LegState == LegState.HeadBumpLeft
                || Humanoid.LegState == LegState.SlidingWallRight
                || Humanoid.LegState == LegState.StandingLeft
                || Humanoid.LegState == LegState.WalkingLeft
                || Humanoid.LegState == LegState.WallJumpingToTheLeft
                )
            {
                if (AttackDuration < enableDuration)
                    Humanoid.AttackLeftCollider.Disabled = false;

                Humanoid.TorsoState = TorsoState.AttackLeft;
                return;
            }

            if (Humanoid.LegState == LegState.FallingRight
               || Humanoid.LegState == LegState.HeadBumpRight
               || Humanoid.LegState == LegState.SlidingWallLeft
               || Humanoid.LegState == LegState.StandingRight
               || Humanoid.LegState == LegState.WalkingRight
               || Humanoid.LegState == LegState.WallJumpingToTheRight
               )
            {
                if (AttackDuration < enableDuration)
                    Humanoid.AttackRightCollider.Disabled = false;

                Humanoid.TorsoState = TorsoState.AttackRight;
                return;
            }

            if (Humanoid.LegState == LegState.CrouchingRight
            )
            {
                if (AttackDuration < enableDuration)
                    Humanoid.AttackRightCollider.Disabled = false;

                Humanoid.TorsoState = TorsoState.AttackCrouchingRight;
                return;
            }

            if (Humanoid.LegState == LegState.CrouchingLeft)
            {
                if (AttackDuration < enableDuration)
                    Humanoid.AttackLeftCollider.Disabled = false;

                Humanoid.TorsoState = TorsoState.AttackCrouchingLeft;
                return;
            }
        }
    }
}
