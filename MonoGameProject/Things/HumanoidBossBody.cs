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

            CreateBodyAnimator(0.43f);

            boss.AddUpdate(UpdateBasedOnState);
        }

        private void FindPlayer(Collider s, Collider t)
        {
            if (s.Parent is Player)
            {
                player = s.Parent as Player;
                boss.state = BossState.BodyAttack1;
            }
            if (t.Parent is Player)
            {
                player = t.Parent as Player;
                boss.state = BossState.BodyAttack1;
            }
        }

        private void UpdateBasedOnState()
        {
            //if (boss.state == BossState.Idle)
            //    return;

            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (SameHightOfPlayer())
            {
                if (player.MainCollider.Left() > boss.mainCollider.Right())
                    boss.facingRight = true;
                else
                    boss.facingRight = false;
            }

            if (SameHightOfPlayer())
                boss.state = BossState.BodyAttack1;
            else
                boss.state = BossState.BodyAttack2;

            if (boss.state == BossState.BodyAttack1)
            {
                if (SameHightOfPlayer())
                {
                    if (boss.facingRight)
                        boss.HorizontalSpeed = 25 + (boss.damageTaken > 5 ? 25 : 0);
                    else
                        boss.HorizontalSpeed = -25 - (boss.damageTaken > 5 ? 25 : 0);

                    boss.MouthOpen = true;
                }
                else
                {
                    boss.HorizontalSpeed = 0;
                    boss.MouthOpen = false;
                }
            }

            if (boss.state == BossState.BodyAttack2)
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