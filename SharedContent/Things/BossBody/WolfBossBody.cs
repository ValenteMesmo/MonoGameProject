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
        private int IdleCooldown = 500;

        //int fireballStacks = 3;
        //int eyeSpellStacks = 3;

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

            //CreateBodyAnimator(Boss.TORSO_Z);

            boss.AddUpdate(UpdateBasedOnState);
        }

        private void ChangeState()
        {
            var rnd = boss.MyRandom.Next(1, 3);
            if (IdleCooldown == 0)
            {
                boss.state = BossState.Idle;
                boss.MouthState = BossMouthState.Idle;
                state1Duration = 250;
                IdleCooldown = 500 + state1Duration;
            }
            else if (rnd == 1)
            {
                //eyeSpellStacks--;

                boss.state = BossState.EyeAttack;
                boss.MouthState = BossMouthState.Idle;
                state1Duration = 50;
            }
            else if (rnd == 2)
            {
                //fireballStacks--;

                boss.state = BossState.HeadAttack1;
                boss.MouthState = BossMouthState.Shoot;
                state1Duration = 100;
            }
            else
            {
                boss.state = BossState.BodyAttack1;
                boss.MouthState = BossMouthState.BiteOpen;

                if (boss.MyRandom.Next(0, 100) > 50)
                    boss.VerticalSpeed = -150;

                state1Duration = 100;
            }
        }

        private void UpdateBasedOnState()
        {
            if (boss.player == null)
                return;

            if (IdleCooldown > 0)
                IdleCooldown--;

            if (state1Duration > 0)
                state1Duration--;

            //if (IdleCooldown % 500 == 0)
            //{
            //    fireballStacks++;
            //    if (fireballStacks > 3)
            //        fireballStacks = 3;

            //    eyeSpellStacks++;
            //    if (eyeSpellStacks > 2)
            //        eyeSpellStacks = 2;
            //}

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

                var stage1 = Boss.HEALTH / 4;
                var stage2 = Boss.HEALTH / 2;

                var speed = 0;
                if (boss.PlayerDamageHandler.damageTaken < stage1)
                    speed = 50;
                else if (boss.PlayerDamageHandler.damageTaken < stage2)
                    speed = 80;
                else
                    speed = 100;

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

                if (state1Duration == 75)
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

                if (state1Duration == 75)
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

        //private void CreateBodyAnimator(float z)
        //{
        //    var width = 1500;
        //    var height = 1500;

        //    var standing_left = GeneratedContent.Create_knight_wolf_body(
        //                        -width / 2
        //                        , -height
        //                        , width * 2
        //                        , height * 2
        //                        , false
        //                    );
        //    standing_left.RenderingLayer = z;
        //    standing_left.ColorGetter = () => boss.BodyColor;

        //    var standing_right = GeneratedContent.Create_knight_wolf_body(
        //            -width / 2
        //            , -height
        //            , width * 2
        //            , height * 2
        //            , true
        //    );
        //    standing_right.RenderingLayer = z;
        //    standing_right.ColorGetter = () => boss.BodyColor;

        //    var jump_left = GeneratedContent.Create_knight_wolf_body_jump(
        //                        -width / 2
        //                        , -height
        //                        , width * 2
        //                        , height * 2
        //                        , false
        //                    );
        //    jump_left.RenderingLayer = z;
        //    jump_left.ColorGetter = () => boss.BodyColor;

        //    var jump_right = GeneratedContent.Create_knight_wolf_body_jump(
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