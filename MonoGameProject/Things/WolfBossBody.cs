using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    class WolfBossBody
    {
        private readonly Boss boss;
        private int state1Duration;

        public WolfBossBody(Boss boss)
        {
            this.boss = boss;
            boss.state = BossState.BodyAttack1;

            boss.mainCollider.AddLeftCollisionHandler((s, t) =>
            {
                //mudar estado na colisao...
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
        }

        private void ChangeState()
        {
            var rnd = boss.MyRandom.Next(1, 3);
            if (boss.state != BossState.Idle && rnd == 1)
            {
                boss.MouthOpen = false;
                boss.state = BossState.Idle;
                state1Duration = 100;
            }
            else if (rnd == 2)
            {
                boss.MouthOpen = true;

                boss.state = BossState.BodyAttack1;
            }
            else
            {
                boss.MouthOpen = true;

                boss.state = BossState.HeadAttack1;
                state1Duration = 100;
            }
        }

        private void UpdateBasedOnState()
        {
            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (boss.state == BossState.BodyAttack1)
            {
                if (boss.facingRight)
                    boss.HorizontalSpeed = 100;
                else
                    boss.HorizontalSpeed = -100;
            }

            if (boss.state == BossState.Idle)
            {
                state1Duration--;
                boss.HorizontalSpeed = 0;
                if (state1Duration <= 0)
                {
                    if (boss.MyRandom.Next(0, 100) > 50)
                        boss.VerticalSpeed = -150;
                    boss.state = BossState.BodyAttack1;
                }
            }

            if (boss.state == BossState.HeadAttack1)
            {
                state1Duration--;
                boss.HorizontalSpeed = 0;
                if (state1Duration <= 0)
                {
                    if (boss.MyRandom.Next(0, 100) > 50)
                        boss.VerticalSpeed = -150;
                    boss.state = BossState.BodyAttack1;
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