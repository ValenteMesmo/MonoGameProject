using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class Enemy : Thing
    {
        const int VELOCITY = 25;
        const int size = 800;
        private AttackCollider AttackCollider;
        private bool attacking;
        private int attackDuration;
        private CollisionChecker groundleft;
        private CollisionChecker groundright;

        public Enemy(Game1 Game1)
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
                    attacking = false;
            });

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(ChangeDirectionIfAboutToFall);
        }

        private void ChangeDirectionIfAboutToFall()
        {
            if (HorizontalSpeed > 0 && !groundright.Colliding<GroundCollider>())
            {
                HorizontalSpeed = -HorizontalSpeed;
            }
            else if (HorizontalSpeed < 0 && !groundleft.Colliding<GroundCollider>())
            {
                HorizontalSpeed = -HorizontalSpeed;
            }
        }

        private void ExtraColliders()
        {
            var playerFinder = new Collider(size, size / 2);
            playerFinder.OffsetY = size / 2;
            playerFinder.AddHandler(AttackNearPlayer);
            AddCollider(playerFinder);


            AttackCollider = new AttackCollider();
            AttackCollider.OffsetY = size / 2;
            AttackCollider.Width = size / 2;
            AttackCollider.Height = size / 2;
            AddCollider(AttackCollider);

            AddUpdate(() =>
            {
                if (HorizontalSpeed > 0)
                {
                    AttackCollider.OffsetX = size;
                    playerFinder.OffsetX = size;
                }
                else
                {
                    AttackCollider.OffsetX = -size / 2;
                    playerFinder.OffsetX = -size;
                }
            });

            {
                groundleft = new CollisionChecker();

                groundleft.Width = size/2;
                groundleft.Height = size / 4;
                groundleft.OffsetX = -size/2;
                groundleft.OffsetY = size;
                groundleft.AddHandler(AttackNearPlayer);
                AddCollider(groundleft);
            }
            {
                groundright = new CollisionChecker();

                groundright.Width = size/2;
                groundright.Height = size / 4;
                groundright.OffsetX = size;
                groundright.OffsetY = size;
                groundright.AddHandler(AttackNearPlayer);
                AddCollider(groundright);
            }

        }

        private void MainCollider()
        {
            var PlayerDamageHandler = new PlayerDamageHandler(Game1.Instance, Color.White, (p, s, t) => { }, (p, s, t) => { });
            AddUpdate(PlayerDamageHandler.Update);

            var MainCollider = new SolidCollider(size, size);
            //MainCollider.OffsetY = size / 2;
            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot<GroundCollider>());
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left<GroundCollider>());
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right<GroundCollider>());
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top<GroundCollider>());
            MainCollider.AddLeftCollisionHandler(left);
            MainCollider.AddRightCollisionHandler(right);
            MainCollider.AddHandler(PlayerDamageHandler.CollisionHandler);
            AddCollider(MainCollider);
        }

        private void Animations()
        {
            var idleAniamtion_left = GeneratedContent.Create_knight_Slime(-size / 2, -size, size * 2, size * 2);
            var idleAniamtion_right = GeneratedContent.Create_knight_Slime(-size / 2, -size, size * 2, size * 2, true);
            var attackAniamtion_left = GeneratedContent.Create_knight_Slime_attack(-size / 2, -size, size * 2, size * 2);
            var attackAniamtion_right = GeneratedContent.Create_knight_Slime_attack(-size / 2, -size, size * 2, size * 2, true);
            AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(idleAniamtion_left, () => HorizontalSpeed < 0 && !attacking),
                    new AnimationTransitionOnCondition(idleAniamtion_right, () => HorizontalSpeed > 0 && !attacking),
                    new AnimationTransitionOnCondition(attackAniamtion_left, () => HorizontalSpeed < 0 && attacking),
                    new AnimationTransitionOnCondition(attackAniamtion_right, () => HorizontalSpeed > 0 && attacking)
                )
            );
        }

        private void AttackNearPlayer(Collider arg1, Collider arg2)
        {
            if (arg2.Parent is Player)
            {
                attacking = true;
                attackDuration = 50;
            }
        }

        private void right(Collider arg1, Collider arg2)
        {
            if (arg2 is GroundCollider)
                HorizontalSpeed = -VELOCITY;
        }

        private void left(Collider arg1, Collider arg2)
        {
            if (arg2 is GroundCollider)
                HorizontalSpeed = VELOCITY;
        }
    }
}