using GameCore;
using MonoGameProject.Things;
using System;
using System.Linq;

namespace MonoGameProject
{
    class WolfBossBody
    {
        private readonly Action<Boss> CreateFireBall;
        private readonly Action UseEyeSpell;
        private readonly Action<Thing> AddToWorld;
        private readonly Boss boss;
        private int state1Duration;

        public WolfBossBody(Boss boss, Action<Thing> AddToWorld, Action<Boss> CreateFireBall, Action UseEyeSpell)
        {
            this.CreateFireBall = CreateFireBall;
            this.UseEyeSpell = UseEyeSpell;
            this.AddToWorld = AddToWorld;
            this.boss = boss;
            boss.state = BossState.BodyAttack1;

            boss.mainCollider.AddLeftCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    boss.facingRight = true;
                    ChangeState();
                }
            });

            boss.mainCollider.AddRightCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    boss.facingRight = false;
                    ChangeState();
                }
            });

            boss.AddUpdate(UpdateBasedOnState);
        }

        private void ChangeState()
        {
            var rnd = boss.MyRandom.Next(1, 3);
            
            if (rnd == 1)
            {
                boss.state = BossState.EyeAttack;
                boss.MouthState = BossMouthState.Idle;
                state1Duration = 90;
            }
            else if (rnd == 2)
            {
                boss.state = BossState.HeadAttack1;
                boss.MouthState = BossMouthState.Shoot;
                state1Duration = 50;
            }
            else
            {
                boss.state = BossState.BodyAttack1;
                boss.MouthState = BossMouthState.BiteOpen;
            }
        }

        private void UpdateBasedOnState()
        {
            if (boss.player == null)
                return;
            
            if (state1Duration > 0)
                state1Duration--;

            boss.AttackingWithTheHand = false;
            if (boss.state == BossState.BodyAttack1)
            {
                foreach (var collider in boss.playerFinder.CollidingWith)
                {
                    if (collider.Parent is Player)
                    {
                        boss.AttackingWithTheHand = true;
                        break;
                    }
                }

                var speed = 60;

                if (boss.facingRight)
                    boss.HorizontalSpeed = speed;
                else
                    boss.HorizontalSpeed = -speed;
            }

            if (boss.state == BossState.Idle)
            {
                boss.HorizontalSpeed = 0;
                if (state1Duration <= 0)
                {
                    ChangeState();
                }
            }
            
            if (boss.state == BossState.EyeAttack)
            {
                boss.HorizontalSpeed = 0;

                if (state1Duration == 70)
                {
                    UseEyeSpell();
                }

                boss.MouthState = BossMouthState.Idle;

                if (state1Duration <= 0)
                {
                    ChangeState();
                }
            }

            if (boss.state == BossState.HeadAttack1)
            {
                boss.HorizontalSpeed = 0;

                if (state1Duration == 40)
                {
                    CreateFireBall(boss);
                }

                if (state1Duration == 15)
                {
                    boss.MouthState = BossMouthState.Idle;
                }

                if (state1Duration <= 0)
                {
                    ChangeState();
                }
            }
        }
    }
}