using GameCore;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    class WolfBossBody
    {
        private readonly Action<Thing> AddToWorld;
        private readonly Boss boss;
        private int state1Duration;

        public WolfBossBody(Boss boss, Action<Thing> AddToWorld)
        {
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

            CreateBodyAnimator(Boss.TORSO_Z);

            boss.AddUpdate(UpdateBasedOnState);

            boss.AddUpdate(() => Game.LOG += $@"
{boss.MouthState}");
        }

        private void ChangeState()
        {
            var rnd = boss.MyRandom.Next(1, 5);
            if (boss.state != BossState.Idle && rnd == 1)
            {
                boss.state = BossState.Idle;
                boss.MouthState = BossMouthState.Idle;
                state1Duration = 100;
            }
            else if (rnd == 2)
            {
                boss.state = BossState.BodyAttack1;
                boss.MouthState = BossMouthState.BiteOpen;

                if (boss.MyRandom.Next(0, 100) > 50)
                    boss.VerticalSpeed = -150;
            }
            else if (rnd == 3)
            {
                boss.state = BossState.EyeAttack;
                boss.MouthState = BossMouthState.Shoot;
                state1Duration = 50;
            }
            else
            {
                boss.state = BossState.HeadAttack1;
                boss.MouthState = BossMouthState.Shoot;
                state1Duration = 50;
            }
        }

        private void UpdateBasedOnState()
        {
            if (boss.player == null)
                return;

            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (boss.state == BossState.BodyAttack1)
            {
                if (boss.facingRight)
                    boss.HorizontalSpeed = 100;
                else
                    boss.HorizontalSpeed = -100;
            }

            if (boss.state == BossState.Idle || boss.state == BossState.EyeAttack)
            {
                state1Duration--;
                boss.HorizontalSpeed = 0;
                if (state1Duration <= 0)
                {
                    ChangeState();
                }
            }

            if (boss.state == BossState.HeadAttack1)
            {
                state1Duration--;
                boss.HorizontalSpeed = 0;

                if (state1Duration == 25)
                {
                    var speed = -FireBall.SPEED;
                    if (boss.facingRight)
                        speed = -speed;
                    AddToWorld(new FireBall(speed, 0) { X = boss.attackCollider.X, Y = boss.attackCollider.Y });
                }

                if (state1Duration == 5)
                {
                    //boss.state = BossState.Idle;
                    boss.MouthState = BossMouthState.Idle;
                }

                if (state1Duration <= 0)
                {
                    ChangeState();
                }
            }
            //boss.MouthOpen = boss.HorizontalSpeed != 0;
        }

        private void CreateBodyAnimator(float z)
        {
            var width = 1500;
            var height = 1500;

            var standing_left = GeneratedContent.Create_knight_wolf_body(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;
            standing_left.ColorGetter = () => boss.BodyColor;

            var standing_right = GeneratedContent.Create_knight_wolf_body(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => boss.BodyColor;

            var jump_left = GeneratedContent.Create_knight_wolf_body_jump(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            jump_left.RenderingLayer = z;
            jump_left.ColorGetter = () => boss.BodyColor;

            var jump_right = GeneratedContent.Create_knight_wolf_body_jump(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            jump_right.RenderingLayer = z;
            jump_right.ColorGetter = () => boss.BodyColor;

            var animation =
                new Animator(
                    new AnimationTransitionOnCondition(standing_left, () => !boss.facingRight && boss.grounded)
                    , new AnimationTransitionOnCondition(standing_right, () => boss.facingRight && boss.grounded)
                    , new AnimationTransitionOnCondition(jump_left, () => !boss.facingRight && !boss.grounded)
                    , new AnimationTransitionOnCondition(jump_right, () => boss.facingRight && !boss.grounded)
            );
            boss.AddAnimation(animation);
        }
    }
}