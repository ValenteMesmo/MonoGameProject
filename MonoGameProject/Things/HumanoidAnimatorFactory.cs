using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class HumanoidAnimatorFactory
    {
        private int x = -200;
        private int flippedx = -130;
        private int feet_y = -300;
        private int crouch_y = 0;
        protected int scale = 5;

        private float HEAD_Z = 0.120f;
        private float TORSO_Z = 0.121f;
        private float LEG_Z = 0.122f;

        private const int bump_y = -50;

        public void CreateAnimator(Humanoid thing)
        {
            thing.ArmorColor = Color.White;
            HeadAnimator(thing);
            TorsoAnimator(thing);
            LegsAnimator(thing);
        }

        private void LegsAnimator(Humanoid thing)
        {
            var fall_left = GeneratedContent.Create_knight_Legs_Falling(
                x
                , feet_y);
            fall_left.ScaleX = scale;
            fall_left.ScaleY = scale;
            fall_left.RenderingLayer = LEG_Z;

            var fall_right = GeneratedContent.Create_knight_Legs_Falling(
                flippedx
                , feet_y
                , null
                , null
                , true);
            fall_right.ScaleX = scale;
            fall_right.ScaleY = scale;
            fall_right.RenderingLayer = LEG_Z;

            var fall_left_armored = GeneratedContent.Create_knight_Legs_Falling_armored(
                x
                , feet_y);
            fall_left_armored.ScaleX = scale;
            fall_left_armored.ScaleY = scale;
            fall_left_armored.RenderingLayer = LEG_Z;

            var fall_right_armored = GeneratedContent.Create_knight_Legs_Falling_armored(
                flippedx
                , feet_y
                , null
                , null
                , true);
            fall_right_armored.ScaleX = scale;
            fall_right_armored.ScaleY = scale;
            fall_right_armored.RenderingLayer = LEG_Z;

            var crouch_left = GeneratedContent.Create_knight_Legs_Crouching(
                x
                , crouch_y);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;
            crouch_left.RenderingLayer = LEG_Z;

            var crouch_right = GeneratedContent.Create_knight_Legs_Crouching(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;
            crouch_right.RenderingLayer = LEG_Z;

            var crouch_left_armored = GeneratedContent.Create_knight_Legs_Crouching_armored(
                x
                , crouch_y);
            crouch_left_armored.ScaleX = scale;
            crouch_left_armored.ScaleY = scale;
            crouch_left_armored.RenderingLayer = LEG_Z;

            var crouch_right_armored = GeneratedContent.Create_knight_Legs_Crouching_armored(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right_armored.ScaleX = scale;
            crouch_right_armored.ScaleY = scale;
            crouch_right_armored.RenderingLayer = LEG_Z;


            var crouch_left_edge = GeneratedContent.Create_knight_Legs_Crouching_edge(
                x
                , crouch_y);
            crouch_left_edge.ScaleX = scale;
            crouch_left_edge.ScaleY = scale;
            crouch_left_edge.RenderingLayer = LEG_Z;

            var crouch_right_edge = GeneratedContent.Create_knight_Legs_Crouching_edge(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right_edge.ScaleX = scale;
            crouch_right_edge.ScaleY = scale;
            crouch_right_edge.RenderingLayer = LEG_Z;

            var crouch_left_edge_armored = GeneratedContent.Create_knight_Legs_Crouching_edge_armored(
                x
                , crouch_y);
            crouch_left_edge_armored.ScaleX = scale;
            crouch_left_edge_armored.ScaleY = scale;
            crouch_left_edge_armored.RenderingLayer = LEG_Z;

            var crouch_right_edge_armored = GeneratedContent.Create_knight_Legs_Crouching_edge_armored(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right_edge_armored.ScaleX = scale;
            crouch_right_edge_armored.ScaleY = scale;
            crouch_right_edge_armored.RenderingLayer = LEG_Z;


            var sweetDreams_left = GeneratedContent.Create_knight_Legs_Sweet_dreams(
                x
                , crouch_y);
            sweetDreams_left.ScaleX = scale;
            sweetDreams_left.ScaleY = scale;
            sweetDreams_left.RenderingLayer = LEG_Z;

            var sweetDreams_right = GeneratedContent.Create_knight_Legs_Sweet_dreams(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            sweetDreams_right.ScaleX = scale;
            sweetDreams_right.ScaleY = scale;
            sweetDreams_right.RenderingLayer = LEG_Z;

            var sweetDreams_left_armored = GeneratedContent.Create_knight_Legs_Sweet_dreams_armored(
                x
                , crouch_y);
            sweetDreams_left_armored.ScaleX = scale;
            sweetDreams_left_armored.ScaleY = scale;
            sweetDreams_left_armored.RenderingLayer = LEG_Z;

            var sweetDreams_right_armored = GeneratedContent.Create_knight_Legs_Sweet_dreams_armored(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            sweetDreams_right_armored.ScaleX = scale;
            sweetDreams_right_armored.ScaleY = scale;
            sweetDreams_right_armored.RenderingLayer = LEG_Z;


            var walk_left = GeneratedContent.Create_knight_Legs_Walking(
                x
                , feet_y);
            walk_left.ScaleX = scale;
            walk_left.ScaleY = scale;
            walk_left.RenderingLayer = LEG_Z;
            walk_left.FrameDuration = 2;

            var walk_right = GeneratedContent.Create_knight_Legs_Walking(
                flippedx
                , feet_y
                , null
                , null
                , true);
            walk_right.ScaleX = scale;
            walk_right.ScaleY = scale;
            walk_right.RenderingLayer = LEG_Z;
            walk_right.FrameDuration = 2;

            var walk_left_armored = GeneratedContent.Create_knight_Legs_Walking_armored(
                x
                , feet_y);
            walk_left_armored.ScaleX = scale;
            walk_left_armored.ScaleY = scale;
            walk_left_armored.RenderingLayer = LEG_Z;
            walk_left_armored.FrameDuration = 2;
            walk_left_armored.ColorGetter = () => thing.ArmorColor;

            var walk_right_armored = GeneratedContent.Create_knight_Legs_Walking_armored(
                flippedx
                , feet_y
                , null
                , null
                , true);
            walk_right_armored.ScaleX = scale;
            walk_right_armored.ScaleY = scale;
            walk_right_armored.RenderingLayer = LEG_Z;
            walk_right_armored.FrameDuration = 2;
            walk_right_armored.ColorGetter = () => thing.ArmorColor;

            var headbang_left = GeneratedContent.Create_knight_roof_bang_legs(
                x
                , feet_y + bump_y);
            headbang_left.ScaleX = scale;
            headbang_left.ScaleY = scale;
            headbang_left.RenderingLayer = LEG_Z;

            var headbang_right = GeneratedContent.Create_knight_roof_bang_legs(
                flippedx
                , feet_y + bump_y
                , null
                , null
                , true);
            headbang_right.ScaleX = scale;
            headbang_right.ScaleY = scale;
            headbang_right.RenderingLayer = LEG_Z;

            var headbang_left_armored = GeneratedContent.Create_knight_roof_bang_legs_armored(
                x
                , feet_y + bump_y);
            headbang_left_armored.ScaleX = scale;
            headbang_left_armored.ScaleY = scale;
            headbang_left_armored.RenderingLayer = LEG_Z;

            var headbang_right_armored = GeneratedContent.Create_knight_roof_bang_legs_armored(
                flippedx
                , feet_y + bump_y
                , null
                , null
                , true);
            headbang_right_armored.ScaleX = scale;
            headbang_right_armored.ScaleY = scale;
            headbang_right_armored.RenderingLayer = LEG_Z;
            
            var sliding_left = GeneratedContent.Create_knight_Legs_slide_wall(
                x
                , feet_y);
            sliding_left.ScaleX = scale;
            sliding_left.ScaleY = scale;
            sliding_left.RenderingLayer = LEG_Z;

            var sliding_right = GeneratedContent.Create_knight_Legs_slide_wall(
                flippedx
                , feet_y
                , null
                , null
                , true);
            sliding_right.ScaleX = scale;
            sliding_right.ScaleY = scale;
            sliding_right.RenderingLayer = LEG_Z;

            var sliding_left_armored = GeneratedContent.Create_knight_Legs_slide_wall_armored(
                x
                , feet_y);
            sliding_left_armored.ScaleX = scale;
            sliding_left_armored.ScaleY = scale;
            sliding_left_armored.RenderingLayer = LEG_Z;

            var sliding_right_armored = GeneratedContent.Create_knight_Legs_slide_wall_armored(
                flippedx
                , feet_y
                , null
                , null
                , true);
            sliding_right_armored.ScaleX = scale;
            sliding_right_armored.ScaleY = scale;
            sliding_right_armored.RenderingLayer = LEG_Z;

            var nakedLegs = new Animator(
                new AnimationTransitionOnCondition(walk_left, () => (thing.LegState == LegState.Walking || thing.LegState == LegState.Standing) && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(walk_right, () => (thing.LegState == LegState.Walking || thing.LegState == LegState.Standing) && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(crouch_left, () => thing.LegState == LegState.Crouching && thing.FacingRight == false && thing.LeftGroundAcidentChecker.Colliding<GroundCollider>())
                , new AnimationTransitionOnCondition(crouch_right, () => thing.LegState == LegState.Crouching && thing.FacingRight == true && thing.RightGroundAcidentChecker.Colliding<GroundCollider>())
                , new AnimationTransitionOnCondition(crouch_left_edge, () => thing.LegState == LegState.Crouching && thing.FacingRight == false && !thing.LeftGroundAcidentChecker.Colliding<GroundCollider>())
                , new AnimationTransitionOnCondition(crouch_right_edge, () => thing.LegState == LegState.Crouching && thing.FacingRight == true && !thing.RightGroundAcidentChecker.Colliding<GroundCollider>())
                , new AnimationTransitionOnCondition(sweetDreams_left, () => thing.LegState == LegState.SweetDreams && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(sweetDreams_right, () => thing.LegState == LegState.SweetDreams && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_left, () => thing.LegState == LegState.Falling && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(fall_right, () => thing.LegState == LegState.Falling && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_right, () => thing.LegState == LegState.WallJumping && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_left, () => thing.LegState == LegState.WallJumping && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(headbang_left, () => thing.LegState == LegState.HeadBump && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(headbang_right, () => thing.LegState == LegState.HeadBump && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(sliding_left, () => thing.LegState == LegState.SlidingWall && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(sliding_right, () => thing.LegState == LegState.SlidingWall && thing.FacingRight == true)
            );

            var armoredLegs = new Animator(
                new AnimationTransitionOnCondition(walk_left_armored, () => (thing.LegState == LegState.Walking || thing.LegState == LegState.Standing) && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(walk_right_armored, () => (thing.LegState == LegState.Walking || thing.LegState == LegState.Standing) && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(crouch_left_armored, () => thing.LegState == LegState.Crouching && thing.FacingRight == false && thing.LeftGroundAcidentChecker.Colliding<GroundCollider>())
                , new AnimationTransitionOnCondition(crouch_right_armored, () => thing.LegState == LegState.Crouching && thing.FacingRight == true && thing.RightGroundAcidentChecker.Colliding<GroundCollider>())
                , new AnimationTransitionOnCondition(crouch_left_edge_armored, () => thing.LegState == LegState.Crouching && thing.FacingRight == false && !thing.LeftGroundAcidentChecker.Colliding<GroundCollider>())
                , new AnimationTransitionOnCondition(crouch_right_edge_armored, () => thing.LegState == LegState.Crouching && thing.FacingRight == true && !thing.RightGroundAcidentChecker.Colliding<GroundCollider>())
                , new AnimationTransitionOnCondition(sweetDreams_left_armored, () => thing.LegState == LegState.SweetDreams && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(sweetDreams_right_armored, () => thing.LegState == LegState.SweetDreams && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_left_armored, () => thing.LegState == LegState.Falling && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(fall_right_armored, () => thing.LegState == LegState.Falling && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_right_armored, () => thing.LegState == LegState.WallJumping && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(fall_left_armored, () => thing.LegState == LegState.WallJumping && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(headbang_left_armored, () => thing.LegState == LegState.HeadBump && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(headbang_right_armored, () => thing.LegState == LegState.HeadBump && thing.FacingRight == true)
                , new AnimationTransitionOnCondition(sliding_left_armored, () => thing.LegState == LegState.SlidingWall && thing.FacingRight == false)
                , new AnimationTransitionOnCondition(sliding_right_armored, () => thing.LegState == LegState.SlidingWall && thing.FacingRight == true)
            );

            thing.AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(armoredLegs, () => thing.HitPoints > 1)
                    , new AnimationTransitionOnCondition(nakedLegs, () => thing.HitPoints <= 1)
                )
            );
        }

        private void HeadAnimator(Humanoid thing)
        {
            var stand_left = GeneratedContent.Create_knight_head(
                x
                , feet_y);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;
            stand_left.RenderingLayer = HEAD_Z;

            var stand_right = GeneratedContent.Create_knight_head(
                flippedx
                , feet_y
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;
            stand_right.RenderingLayer = HEAD_Z;

            var stand_left_armored = GeneratedContent.Create_knight_head_armor1(
                x
                , feet_y);
            stand_left_armored.ScaleX = scale;
            stand_left_armored.ScaleY = scale;
            stand_left_armored.ColorGetter = () => thing.ArmorColor;
            stand_left_armored.RenderingLayer = HEAD_Z;

            var stand_right_armored = GeneratedContent.Create_knight_head_armor1(
                flippedx
                , feet_y
                , null
                , null
                , true);
            stand_right_armored.ScaleX = scale;
            stand_right_armored.ScaleY = scale;
            stand_right_armored.ColorGetter = () => thing.ArmorColor;
            stand_right_armored.RenderingLayer = HEAD_Z;

            var crouch_left = GeneratedContent.Create_knight_head(
                x
                , crouch_y);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;
            crouch_left.RenderingLayer = HEAD_Z;

            var crouch_right = GeneratedContent.Create_knight_head(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;
            crouch_right.RenderingLayer = HEAD_Z;

            var headbang_left = GeneratedContent.Create_knight_roof_bang_head(
                x
                , feet_y + bump_y);
            headbang_left.ScaleX = scale;
            headbang_left.ScaleY = scale;
            headbang_left.RenderingLayer = HEAD_Z;

            var headbang_right = GeneratedContent.Create_knight_roof_bang_head(
                flippedx
                , feet_y + bump_y
                , null
                , null
                , true);
            headbang_right.ScaleX = scale;
            headbang_right.ScaleY = scale;
            headbang_right.RenderingLayer = HEAD_Z;

            var crouch_left_armored = GeneratedContent.Create_knight_head_armor1(
                x
                , crouch_y);
            crouch_left_armored.ScaleX = scale;
            crouch_left_armored.ScaleY = scale;
            crouch_left_armored.ColorGetter = () => thing.ArmorColor;
            crouch_left_armored.RenderingLayer = HEAD_Z;

            var crouch_right_armored = GeneratedContent.Create_knight_head_armor1(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right_armored.ScaleX = scale;
            crouch_right_armored.ScaleY = scale;
            crouch_right_armored.ColorGetter = () => thing.ArmorColor;
            crouch_right_armored.RenderingLayer = HEAD_Z;

            var headbang_left_armored = GeneratedContent.Create_knight_head_armor_bang1(
                x
                , feet_y + bump_y);
            headbang_left_armored.ScaleX = scale;
            headbang_left_armored.ScaleY = scale;
            headbang_left_armored.ColorGetter = () => thing.ArmorColor;
            headbang_left_armored.RenderingLayer = HEAD_Z;

            var headbang_right_armored = GeneratedContent.Create_knight_head_armor_bang1(
                flippedx
                , feet_y + bump_y
                , null
                , null
                , true);
            headbang_right_armored.ScaleX = scale;
            headbang_right_armored.ScaleY = scale;
            headbang_right_armored.ColorGetter = () => thing.ArmorColor;
            headbang_right_armored.RenderingLayer = HEAD_Z;

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

        private void TorsoAnimator(Humanoid thing)
        {
            var stand_left = GeneratedContent.Create_knight_torso_walking(
                x
                , feet_y);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;
            stand_left.RenderingLayer = TORSO_Z;
            stand_left.FrameDuration = 2;

            var stand_right = GeneratedContent.Create_knight_torso_walking(
                flippedx
                , feet_y
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;
            stand_right.RenderingLayer = TORSO_Z;
            stand_right.FrameDuration = 2;

            var stand_left_armored = GeneratedContent.Create_knight_torso_walking_armored(
                x
                , feet_y);
            stand_left_armored.ScaleX = scale;
            stand_left_armored.ScaleY = scale;
            stand_left_armored.RenderingLayer = TORSO_Z;
            stand_left_armored.FrameDuration = 2;
            stand_left_armored.ColorGetter = () => thing.ArmorColor;

            var stand_right_armored = GeneratedContent.Create_knight_torso_walking_armored(
                flippedx
                , feet_y
                , null
                , null
                , true);
            stand_right_armored.ScaleX = scale;
            stand_right_armored.ScaleY = scale;
            stand_right_armored.RenderingLayer = TORSO_Z;
            stand_right_armored.FrameDuration = 2;
            stand_right_armored.ColorGetter = () => thing.ArmorColor;

            var crouch_left = GeneratedContent.Create_knight_torso_walking(
                x
                , crouch_y);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;
            crouch_left.RenderingLayer = TORSO_Z;

            var crouch_right = GeneratedContent.Create_knight_torso_walking(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;
            crouch_right.RenderingLayer = TORSO_Z;


            var crouch_left_armored = GeneratedContent.Create_knight_torso_walking_armored(
                x
                , crouch_y);
            crouch_left_armored.ScaleX = scale;
            crouch_left_armored.ScaleY = scale;
            crouch_left_armored.RenderingLayer = TORSO_Z;
            crouch_left_armored.ColorGetter = () => thing.ArmorColor;

            var crouch_right_armored = GeneratedContent.Create_knight_torso_walking_armored(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right_armored.ScaleX = scale;
            crouch_right_armored.ScaleY = scale;
            crouch_right_armored.RenderingLayer = TORSO_Z;
            crouch_right_armored.ColorGetter = () => thing.ArmorColor;


            var stand_attack_left = GeneratedContent.Create_knight_torso_attack(
                x
                , feet_y);
            stand_attack_left.ScaleX = scale;
            stand_attack_left.ScaleY = scale;
            stand_attack_left.RenderingLayer = TORSO_Z;
            stand_attack_left.LoopDisabled = true;

            var stand_attack_right = GeneratedContent.Create_knight_torso_attack(
                flippedx
                , feet_y
                , null
                , null
                , true);
            stand_attack_right.ScaleX = scale;
            stand_attack_right.ScaleY = scale;
            stand_attack_right.RenderingLayer = TORSO_Z;
            stand_attack_right.LoopDisabled = true;

            var crouch_attack_left = GeneratedContent.Create_knight_torso_attack(
                x
                , crouch_y);
            crouch_attack_left.ScaleX = scale;
            crouch_attack_left.ScaleY = scale;
            crouch_attack_left.LoopDisabled = true;
            crouch_attack_left.RenderingLayer = TORSO_Z;
            
            var crouch_attack_right = GeneratedContent.Create_knight_torso_attack(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_attack_right.ScaleX = scale;
            crouch_attack_right.ScaleY = scale;
            crouch_attack_right.LoopDisabled = true;
            crouch_attack_right.RenderingLayer = TORSO_Z;
            
            var whip_left = GeneratedContent.Create_knight_whip_attack(-1500, feet_y);
            whip_left.ScaleX = scale;
            whip_left.ScaleY = scale;
            whip_left.LoopDisabled = true;
            whip_left.RenderingLayer = TORSO_Z - 0.01f;
            var whip_left_crouch = GeneratedContent.Create_knight_whip_attack(-1500, crouch_y);
            whip_left_crouch.ScaleX = scale;
            whip_left_crouch.ScaleY = scale;
            whip_left_crouch.LoopDisabled = true;
            whip_left_crouch.RenderingLayer = TORSO_Z - 0.01f;
            var whip_right = GeneratedContent.Create_knight_whip_attack(-1400, feet_y, null, null, true);
            whip_right.ScaleX = scale;
            whip_right.ScaleY = scale;
            whip_right.LoopDisabled = true;
            whip_right.RenderingLayer = TORSO_Z - 0.01f;
            var whip_right_crouch = GeneratedContent.Create_knight_whip_attack(-1400, crouch_y, null, null, true);
            whip_right_crouch.ScaleX = scale;
            whip_right_crouch.ScaleY = scale;
            whip_right_crouch.LoopDisabled = true;
            whip_right_crouch.RenderingLayer = TORSO_Z - 0.01f;

            var whipi_left = GeneratedContent.Create_knight_whip_idle(-1500, feet_y);
            whipi_left.ScaleX = scale;
            whipi_left.ScaleY = scale;
            whipi_left.LoopDisabled = true;
            whipi_left.RenderingLayer = TORSO_Z - 0.01f;
            var whipi_left_crouch = GeneratedContent.Create_knight_whip_idle(-1500, crouch_y);
            whipi_left_crouch.ScaleX = scale;
            whipi_left_crouch.ScaleY = scale;
            whipi_left_crouch.LoopDisabled = true;
            whipi_left_crouch.RenderingLayer = TORSO_Z - 0.01f;
            var whipi_right = GeneratedContent.Create_knight_whip_idle(-1400, feet_y, null, null, true);
            whipi_right.ScaleX = scale;
            whipi_right.ScaleY = scale;
            whipi_right.LoopDisabled = true;
            whipi_right.RenderingLayer = TORSO_Z - 0.01f;
            var whipi_right_crouch = GeneratedContent.Create_knight_whip_idle(-1400, crouch_y, null, null, true);
            whipi_right_crouch.ScaleX = scale;
            whipi_right_crouch.ScaleY = scale;
            whipi_right_crouch.LoopDisabled = true;
            whipi_right_crouch.RenderingLayer = TORSO_Z - 0.01f;

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(whipi_left, () => thing.TorsoState == TorsoState.Standing && !thing.FacingRight)
                , new AnimationTransitionOnCondition(whipi_right, () => thing.TorsoState == TorsoState.Standing && thing.FacingRight)
                , new AnimationTransitionOnCondition(whipi_left_crouch, () => thing.TorsoState == TorsoState.Crouch && !thing.FacingRight)
                , new AnimationTransitionOnCondition(whipi_right_crouch, () => thing.TorsoState == TorsoState.Crouch && thing.FacingRight)
                , new AnimationTransitionOnCondition(whipi_left, () => thing.TorsoState == TorsoState.SlidingWall && !thing.FacingRight)
                , new AnimationTransitionOnCondition(whipi_right, () => thing.TorsoState == TorsoState.SlidingWall && thing.FacingRight)
                , new AnimationTransitionOnCondition(whip_left, () => thing.TorsoState == TorsoState.Attack && !thing.FacingRight)
                , new AnimationTransitionOnCondition(whip_right, () => thing.TorsoState == TorsoState.Attack && thing.FacingRight)
                , new AnimationTransitionOnCondition(whip_left_crouch, () => thing.TorsoState == TorsoState.AttackCrouching && !thing.FacingRight)
                , new AnimationTransitionOnCondition(whip_right_crouch, () => thing.TorsoState == TorsoState.AttackCrouching && thing.FacingRight)
            ));
            
            var naked_torso = new Animator(
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
            );


            var armored_torso = new Animator(
                new AnimationTransitionOnCondition(stand_left_armored,
                    () =>
                    thing.TorsoState == TorsoState.Standing
                    && thing.FacingRight == false
                )
                , new AnimationTransitionOnCondition(stand_right_armored,
                    () =>
                    thing.TorsoState == TorsoState.Standing
                    && thing.FacingRight == true
                )
                , new AnimationTransitionOnCondition(crouch_left_armored,
                    () =>
                    thing.TorsoState == TorsoState.Crouch
                    && thing.FacingRight == false
                )
                , new AnimationTransitionOnCondition(crouch_right_armored,
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
            );

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(armored_torso, () => thing.HitPoints > 1)
                , new AnimationTransitionOnCondition(naked_torso, () => thing.HitPoints <= 1)
                )
            );
        }

    }
}
