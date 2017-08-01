using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class HumanoidAnimatorFactory
    {
        public void CreateAnimator(
            int width
            , int height
            , Humanoid thing)
        {
            var size2 = 2800;
            var y2 = -1880;
            var x2 = -1550;
            var flippedx = -200;

            LegsAnimator(thing, size2, y2, x2, flippedx);
        }

        private static void LegsAnimator(Humanoid thing, int size, int y, int x, int flippedx)
        {
            var stand_left = GeneratedContent.Create_knight_Legs_Standing(
                x
                , y
                , 0
                , size
                , size);
            var stand_right = GeneratedContent.Create_knight_Legs_Standing(
                flippedx
                , y
                , 0
                , size
                , size
                , true);

            var fall_left = GeneratedContent.Create_knight_Legs_Falling(
                x
                , y
                , 0
                , size
                , size);
            var fall_right = GeneratedContent.Create_knight_Legs_Falling(
                flippedx
                , y
                , 0
                , size
                , size
                , true);

            var crouch_left = GeneratedContent.Create_knight_Legs_Crouching(
                x
                , y
                , 0
                , size
                , size);
            var crouch_right = GeneratedContent.Create_knight_Legs_Crouching(
                flippedx
                , y
                , 0
                , size
                , size
                , true);

            var walk_left = GeneratedContent.Create_knight_Legs_Walking(
                x
                , y
                , 0
                , size
                , size);
            var walk_right = GeneratedContent.Create_knight_Legs_Walking(
                flippedx
                , y
                , 0
                , size
                , size
                ,true);

            var headbang_left = GeneratedContent.Create_knight_head_bang(
                x
                , y
                , 0
                , size
                , size);
            var headbang_right = GeneratedContent.Create_knight_head_bang(
                flippedx
                , y
                , 0
                , size
                , size
                , true);

            var attack_left = GeneratedContent.Create_knight_Attack(
                x
                , y
                , 0
                , size
                , size);
            attack_left.LoopDisabled = true;
            var attack_right = GeneratedContent.Create_knight_Attack(
                flippedx
                , y
                , 0
                , size
                , size
                , true);
            attack_right.LoopDisabled = true;

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(walk_left, () => thing.State == PlayerState.WalkingLeft)
                , new AnimationTransitionOnCondition(walk_right, () => thing.State == PlayerState.WalkingRight)
                , new AnimationTransitionOnCondition(stand_left, () => thing.State == PlayerState.StandingLeft)
                , new AnimationTransitionOnCondition(stand_right, () => thing.State == PlayerState.StandingRight)
                , new AnimationTransitionOnCondition(crouch_left, () => thing.State == PlayerState.CrouchingLeft)
                , new AnimationTransitionOnCondition(crouch_right, () => thing.State == PlayerState.CrouchingRight)
                , new AnimationTransitionOnCondition(fall_left, () => thing.State == PlayerState.FallingLeft)
                , new AnimationTransitionOnCondition(fall_right, () => thing.State == PlayerState.FallingRight)
                , new AnimationTransitionOnCondition(fall_left, () => thing.State == PlayerState.WallJumpingToTheRight)
                , new AnimationTransitionOnCondition(fall_right, () => thing.State == PlayerState.WallJumpingToTheLeft)
                , new AnimationTransitionOnCondition(headbang_left, () => thing.State == PlayerState.HeadBumpLeft)
                , new AnimationTransitionOnCondition(headbang_right, () => thing.State == PlayerState.HeadBumpRight)
                , new AnimationTransitionOnCondition(attack_left, () => thing.State == PlayerState.AttackLeft)
                , new AnimationTransitionOnCondition(attack_right, () => thing.State == PlayerState.AttackRight)
                , new AnimationTransitionOnCondition(fall_left, () => thing.State == PlayerState.TakingDamage)
            ));
        }

    }
}
