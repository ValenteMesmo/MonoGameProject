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
            if (Humanoid.TorsoState == TorsoState.Attack)
            {
                Humanoid.TorsoState = TorsoState.Standing;
                return;
            }

            if (Humanoid.TorsoState == TorsoState.AttackCrouching)
            {
                Humanoid.TorsoState = TorsoState.Crouch;
                return;
            }
        }

        private void ChangeToAttackMode()
        {
            var enableDuration = 15;

            if (AttackDuration < enableDuration)
                Humanoid.AttackLeftCollider.Disabled = false;

            if (Humanoid.LegState == LegState.Crouching)
            {
                Humanoid.TorsoState = TorsoState.AttackCrouching;
            }
            else
            {
                Humanoid.TorsoState = TorsoState.Attack;
            }
        }
    }
}
