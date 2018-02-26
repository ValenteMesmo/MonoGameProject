using System;
using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public interface EnemyAttackImplementation
    {
        bool AttackCondition();
        void CreateFireball(BaseEnemy Parent);
    }

    public class SlimeAttackImplementation : EnemyAttackImplementation
    {
        public bool AttackCondition()
        {
            return Game1.Instance.MusicController.PrepareTarol();
        }

        public void CreateFireball(BaseEnemy Parent)
        {
            Game1.Instance.AddToWorld(new SlimeRainDrop(Parent, -20));
            Game1.Instance.AddToWorld(new SlimeRainDrop(Parent, 0));
            Game1.Instance.AddToWorld(new SlimeRainDrop(Parent, 20));
        }
    }

    public class SkullAttackImplementation : EnemyAttackImplementation
    {
        public bool AttackCondition()
        {
            return Game1.Instance.MusicController.PrepareTarol();
        }

        public void CreateFireball(BaseEnemy Parent)
        {
            Game1.Instance.AddToWorld(new BoneFireball(Parent, Parent.facingRight, Color.White) { X = Parent.X, Y = Parent.Y - 500 });
        }
    }

    public class SlimeEnemy : BaseEnemy
    {
        public SlimeEnemy() : base(new SlimeAttackImplementation())
        {
            mainCollider.Height = 500;
            //mainCollider.OffsetY = 500;
            Animations();
        }

        private void Animations()
        {
            var width = 800;
            var height = 800;
            var offsetX = -300;
            var offsetY = -900;

            var idleAniamtion_left = GeneratedContent.Create_knight_Slime(offsetX, offsetY, width, height);
            idleAniamtion_left.RenderingLayer = Boss.HEAD_Z;

            var idleAniamtion_right = GeneratedContent.Create_knight_Slime(offsetX, offsetY, width, height, true);
            idleAniamtion_right.RenderingLayer = Boss.HEAD_Z;

            var attackAniamtion_left = GeneratedContent.Create_knight_Slime_Attack(offsetX, offsetY, width, height);
            attackAniamtion_left.LoopDisabled = true;
            attackAniamtion_left.RenderingLayer = Boss.HEAD_Z;

            var attackAniamtion_right = GeneratedContent.Create_knight_Slime_Attack(offsetX, offsetY, width, height, true);
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
    }

    public class SpinnerEnemy : Thing, MagicProjectile
    {
        const int max = 50;
        const int speed = 1;

        int horizontalSpeed = max;
        int verticalSpeed = 0;
        int velocityVertical = speed;
        int velocityHorizontal = -speed;

        public SpinnerEnemy(bool reverse = false)
        {
            if (reverse)
            {
                horizontalSpeed = -max;
                verticalSpeed = 0;
            }
            else
            {
                horizontalSpeed = max;
                verticalSpeed = 0;
            }

            Animation();

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(RotationUpdate);

            var damageHandler = new PlayerDamageHandler(Game1.Instance, Color.White);
            AddUpdate( damageHandler.Update);
            
            var collider = new AttackCollider();
            collider.Width = collider.Height = 100;
            collider.OffsetX = 200;
            collider.OffsetY = 200;
            collider.AddHandler(damageHandler.CollisionHandler);

            AddCollider(collider);
        }

        private void RotationUpdate()
        {
            if (horizontalSpeed < -max)
                velocityHorizontal = speed;
            if (horizontalSpeed > max)
                velocityHorizontal = -speed;

            if (verticalSpeed < -max)
                velocityVertical = speed;
            if (verticalSpeed > max)
                velocityVertical = -speed;

            horizontalSpeed += velocityHorizontal;
            verticalSpeed += velocityVertical;

            {
                X = horizontalSpeed + X;
                Y = verticalSpeed + Y;
            }
        }

        private void Animation()
        {
            var animation = GeneratedContent.Create_knight_Bone(0, 0, 500, 500);
            animation.ColorGetter = () => Color.Red;
            animation.RenderingLayer = 0f;
            AddAnimation(animation);
        }
    }

    public class BaseEnemy : Thing
    {
        const int VELOCITY = 35;
        const int WIDTH = 300;
        const int HEIGHT = 600;
        protected bool attacking;
        private int attackDuration;
        public bool facingRight;
        private CollisionChecker groundleft;
        private CollisionChecker groundright;
        private bool skipThisOne;
        public SolidCollider mainCollider;
        private readonly EnemyAttackImplementation AttackImplementation;

        public BaseEnemy(EnemyAttackImplementation AttackImplementation)
        {
            this.AttackImplementation = AttackImplementation;

            HorizontalSpeed = VELOCITY;

            //Animations();
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
                    AttackImplementation.CreateFireball(this);
                }

                if (AttackImplementation.AttackCondition() && attackDuration == 0)
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
            if (facingRight && !groundright.Colliding<GroundCollider>())
            {
                facingRight = false;
            }
            else if (!facingRight && !groundleft.Colliding<GroundCollider>())
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