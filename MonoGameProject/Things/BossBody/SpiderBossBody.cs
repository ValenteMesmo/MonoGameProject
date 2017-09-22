﻿using GameCore;
using System;

namespace MonoGameProject
{
    public class SpiderBossBody
    {
        private readonly Boss boss;
        private Player player;
        private int stateCooldown;
        private DelayedAction DelayedAction = new DelayedAction();
        int flyingMod = -1;
        int horizontalSpeedMod = -1;

        public SpiderBossBody(Boss boss)
        {
            this.boss = boss;
            boss.state = BossState.Idle;
            boss.mainCollider.AddHandler(FindPlayer);
            boss.mainCollider.AddLeftCollisionHandler(LeftCollision);
            boss.mainCollider.AddRightCollisionHandler(RightCollision);
            boss.mainCollider.AddTopCollisionHandler(TopCollision);
            boss.mainCollider.AddBotCollisionHandler(TopCollision);

            CreateBodyAnimator(Boss.TORSO_Z);

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
            if (boss.player == null)
                return;

            if (idleCooldown > 0)
                idleCooldown--;

            if (boss.damageCooldown >= 0)
                boss.damageCooldown--;

            if (player != null)
            {
                if (player.MainCollider.Left() > boss.mainCollider.Right())
                    DelayedAction.Execute(() => boss.facingRight = true, 25);
                else
                    DelayedAction.Execute(() => boss.facingRight = false, 25);
            }

            if (stateCooldown <= 0)
            {
                ChangeState();
            }

            if (boss.state == BossState.BodyAttack1)
            {
                boss.HorizontalSpeed = 80 * horizontalSpeedMod;
                boss.VerticalSpeed = 80 * flyingMod;

                stateCooldown--;
                boss.MouthState = BossMouthState.BiteOpen;
            }

            if (boss.state == BossState.Idle || boss.state == BossState.EyeAttack)
            {
                boss.HorizontalSpeed = 0;
                boss.MouthState = BossMouthState.Idle;
                stateCooldown--;
            }

            if (boss.state == BossState.HeadAttack1)
            {
                boss.HorizontalSpeed = 0;
                boss.MouthState = BossMouthState.BiteOpen;
                stateCooldown--;
            }

            Game1.LOG += boss.state;
        }

        int idleCooldown = 0;

        private void ChangeState()
        {
            var rnd = boss.MyRandom.Next(1, 4);

            if (rnd == 1 && idleCooldown <= 0)
            {
                idleCooldown = 500;
                boss.state = BossState.Idle;
                stateCooldown = 150;
            }
            else if (rnd == 2)
            {
                boss.state = BossState.HeadAttack1;
                stateCooldown = 50;
            }
            else if (rnd == 3)
            {
                boss.state = BossState.EyeAttack;
                stateCooldown = 100;
            }
            else
            {
                boss.state = BossState.BodyAttack1;
                stateCooldown = 100;
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