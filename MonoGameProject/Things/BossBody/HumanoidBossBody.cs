using GameCore;
using System;

namespace MonoGameProject
{
    public class HumanoidBossBody
    {
        private readonly Action<Boss> CreateFireBall;
        private readonly Action ShakeCamera;
        private readonly Action<Thing> AddToWorld;
        private readonly Boss boss;
        private int patience;
        private DelayedAction DelayedAction = new DelayedAction();
        int FireBallDuration;

        int fireballStacks = 3;
        int eyeSpellStacks = 3;

        public HumanoidBossBody(Boss boss, Action<Thing> AddToWorld, Action ShakeCamera, Action<Boss> CreateFireBall)
        {
            this.CreateFireBall = CreateFireBall;
            this.ShakeCamera = ShakeCamera;
            this.AddToWorld = AddToWorld;
            this.boss = boss;
            boss.state = BossState.Idle;

            CreateBodyAnimator(Boss.TORSO_Z);

            boss.AddUpdate(MainUpdate);
        }

        private void MainUpdate()
        {
            if (boss.player == null)
                return;

            boss.damageCooldown--;
            if (boss.damageCooldown < 0)
                boss.damageCooldown = 0;

            stateDuration--;
            if (stateDuration < 0)
                stateDuration = 0;

            IdleCooldown--;
            if (IdleCooldown < 0)
                IdleCooldown = 0;
            
            if (IdleCooldown % 500 == 0)
            {
                fireballStacks++;
                if (fireballStacks > 3)
                    fireballStacks = 3;

                eyeSpellStacks++;
                if (eyeSpellStacks > 3)
                    eyeSpellStacks = 3;
            }

            if (stateDuration == 0)
            {
                ChangeState();
            }

            if (SameHightOfPlayer())
            {
                if (boss.player.MainCollider.Left() > boss.mainCollider.CenterX())
                    DelayedAction.Execute(() => boss.facingRight = true, 25);
                else
                    DelayedAction.Execute(() => boss.facingRight = false, 25);
            }

            if (boss.state == BossState.BodyAttack1)
            {
                if (stateDuration % (5 * 3) == 0)
                    ShakeCamera();

                if (boss.facingRight)
                    boss.HorizontalSpeed = 25 + (boss.damageTaken > 5 ? 15 : 0);
                else
                    boss.HorizontalSpeed = -25 - (boss.damageTaken > 5 ? 15 : 0);

                boss.MouthState = BossMouthState.BiteOpen;
            }
            else if (boss.state == BossState.Idle)
            {
                boss.HorizontalSpeed = 0;
                boss.MouthState = BossMouthState.Idle;
            }
            else if (boss.state == BossState.HeadAttack1)
            {
                if (FireBallDuration <= 0)
                {
                    FireBallDuration = 50;
                    boss.MouthState = BossMouthState.Shoot;
                }

                FireBallDuration--;
                boss.HorizontalSpeed = 0;

                if (FireBallDuration == 25)
                {
                    CreateFireBall(boss);
                }

                if (FireBallDuration == 5)
                {
                    //boss.state = BossState.Idle;
                    boss.MouthState = BossMouthState.Idle;
                }
            }

            if (SameHightOfPlayer())
                patience = 80 - (boss.damageTaken > 10 ? 30 : 0);
            else
                patience--;

            if (patience <= 0)
            {
                if (boss.MyRandom.Next(0, 100) > 50)
                    boss.VerticalSpeed = -150;
                patience = 80 - (boss.damageTaken > 10 ? 30 : 0);
            }

        }

        private int stateDuration;
        private int IdleCooldown = 500;

        private void ChangeState()
        {
            var rnd = boss.MyRandom.Next(2, 4);
            if (boss.grounded && IdleCooldown == 0)
            {
                boss.state = BossState.Idle;
                stateDuration = 150;
                IdleCooldown = 500 + stateDuration;
            }
            else if (rnd == 2 && fireballStacks > 0)
            {
                fireballStacks--;
                boss.state = BossState.HeadAttack1;
                stateDuration = 50;
            }
            else if (rnd == 3 && eyeSpellStacks > 0)
            {
                eyeSpellStacks--;
                boss.state = BossState.EyeAttack;
                stateDuration = 50;
            }
            else
            {
                boss.state = BossState.BodyAttack1;
                stateDuration = 100;
            }
        }

        private bool SameHightOfPlayer()
        {
            return boss.player != null
                && Math.Abs(
                    boss.player.MainCollider.Bottom()
                    - boss.mainCollider.Bottom()
                ) < MapModule.CELL_SIZE * 2;
        }

        private void CreateBodyAnimator(float z)
        {
            return;


            var width = 1500;
            var height = 1500;

            var standing_left = GeneratedContent.Create_knight_human_body(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;
            standing_left.ColorGetter = () => boss.BodyColor;

            var standing_right = GeneratedContent.Create_knight_human_body(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => boss.BodyColor;

            var jump_left = GeneratedContent.Create_knight_human_body(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            jump_left.RenderingLayer = z;
            jump_left.ColorGetter = () => boss.BodyColor;

            var jump_right = GeneratedContent.Create_knight_human_body(
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