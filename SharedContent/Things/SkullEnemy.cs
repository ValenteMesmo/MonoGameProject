using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class SkullEnemy : BaseEnemy
    {
        public SkullEnemy() : base(new SkullAttackImplementation())
        {
            Animations();
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
        
    }
}