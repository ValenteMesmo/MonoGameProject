using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class BossAnimatorFactory : HumanoidAnimatorFactory
    {
        public BossAnimatorFactory()
        {
            scale = 7;
            y_bonus = -500;
        }
    }

    public class HumanoidAnimatorFactory
    {
        private int x = -200;
        private int flippedx = -130;
        private int feet_y = -350;
        private int crouch_y = -50;
        protected int scale = 5;
        protected int y_bonus = 0;

        public void CreateAnimator(Humanoid thing)
        {
            thing.ArmorColor = Color.White;
            HeadAnimator(thing, 0.10f);
            TorsoAnimator(thing, 0.11f);
            LegsAnimator(thing, 0.10f);
        }

        private void LegsAnimator(Humanoid thing, float Z_INDEX)
        {
            var stand_left = GeneratedContent.Create_knight_Legs_Standing(
                x
                , feet_y + y_bonus);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;
            stand_left.RenderingLayer = Z_INDEX;

            var stand_right = GeneratedContent.Create_knight_Legs_Standing(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;
            stand_right.RenderingLayer = Z_INDEX;

            var fall_left = GeneratedContent.Create_knight_Legs_Falling(
                x
                , feet_y + y_bonus);
            fall_left.ScaleX = scale;
            fall_left.ScaleY = scale;
            fall_left.RenderingLayer = Z_INDEX;

            var fall_right = GeneratedContent.Create_knight_Legs_Falling(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            fall_right.ScaleX = scale;
            fall_right.ScaleY = scale;
            fall_right.RenderingLayer = Z_INDEX;

            var crouch_left = GeneratedContent.Create_knight_Legs_Crouching(
                x
                , crouch_y + y_bonus);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;
            crouch_left.RenderingLayer = Z_INDEX;

            var crouch_right = GeneratedContent.Create_knight_Legs_Crouching(
                flippedx
                , crouch_y + y_bonus
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;
            crouch_right.RenderingLayer = Z_INDEX;

            var walk_left = GeneratedContent.Create_knight_Legs_Walking(
                x
                , feet_y + y_bonus);
            walk_left.ScaleX = scale;
            walk_left.ScaleY = scale;
            walk_left.RenderingLayer = Z_INDEX;

            var walk_right = GeneratedContent.Create_knight_Legs_Walking(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            walk_right.ScaleX = scale;
            walk_right.ScaleY = scale;
            walk_right.RenderingLayer = Z_INDEX;

            var headbang_left = GeneratedContent.Create_knight_roof_bang_legs(
                x
                , feet_y + y_bonus);
            headbang_left.ScaleX = scale;
            headbang_left.ScaleY = scale;
            headbang_left.RenderingLayer = Z_INDEX;

            var headbang_right = GeneratedContent.Create_knight_roof_bang_legs(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            headbang_right.ScaleX = scale;
            headbang_right.ScaleY = scale;
            headbang_right.RenderingLayer = Z_INDEX;

            var sliding_left = GeneratedContent.Create_knight_Legs_slide_wall(
                x
                , feet_y + y_bonus);
            sliding_left.ScaleX = scale;
            sliding_left.ScaleY = scale;
            sliding_left.RenderingLayer = Z_INDEX;

            var sliding_right = GeneratedContent.Create_knight_Legs_slide_wall(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            sliding_right.ScaleX = scale;
            sliding_right.ScaleY = scale;
            sliding_right.RenderingLayer = Z_INDEX;

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(walk_left, () => thing.LegState == LegState.Walking && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(walk_right, () => thing.LegState == LegState.Walking && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(stand_left, () => thing.LegState == LegState.Standing && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(stand_right, () => thing.LegState == LegState.Standing && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(crouch_left, () => thing.LegState == LegState.Crouching && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(crouch_right, () => thing.LegState == LegState.Crouching && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_left, () => thing.LegState == LegState.Falling && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(fall_right, () => thing.LegState == LegState.Falling && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_right, () => thing.LegState == LegState.WallJumping && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_left, () => thing.LegState == LegState.WallJumping && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(headbang_left, () => thing.LegState == LegState.HeadBump && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(headbang_right, () => thing.LegState == LegState.HeadBump && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(sliding_left, () => thing.LegState == LegState.SlidingWall && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(sliding_right, () => thing.LegState == LegState.SlidingWall && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_left, () => thing.LegState == LegState.TakingDamage)
            ));
        }

        private void HeadAnimator(Humanoid thing, float Z_INDEX)
        {
            var stand_left = GeneratedContent.Create_knight_head(
                x
                , feet_y + y_bonus);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;
            stand_left.RenderingLayer = Z_INDEX;

            var stand_right = GeneratedContent.Create_knight_head(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;
            stand_right.RenderingLayer = Z_INDEX;

            var stand_left_armored = GeneratedContent.Create_knight_head_armor1(
                x
                , feet_y + y_bonus);
            stand_left_armored.ScaleX = scale;
            stand_left_armored.ScaleY = scale;
            stand_left_armored.ColorGetter = () => thing.ArmorColor;
            stand_left_armored.RenderingLayer = Z_INDEX;

            var stand_right_armored = GeneratedContent.Create_knight_head_armor1(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            stand_right_armored.ScaleX = scale;
            stand_right_armored.ScaleY = scale;
            stand_right_armored.ColorGetter = () => thing.ArmorColor;
            stand_right_armored.RenderingLayer = Z_INDEX;

            var crouch_left = GeneratedContent.Create_knight_head(
                x
                , crouch_y + y_bonus);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;
            crouch_left.RenderingLayer = Z_INDEX;

            var crouch_right = GeneratedContent.Create_knight_head(
                flippedx
                , crouch_y + y_bonus
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;
            crouch_right.RenderingLayer = Z_INDEX;

            var headbang_left = GeneratedContent.Create_knight_roof_bang_head(
                x
                , feet_y + y_bonus);
            headbang_left.ScaleX = scale;
            headbang_left.ScaleY = scale;
            headbang_left.RenderingLayer = Z_INDEX;

            var headbang_right = GeneratedContent.Create_knight_roof_bang_head(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            headbang_right.ScaleX = scale;
            headbang_right.ScaleY = scale;
            headbang_right.RenderingLayer = Z_INDEX;

            var crouch_left_armored = GeneratedContent.Create_knight_head_armor1(
                x
                , crouch_y + y_bonus);
            crouch_left_armored.ScaleX = scale;
            crouch_left_armored.ScaleY = scale;
            crouch_left_armored.ColorGetter = () => thing.ArmorColor;
            crouch_left_armored.RenderingLayer = Z_INDEX;

            var crouch_right_armored = GeneratedContent.Create_knight_head_armor1(
                flippedx
                , crouch_y + y_bonus
                , null
                , null
                , true);
            crouch_right_armored.ScaleX = scale;
            crouch_right_armored.ScaleY = scale;
            crouch_right_armored.ColorGetter = () => thing.ArmorColor;
            crouch_right_armored.RenderingLayer = Z_INDEX;

            var headbang_left_armored = GeneratedContent.Create_knight_head_armor_bang1(
                x
                , feet_y + y_bonus);
            headbang_left_armored.ScaleX = scale;
            headbang_left_armored.ScaleY = scale;
            headbang_left_armored.ColorGetter = () => thing.ArmorColor;
            headbang_left_armored.RenderingLayer = Z_INDEX;

            var headbang_right_armored = GeneratedContent.Create_knight_head_armor_bang1(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            headbang_right_armored.ScaleX = scale;
            headbang_right_armored.ScaleY = scale;
            headbang_right_armored.ColorGetter = () => thing.ArmorColor;
            headbang_right_armored.RenderingLayer = Z_INDEX;

            var nakedAnimator = new Animator(
                new AnimationTransitionOnCondition(stand_left, () => thing.HeadState == HeadState.Standing && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(stand_right, () => thing.HeadState == HeadState.Standing && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(crouch_left, () => thing.HeadState == HeadState.Crouching && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(crouch_right, () => thing.HeadState == HeadState.Crouching && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(headbang_left, () => thing.HeadState == HeadState.Bump && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(headbang_right, () => thing.HeadState == HeadState.Bump && thing.FacingRight == true)
            );

            var armoredAnimator = new Animator(
                new AnimationTransitionOnCondition(stand_left_armored, () => thing.HeadState == HeadState.Standing && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(stand_right_armored, () => thing.HeadState == HeadState.Standing && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(crouch_left_armored, () => thing.HeadState == HeadState.Crouching && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(crouch_right_armored, () => thing.HeadState == HeadState.Crouching && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(headbang_left_armored, () => thing.HeadState == HeadState.Bump && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(headbang_right_armored, () => thing.HeadState == HeadState.Bump && thing.FacingRight == true)
            );

            var animatorsWrapper =
                new Animator(
                    new AnimationTransitionOnCondition(nakedAnimator, () => thing.HitPoints <= 1)
                    , new AnimationTransitionOnCondition(armoredAnimator, () => thing.HitPoints == 2));

            thing.AddAnimation(animatorsWrapper);
        }

        private void TorsoAnimator(Humanoid thing, float Z_INDEX)
        {
            var stand_left = GeneratedContent.Create_knight_torso_stand(
                x
                , feet_y + y_bonus);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;
            stand_left.RenderingLayer = Z_INDEX;

            var stand_right = GeneratedContent.Create_knight_torso_stand(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;
            stand_right.RenderingLayer = Z_INDEX;

            var crouch_left = GeneratedContent.Create_knight_torso_stand(
                x
                , crouch_y + y_bonus);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;
            crouch_left.RenderingLayer = Z_INDEX;

            var crouch_right = GeneratedContent.Create_knight_torso_stand(
                flippedx
                , crouch_y + y_bonus
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;
            crouch_right.RenderingLayer = Z_INDEX;

            var stand_attack_left = GeneratedContent.Create_knight_torso_attack(
                x
                , feet_y + y_bonus);
            stand_attack_left.ScaleX = scale;
            stand_attack_left.ScaleY = scale;
            stand_attack_left.RenderingLayer = Z_INDEX;
            stand_attack_left.LoopDisabled = true;

            var stand_attack_right = GeneratedContent.Create_knight_torso_attack(
                flippedx
                , feet_y + y_bonus
                , null
                , null
                , true);
            stand_attack_right.ScaleX = scale;
            stand_attack_right.ScaleY = scale;
            stand_attack_right.RenderingLayer = Z_INDEX;
            stand_attack_right.LoopDisabled = true;

            var crouch_attack_left = GeneratedContent.Create_knight_torso_attack(
                x
                , crouch_y + y_bonus);
            crouch_attack_left.ScaleX = scale;
            crouch_attack_left.ScaleY = scale;
            crouch_attack_left.LoopDisabled = true;
            crouch_attack_left.RenderingLayer = Z_INDEX;

            var crouch_attack_right = GeneratedContent.Create_knight_torso_attack(
                flippedx
                , crouch_y + y_bonus
                , null
                , null
                , true);
            crouch_attack_right.ScaleX = scale;
            crouch_attack_right.ScaleY = scale;
            crouch_attack_right.LoopDisabled = true;
            crouch_attack_right.RenderingLayer = Z_INDEX;


            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(stand_left,
                    () =>
                    thing.TorsoState == TorsoState.Standing
                    && thing.FacingRight == false
                )
                , new AnimationTransitionOnCondition(stand_right,
                    () =>
                    thing.TorsoState == TorsoState.Standing
                    && thing.FacingRight == true
                )
                , new AnimationTransitionOnCondition(crouch_left,
                    () =>
                    thing.TorsoState == TorsoState.Crouch
                    && thing.FacingRight == false
                )
                , new AnimationTransitionOnCondition(crouch_right,
                    () =>
                    thing.TorsoState == TorsoState.Crouch
                    && thing.FacingRight == true
                )
                , new AnimationTransitionOnCondition(stand_attack_left,
                    () =>
                    thing.TorsoState == TorsoState.Attack
                    && thing.FacingRight == false
                    )
                , new AnimationTransitionOnCondition(stand_attack_right,
                    () =>
                    thing.TorsoState == TorsoState.Attack
                    && thing.FacingRight == true
                    )
                , new AnimationTransitionOnCondition(crouch_attack_left,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouching
                    && thing.FacingRight == false
                    )
                , new AnimationTransitionOnCondition(crouch_attack_right,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouching
                    && thing.FacingRight == true
                )
            ));
        }

    }
}
