using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class HumanoidAnimatorFactory
    {
        private const int x = -160;
        private const int flippedx = -140;
        public const int feet_y = -300;
        public const int crouch_y = 0;
        public const int scale = 5;

        public const float HEAD_Z = 0.120f;
        public const float TORSO_Z = 0.122f;
        public const float LEG_Z = 0.123f;

        private float HeadZ = HEAD_Z;
        private float TorsoZ = TORSO_Z;
        private float LegZ = LEG_Z;

        private const int bump_y = -50;

        public void CreateAnimator(Humanoid thing, int playerIndex)
        {
            //TODO: move to constructor... thing too
            HeadZ += playerIndex / 100f;
            TorsoZ += playerIndex / 100f;
            LegZ += playerIndex / 100f;

            thing.SetArmorColor(Color.White);
            HeadAnimator(thing);
            TorsoAnimator(thing);


            var armoredArm = CreateArmAnimation(thing, thing.GetArmorColor, GeneratedContent.Create_knight_Arm_Idle_armored, GeneratedContent.Create_knight_Arm_Attack_armored);
            var armoredArm2 = CreateArmAnimation2(thing, thing.GetArmorColor, GeneratedContent.Create_knight_Arm_Idle_armored, GeneratedContent.Create_knight_Arm_Attack_armored);

            var nakedArm = CreateArmAnimation(thing, thing.GetSkinColor, GeneratedContent.Create_knight_Arm_Idle, GeneratedContent.Create_knight_Arm_Attack);
            var nakedArm2 = CreateArmAnimation2(thing, thing.GetSkinColor, GeneratedContent.Create_knight_Arm_Idle, GeneratedContent.Create_knight_Arm_Attack);

            thing.AddAnimation(
                ShowOnlyWhen(nakedArm, thing.IsNotUsingBreastPlate)
            );
            thing.AddAnimation(
                ShowOnlyWhen(armoredArm, thing.IsUsingBreastPlate)
            );

            thing.AddAnimation(
                ShowOnlyWhen(nakedArm2, thing.IsNotUsingBreastPlate)
            );
            thing.AddAnimation(
                ShowOnlyWhen(armoredArm2, thing.IsUsingBreastPlate)
            );


            var legArmored = GreateLegsAnimator(
                thing
                , thing.GetArmorColor
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
                , thing.GetArmorColor
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
                , thing.GetSkinColor
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
                , thing.GetSkinColor
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
                ShowOnlyWhen(legNaked, thing.IsNotUsingPlateShoe)
            );

            thing.AddAnimation(
                ShowOnlyWhen(legArmored, thing.IsUsingPlateShoe)
            );

            thing.AddAnimation(
                ShowOnlyWhen(legNaked2, thing.IsNotUsingPlateShoe)
            );

            thing.AddAnimation(
                ShowOnlyWhen(legArmored2, thing.IsUsingPlateShoe)
            );
        }

        private Animator CreateArmAnimation(
            Humanoid thing
            , Func<Color> ArmorColor
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Arm_Idle
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Arm_Attack)
        {
            var backLegIndex = TorsoZ + 0.002f;

            var backLegWalking = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, backLegIndex, feet_y, true, true, 200, 5);
            var backLegCrouch = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, backLegIndex, crouch_y, true, true, 200, 5);
            var backLegWalkingAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, backLegIndex, feet_y, false, true, 200, 5);
            var backLegCrouchAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, backLegIndex, crouch_y, false, true, 200, 5);

            Func<bool> walkIdle = () => !thing.IsCrouchingOrSweetDreaming() && !thing.IsAttacking();
            Func<bool> crouchIdle = () => thing.IsCrouchingOrSweetDreaming() && !thing.IsAttacking();
            Func<bool> walkAttack = () => !thing.IsCrouchingOrSweetDreaming() && thing.IsAttacking();
            Func<bool> crouchAttack = () => thing.IsCrouchingOrSweetDreaming() && thing.IsAttacking();

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
            var frontLegIndex = TorsoZ - 0.002f;

            var frontLegWalking = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, frontLegIndex, feet_y);
            var frontLegCrouch = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, frontLegIndex, crouch_y);
            var frontLegWalkingAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, frontLegIndex, feet_y, false, false);
            var frontLegCrouchAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, frontLegIndex, crouch_y, false, false);

            Func<bool> walkIdle = () => !thing.IsCrouchingOrSweetDreaming() && !thing.IsAttacking();
            Func<bool> crouchIdle = () => thing.IsCrouchingOrSweetDreaming() && !thing.IsAttacking();
            Func<bool> walkAttack = () => !thing.IsCrouchingOrSweetDreaming() && thing.IsAttacking();
            Func<bool> crouchAttack = () => thing.IsCrouchingOrSweetDreaming() && thing.IsAttacking();

            return new Animator(
                new AnimationTransitionOnCondition(frontLegWalking, walkIdle)
                , new AnimationTransitionOnCondition(frontLegCrouch, crouchIdle)
                , new AnimationTransitionOnCondition(frontLegWalkingAttack, walkAttack)
                , new AnimationTransitionOnCondition(frontLegCrouchAttack, crouchAttack)
            );
        }

        //rename to to mention backleg
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
            //remove back prefix
            var backLegIndex = TorsoZ + 0.001f;

            //true em todos os loops

            var backLegWalking = CreateFlippableAnimation(thing, Create_knight_Leg_Walking, ArmorColor, backLegIndex, feet_y, true, false, 255, 5);
            var backWall = CreateFlippableAnimation(thing, Create_knight_Leg_wall_back, ArmorColor, backLegIndex, feet_y, true, false, 255, 5);
            var backLegFall = CreateFlippableAnimation(thing, Create_knight_Leg_Fall_back, ArmorColor, backLegIndex, feet_y, true, false, 255, 5);
            var backLegRoof_bang = CreateFlippableAnimation(thing, Create_knight_Leg_Roof_bang, ArmorColor, backLegIndex, feet_y, true, false, 255, 5);
            var backLegIdle = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, backLegIndex, feet_y, true, true, 255, 5);
            var backLegIdleEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, backLegIndex, feet_y, true, false, 255, 5);
            var backLegIdleBackOnTheEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, backLegIndex, feet_y, true, true, 255, 0);
            var backLegCrouchBackOnTheEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching, ArmorColor, backLegIndex, crouch_y, true, false, 255, 0);
            var backLegCrouchEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching_edge, ArmorColor, backLegIndex, crouch_y, true, false, 255, 5);
            var backLegCrouch = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching, ArmorColor, backLegIndex, crouch_y, true, false, 255, 5);
            var backSweetDreams = CreateFlippableAnimation(thing, Create_knight_Leg_SweetDreams_back, ArmorColor, backLegIndex, crouch_y, true, false, 255, 5);

            return
                new Animator(
                    new AnimationTransitionOnCondition(backLegIdle, thing.IsIdle)
                    , new AnimationTransitionOnCondition(backLegIdleEdge, thing.IsIdleOnTheEdge)
                    , new AnimationTransitionOnCondition(backLegIdleBackOnTheEdge, thing.IsIdleOnTheEdgeFacingBack)
                    , new AnimationTransitionOnCondition(backLegCrouchBackOnTheEdge, thing.IsCrouchingOnTheEdgeFacingBack)
                    , new AnimationTransitionOnCondition(backWall, () => thing.LegState == LegState.SlidingWall)
                    , new AnimationTransitionOnCondition(backSweetDreams, () => thing.LegState == LegState.SweetDreams)
                    , new AnimationTransitionOnCondition(backLegWalking, () => thing.LegState == LegState.Walking)
                    , new AnimationTransitionOnCondition(backLegFall, () => thing.LegState == LegState.Falling)
                    , new AnimationTransitionOnCondition(backLegRoof_bang, () => thing.LegState == LegState.HeadBump)
                    , new AnimationTransitionOnCondition(backLegCrouch, thing.IsCrouching)
                    , new AnimationTransitionOnCondition(backLegCrouchEdge, thing.IsCrouchingOnTheEdge)
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
            var frontLegIndex = TorsoZ - 0.001f;

            var frontLegWalking = CreateFlippableAnimation(thing, Create_knight_Leg_Walking, ArmorColor, frontLegIndex, feet_y);
            var frontWall = CreateFlippableAnimation(thing, Create_knight_Leg_wall_front, ArmorColor, frontLegIndex, feet_y);
            var frontLegFall = CreateFlippableAnimation(thing, Create_knight_Leg_Fall_front, ArmorColor, frontLegIndex, feet_y);
            var frontLegRoof_bang = CreateFlippableAnimation(thing, Create_knight_Leg_Roof_bang, ArmorColor, frontLegIndex, feet_y);
            var frontLegIdle = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, frontLegIndex, feet_y);
            var frontLegIdleEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Idle, ArmorColor, frontLegIndex, feet_y);
            var frontLegIdleBackOnTheEdge = CreateFlippableAnimation(thing, Create_knight_Leg_SweetDreams_front, ArmorColor, frontLegIndex, feet_y);
            var frontLegCrouchBackOnTheEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Fall_back, ArmorColor, frontLegIndex, crouch_y);
            var frontLegCrouchEdge = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching_edge, ArmorColor, frontLegIndex, crouch_y);
            var frontLegCrouch = CreateFlippableAnimation(thing, Create_knight_Leg_Crouching, ArmorColor, frontLegIndex, crouch_y);
            var frontSweetDreams = CreateFlippableAnimation(thing, Create_knight_Leg_SweetDreams_front, ArmorColor, frontLegIndex, crouch_y);

            return
                new Animator(
                    new AnimationTransitionOnCondition(frontLegIdle, thing.IsIdle)
                    , new AnimationTransitionOnCondition(frontLegIdleEdge, thing.IsIdleOnTheEdge)
                    , new AnimationTransitionOnCondition(frontLegIdleBackOnTheEdge, thing.IsIdleOnTheEdgeFacingBack)
                    , new AnimationTransitionOnCondition(frontLegCrouchBackOnTheEdge, thing.IsCrouchingOnTheEdgeFacingBack)
                    , new AnimationTransitionOnCondition(frontWall, () => thing.LegState == LegState.SlidingWall)
                    , new AnimationTransitionOnCondition(frontSweetDreams, () => thing.LegState == LegState.SweetDreams)
                    , new AnimationTransitionOnCondition(frontLegWalking, () => thing.LegState == LegState.Walking)
                    , new AnimationTransitionOnCondition(frontLegFall, () => thing.LegState == LegState.Falling)
                    , new AnimationTransitionOnCondition(frontLegRoof_bang, () => thing.LegState == LegState.HeadBump)
                    , new AnimationTransitionOnCondition(frontLegCrouch, thing.IsCrouching)
                    , new AnimationTransitionOnCondition(frontLegCrouchEdge, thing.IsCrouchingOnTheEdge)
            );
        }

        private IHandleAnimation CreateFlippableAnimation(
            Humanoid thing
            , Func<int, int, int?, int?, bool, Animation> createAnimation
            , Func<Color> ColorGetter
            , float z
            , int y
            //, int x_notFlipped = x
            //, int x_flipped = flippedx
            , bool loop = true
            , bool reverse = false
            , int reverseBonusX = 0
            , int startingFrame = 0
            )
        {
            if (reverse)
                reverseBonusX *= -1;

            var flipped = createAnimation(
                                flippedx + reverseBonusX
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
                   x - reverseBonusX
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
            walk_right_back.RenderingLayer = TorsoZ + 0.001f; ;
            walk_right_back.FrameDuration = 2;
            walk_right_back.StartingFrame = 6;
        }


        private Animator CreateCrouchAnimator(Humanoid thing, IHandleAnimation stand, IHandleAnimation crouch)
        {
            return new Animator(
                new AnimationTransitionOnCondition(stand, () => !thing.IsCrouchingOrSweetDreaming())
                , new AnimationTransitionOnCondition(crouch, thing.IsCrouchingOrSweetDreaming)
            );
        }

        Animation EmptyAnimation = new Animation();

        private Animator ShowOnlyWhen(IHandleAnimation animation, Func<bool> condition)
        {
            return new Animator(
                new AnimationTransitionOnCondition(animation, condition)
                , new AnimationTransitionOnCondition(EmptyAnimation, () => !condition())
            );
        }

        private void HeadAnimator(Humanoid thing)
        {

            Func<bool> NakedHead = () => !thing.IsUsingHelmet()
                                 && thing.HeadState != HeadState.Bump;
            Func<bool> NakedHeadBump = () => !thing.IsUsingHelmet()
                                && thing.HeadState == HeadState.Bump;
            Func<bool> ArmoredHead = () => thing.IsUsingHelmet()
                                 && thing.HeadState != HeadState.Bump;
            Func<bool> ArmoredHeadBump = () => thing.IsUsingHelmet()
                                && thing.HeadState == HeadState.Bump;

            {
                var hair_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_hair, thing.GetHairColor, HeadZ - 0.002f, feet_y);
                var eye_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_eyes, thing.GetEyeColor, HeadZ - 0.001f, feet_y);
                var face_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_face, thing.GetSkinColor, HeadZ, feet_y);
                var hair_crouching = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_hair, thing.GetHairColor, HeadZ - 0.002f, crouch_y);
                var eye_crouching = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_eyes, thing.GetEyeColor, HeadZ - 0.001f, crouch_y);
                var face_crouching = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_face, thing.GetSkinColor, HeadZ, crouch_y);

                thing.AddAnimation(ShowOnlyWhen(CreateCrouchAnimator(thing, hair_standing, hair_crouching), NakedHead));
                thing.AddAnimation(ShowOnlyWhen(CreateCrouchAnimator(thing, eye_standing, eye_crouching), NakedHead));
                thing.AddAnimation(ShowOnlyWhen(CreateCrouchAnimator(thing, face_standing, face_crouching), NakedHead));
            }

            {
                var hair_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_bang_hair, thing.GetHairColor, HeadZ - 0.002f, feet_y);
                var eye_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_bang_eye, thing.GetEyeColor, HeadZ - 0.001f, feet_y);
                var face_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_bang_face, thing.GetSkinColor, HeadZ, feet_y);
                thing.AddAnimation(ShowOnlyWhen(hair_standing, NakedHeadBump));
                thing.AddAnimation(ShowOnlyWhen(eye_standing, NakedHeadBump));
                thing.AddAnimation(ShowOnlyWhen(face_standing, NakedHeadBump));
            }

            {
                var helm_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_armor1, thing.GetArmorColor, HeadZ, feet_y);
                var helm_crouching = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_armor1, thing.GetArmorColor, HeadZ, crouch_y);

                var normalHelm = CreateCrouchAnimator(
                thing
                , helm_standing
                , helm_crouching);

                thing.AddAnimation(
                    ShowOnlyWhen(normalHelm, ArmoredHead)
                );
            }

            {
                var slamedHelm = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_armor_bang1, thing.GetArmorColor, HeadZ, feet_y);

                thing.AddAnimation(
                    ShowOnlyWhen(slamedHelm, ArmoredHeadBump)
                );
            }
        }

        private void TorsoAnimator(Humanoid thing)
        {
            var stand_left = GeneratedContent.Create_knight_torso_walking(
                x
                , feet_y);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;
            stand_left.RenderingLayer = TorsoZ;
            stand_left.FrameDuration = 2;
            stand_left.ColorGetter = thing.GetEyeColor;

            var stand_right = GeneratedContent.Create_knight_torso_walking(
                flippedx
                , feet_y
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;
            stand_right.RenderingLayer = TorsoZ;
            stand_right.FrameDuration = 2;
            stand_right.ColorGetter = thing.GetEyeColor;

            var stand_left_armored = GeneratedContent.Create_knight_torso_walking_armored(
                x
                , feet_y);
            stand_left_armored.ScaleX = scale;
            stand_left_armored.ScaleY = scale;
            stand_left_armored.RenderingLayer = TorsoZ;
            stand_left_armored.FrameDuration = 2;
            stand_left_armored.ColorGetter = thing.GetArmorColor;

            var stand_right_armored = GeneratedContent.Create_knight_torso_walking_armored(
                flippedx
                , feet_y
                , null
                , null
                , true);
            stand_right_armored.ScaleX = scale;
            stand_right_armored.ScaleY = scale;
            stand_right_armored.RenderingLayer = TorsoZ;
            stand_right_armored.FrameDuration = 2;
            stand_right_armored.ColorGetter = thing.GetArmorColor;

            var crouch_left = GeneratedContent.Create_knight_torso_walking(
                x
                , crouch_y);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;
            crouch_left.RenderingLayer = TorsoZ;
            crouch_left.ColorGetter = thing.GetEyeColor;

            var crouch_right = GeneratedContent.Create_knight_torso_walking(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;
            crouch_right.RenderingLayer = TorsoZ;
            crouch_right.ColorGetter = thing.GetEyeColor;


            var crouch_left_armored = GeneratedContent.Create_knight_torso_walking_armored(
                x
                , crouch_y);
            crouch_left_armored.ScaleX = scale;
            crouch_left_armored.ScaleY = scale;
            crouch_left_armored.RenderingLayer = TorsoZ;
            crouch_left_armored.ColorGetter = thing.GetArmorColor;

            var crouch_right_armored = GeneratedContent.Create_knight_torso_walking_armored(
                flippedx
                , crouch_y
                , null
                , null
                , true);
            crouch_right_armored.ScaleX = scale;
            crouch_right_armored.ScaleY = scale;
            crouch_right_armored.RenderingLayer = TorsoZ;
            crouch_right_armored.ColorGetter = thing.GetArmorColor;

            Animator whipAnimator = CreateWeaponAnimator(
                thing
                , GeneratedContent.Create_knight_whip_idle
                , GeneratedContent.Create_knight_whip_attack);

            Animator swordAnimator = CreateWeaponAnimator(
                thing
                , GeneratedContent.Create_knight_whip_idle
                , GeneratedContent.Create_knight_sword_attack);

            Animator WandAnimator = CreateWeaponAnimator(
                thing
                , GeneratedContent.Create_knight_whip_idle
                , GeneratedContent.Create_knight_sword_attack);

            thing.AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(whipAnimator, () => thing.weaponType == WeaponType.Whip)
                    , new AnimationTransitionOnCondition(swordAnimator, () => thing.weaponType == WeaponType.Sword)
                    , new AnimationTransitionOnCondition(WandAnimator, () => thing.weaponType == WeaponType.Wand)
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

        private Animator CreateWeaponAnimator(Humanoid thing, Func<int, int, int?, int?, bool, Animation> WeaponIdleAnimation, Func<int, int, int?, int?, bool, Animation> WeaponAttackAnimation)
        {
            Animator whipAnimator = CreateWhipAnimator(thing, WeaponIdleAnimation, WeaponAttackAnimation);
            Animator whipAnimatorArmored = CreateWhipAnimator(thing, WeaponIdleAnimation, WeaponAttackAnimation);

            var animator = new Animator(
                    new AnimationTransitionOnCondition(whipAnimatorArmored, () => thing.HitPoints > 1)
                    , new AnimationTransitionOnCondition(whipAnimator, () => thing.HitPoints <= 1 && thing.DamageDuration == TakesDamage.DAMAGE_DURATION / 2)
                );
            return animator;
        }

        private Animator CreateWhipAnimator(Humanoid thing, Func<int, int, int?, int?, bool, Animation> WeaponIdleAnimation, Func<int, int, int?, int?, bool, Animation> WeaponAttackAnimation)
        {
            var whipZ = HEAD_Z - 0.005f;

            var left_x = -1500;

            var whip_left = WeaponAttackAnimation(left_x, feet_y, null, null, false);
            whip_left.ScaleX = scale;
            whip_left.ScaleY = scale;
            whip_left.LoopDisabled = true;
            whip_left.RenderingLayer = whipZ;
            var whip_left_crouch = WeaponAttackAnimation(left_x, crouch_y, null, null, false);
            whip_left_crouch.ScaleX = scale;
            whip_left_crouch.ScaleY = scale;
            whip_left_crouch.LoopDisabled = true;
            whip_left_crouch.RenderingLayer = whipZ;
            var whip_right = WeaponAttackAnimation(-1400, feet_y, null, null, true);
            whip_right.ScaleX = scale;
            whip_right.ScaleY = scale;
            whip_right.LoopDisabled = true;
            whip_right.RenderingLayer = whipZ;
            var whip_right_crouch = WeaponAttackAnimation(-1400, crouch_y, null, null, true);
            whip_right_crouch.ScaleX = scale;
            whip_right_crouch.ScaleY = scale;
            whip_right_crouch.LoopDisabled = true;
            whip_right_crouch.RenderingLayer = whipZ;

            var whipi_left = WeaponIdleAnimation(left_x, feet_y, null, null, false);
            whipi_left.ScaleX = scale;
            whipi_left.ScaleY = scale;
            whipi_left.FrameDuration = 2;
            whipi_left.RenderingLayer = whipZ;
            var whipi_left_crouch = WeaponIdleAnimation(left_x, crouch_y, null, null, false);
            whipi_left_crouch.ScaleX = scale;
            whipi_left_crouch.ScaleY = scale;
            //whipi_left_crouch.FrameDuration = 2;
            whipi_left_crouch.RenderingLayer = whipZ;
            var whipi_right = WeaponIdleAnimation(-1400, feet_y, null, null, true);
            whipi_right.ScaleX = scale;
            whipi_right.ScaleY = scale;
            whipi_right.FrameDuration = 2;
            whipi_right.RenderingLayer = whipZ;
            var whipi_right_crouch = WeaponIdleAnimation(-1400, crouch_y, null, null, true);
            whipi_right_crouch.ScaleX = scale;
            whipi_right_crouch.ScaleY = scale;
            //whipi_right_crouch.FrameDuration = 2;
            whipi_right_crouch.RenderingLayer = whipZ;
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
