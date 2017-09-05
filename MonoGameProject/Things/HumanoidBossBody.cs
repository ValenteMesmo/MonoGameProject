using GameCore;
using System;

namespace MonoGameProject
{
    public class HumanoidBossBody
    {
        private readonly Boss boss;
        private int patience;
        private Player player;

        public HumanoidBossBody(Boss boss)
        {
            this.boss = boss;
            boss.state = BossState.Idle;
            boss.mainCollider.AddCollisionHandler(FindPlayer);

            CreateBodyAnimator(Boss.TORSO_Z);

            boss.AddUpdate(MainUpdate);
        }

        private void FindPlayer(Collider s, Collider t)
        {
            if (s.Parent is Player)
            {
                player = s.Parent as Player;
            }
            if (t.Parent is Player)
            {
                player = t.Parent as Player;
            }
        }

        private int TurnCooldown;

        private void MainUpdate()
        {
            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (TurnCooldown > 0)
                TurnCooldown--;

            if (SameHightOfPlayer() && TurnCooldown <= 0)
            {
                if (player.MainCollider.Left() > boss.mainCollider.CenterX())
                    boss.facingRight = true;
                else
                    boss.facingRight = false;

                TurnCooldown = 50;
            }

            ChangeState();

            if (boss.state == BossState.BodyAttack1)
            {
                //if (SameHightOfPlayer())
                //{
                if (boss.facingRight)
                    boss.HorizontalSpeed = 25 + (boss.damageTaken > 5 ? 15 : 0);
                else
                    boss.HorizontalSpeed = -25 - (boss.damageTaken > 5 ? 15 : 0);

                boss.MouthOpen = true;
                //}
                //else
                //{
                //    boss.HorizontalSpeed = 0;
                //    boss.MouthOpen = false;
                //}
            }
            else if (boss.state == BossState.Idle)
            {
                boss.HorizontalSpeed = 0;
                boss.MouthOpen = false;
            }
            else if (boss.state == BossState.HeadAttack1)
            {
                boss.HorizontalSpeed = 0;
                boss.MouthOpen = false;
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
        private void ChangeState()
        {
            stateDuration--;
            if (stateDuration > 0)
                return;

            var rnd = boss.MyRandom.Next(1, 3);
            if (rnd == 1
                && boss.state != BossState.Idle
                && boss.grounded)
            {
                boss.state = BossState.Idle;
                stateDuration = 150;
            }
            else if (rnd == 2)
            {
                boss.state = BossState.HeadAttack1;
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
            return player != null
                && Math.Abs(
                    player.MainCollider.Bottom()
                    - boss.mainCollider.Bottom()
                ) < MapModule.CELL_SIZE * 2;
        }

        private void CreateBodyAnimator(float z)
        {
            var width = 1500;
            var height = 1500;

            var standing_left = GeneratedContent.Create_knight_spider_body(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            standing_left.RenderingLayer = z;
            standing_left.ColorGetter = () => boss.BodyColor;

            var standing_right = GeneratedContent.Create_knight_spider_body(
                    -width / 2
                    , -height
                    , width * 2
                    , height * 2
                    , true
            );
            standing_right.RenderingLayer = z;
            standing_right.ColorGetter = () => boss.BodyColor;

            var jump_left = GeneratedContent.Create_knight_spider_body_jump(
                                -width / 2
                                , -height
                                , width * 2
                                , height * 2
                                , false
                            );
            jump_left.RenderingLayer = z;
            jump_left.ColorGetter = () => boss.BodyColor;

            var jump_right = GeneratedContent.Create_knight_spider_body_jump(
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