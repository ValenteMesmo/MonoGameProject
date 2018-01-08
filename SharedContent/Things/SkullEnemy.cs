﻿using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class SkullEnemy : Thing
    {
        const int VELOCITY = 25;
        const int WIDTH = 300;
        const int HEIGHT = 600;
        private bool attacking;
        private int attackDuration;
        private bool facingRight;
        private CollisionChecker groundleft;
        private CollisionChecker groundright;
        private bool skipThisOne;

        public SkullEnemy(Game1 Game1)
        {
            HorizontalSpeed = VELOCITY;

            Animations();
            MainCollider();
            ExtraColliders();

            AddUpdate(() =>
            {
                if (attackDuration > 0)
                    attackDuration--;

                if (attackDuration == 0)
                {
                    attacking = false;
                    HorizontalSpeed = facingRight ? VELOCITY : -VELOCITY;
                }
                else if (attackDuration == 40)
                {
                    Game1.AddToWorld(new BoneFireball(this, facingRight, Color.White) { X = X, Y = Y - 500 });
                }

                if (Game1.MusicController.PrepareTarol() && attackDuration == 0)
                {
                    if (skipThisOne)
                    {
                        skipThisOne = false;
                    }
                    else
                    {
                        skipThisOne = true;

                        attacking = true;
                        attackDuration = 50;
                        HorizontalSpeed = 0;                        
                    }
                }

                if (HorizontalSpeed > 0)
                    facingRight = true;
                else if (HorizontalSpeed < 0)
                    facingRight = false;
            });

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(ChangeDirectionIfAboutToFall);

        }

        private void ChangeDirectionIfAboutToFall()
        {
            if (facingRight  && !groundright.Colliding<GroundCollider>())
            {
                facingRight = false;
            }
            else if (!facingRight  && !groundleft.Colliding<GroundCollider>())
            {
                facingRight = true;
            }
        }

        private void ExtraColliders()
        {
            var size = 200;
            {
                groundleft = new CollisionChecker();

                groundleft.Width = size;
                groundleft.Height = size / 2;
                groundleft.OffsetX = -size - 10;
                groundleft.OffsetY = mainCollider.Height + 10;
                AddCollider(groundleft);
            }
            {
                groundright = new CollisionChecker();

                groundright.Width = size;
                groundright.Height = size / 2;
                groundright.OffsetX = mainCollider.Width + 10;
                groundright.OffsetY = mainCollider.Height + 10;
                AddCollider(groundright);
            }

        }
        SolidCollider mainCollider;
        private void MainCollider()
        {
            var PlayerDamageHandler = new PlayerDamageHandler(Game1.Instance, Color.White, (p, s, t) => { }, (p, s, t) => { });
            AddUpdate(PlayerDamageHandler.Update);

            //var width = size / 2;
            //var height = (size - 200) * 2;
            mainCollider = new SolidCollider(WIDTH, HEIGHT);
            mainCollider.OffsetY = -HEIGHT;
            mainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot<GroundCollider>());
            mainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left<GroundCollider>());
            mainCollider.AddRightCollisionHandler(StopsWhenHitting.Right<GroundCollider>());
            mainCollider.AddTopCollisionHandler(StopsWhenHitting.Top<GroundCollider>());
            mainCollider.AddLeftCollisionHandler(left);
            mainCollider.AddRightCollisionHandler(right);
            mainCollider.AddHandler(PlayerDamageHandler.CollisionHandler);
            AddCollider(mainCollider);
        }

        private void Animations()
        {
            var width = 1200;
            var height = 1200;
            var offsetX = -400;
            var offsetY = -1200;

            var idleAniamtion_left = GeneratedContent.Create_knight_skull_mob_idle(offsetX, offsetY, width, height);
            idleAniamtion_left.RenderingLayer = Boss.HEAD_Z;

            var idleAniamtion_right = GeneratedContent.Create_knight_skull_mob_idle(offsetX, offsetY, width, height, true);
            idleAniamtion_right.RenderingLayer = Boss.HEAD_Z;

            var attackAniamtion_left = GeneratedContent.Create_knight_skull_mob_attack(offsetX, offsetY, width, height);
            attackAniamtion_left.LoopDisabled = true;
            attackAniamtion_left.RenderingLayer = Boss.HEAD_Z;

            var attackAniamtion_right = GeneratedContent.Create_knight_skull_mob_attack(offsetX, offsetY, width, height, true);
            attackAniamtion_right.LoopDisabled = true;
            attackAniamtion_right.RenderingLayer = Boss.HEAD_Z;

            AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(idleAniamtion_left, () => !facingRight && !attacking),
                    new AnimationTransitionOnCondition(idleAniamtion_right, () => facingRight && !attacking),
                    new AnimationTransitionOnCondition(attackAniamtion_left, () => !facingRight && attacking),
                    new AnimationTransitionOnCondition(attackAniamtion_right, () => facingRight && attacking)
                )
            );
        }

        private void right(Collider arg1, Collider arg2)
        {
            if (arg2 is GroundCollider)
            {
                HorizontalSpeed = -VELOCITY;
                facingRight = false;
            }
        }

        private void left(Collider arg1, Collider arg2)
        {
            if (arg2 is GroundCollider)
            {
                HorizontalSpeed = VELOCITY;
                facingRight = true;
            }
        }
    }
}