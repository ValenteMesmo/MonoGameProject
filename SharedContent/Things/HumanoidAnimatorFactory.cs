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

        public const float WEAPON_Z = 0.120f;
        public const float FRONT_ARM_Z = 0.121f;
        public const float HAIR_BONUS_Z = 0.122f;
        public const float HAIR_Z = 0.123f;
        public const float EYE_Z = 0.124f;
        public const float FACE_Z = 0.125f;
        public const float FRONT_LEG_Z = 0.126f;
        public const float TORSO_Z = 0.127f;
        public const float BACK_LEG_Z = 0.128f;
        public const float BACK_ARM_Z = 0.129f;

        public float Weapon_z = WEAPON_Z;
        public float Front_arm_z = FRONT_ARM_Z;
        public float Hair_z = HAIR_Z;
        public float Hair_bonus_z = HAIR_BONUS_Z;
        public float Eye_z = EYE_Z;
        public float Face_z = FACE_Z;
        public float Front_leg_z = FRONT_LEG_Z;
        public float Torso_z = TORSO_Z;
        public float Back_leg_z = BACK_LEG_Z;
        public float Back_arm_z = BACK_ARM_Z;

        private const int bump_y = -50;

        public HumanoidAnimatorFactory(Game1 Game1)
        {
            this.Game1 = Game1;
        }


        public void CreateHairBonus(Humanoid parent, Action<Thing> AddToTheWorld)
        {
            var thing = new Thing();
            var hair_standing = CreateFlippableAnimation(parent, GeneratedContent.Create_knight_head_hair_bonus, parent.GetHairColor, Hair_bonus_z, feet_y, true, false, 0, 0, true);
            var hair_crouching = CreateFlippableAnimation(parent, GeneratedContent.Create_knight_head_hair_bonus, parent.GetHairColor, Hair_bonus_z, crouch_y, true, false, 0, 0, true);
            var backhair_standing = CreateFlippableAnimation(parent, GeneratedContent.Create_knight_head_hair_bonus, parent.GetHairColor, Back_leg_z, feet_y, true, false, 400, 0, true);
            var backhair_crouching = CreateFlippableAnimation(parent, GeneratedContent.Create_knight_head_hair_bonus, parent.GetHairColor, Back_leg_z, crouch_y, true, false, 400, 0, true);

            thing.AddAnimation(ShowOnlyWhen(CreateCrouchAnimator(parent, hair_standing, hair_crouching), CreateNakedHeadCondition(parent)));
            thing.AddAnimation(ShowOnlyWhen(CreateCrouchAnimator(parent, backhair_standing, backhair_crouching), CreateNakedHeadCondition(parent)));

            var bonusX = 0;
            var bonusY = 0;
            var horizontalBonusLimit = 50;
            var upBonusLimit = 35;
            var downBonusLimit = 70;
            var speed = 5;

            thing.AddUpdate(() =>
            {
                if (parent.HorizontalSpeed > 50 && parent.FacingRight)
                {
                    bonusX -= speed;
                    if (bonusX < -horizontalBonusLimit)
                        bonusX = -horizontalBonusLimit;
                }
                else if (parent.HorizontalSpeed < -50 && !parent.FacingRight)
                {
                    bonusX += speed;
                    if (bonusX > horizontalBonusLimit)
                        bonusX = horizontalBonusLimit;
                }
                else
                {
                    if (bonusX > 0)
                        bonusX -= speed;
                    else if (bonusX < 0)
                        bonusX += speed;
                }


                if (parent.VerticalSpeed > 50)
                {
                    bonusY -= speed;
                    if (bonusY < -upBonusLimit)
                        bonusY = -upBonusLimit;
                }
                else if (parent.VerticalSpeed < -50)
                {
                    bonusY += speed;
                    if (bonusY > downBonusLimit)
                        bonusY = downBonusLimit;
                }
                else
                {
                    if (bonusY > 0)
                        bonusY -= speed;
                    else if (bonusY < 0)
                        bonusY += speed;
                }
            });
            thing.AddAfterUpdate(() =>
            {
                thing.X = parent.X + bonusX;
                thing.Y = parent.Y + bonusY;
            });
            parent.OnDestroy += () => thing.Destroy();
            thing.AddAfterUpdate(new MoveHorizontallyWithTheWorld(thing));
            AddToTheWorld(thing);
        }

        public void CreateAnimator(Humanoid thing, int playerIndex)
        {
            //TODO: move to constructor... thing too

            Weapon_z += playerIndex / 100f;
            Front_arm_z += playerIndex / 100f;
            Hair_z += playerIndex / 100f;
            Hair_bonus_z += playerIndex / 100f;
            Eye_z += playerIndex / 100f;
            Face_z += playerIndex / 100f;
            Front_leg_z += playerIndex / 100f;
            Torso_z += playerIndex / 100f;
            Back_leg_z += playerIndex / 100f;
            Back_arm_z += playerIndex / 100f;

            //thing.SetArmorColor(Color.White);
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
        }

        private Animator CreateArmAnimation(
            Humanoid thing
            , Func<Color> ArmorColor
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Arm_Idle
            , Func<int, int, int?, int?, bool, Animation> Create_knight_Arm_Attack)
        {
            var backLegWalking = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, Back_arm_z, feet_y, true, true, 200, 5);
            var backLegCrouch = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, Back_arm_z, crouch_y, true, true, 200, 5);
            var backLegWalkingAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, Back_arm_z, feet_y, false, true, 200, 5);
            var backLegCrouchAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, Back_arm_z, crouch_y, false, true, 200, 5);

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
            var frontLegWalking = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, Front_arm_z, feet_y);
            var frontLegCrouch = CreateFlippableAnimation(thing, Create_knight_Arm_Idle, ArmorColor, Front_arm_z, crouch_y);
            var frontLegWalkingAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, Front_arm_z, feet_y, false, false);
            var frontLegCrouchAttack = CreateFlippableAnimation(thing, Create_knight_Arm_Attack, ArmorColor, Front_arm_z, crouch_y, false, false);

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
            , bool reverseFrames = false
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
            if (reverseFrames)
                flipped.AddReverseFrames();

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

        private Animator CreateCrouchAnimator(Humanoid thing, IHandleAnimation stand, IHandleAnimation crouch)
        {
            return new Animator(
                new AnimationTransitionOnCondition(stand, () => !thing.IsCrouchingOrSweetDreaming())
                , new AnimationTransitionOnCondition(crouch, thing.IsCrouchingOrSweetDreaming)
            );
        }

        Animation EmptyAnimation = new Animation();
        private readonly Game1 Game1;

        private Animator ShowOnlyWhen(IHandleAnimation animation, Func<bool> condition)
        {
            return new Animator(
                new AnimationTransitionOnCondition(animation, condition)
                , new AnimationTransitionOnCondition(EmptyAnimation, () => !condition())
            );
        }

        private void HeadAnimator(Humanoid thing)
        {
            Func<bool> NakedHead = CreateNakedHeadCondition(thing);
            Func<bool> NakedHeadBump = () => !thing.IsUsingHelmet()
                                && thing.HeadState == HeadState.Bump;
            Func<bool> ArmoredHead = () => thing.IsUsingHelmet()
                                 && thing.HeadState != HeadState.Bump;
            Func<bool> ArmoredHeadBump = () => thing.IsUsingHelmet()
                                && thing.HeadState == HeadState.Bump;

            {
                var hair_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_hair, thing.GetHairColor, Hair_z, feet_y, true, false, 0, 0, true);
                var eye_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_eyes, thing.GetEyeColor, Eye_z, feet_y);
                var face_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_face, thing.GetSkinColor, Face_z, feet_y);
                var hair_crouching = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_hair, thing.GetHairColor, Hair_z, crouch_y, true, false, 0, 0, true);
                var eye_crouching = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_eyes, thing.GetEyeColor, Eye_z, crouch_y);
                var face_crouching = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_face, thing.GetSkinColor, Face_z, crouch_y);

                thing.AddAnimation(ShowOnlyWhen(CreateCrouchAnimator(thing, hair_standing, hair_crouching), NakedHead));
                thing.AddAnimation(ShowOnlyWhen(CreateCrouchAnimator(thing, eye_standing, eye_crouching), NakedHead));
                thing.AddAnimation(ShowOnlyWhen(CreateCrouchAnimator(thing, face_standing, face_crouching), NakedHead));
            }

            {
                var hair_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_bang_hair, thing.GetHairColor, Hair_z, feet_y);
                var eye_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_bang_eye, thing.GetEyeColor, Eye_z, feet_y);
                var face_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_bang_face, thing.GetSkinColor, Face_z, feet_y);
                thing.AddAnimation(ShowOnlyWhen(hair_standing, NakedHeadBump));
                thing.AddAnimation(ShowOnlyWhen(eye_standing, NakedHeadBump));
                thing.AddAnimation(ShowOnlyWhen(face_standing, NakedHeadBump));
            }

            {
                var helm_standing = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_armor1, thing.GetArmorColor, Face_z, feet_y);
                var helm_crouching = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_armor1, thing.GetArmorColor, Face_z, crouch_y);

                var normalHelm = CreateCrouchAnimator(
                thing
                , helm_standing
                , helm_crouching);

                thing.AddAnimation(
                    ShowOnlyWhen(normalHelm, ArmoredHead)
                );
            }

            {
                var slamedHelm = CreateFlippableAnimation(thing, GeneratedContent.Create_knight_head_armor_bang1, thing.GetArmorColor, Face_z, feet_y);

                thing.AddAnimation(
                    ShowOnlyWhen(slamedHelm, ArmoredHeadBump)
                );
            }
        }

        private static Func<bool> CreateNakedHeadCondition(Humanoid thing)
        {
            return () => !thing.IsUsingHelmet()
                                 && thing.HeadState != HeadState.Bump;
        }

        private IHandleAnimation bodyAnimationHelper(
            Humanoid thing,
            int y,
            Func<int, int, int?, int?, bool, Animation> animation,
            Func<Color> GetColor,
            bool autorewind = false)
        {
            var stand_left = animation(
                x
                , y
                , null
                , null
                , false);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;
            stand_left.RenderingLayer = Torso_z;
            stand_left.FrameDuration = 2;
            stand_left.ColorGetter = GetColor;

            var stand_right = animation(
                flippedx
                , y
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;
            stand_right.RenderingLayer = Torso_z;
            stand_right.FrameDuration = 2;
            stand_right.ColorGetter = GetColor;

            return new Animator(
                new AnimationTransitionOnCondition(autorewind ? (IHandleAnimation)stand_right.AsAutoRewindable() : stand_right, () => thing.FacingRight == true)
                , new AnimationTransitionOnCondition(autorewind ? (IHandleAnimation)stand_left.AsAutoRewindable() : stand_left, () => thing.FacingRight == false)
            );
        }

        private void TorsoAnimator(Humanoid thing)
        {
            var stand = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_stand, thing.GetEyeColor, true);
            var jump = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_jump, thing.GetEyeColor, false);
            var headbump = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_headbump, thing.GetEyeColor, false);
            var fall = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_fall, thing.GetEyeColor, false);
            var walk = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_walking, thing.GetEyeColor);
            var crouch = bodyAnimationHelper(thing, crouch_y, GeneratedContent.Create_knight_torso_crouch, thing.GetEyeColor, true);
            var edgecrouch = bodyAnimationHelper(thing, crouch_y, GeneratedContent.Create_knight_torso_edgecrouch, thing.GetEyeColor, true);
            var edgecrouchback = bodyAnimationHelper(thing, crouch_y, GeneratedContent.Create_knight_torso_edgecrouchback, thing.GetEyeColor, true);
            var sweetdreams = bodyAnimationHelper(thing, crouch_y, GeneratedContent.Create_knight_torso_sweetdreams, thing.GetEyeColor, true);
            var edgeStand = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_edgestand, thing.GetEyeColor, true);
            var edgeStandBack = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_edgestandback, thing.GetEyeColor, true);
            var wallslide = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_wallslide, thing.GetEyeColor, true);

            var stand_armor = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_stand_armor, thing.GetArmorColor, true);
            var jump_armor = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_jump_armor, thing.GetArmorColor, false);
            var headbump_armor = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_headbump_armor, thing.GetArmorColor, false);
            var fall_armor = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_fall_armor, thing.GetArmorColor, false);
            var walk_armor = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_walking_armor, thing.GetArmorColor);
            var crouch_armor = bodyAnimationHelper(thing, crouch_y, GeneratedContent.Create_knight_torso_crouch_armor, thing.GetArmorColor, true);
            var edgecrouch_armor = bodyAnimationHelper(thing, crouch_y, GeneratedContent.Create_knight_torso_edgecrouch_armor, thing.GetArmorColor, true);
            var edgecrouchback_armor = bodyAnimationHelper(thing, crouch_y, GeneratedContent.Create_knight_torso_edgecrouchback_armor, thing.GetArmorColor, true);
            var sweetdreams_armor = bodyAnimationHelper(thing, crouch_y, GeneratedContent.Create_knight_torso_sweetdreams_armor, thing.GetArmorColor, true);
            var edgeStand_armor = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_edgestand_armor, thing.GetArmorColor, true);
            var edgeStandBack_armor = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_edgestandback_armor, thing.GetArmorColor, true);
            var wallslide_armor = bodyAnimationHelper(thing, feet_y, GeneratedContent.Create_knight_torso_wallslide_armor, thing.GetArmorColor, true);

            Animator whipAnimator = CreateWeaponAnimator(
                thing
                , GeneratedContent.Create_knight_whip_idle
                , GeneratedContent.Create_knight_whip_attack);

            Animator swordAnimator = CreateWeaponAnimator(
                thing
                , GeneratedContent.Create_knight_sword_idle
                , GeneratedContent.Create_knight_sword_attack);

            Animator WandAnimator = CreateWeaponAnimator(
                thing
                , GeneratedContent.Create_knight_wand_idle
                , GeneratedContent.Create_knight_wand_attack);

            thing.AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(whipAnimator, () => thing.weaponType == WeaponType.Whip)
                    , new AnimationTransitionOnCondition(swordAnimator, () => thing.weaponType == WeaponType.Sword)
                    , new AnimationTransitionOnCondition(WandAnimator, () => thing.weaponType == WeaponType.Wand)
                )
            );


            var naked_torso = new Animator(
                    new AnimationTransitionOnCondition(stand, thing.IsIdle)
                    , new AnimationTransitionOnCondition(edgeStand, thing.IsIdleOnTheEdge)
                    , new AnimationTransitionOnCondition(edgeStandBack, thing.IsIdleOnTheEdgeFacingBack)
                    , new AnimationTransitionOnCondition(edgecrouchback, thing.IsCrouchingOnTheEdgeFacingBack)
                    , new AnimationTransitionOnCondition(wallslide, () => thing.LegState == LegState.SlidingWall)
                    , new AnimationTransitionOnCondition(sweetdreams, () => thing.LegState == LegState.SweetDreams)
                    , new AnimationTransitionOnCondition(walk, () => thing.LegState == LegState.Walking)
                    , new AnimationTransitionOnCondition(jump, () => thing.LegState == LegState.Falling && thing.VerticalSpeed <= 0)
                    , new AnimationTransitionOnCondition(fall, () => thing.LegState == LegState.Falling && thing.VerticalSpeed > 0)
                    , new AnimationTransitionOnCondition(headbump, () => thing.LegState == LegState.HeadBump)
                    , new AnimationTransitionOnCondition(crouch, thing.IsCrouching)
                    , new AnimationTransitionOnCondition(edgecrouch, thing.IsCrouchingOnTheEdge));
            var armored_torso = new Animator(
                    new AnimationTransitionOnCondition(stand_armor, thing.IsIdle)
                    , new AnimationTransitionOnCondition(edgeStand_armor, thing.IsIdleOnTheEdge)
                    , new AnimationTransitionOnCondition(edgeStandBack_armor, thing.IsIdleOnTheEdgeFacingBack)
                    , new AnimationTransitionOnCondition(edgecrouchback_armor, thing.IsCrouchingOnTheEdgeFacingBack)
                    , new AnimationTransitionOnCondition(wallslide_armor, () => thing.LegState == LegState.SlidingWall)
                    , new AnimationTransitionOnCondition(sweetdreams_armor, () => thing.LegState == LegState.SweetDreams)
                    , new AnimationTransitionOnCondition(walk_armor, () => thing.LegState == LegState.Walking)
                    , new AnimationTransitionOnCondition(jump_armor, () => thing.LegState == LegState.Falling && thing.VerticalSpeed <= 0)
                    , new AnimationTransitionOnCondition(fall_armor, () => thing.LegState == LegState.Falling && thing.VerticalSpeed > 0)
                    , new AnimationTransitionOnCondition(headbump_armor, () => thing.LegState == LegState.HeadBump)
                    , new AnimationTransitionOnCondition(crouch_armor, thing.IsCrouching)
                    , new AnimationTransitionOnCondition(edgecrouch_armor, thing.IsCrouchingOnTheEdge));


            thing.AddUpdate(() =>
            {
                if (Game1.MusicController.AboutToPlayBumbo())
                {
                    stand.Restart();
                    stand_armor.Restart();
                    crouch.Restart();
                    sweetdreams.Restart();
                    sweetdreams_armor.Restart();
                }
            });

            thing.AddAnimation(
                new Animator(
                new AnimationTransitionOnCondition(armored_torso, () => thing.HitPoints > 1)
                , new AnimationTransitionOnCondition(naked_torso, () => thing.HitPoints == 1 && (thing.DamageDuration == TakesDamage.DAMAGE_DURATION / 2 || thing.DamageDuration == 0))
                )
            );

            //thing.AddAnimation(
            //    armored_torso
            //);

            //thing.AddAnimation(
            //    naked_torso
            //);
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
            var left_x = -1450;
            var right_x = -1450;

            var whip_left = WeaponAttackAnimation(left_x, feet_y, null, null, false);
            whip_left.ScaleX = scale;
            whip_left.ScaleY = scale;
            whip_left.LoopDisabled = true;
            whip_left.RenderingLayer = Weapon_z;
            var whip_left_crouch = WeaponAttackAnimation(left_x, crouch_y, null, null, false);
            whip_left_crouch.ScaleX = scale;
            whip_left_crouch.ScaleY = scale;
            whip_left_crouch.LoopDisabled = true;
            whip_left_crouch.RenderingLayer = Weapon_z;
            var whip_right = WeaponAttackAnimation(right_x, feet_y, null, null, true);
            whip_right.ScaleX = scale;
            whip_right.ScaleY = scale;
            whip_right.LoopDisabled = true;
            whip_right.RenderingLayer = Weapon_z;
            var whip_right_crouch = WeaponAttackAnimation(right_x, crouch_y, null, null, true);
            whip_right_crouch.ScaleX = scale;
            whip_right_crouch.ScaleY = scale;
            whip_right_crouch.LoopDisabled = true;
            whip_right_crouch.RenderingLayer = Weapon_z;

            var whipi_left = WeaponIdleAnimation(left_x, feet_y, null, null, false);
            whipi_left.ScaleX = scale;
            whipi_left.ScaleY = scale;
            whipi_left.FrameDuration = 2;
            whipi_left.RenderingLayer = Weapon_z;
            var whipi_left_crouch = WeaponIdleAnimation(left_x, crouch_y, null, null, false);
            whipi_left_crouch.ScaleX = scale;
            whipi_left_crouch.ScaleY = scale;
            //whipi_left_crouch.FrameDuration = 2;
            whipi_left_crouch.RenderingLayer = Weapon_z;
            var whipi_right = WeaponIdleAnimation(right_x, feet_y, null, null, true);
            whipi_right.ScaleX = scale;
            whipi_right.ScaleY = scale;
            whipi_right.FrameDuration = 2;
            whipi_right.RenderingLayer = Weapon_z;
            var whipi_right_crouch = WeaponIdleAnimation(right_x, crouch_y, null, null, true);
            whipi_right_crouch.ScaleX = scale;
            whipi_right_crouch.ScaleY = scale;
            //whipi_right_crouch.FrameDuration = 2;
            whipi_right_crouch.RenderingLayer = Weapon_z;
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
