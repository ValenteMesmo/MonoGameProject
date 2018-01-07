using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class ChangeToAttackState : UpdateHandler
    {
        private readonly Humanoid Humanoid;
        private readonly Game1 Game1;
        private int AttackDuration = 0;
        private int AttackCooldown = 0;

        public ChangeToAttackState(Humanoid Humanoid, Game1 Game1)
        {
            this.Humanoid = Humanoid;
            this.Game1 = Game1;
        }

        public void Update()
        {
            //            Game.LOG += @"
            //Attack cd: "+ AttackDuration;
            if (Humanoid.Inputs.ClickedAction1
                && AttackDuration <= 0
                && AttackCooldown == 0)
            {
                if (Humanoid.weaponType == WeaponType.Sword)
                {
                    AttackDuration = 18;
                    AttackCooldown = AttackDuration + 6;
                }
                else if (Humanoid.weaponType == WeaponType.Whip)
                {
                    AttackDuration = 18;
                    AttackCooldown = AttackDuration + 3;
                }
                else
                {                    
                    AttackDuration = 16;
                    AttackCooldown = AttackDuration + 0;
                }

                //if (Game1.MusicController.Queue("beat2") == false)
                //    Game1.MusicController.Force("beat1");
                ////Game1.MusicController.Queue("beat2");
            }

            Humanoid.AttackLeftCollider.Disabled = true;
            Humanoid.AttackRightCollider.Disabled = true;

            if (AttackCooldown > 0)
                AttackCooldown--;

            if (AttackDuration > 0)
            {
                ChangeToAttackMode();
                AttackDuration--;
                if (AttackDuration <= 0)
                {
                    if (Humanoid.weaponType == WeaponType.Wand)
                    {
                        int speed = -FireBall.SPEED;
                        var x = Humanoid.AttackLeftCollider.X;
                        if (Humanoid.FacingRight)
                        {
                            speed = FireBall.SPEED;
                            x = Humanoid.AttackRightCollider.X;
                        }

                        var fireball = new FireballDefault(Humanoid, speed, 0, Game1, Color.LightBlue)
                        {
                            X = x,
                            Y = Humanoid.AttackRightCollider.Y - 50
                        };
                        fireball.collider.AddHandler((s, t) =>
                        {
                            if (t.Parent is Boss && t is AttackCollider)
                                fireball.Destroy();
                        });
                        fireball.duration = 50;
                        Game1.AddToWorld(fireball);
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

            if (AttackDuration < enableDuration && Humanoid.weaponType != WeaponType.Wand)
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
