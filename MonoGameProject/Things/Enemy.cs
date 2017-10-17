using GameCore;
using System;

namespace MonoGameProject
{
    public class Enemy : Thing
    {
        const int VELOCITY = 25;
        const int size = 800;
        private readonly Action<Thing> AddToWorld;
        private int Health = 2;
        private int DamageCooldown = 0;
        private AttackCollider AttackCollider;
        private bool attacking;
        private int attackDuration;

        public Enemy(Action<Thing> AddToWorld)
        {
            this.AddToWorld = AddToWorld;
            HorizontalSpeed = VELOCITY;

            //var eye = GeneratedContent.Create_knight_wolf_eye(0, 0, size*2, size*2);
            //eye.RenderingLayer = 0;
            //AddAnimation(eye);
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

            var MainCollider = new Collider(size, size / 2);
            MainCollider.OffsetY = size / 2;
            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);
            MainCollider.AddLeftCollisionHandler(left);
            MainCollider.AddRightCollisionHandler(right);
            MainCollider.AddHandler(HandleDamageFromPlayer);
            AddCollider(MainCollider);

            var playerFinder = new Collider(size, size);
            playerFinder.AddHandler(AttackNearPlayer);
            AddCollider(playerFinder);
            AddUpdate(() =>
            {
                if (attackDuration > 0)
                    attackDuration--;

                if (attackDuration ==0)
                attacking = false;
            });

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

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(() =>
            {
                if (DamageCooldown > 0)
                    DamageCooldown--;
            });
        }

        private void AttackNearPlayer(Collider arg1, Collider arg2)
        {
            if (arg2.Parent is Player)
            {
                attacking = true;
                attackDuration = 50;
            }
        }

        private void HandleDamageFromPlayer(Collider arg1, Collider arg2)
        {
            if (arg2 is AttackCollider && arg2.Parent is Player)
            {
                if (DamageCooldown > 0)
                {
                    return;
                }
                DamageCooldown = 100;

                AddToWorld(new HitEffect(0.01f, 0, 0, size * 2, size * 2) { X = X, Y = Y });
                Health--;
                if (Health == 0)
                    Destroy();
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