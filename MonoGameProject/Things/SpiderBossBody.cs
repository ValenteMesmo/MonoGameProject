using GameCore;
using System;

namespace MonoGameProject
{
    public class SpiderBossBody
    {
        private readonly Boss boss;
        private Player player;
        private int stateCooldown;
        private int directionCooldown;

        public SpiderBossBody(Boss boss)
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
            }
            if (t.Parent is Player)
            {
                player = t.Parent as Player;
            }
        }

        private void UpdateBasedOnState()
        {
            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (SameHightOfPlayer())
            {
                if (player.MainCollider.Left() > boss.mainCollider.Right())
                    boss.facingRight = true;
                else
                    boss.facingRight = false;
            }

            if (stateCooldown <= 0)
            {
                var rnd = boss.MyRandom.Next(0, 2);
                if (rnd == 0 && boss.state != BossState.Idle)
                {
                    boss.state = BossState.Idle;
                    stateCooldown = 150;
                }
                else if (rnd == 1)
                {
                    boss.state = BossState.HeadAttack1;
                    stateCooldown = 50;
                }
                else
                {
                    boss.state = BossState.BodyAttack1;
                    stateCooldown = 100;
                }
            }

            if (boss.state == BossState.BodyAttack1)
            {
                if (directionCooldown <= 0)
                {
                    boss.HorizontalSpeed = 80 * boss.MyRandom.Next(-1, 1);
                    directionCooldown = 15;
                    //if (boss.facingRight && boss.HorizontalSpeed > 0)
                    //    boss.MouthOpen = true;
                    //else if (!boss.facingRight && boss.HorizontalSpeed < 0)
                    //    boss.MouthOpen = true;
                    //else
                    //    boss.MouthOpen = false;
                }
                else
                    directionCooldown--;

                stateCooldown--;
                boss.MouthOpen = true;

            }

            if (boss.state == BossState.Idle)
            {
                boss.HorizontalSpeed = 0;
                boss.MouthOpen = false;
                stateCooldown--;
            }

            if (boss.state == BossState.HeadAttack1)
            {
                boss.HorizontalSpeed = 0;
                boss.MouthOpen = true;
                stateCooldown--;
            }

            Game1.LOG += boss.state;
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