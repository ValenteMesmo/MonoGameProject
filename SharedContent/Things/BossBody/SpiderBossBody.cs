using GameCore;
using System;

namespace MonoGameProject
{
    public class SpiderBossBody
    {
        private readonly Action<Boss> CreateFireBall;
        private readonly Boss boss;
        private readonly Action<Thing> AddToWorld;
        private int stateCooldown;
        private DelayedAction DelayedAction = new DelayedAction();
        int flyingMod = -1;
        int horizontalSpeedMod = 0;
        private int IdleCooldown = 500;
        int fireballStacks = 3;
        int eyeSpellStacks = 3;

        public SpiderBossBody(Boss boss, Action<Thing> AddToWorld, Action<Boss> CreateFireBall)
        {
            horizontalSpeedMod = boss.MyRandom.Next(0, 1) == 0 ? -1 : 1;

            this.CreateFireBall = CreateFireBall;
            this.boss = boss;
            this.AddToWorld = AddToWorld;
            boss.state = BossState.Idle;
            boss.mainCollider.AddLeftCollisionHandler(LeftCollision);
            boss.mainCollider.AddRightCollisionHandler(RightCollision);
            boss.mainCollider.AddTopCollisionHandler(TopCollision);
            boss.mainCollider.AddBotCollisionHandler(TopCollision);

            //CreateBodyAnimator(Boss.TORSO_Z);

            boss.AddUpdate(UpdateBasedOnState);
        }


        private void RightCollision(Collider s, Collider t)
        {
            if (t is GroundCollider)
                horizontalSpeedMod = -1;
        }

        private void TopCollision(Collider s, Collider t)
        {
            if (t is GroundCollider)
                flyingMod = boss.MyRandom.Next(-1, 1);
        }

        private void LeftCollision(Collider s, Collider t)
        {
            if (t is GroundCollider)
                horizontalSpeedMod = 1;
        }

        private void UpdateBasedOnState()
        {
            if (boss.player == null)
                return;

            if (IdleCooldown > 0)
                IdleCooldown--;

            if (IdleCooldown % 500 == 0)
            {
                fireballStacks++;
                if (fireballStacks > 3)
                    fireballStacks = 3;

                eyeSpellStacks++;
                if (eyeSpellStacks > 2)
                    eyeSpellStacks = 2;
            }

            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (boss.player != null
                && boss.state != BossState.Idle
                && boss.state != BossState.EyeAttack)
            {
                if (boss.player.MainCollider.Left() > boss.mainCollider.Right())
                    DelayedAction.Execute(() => boss.facingRight = true, 25);
                else
                    DelayedAction.Execute(() => boss.facingRight = false, 25);
            }

            if (stateCooldown <= 0)
            {
                ChangeState();
            }

            if (boss.state != BossState.Idle)
                boss.VerticalSpeed = 40 * flyingMod;

            if (boss.state == BossState.BodyAttack1)
            {
                boss.HorizontalSpeed = 80 * horizontalSpeedMod;

                stateCooldown--;
                boss.MouthState = BossMouthState.BiteOpen;
            }

            if (boss.state == BossState.Idle || boss.state == BossState.EyeAttack)
            {
                //if (boss.state == BossState.Idle)
                boss.HorizontalSpeed = 0;
                boss.MouthState = BossMouthState.Idle;
                stateCooldown--;
            }

            if (boss.state == BossState.HeadAttack1)
            {
                stateCooldown--;
                boss.HorizontalSpeed = 0;

                if (stateCooldown == 25)
                {
                    CreateFireBall(boss);
                }

                if (stateCooldown == 5)
                {
                    //boss.state = BossState.Idle;
                    boss.MouthState = BossMouthState.Idle;
                }

                if (stateCooldown <= 0)
                {
                    ChangeState();
                }
            }

            Game1.LOG += boss.state;
        }

        private void ChangeState()
        {
            var rnd = boss.MyRandom.Next(2, 6);

            if (IdleCooldown == 0)
            {
                boss.state = BossState.Idle;
                stateCooldown = 250;
                IdleCooldown = 500 + stateCooldown;
            }
            else if (rnd <= 2 && eyeSpellStacks > 0)
            {
                eyeSpellStacks--;
                boss.state = BossState.EyeAttack;
                stateCooldown = 100;
            }
            else if (rnd <= 3 && fireballStacks > 0)
            {
                fireballStacks--;
                boss.state = BossState.HeadAttack1;
                boss.MouthState = BossMouthState.Shoot;
                stateCooldown = 50;
            }
            else
            {
                boss.state = BossState.BodyAttack1;
                stateCooldown = 100;
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

        //private void CreateBodyAnimator(float z)
        //{
        //    var width = 1500;
        //    var height = 1500;

        //    var standing_left = GeneratedContent.Create_knight_spider_body(
        //                        -width / 2
        //                        , -height
        //                        , width * 2
        //                        , height * 2
        //                        , false
        //                    );
        //    standing_left.RenderingLayer = z;
        //    standing_left.ColorGetter = () => boss.BodyColor;

        //    var standing_right = GeneratedContent.Create_knight_spider_body(
        //            -width / 2
        //            , -height
        //            , width * 2
        //            , height * 2
        //            , true
        //    );
        //    standing_right.RenderingLayer = z;
        //    standing_right.ColorGetter = () => boss.BodyColor;

        //    var jump_left = GeneratedContent.Create_knight_spider_body_jump(
        //                        -width / 2
        //                        , -height
        //                        , width * 2
        //                        , height * 2
        //                        , false
        //                    );
        //    jump_left.RenderingLayer = z;
        //    jump_left.ColorGetter = () => boss.BodyColor;

        //    var jump_right = GeneratedContent.Create_knight_spider_body_jump(
        //            -width / 2
        //            , -height
        //            , width * 2
        //            , height * 2
        //            , true
        //    );
        //    jump_right.RenderingLayer = z;
        //    jump_right.ColorGetter = () => boss.BodyColor;

        //    var animation =
        //        new Animator(
        //            new AnimationTransitionOnCondition(standing_left, () => !boss.facingRight && boss.grounded)
        //            , new AnimationTransitionOnCondition(standing_right, () => boss.facingRight && boss.grounded)
        //            , new AnimationTransitionOnCondition(jump_left, () => !boss.facingRight && !boss.grounded)
        //            , new AnimationTransitionOnCondition(jump_right, () => boss.facingRight && !boss.grounded)
        //    );
        //    boss.AddAnimation(animation);
        //}
    }
}