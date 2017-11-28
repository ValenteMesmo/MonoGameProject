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
            cooldown = 60;
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

            boss.AddUpdate(() =>
            {

                if (boss.player == null)
                    return;

                if (boss.state == BossState.BodyAttack1)
                {
                    var speed = 60;

                    if (boss.facingRight)
                        boss.VerticalSpeed= boss.HorizontalSpeed = speed;
                    else
                        boss.VerticalSpeed = boss.HorizontalSpeed = -speed;
                }
            });
        }

        public static void Tree(Boss boss, BossStateController BossStateController)
        {
            boss.AddUpdate(() =>
            {

                if (boss.player == null)
                    return;

                if (boss.state == BossState.BodyAttack1)
                {
                    BossStateController.ChangeState();
                }
            });
        }

    }

    class BossStateController
    {
        private readonly Action<Boss> CreateFireBall;
        private readonly Action UseEyeSpell;
        private readonly Action<Thing> AddToWorld;
        private readonly Boss boss;
        private int state1Duration;
        private const int FULL_ENERGY = 10;
        private int energy = FULL_ENERGY;
        BoolTrigger handAttacking = new BoolTrigger();

        public BossStateController(Boss boss, Action<Thing> AddToWorld, Action<Boss> CreateFireBall, Action UseEyeSpell)
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
                if (state1Duration < 100)
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

        private static bool IsAPlayerAttack(Collider t)
        {
            if (t.Parent is Player)
                return true;

            if (t.Parent is FireBall && (t.Parent as FireBall).Owner is Player)
                return true;

            return false;
        }
    }
}