using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class HumanoidAnimatorFactory
    {
        private int x = -200;
        private int flippedx = -130;
        public const int feet_y = -300;
        public const int crouch_y = 0;
        public const int scale = 5;

        public const float HEAD_Z = 0.120f;
        public const float TORSO_Z = 0.121f;
        public const float LEG_Z = 0.122f;

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
            var buttIndex = TORSO_Z + 0.005f;
            var frontLegIndex = TORSO_Z - 0.001f;
            var backLegIndex = buttIndex + 0.001f;


            var butt = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_butt_idle, feet_y, buttIndex);
            var buttCrouch = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_butt_idle, crouch_y, buttIndex);
            thing.AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(butt, () => thing.LegState != LegState.Crouching && thing.LegState != LegState.SweetDreams)
                    , new AnimationTransitionOnCondition(buttCrouch, () => thing.LegState == LegState.Crouching || thing.LegState == LegState.SweetDreams)
                )
            );

            var frontLegWalking = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_Leg_Walking, feet_y, frontLegIndex);
            var backLegWalking = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_Leg_Walking, feet_y, backLegIndex, 225, 5);

            var frontLegIdle = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_Leg_idle, feet_y, frontLegIndex);
            var backLegIdle = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_Leg_idle, feet_y, backLegIndex, 225, 5, true);

            //var frontLegIdleEdge = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_Leg_idle, frontLegIndex);
            //var backLegIdleEdge = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_Leg_idle, backLegIndex, 225, 5);

            var frontLegCrouch = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_Leg_Crouching, crouch_y, frontLegIndex);
            var backLegCrouch = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_Leg_Crouching, crouch_y, backLegIndex, 225, 5);

            thing.AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(frontLegIdle, () => thing.LegState == LegState.Standing)
                    , new AnimationTransitionOnCondition(frontLegWalking, () => thing.LegState == LegState.Walking)
                    , new AnimationTransitionOnCondition(frontLegCrouch, () => thing.LegState == LegState.Crouching)
                )
            );

            thing.AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(backLegIdle, () => thing.LegState == LegState.Standing)
                    , new AnimationTransitionOnCondition(backLegWalking, () => thing.LegState == LegState.Walking)
                    , new AnimationTransitionOnCondition(backLegCrouch, () => thing.LegState == LegState.Crouching)
                )
            );
        }

        private IHandleAnimation CreateFlippableAnimation(
            Humanoid thing
            , Func<int, int, int?, int?, bool, Animation> createAnimation
            , int y
            , float z
            , int bonus = 0
            , int startingFrame = 0
            , bool reverse = false)
        {
            if (reverse)
                bonus *= -1;

            var flipped = createAnimation(
                                flippedx + bonus
                                , y
                                , null
                                , null
                                , !reverse);
            flipped.ScaleX = scale;
            flipped.ScaleY = scale;
            flipped.RenderingLayer = z;
            flipped.FrameDuration = 2;
            flipped.StartingFrame = startingFrame;

            var notFlipped = createAnimation(
                   x - bonus
                   , y
                   , null
                   , null
                   , reverse);
            notFlipped.ScaleX = scale;
            notFlipped.ScaleY = scale;
            notFlipped.RenderingLayer = z;
            notFlipped.FrameDuration = 2;
            notFlipped.StartingFrame = startingFrame;

            return new Animator(
                new AnimationTransitionOnCondition(flipped, () => thing.FacingRight == true)
                , new AnimationTransitionOnCondition(notFlipped, () => thing.FacingRight == false)
            );
        }

        private void NewMethod_back(Func<int, int, int?, int?, bool, Animation> aaaa)
        {

            var walk_right_back = aaaa(
                flippedx + 225
                , feet_y
                , null
                , null
                , true);
            walk_right_back.ScaleX = scale;
            walk_right_back.ScaleY = scale;
            walk_right_back.RenderingLayer = TORSO_Z + 0.001f; ;
            walk_right_back.FrameDuration = 2;
            walk_right_back.StartingFrame = 6;
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
                    new AnimationTransitionOnCondition(nakedAnimator, () => thing.HitPoints <= 1 && thing.DamageDuration == TakesDamage.DAMAGE_DURATION - 5)
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

            var stand_attack_left_armored = GeneratedContent.Create_knight_torso_attack_armored(
                x
                , feet_y);
            stand_attack_left_armored.ScaleX = scale;
            stand_attack_left_armored.ScaleY = scale;
            stand_attack_left_armored.RenderingLayer = TORSO_Z;
            stand_attack_left_armored.LoopDisabled = true;
            stand_attack_left_armored.ColorGetter = () => thing.ArmorColor;

            var stand_attack_right_armored = GeneratedContent.Create_knight_torso_attack_armored(
                flippedx
                , feet_y
                , null
                , null
                , true);
            stand_attack_right_armored.ScaleX = scale;
            stand_attack_right_armored.ScaleY = scale;
            stand_attack_right_armored.RenderingLayer = TORSO_Z;
            stand_attack_right_armored.LoopDisabled = true;
            stand_attack_right_armored.ColorGetter = () => thing.ArmorColor;


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

            var crouch_attack_left_armored = GeneratedContent.Create_knight_torso_attack_armored(
                x
                , crouch_y);
            crouch_attack_left_armored.ScaleX = scale;
            crouch_attack_left_armored.ScaleY = scale;
            crouch_attack_left_armored.LoopDisabled = true;
            crouch_attack_left_armored.RenderingLayer = TORSO_Z;
            crouch_attack_left_armored.ColorGetter = () => thing.ArmorColor;

            var crouch_attack_right_armored = GeneratedContent.Create_knight_torso_attack_armored(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_attack_right_armored.ScaleX = scale;
            crouch_attack_right_armored.ScaleY = scale;
            crouch_attack_right_armored.LoopDisabled = true;
            crouch_attack_right_armored.RenderingLayer = TORSO_Z;
            crouch_attack_right_armored.ColorGetter = () => thing.ArmorColor;

            Animator whipAnimator = CreateWhipAnimator(thing);
            Animator whipAnimatorArmored = CreateWhipAnimator(thing);
            thing.AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(whipAnimatorArmored, () => thing.HitPoints > 1)
                    , new AnimationTransitionOnCondition(whipAnimator, () => thing.HitPoints <= 1 && thing.DamageDuration == TakesDamage.DAMAGE_DURATION / 2)
                )
            );

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
                , new AnimationTransitionOnCondition(stand_attack_left_armored,
                    () =>
                    thing.TorsoState == TorsoState.Attack
                    && thing.FacingRight == false
                    )
                , new AnimationTransitionOnCondition(stand_attack_right_armored,
                    () =>
                    thing.TorsoState == TorsoState.Attack
                    && thing.FacingRight == true
                    )
                , new AnimationTransitionOnCondition(crouch_attack_left_armored,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouching
                    && thing.FacingRight == false
                    )
                , new AnimationTransitionOnCondition(crouch_attack_right_armored,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouching
                    && thing.FacingRight == true
                )
            );

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(armored_torso, () => thing.HitPoints > 1)
                , new AnimationTransitionOnCondition(naked_torso, () => thing.HitPoints <= 1 && thing.DamageDuration == TakesDamage.DAMAGE_DURATION / 2)
                )
            );
        }

        private static Animator CreateWhipAnimator(Humanoid thing)
        {
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
            whipi_left.FrameDuration = 2;
            whipi_left.RenderingLayer = TORSO_Z - 0.01f;
            var whipi_left_crouch = GeneratedContent.Create_knight_whip_idle(-1500, crouch_y);
            whipi_left_crouch.ScaleX = scale;
            whipi_left_crouch.ScaleY = scale;
            //whipi_left_crouch.FrameDuration = 2;
            whipi_left_crouch.RenderingLayer = TORSO_Z - 0.01f;
            var whipi_right = GeneratedContent.Create_knight_whip_idle(-1400, feet_y, null, null, true);
            whipi_right.ScaleX = scale;
            whipi_right.ScaleY = scale;
            whipi_right.FrameDuration = 2;
            whipi_right.RenderingLayer = TORSO_Z - 0.01f;
            var whipi_right_crouch = GeneratedContent.Create_knight_whip_idle(-1400, crouch_y, null, null, true);
            whipi_right_crouch.ScaleX = scale;
            whipi_right_crouch.ScaleY = scale;
            //whipi_right_crouch.FrameDuration = 2;
            whipi_right_crouch.RenderingLayer = TORSO_Z - 0.01f;
            var whipAnimator = new Animator(
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
            );
            return whipAnimator;
        }
    }
}
