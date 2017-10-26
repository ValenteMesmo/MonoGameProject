using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class HumanoidAnimatorFactory
    {
        private int x = -160;
        private int flippedx = -140;
        public const int feet_y = -300;
        public const int crouch_y = 0;
        public const int scale = 5;

        public const float HEAD_Z = 0.120f;
        public const float TORSO_Z = 0.121f;
        public const float LEG_Z = 0.122f;

        private const int bump_y = -50;
        Func<Color> skinColorGetter = () => new Color(223, 168, 137);
        Func<Color> CothColorGetter = () => new Color(74, 156, 74);
        Func<Color> HairColorGetter = () => new Color(186,120,168);

        public void CreateAnimator(Humanoid thing)
        {
            thing.ArmorColor = Color.White;
            HeadAnimator(thing);
            TorsoAnimator(thing);


            var armoredArm = CreateArmAnimation(thing, () => thing.ArmorColor, GeneratedContent.Create_knight_Arm_Idle_armored, GeneratedContent.Create_knight_Arm_Attack_armored);
            var armoredArm2 = CreateArmAnimation2(thing, () => thing.ArmorColor, GeneratedContent.Create_knight_Arm_Idle_armored, GeneratedContent.Create_knight_Arm_Attack_armored);

            var nakedArm = CreateArmAnimation(thing, skinColorGetter, GeneratedContent.Create_knight_Arm_Idle, GeneratedContent.Create_knight_Arm_Attack);
            var nakedArm2 = CreateArmAnimation2(thing, skinColorGetter, GeneratedContent.Create_knight_Arm_Idle, GeneratedContent.Create_knight_Arm_Attack);

            thing.AddAnimation(
                CreateArmorAnimator(thing, nakedArm, armoredArm, TakesDamage.DAMAGE_DURATION / 2)
            );

            thing.AddAnimation(
                CreateArmorAnimator(thing, nakedArm2, armoredArm2, TakesDamage.DAMAGE_DURATION / 2)
            );

            var legArmored = GreateLegsAnimator(
                thing
                , () => thing.ArmorColor
                , GeneratedContent.Create_knight_Leg_idle_armored
                , GeneratedContent.Create_knight_Leg_Walking_armored
                , GeneratedContent.Create_knight_Leg_wall_back_armored
                , GeneratedContent.Create_knight_Leg_Fall_back_armored
                , GeneratedContent.Create_knight_Leg_Roof_bang_armored
                , GeneratedContent.Create_knight_Leg_Crouching_armored
                , GeneratedContent.Create_knight_Leg_Crouching_edge_armored
                , GeneratedContent.Create_knight_Leg_SweetDreams_back_armored
            );

            var legArmored2 = GreateLegsAnimator2(
                thing
                , () => thing.ArmorColor
                , GeneratedContent.Create_knight_Leg_idle_armored
                , GeneratedContent.Create_knight_Leg_Walking_armored
                , GeneratedContent.Create_knight_Leg_wall_front_armored
                , GeneratedContent.Create_knight_Leg_Fall_front_armored
                , GeneratedContent.Create_knight_Leg_Roof_bang_armored
                , GeneratedContent.Create_knight_Leg_SweetDreams_front_armored
                , GeneratedContent.Create_knight_Leg_Fall_back_armored
                , GeneratedContent.Create_knight_Leg_Crouching_edge_armored
                , GeneratedContent.Create_knight_Leg_Crouching_armored
            );

            var legNaked = GreateLegsAnimator(
                thing
                , skinColorGetter
                , GeneratedContent.Create_knight_Leg_idle
                , GeneratedContent.Create_knight_Leg_Walking
                , GeneratedContent.Create_knight_Leg_wall_back
                , GeneratedContent.Create_knight_Leg_Fall_back
                , GeneratedContent.Create_knight_Leg_Roof_bang
                , GeneratedContent.Create_knight_Leg_Crouching
                , GeneratedContent.Create_knight_Leg_Crouching_edge
                , GeneratedContent.Create_knight_Leg_SweetDreams_back
            );

            var legNaked2 = GreateLegsAnimator2(
                thing
                , skinColorGetter
                , GeneratedContent.Create_knight_Leg_idle
                , GeneratedContent.Create_knight_Leg_Walking
                , GeneratedContent.Create_knight_Leg_wall_front
                , GeneratedContent.Create_knight_Leg_Fall_front
                , GeneratedContent.Create_knight_Leg_Roof_bang
                , GeneratedContent.Create_knight_Leg_SweetDreams_front
                , GeneratedContent.Create_knight_Leg_Fall_back
                , GeneratedContent.Create_knight_Leg_Crouching_edge
                , GeneratedContent.Create_knight_Leg_Crouching
            );

            thing.AddAnimation(
                CreateArmorAnimator(thing, legNaked, legArmored, TakesDamage.DAMAGE_DURATION)
            );

            thing.AddAnimation(
                CreateArmorAnimator(thing, legNaked2, legArmored2, TakesDamage.DAMAGE_DURATION)
            );
        }

        private Animator CreateArmorAnimator(Humanoid thing, Animator naked, Animator armored, int asdzxc)
        {
            return new Animator(
                    new AnimationTransitionOnCondition(naked, () => HeadIsArmored(thing, asdzxc))
                    , new AnimationTransitionOnCondition(armored, () => !HeadIsArmored(thing, asdzxc))
            );
        }

        private bool HeadIsArmored(Humanoid thing, int asdzxc)
        {
            return thing.HitPoints <= 1
                && thing.DamageDuration <= TakesDamage.DAMAGE_DURATION - asdzxc;
        }

        private Animator CreateArmAnimation(
            Humanoid thing
            , Func<Color> ArmorColor
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Arm_Idle
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Arm_Attack)
        {
            var backLegIndex = TORSO_Z + 0.002f;

            var backLegWalking = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, feet_y, backLegIndex, 200, 5, true);

            var backLegCrouch = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, crouch_y, backLegIndex, 200, 5, true);

            var backLegWalkingAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, feet_y, backLegIndex, 200, 5, true, false);

            var backLegCrouchAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, crouch_y, backLegIndex, 200, 5, true, false);

            Func<bool> crouchCondition = () =>
                thing.LegState == LegState.Crouching
                || thing.LegState == LegState.SweetDreams;

            Func<bool> attackCondition = () =>
                thing.TorsoState == TorsoState.Attack
                || thing.TorsoState == TorsoState.AttackCrouching;

            Func<bool> walkIdle = () => !crouchCondition() && !attackCondition();
            Func<bool> crouchIdle = () => crouchCondition() && !attackCondition();
            Func<bool> walkAttack = () => !crouchCondition() && attackCondition();
            Func<bool> crouchAttack = () => crouchCondition() && attackCondition();

            return new Animator(
                new AnimationTransitionOnCondition(backLegWalking, walkIdle)
                , new AnimationTransitionOnCondition(backLegCrouch, crouchIdle)
                , new AnimationTransitionOnCondition(backLegWalkingAttack, walkAttack)
                , new AnimationTransitionOnCondition(backLegCrouchAttack, crouchAttack)
            );
        }

        private Animator CreateArmAnimation2(
            Humanoid thing
            , Func<Color> ArmorColor
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Arm_Idle
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Arm_Attack)
        {
            var frontLegIndex = TORSO_Z - 0.002f;

            var frontLegWalking = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, feet_y, frontLegIndex);

            var frontLegCrouch = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, crouch_y, frontLegIndex);

            var frontLegWalkingAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, feet_y, frontLegIndex, 0, 0, false, false);

            var frontLegCrouchAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, crouch_y, frontLegIndex, 0, 0, false, false);

            Func<bool> crouchCondition = () =>
                thing.LegState == LegState.Crouching
                || thing.LegState == LegState.SweetDreams;

            Func<bool> attackCondition = () =>
                thing.TorsoState == TorsoState.Attack
                || thing.TorsoState == TorsoState.AttackCrouching;

            Func<bool> walkIdle = () => !crouchCondition() && !attackCondition();
            Func<bool> crouchIdle = () => crouchCondition() && !attackCondition();
            Func<bool> walkAttack = () => !crouchCondition() && attackCondition();
            Func<bool> crouchAttack = () => crouchCondition() && attackCondition();

            return new Animator(
                new AnimationTransitionOnCondition(frontLegWalking, walkIdle)
                , new AnimationTransitionOnCondition(frontLegCrouch, crouchIdle)
                , new AnimationTransitionOnCondition(frontLegWalkingAttack, walkAttack)
                , new AnimationTransitionOnCondition(frontLegCrouchAttack, crouchAttack)
            );
        }

        private Animator GreateLegsAnimator(
            Humanoid thing
            , Func<Color> ArmorColor
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Idle
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Walking
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_wall_back
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Fall_back
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Roof_bang
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Crouching
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Crouching_edge
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_SweetDreams_back
            )
        {
            var backLegIndex = TORSO_Z + 0.001f;

            var backLegWalking = CreateFlippableAnimation(thing, Create_knight_Leg_Walking, ArmorColor, feet_y, backLegIndex, 225, 5);

            var backWall = CreateFlippableAnimation(thing, Create_knight_Leg_wall_back, ArmorColor, feet_y, backLegIndex, 225, 5);

            var backLegFall = CreateFlippableAnimation(thing, Create_knight_Leg_Fall_back, ArmorColor, feet_y, backLegIndex, 225, 5);

            var backLegRoof_bang = CreateFlippableAnimation(thing, Create_knight_Leg_Roof_bang, ArmorColor, feet_y, backLegIndex, 225, 5);

            var backLegIdle = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, feet_y, backLegIndex, 225, 5, true);

            var backLegIdleEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, feet_y, backLegIndex, 225, 5);

            var backLegIdleBackOnTheEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, feet_y, backLegIndex, 255, 0, true);

            var backLegCrouchBackOnTheEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching, ArmorColor, crouch_y, backLegIndex, 255, 0);

            var backLegCrouchEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching_edge, ArmorColor, crouch_y, backLegIndex, 225, 5);

            var backLegCrouch = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching, ArmorColor, crouch_y, backLegIndex, 225, 5);

            var backSweetDreams = CreateFlippableAnimation(thing, Create_knight_Leg_SweetDreams_back, ArmorColor, crouch_y, backLegIndex, 225, 5);

            return
                new Animator(
                    new AnimationTransitionOnCondition(backLegIdle, () => NormalStanding(thing))
                    , new AnimationTransitionOnCondition(backLegIdleEdge, () => EdgeStanding(thing))
                    , new AnimationTransitionOnCondition(backLegIdleBackOnTheEdge, () => IdleFacingBackEdge(thing))
                    , new AnimationTransitionOnCondition(backLegCrouchBackOnTheEdge, () => CrouchFacingBackEdge(thing))
                    , new AnimationTransitionOnCondition(backWall, () => thing.LegState == LegState.SlidingWall)
                    , new AnimationTransitionOnCondition(backSweetDreams, () => thing.LegState == LegState.SweetDreams)
                    , new AnimationTransitionOnCondition(backLegWalking, () => thing.LegState == LegState.Walking)
                    , new AnimationTransitionOnCondition(backLegFall, () => thing.LegState == LegState.Falling)
                    , new AnimationTransitionOnCondition(backLegRoof_bang, () => thing.LegState == LegState.HeadBump)
                    , new AnimationTransitionOnCondition(backLegCrouch, () => NormalCrouch(thing))
                    , new AnimationTransitionOnCondition(backLegCrouchEdge, () => EdgeCrouch(thing))
                );
        }

        private Animator GreateLegsAnimator2(Humanoid thing, Func<Color> ArmorColor
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Idle
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Walking
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_wall_front
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Fall_front
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Roof_bang
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_SweetDreams_front
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Fall_back
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Crouching_edge
           , Func<int, int, int?, int?, bool, Animation> Create_knight_Leg_Crouching

            )
        {
            var frontLegIndex = TORSO_Z - 0.001f;

            var frontLegWalking = CreateFlippableAnimation(thing, Create_knight_Leg_Walking, ArmorColor, feet_y, frontLegIndex);

            var frontWall = CreateFlippableAnimation(thing, Create_knight_Leg_wall_front, ArmorColor, feet_y, frontLegIndex);

            var frontLegFall = CreateFlippableAnimation(thing, Create_knight_Leg_Fall_front, ArmorColor, feet_y, frontLegIndex);

            var frontLegRoof_bang = CreateFlippableAnimation(thing, Create_knight_Leg_Roof_bang, ArmorColor, feet_y, frontLegIndex);

            var frontLegIdle = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, feet_y, frontLegIndex);

            var frontLegIdleEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, feet_y, frontLegIndex);

            var frontLegIdleBackOnTheEdge = CreateFlippableAnimation(thing, Create_knight_Leg_SweetDreams_front, ArmorColor, feet_y, frontLegIndex);

            var frontLegCrouchBackOnTheEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Fall_back, ArmorColor, crouch_y, frontLegIndex);

            var frontLegCrouchEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching_edge, ArmorColor, crouch_y, frontLegIndex);

            var frontLegCrouch = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching, ArmorColor, crouch_y, frontLegIndex);

            var frontSweetDreams = CreateFlippableAnimation(thing, Create_knight_Leg_SweetDreams_front, ArmorColor, crouch_y, frontLegIndex);

            return
                new Animator(
                    new AnimationTransitionOnCondition(frontLegIdle, () => NormalStanding(thing))
                    , new AnimationTransitionOnCondition(frontLegIdleEdge, () => EdgeStanding(thing))
                    , new AnimationTransitionOnCondition(frontLegIdleBackOnTheEdge, () => IdleFacingBackEdge(thing))
                    , new AnimationTransitionOnCondition(frontLegCrouchBackOnTheEdge, () => CrouchFacingBackEdge(thing))
                    , new AnimationTransitionOnCondition(frontWall, () => thing.LegState == LegState.SlidingWall)
                    , new AnimationTransitionOnCondition(frontSweetDreams, () => thing.LegState == LegState.SweetDreams)
                    , new AnimationTransitionOnCondition(frontLegWalking, () => thing.LegState == LegState.Walking)
                    , new AnimationTransitionOnCondition(frontLegFall, () => thing.LegState == LegState.Falling)
                    , new AnimationTransitionOnCondition(frontLegRoof_bang, () => thing.LegState == LegState.HeadBump)
                    , new AnimationTransitionOnCondition(frontLegCrouch, () => NormalCrouch(thing))
                    , new AnimationTransitionOnCondition(frontLegCrouchEdge, () => EdgeCrouch(thing))
            );
        }

        private IHandleAnimation CreateFlippableAnimation(
            Humanoid thing
            , Func<int, int, int?, int?, bool, Animation> createAnimation
            , Func<Color> ColorGetter
            , int y
            , float z
            , int bonus = 0
            , int startingFrame = 0
            , bool reverse = false
            , bool loop = true
            )
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
            flipped.LoopDisabled = !loop;

            flipped.ColorGetter = ColorGetter;

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
            notFlipped.LoopDisabled = !loop;

            notFlipped.ColorGetter = ColorGetter;

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

        private bool CrouchFacingBackEdge(Humanoid thing)
        {
            return thing.LegState == LegState.Crouching
                            && IsFacingBackTheEdge(thing);
        }

        private bool IdleFacingBackEdge(Humanoid thing)
        {
            return thing.LegState == LegState.Standing
                            && IsFacingBackTheEdge(thing);
        }

        private bool IsFacingBackTheEdge(Humanoid thing)
        {
            return
                  (
                      thing.FacingRight
                      && !thing.LeftGroundAcidentChecker.Colliding<GroundCollider>()
                  )
                  ||
                  (
                      !thing.FacingRight
                      && !thing.RightGroundAcidentChecker.Colliding<GroundCollider>()
                  );
        }

        private bool EdgeCrouch(Humanoid thing)
        {
            return
                  thing.LegState == LegState.Crouching
                  && FacingTheEdge(thing);
        }

        private bool NormalCrouch(Humanoid thing)
        {
            return
                  thing.LegState == LegState.Crouching
                  && thing.RightGroundAcidentChecker.Colliding<GroundCollider>()
                  && thing.LeftGroundAcidentChecker.Colliding<GroundCollider>();
        }

        private bool EdgeStanding(Humanoid thing)
        {
            return
                  thing.LegState == LegState.Standing
                  && FacingTheEdge(thing);
        }

        private bool NormalStanding(Humanoid thing)
        {
            return
                  thing.LegState == LegState.Standing
                  && thing.RightGroundAcidentChecker.Colliding<GroundCollider>()
                  && thing.LeftGroundAcidentChecker.Colliding<GroundCollider>();
        }

        private bool FacingTheEdge(Humanoid thing)
        {
            return
                   (
                       !thing.FacingRight
                       && !thing.LeftGroundAcidentChecker.Colliding<GroundCollider>()
                   )
                   ||
                   (
                       thing.FacingRight
                       && !thing.RightGroundAcidentChecker.Colliding<GroundCollider>()
                   );
        }

        private void HeadAnimator(Humanoid thing)
        {
            thing.AddAnimation(
            CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_hair, HairColorGetter
                , feet_y
                , HEAD_Z - 0.002f)
            );

            thing.AddAnimation(
            CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_eyes, CothColorGetter
                , feet_y
                , HEAD_Z - 0.001f)
            );

            thing.AddAnimation(
            CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_face, skinColorGetter
                , feet_y
                , HEAD_Z)
            );


            //var stand_left = GeneratedContent.Create_knight_head(
            //    x
            //    , feet_y);
            //stand_left.ScaleX = scale;
            //stand_left.ScaleY = scale;
            //stand_left.RenderingLayer = HEAD_Z;

            //var stand_right = GeneratedContent.Create_knight_head(
            //    flippedx
            //    , feet_y
            //    , null
            //    , null
            //    , true);
            //stand_right.ScaleX = scale;
            //stand_right.ScaleY = scale;
            //stand_right.RenderingLayer = HEAD_Z;

            //var stand_left_armored = GeneratedContent.Create_knight_head_armor1(
            //    x
            //    , feet_y);
            //stand_left_armored.ScaleX = scale;
            //stand_left_armored.ScaleY = scale;
            //stand_left_armored.ColorGetter = () => thing.ArmorColor;
            //stand_left_armored.RenderingLayer = HEAD_Z;

            //var stand_right_armored = GeneratedContent.Create_knight_head_armor1(
            //    flippedx
            //    , feet_y
            //    , null
            //    , null
            //    , true);
            //stand_right_armored.ScaleX = scale;
            //stand_right_armored.ScaleY = scale;
            //stand_right_armored.ColorGetter = () => thing.ArmorColor;
            //stand_right_armored.RenderingLayer = HEAD_Z;

            //var crouch_left = GeneratedContent.Create_knight_head(
            //    x
            //    , crouch_y);
            //crouch_left.ScaleX = scale;
            //crouch_left.ScaleY = scale;
            //crouch_left.RenderingLayer = HEAD_Z;

            //var crouch_right = GeneratedContent.Create_knight_head(
            //    flippedx
            //    , crouch_y
            //    , null
            //    , null
            //    , true);
            //crouch_right.ScaleX = scale;
            //crouch_right.ScaleY = scale;
            //crouch_right.RenderingLayer = HEAD_Z;

            //var headbang_left = GeneratedContent.Create_knight_roof_bang_head(
            //    x
            //    , feet_y + bump_y);
            //headbang_left.ScaleX = scale;
            //headbang_left.ScaleY = scale;
            //headbang_left.RenderingLayer = HEAD_Z;

            //var headbang_right = GeneratedContent.Create_knight_roof_bang_head(
            //    flippedx
            //    , feet_y + bump_y
            //    , null
            //    , null
            //    , true);
            //headbang_right.ScaleX = scale;
            //headbang_right.ScaleY = scale;
            //headbang_right.RenderingLayer = HEAD_Z;

            //var crouch_left_armored = GeneratedContent.Create_knight_head_armor1(
            //    x
            //    , crouch_y);
            //crouch_left_armored.ScaleX = scale;
            //crouch_left_armored.ScaleY = scale;
            //crouch_left_armored.ColorGetter = () => thing.ArmorColor;
            //crouch_left_armored.RenderingLayer = HEAD_Z;

            //var crouch_right_armored = GeneratedContent.Create_knight_head_armor1(
            //    flippedx
            //    , crouch_y
            //    , null
            //    , null
            //    , true);
            //crouch_right_armored.ScaleX = scale;
            //crouch_right_armored.ScaleY = scale;
            //crouch_right_armored.ColorGetter = () => thing.ArmorColor;
            //crouch_right_armored.RenderingLayer = HEAD_Z;

            //var headbang_left_armored = GeneratedContent.Create_knight_head_armor_bang1(
            //    x
            //    , feet_y + bump_y);
            //headbang_left_armored.ScaleX = scale;
            //headbang_left_armored.ScaleY = scale;
            //headbang_left_armored.ColorGetter = () => thing.ArmorColor;
            //headbang_left_armored.RenderingLayer = HEAD_Z;

            //var headbang_right_armored = GeneratedContent.Create_knight_head_armor_bang1(
            //    flippedx
            //    , feet_y + bump_y
            //    , null
            //    , null
            //    , true);
            //headbang_right_armored.ScaleX = scale;
            //headbang_right_armored.ScaleY = scale;
            //headbang_right_armored.ColorGetter = () => thing.ArmorColor;
            //headbang_right_armored.RenderingLayer = HEAD_Z;

            //var nakedAnimator = new Animator(
            //    new AnimationTransitionOnCondition(stand_left, () => thing.HeadState == HeadState.Standing && thing.FacingRight == false)
            //    , new AnimationTransitionOnCondition(stand_right, () => thing.HeadState == HeadState.Standing && thing.FacingRight == true)
            //    , new AnimationTransitionOnCondition(crouch_left, () => thing.HeadState == HeadState.Crouching && thing.FacingRight == false)
            //    , new AnimationTransitionOnCondition(crouch_right, () => thing.HeadState == HeadState.Crouching && thing.FacingRight == true)
            //    , new AnimationTransitionOnCondition(headbang_left, () => thing.HeadState == HeadState.Bump && thing.FacingRight == false)
            //    , new AnimationTransitionOnCondition(headbang_right, () => thing.HeadState == HeadState.Bump && thing.FacingRight == true)
            //);

            //var armoredAnimator = new Animator(
            //    new AnimationTransitionOnCondition(stand_left_armored, () => thing.HeadState == HeadState.Standing && thing.FacingRight == false)
            //    , new AnimationTransitionOnCondition(stand_right_armored, () => thing.HeadState == HeadState.Standing && thing.FacingRight == true)
            //    , new AnimationTransitionOnCondition(crouch_left_armored, () => thing.HeadState == HeadState.Crouching && thing.FacingRight == false)
            //    , new AnimationTransitionOnCondition(crouch_right_armored, () => thing.HeadState == HeadState.Crouching && thing.FacingRight == true)
            //    , new AnimationTransitionOnCondition(headbang_left_armored, () => thing.HeadState == HeadState.Bump && thing.FacingRight == false)
            //    , new AnimationTransitionOnCondition(headbang_right_armored, () => thing.HeadState == HeadState.Bump && thing.FacingRight == true)
            //);

            //var animatorsWrapper =
            //    new Animator(
            //        new AnimationTransitionOnCondition(nakedAnimator, () => thing.HitPoints <= 1 && thing.DamageDuration == TakesDamage.DAMAGE_DURATION - 5)
            //        , new AnimationTransitionOnCondition(armoredAnimator, () => thing.HitPoints == 2));

            //thing.AddAnimation(animatorsWrapper);
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
            stand_left.ColorGetter = CothColorGetter;

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
            stand_right.ColorGetter = CothColorGetter;

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
            crouch_left.ColorGetter = CothColorGetter;

            var crouch_right = GeneratedContent.Create_knight_torso_walking(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;
            crouch_right.RenderingLayer = TORSO_Z;
            crouch_right.ColorGetter = CothColorGetter;


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
                , new AnimationTransitionOnCondition(stand_left,
                    () =>
                    thing.TorsoState == TorsoState.Attack
                    && thing.FacingRight == false
                    )
                , new AnimationTransitionOnCondition(stand_right,
                    () =>
                    thing.TorsoState == TorsoState.Attack
                    && thing.FacingRight == true
                    )
                , new AnimationTransitionOnCondition(crouch_left,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouching
                    && thing.FacingRight == false
                    )
                , new AnimationTransitionOnCondition(crouch_right,
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
                , new AnimationTransitionOnCondition(stand_left_armored,
                    () =>
                    thing.TorsoState == TorsoState.Attack
                    && thing.FacingRight == false
                    )
                , new AnimationTransitionOnCondition(stand_right_armored,
                    () =>
                    thing.TorsoState == TorsoState.Attack
                    && thing.FacingRight == true
                    )
                , new AnimationTransitionOnCondition(crouch_left_armored,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouching
                    && thing.FacingRight == false
                    )
                , new AnimationTransitionOnCondition(crouch_right_armored,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouching
                    && thing.FacingRight == true
                )
            );

            thing.AddAnimation(
                new Animator(
                new AnimationTransitionOnCondition(armored_torso, () => thing.HitPoints > 1)
                , new AnimationTransitionOnCondition(naked_torso, () => thing.HitPoints <= 1 && thing.DamageDuration == TakesDamage.DAMAGE_DURATION / 2)
                )
            );
        }

        private Animator CreateWhipAnimator(Humanoid thing)
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
