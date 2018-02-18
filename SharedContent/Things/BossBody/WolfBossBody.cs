using GameCore;
using MonoGameProject.Things;
using System;
using System.Linq;

namespace MonoGameProject
{
    public class BoolTrigger
    {
        int duration = 0;
        int cooldown = 0;

        public void Activate()
        {
            if (cooldown > 0)
                return;

            duration = 30;
            cooldown = 120;
        }

        public void Update()
        {
            if (duration > 0)
                duration--;

            if (cooldown > 0)
                cooldown--;
        }

        public bool IsActivated()
        {
            return duration > 0;
        }
    }


    class BossMovementTypes
    {
        public static void Wolf(Boss boss, BossStateController BossStateController)
        {
            boss.mainCollider.AddLeftCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    boss.facingRight = true;
                    BossStateController.ChangeState();
                }
            });

            boss.mainCollider.AddRightCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    boss.facingRight = false;
                    BossStateController.ChangeState();
                }
            });

            boss.AddUpdate(() =>
            {
                if (boss.player == null)
                    return;

                if (boss.state == BossState.BodyAttack1)
                {
                    var speed = 60;

                    if (boss.facingRight)
                        boss.HorizontalSpeed = speed;
                    else
                        boss.HorizontalSpeed = -speed;
                }
            });
        }

        public static void Bird(Boss boss, BossStateController BossStateController)
        {
            boss.mainCollider.AddLeftCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    boss.facingRight = true;
                    BossStateController.ChangeState();
                }
            });

            boss.mainCollider.AddRightCollisionHandler((s, t) =>
            {
                if (t is BlockHorizontalMovement)
                {
                    boss.facingRight = false;
                    BossStateController.ChangeState();
                }
            });

            var vspeed = -80;
            var vel = 4;
            boss.AddUpdate(() =>
            {
                if (boss.player == null)
                    return;

                if (vspeed >= 80)
                    vel = -4;
                if (vspeed <= -80)
                    vel = +2;

                vspeed += vel;

                if (boss.state == BossState.BodyAttack1)
                {
                    var speed = 40;

                    if (boss.facingRight)
                        boss.HorizontalSpeed = speed;
                    else
                        boss.HorizontalSpeed = -speed;

                    boss.VerticalSpeed = vspeed;
                }

            });
        }
    }

    class BossStateController
    {
        private readonly Func<Boss,int> CreateFireBall;
        private readonly Func<int> UseEyeSpell;
        private readonly Action<Thing> AddToWorld;
        private readonly Boss boss;
        private int state1Duration;
        private const int FULL_ENERGY = 10;
        private int energy = FULL_ENERGY;
        BoolTrigger handAttacking = new BoolTrigger();
        private int damageWhenIdleStarted = Boss.HEALTH;

        public BossStateController(Boss boss, Action<Thing> AddToWorld, Func<Boss,int> CreateFireBall, Func<int> UseEyeSpell)
        {
            this.CreateFireBall = CreateFireBall;
            this.UseEyeSpell = UseEyeSpell;
            this.AddToWorld = AddToWorld;
            this.boss = boss;
            boss.state = BossState.BodyAttack1;

            boss.AddUpdate(UpdateBasedOnState);
        }

        public void ChangeState()
        {
            if (energy == 0)
            {
                boss.state = BossState.Idle;
                damageWhenIdleStarted = boss.PlayerDamageHandler.damageTaken;
                boss.MouthState = BossMouthState.Tired;
                state1Duration = 500;
                energy = FULL_ENERGY;
                return;
            }

            energy--;

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
                boss.MouthState = BossMouthState.Idle;
            }
        }

        private void UpdateBasedOnState()
        {
            if (boss.player == null)
                return;

            if (state1Duration > 0)
                state1Duration--;

            if (boss.state != BossState.Idle)
                foreach (var collider in boss.playerFinder.CollidingWith)
                {
                    if (IsAPlayerAttack(collider))
                    {
                        handAttacking.Activate();
                        break;
                    }
                }
            handAttacking.Update();
            boss.AttackingWithTheHand = handAttacking.IsActivated();

            if (boss.state == BossState.BodyAttack1)
            {
                //each body implements an update... srry
            }

            if (boss.state == BossState.Idle)
            {
                if (state1Duration > 25
                    && boss.PlayerDamageHandler.damageTaken - damageWhenIdleStarted >= 6)
                    state1Duration = 25;

                if (state1Duration < 25)
                {
                    boss.MouthState = BossMouthState.Idle;
                }

                boss.HorizontalSpeed = 0;
                if (state1Duration <= 0)
                {
                    ChangeState();
                }
            }

            if (boss.state == BossState.EyeAttack)
            {
                if (boss.grounded == false)
                    state1Duration++;

                boss.HorizontalSpeed = 0;

                if (state1Duration == 70)
                {
                    state1Duration = UseEyeSpell();
                }

                boss.MouthState = BossMouthState.Idle;

                if (state1Duration <= 0)
                {
                    ChangeState();
                }
            }

            if (boss.state == BossState.HeadAttack1)
            {
                if (boss.grounded == false)
                    state1Duration++;

                boss.HorizontalSpeed = 0;

                if (state1Duration == 40)
                {
                    state1Duration = CreateFireBall(boss);
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

        private static bool IsAPlayerAttack(Collider t)
        {
            if (t.Parent is Player && t is AttackCollider == false)
                return true;

            if (t.Parent is FireBall && (t.Parent as FireBall).Owner is Player)
                return true;

            return false;
        }
    }
}