using GameCore;
using System;

namespace MonoGameProject
{
    public class ChangeToAttackState : UpdateHandler
    {
        private readonly Humanoid Humanoid;
        private readonly Action<Thing> AddToWorld;
        private int AttackDuration = 0;

        public ChangeToAttackState(Humanoid Humanoid, Action<Thing> AddToWorld)
        {
            this.Humanoid = Humanoid;
            this.AddToWorld = AddToWorld;
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
                    if (Humanoid.weaponType == 3)
                    {
                        int speed = -FireBall.SPEED;
                        var x = Humanoid.AttackLeftCollider.X;
                        if (Humanoid.FacingRight)
                        {
                            speed = FireBall.SPEED;
                            x = Humanoid.AttackRightCollider.X;
                        }

                        AddToWorld(new FireBall(Humanoid, speed, 0, AddToWorld)
                        {
                            X = x,
                            Y = Humanoid.AttackRightCollider.Y
                        });
                    }
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

            if (AttackDuration < enableDuration && Humanoid.weaponType != 3)
            {
                Humanoid.AttackLeftCollider.Disabled = Humanoid.FacingRight;
                Humanoid.AttackRightCollider.Disabled = !Humanoid.FacingRight;
            }

            if (Humanoid.LegState == LegState.Crouching || Humanoid.LegState == LegState.SweetDreams)
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
