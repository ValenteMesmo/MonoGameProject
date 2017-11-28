using GameCore;
using MonoGameProject.Things;
using MonoGameProject.Updates.PlayerStates;
using System;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class ChangeDirectionOnInput : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeDirectionOnInput(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.TorsoState == TorsoState.Attack
                || Player.TorsoState == TorsoState.AttackCrouching
                //|| Player.LegState == LegState.Falling
                || Player.LegState == LegState.SlidingWall
                || Player.LegState == LegState.WallJumping
                || Player.LegState == LegState.HeadBump)
                return;

            if (Player.Inputs.Left && !Player.Inputs.Right)
                Player.FacingRight = false;
            else if (!Player.Inputs.Left && Player.Inputs.Right)
                Player.FacingRight = true;
        }
    }

    public class SolidCollider : Collider, BlockHorizontalMovement, BlockVerticalMovement, SlidableWall
    {
        public SolidCollider()
        {

        }

        public SolidCollider(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public class GroundCollider : Collider, SomeKindOfGround, BlockVerticalMovement, BlockHorizontalMovement, SlidableWall
    {
        public GroundCollider()
        {

        }

        public GroundCollider(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public class GroundFromLeftToRightCollider : Collider, SomeKindOfGround
    {
    }

    public class AttackCollider : Collider
    {

    }

    public class Humanoid : Thing
    {
        public HeadState HeadState { get; set; }
        public TorsoState TorsoState { get; set; }
        public LegState LegState { get; set; }
        public bool FacingRight { get; set; }
        public int PlayerIndex { get; }

        private const int width = 1000;
        public const int height = 900;

        public AttackCollider AttackRightCollider { get; private set; }
        public AttackCollider AttackLeftCollider { get; private set; }

        public CollisionChecker groundChecker { get; private set; }
        public CollisionChecker leftWallChecker { get; private set; }
        public CollisionChecker rightWallChecker { get; private set; }
        public CollisionChecker roofChecker { get; private set; }
        public CollisionChecker RightGroundAcidentChecker { get; private set; }
        public CollisionChecker LeftGroundAcidentChecker { get; private set; }

        public Collider MainCollider { get; private set; }
        public GameInputs Inputs { get; private set; }

        public int HitPoints { get; set; }
        public int DamageDuration { get; set; }

        private Color ArmorColor;
        private Color SkinColor = new Color(223, 168, 137);
        private Color HairColor = new Color(186, 120, 168);
        private Color EyeColor = new Color(74, 156, 74);
        private int whipWidth;
        private int swordWidth;
        private int wandWidth;

        public Color GetSkinColor()
        {
            return SkinColor;
        }
        public Color GetEyeColor()
        {
            return EyeColor;
        }
        public Color GetHairColor()
        {
            return HairColor;
        }
        public Color GetArmorColor()
        {
            return ArmorColor;
        }
        public void SetArmorColor(Color Value)
        {
            ArmorColor = Value;
        }

        public Humanoid(
            GameInputs Inputs
            , Game1 Game1
            , int PlayerIndex = 0)
        {
            this.Inputs = Inputs;
            this.PlayerIndex = PlayerIndex;

            if (PlayerIndex == 1)
            {
                SkinColor = new Color(168, 137, 120);
                HairColor = new Color(120, 186, 168);
                EyeColor = new Color(180, 180, 74);
            }
            if (PlayerIndex == 2)
            {
                SkinColor = new Color(240, 210, 190);
                HairColor = new Color(240, 240, 168);
                EyeColor = new Color(180, 120, 120);
            }
            if (PlayerIndex == 3)
            {
                SkinColor = new Color(168, 223, 137);
                HairColor = new Color(180, 160, 228);
                EyeColor = new Color(228, 180, 228);
            }

            CreateColliders();

            AddUpdate(new ChangeDirectionOnInput(this));

            AddUpdate(new ChangeToStandingState(this));
            AddUpdate(new ChangeToWalkingState(this));
            AddUpdate(new ChangeToFallingState(this));
            AddUpdate(new ChangeToSlidingState(this));
            AddUpdate(new ChangeToWallJumping(this));
            AddUpdate(new ChangeToHeadBumpState(this, Game1.Camera, Game1.VibrationCenter));
            AddUpdate(new ChangeToCrouchState(this, Game1.Camera, Game1.VibrationCenter));
            AddUpdate(new ChangeToAttackState(this, Game1));

            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new PreventPlayerFromAccicentlyFalling(this));
            AddUpdate(new ResetSizeAndOffsetY(this));
            AddUpdate(new ReduceSizeWhenHeadBumping(this));
            AddUpdate(new ReduceSizeWhenCrouching(this));
            AddUpdate(new HorizontalFriction(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(new MoveLeftOrRight(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new Jump(this));
            AddUpdate(new ForceOriginalHeightAndOffsetWhenCrouchJumping(this));

            AddUpdate(new WallJump(this));

            AddUpdate(new ReduceSpeedWhileSlidingWall(this));
#if DEBUG
            AddUpdate(() =>
                Game.LOG +=
                $@"{GetType().Name} {LegState.ToString()} {FacingRight} {Environment.NewLine}");
#endif

            AddUpdate(() =>
        {
            if (HitPoints == 1)
            {
                if (DamageDuration == GetDurationInstantByPercentage(HELMET_PERCENTAGE))
                    CreateBreakEffect(
                        HumanoidAnimatorFactory.FACE_Z - PlayerIndex / 100f,
                        HumanoidAnimatorFactory.feet_y * 2,
                         Game1.AddToWorld);
                else if (DamageDuration == GetDurationInstantByPercentage(BREAST_PERCENTAGE))
                    CreateBreakEffect(
                        HumanoidAnimatorFactory.FACE_Z - PlayerIndex / 100f,
                        HumanoidAnimatorFactory.feet_y,
                         Game1.AddToWorld);
                else if (DamageDuration == GetDurationInstantByPercentage(SHOE_PERCENTAGE))
                    CreateBreakEffect(
                        HumanoidAnimatorFactory.FACE_Z - PlayerIndex / 100f,
                        0,
                         Game1.AddToWorld);
            }
        });
        }

        public WeaponType weaponType = WeaponType.Whip;
        public void ChangeToWhip()
        {
            AttackLeftCollider.Width = whipWidth;
            AttackRightCollider.Width = whipWidth;
            AttackLeftCollider.OffsetX = MainCollider.OffsetX - AttackLeftCollider.Width - 1;
            weaponType = WeaponType.Whip;
        }

        public void ChangeToSword()
        {
            AttackLeftCollider.Width = swordWidth;
            AttackRightCollider.Width = swordWidth;
            AttackLeftCollider.OffsetX = MainCollider.OffsetX - AttackLeftCollider.Width - 1;
            weaponType = WeaponType.Sword;
        }

        public void ChangeToWand()
        {
            AttackLeftCollider.Width = wandWidth;
            AttackRightCollider.Width = wandWidth;
            AttackLeftCollider.OffsetX = MainCollider.OffsetX - AttackLeftCollider.Width - 1;
            weaponType = WeaponType.Wand;
        }

        private void CreateBreakEffect(float z, int bonus, Action<Thing> AddToWorld)
        {
            var hitEffect = new ArmorBreaking(this, bonus);
            AddToWorld(hitEffect);
        }

        private void CreateColliders()
        {
            MainCollider = new Collider()
            {
                OffsetX = width / 3,
                Width = width / 3,
                Height = height - 10
            };
            AddCollider(MainCollider);

            groundChecker = new CollisionChecker()
            {
                Width = MainCollider.Width,
                Height = height / 4,
                OffsetX = MainCollider.OffsetX,
                OffsetY = height + 1
            };
            AddCollider(groundChecker);

            RightGroundAcidentChecker = new CollisionChecker()
            {
                Width = width / 4,
                Height = height / 4,
                OffsetX = (width / 3 + width / 3 + 1) + 100,
                OffsetY = height + 1
            };
            AddCollider(RightGroundAcidentChecker);

            LeftGroundAcidentChecker = new CollisionChecker()
            {
                Width = width / 4,
                Height = height / 4,
                OffsetX = ((width / 4) / 3 - 1) - 100,
                OffsetY = height + 1
            };
            AddCollider(LeftGroundAcidentChecker);

            leftWallChecker = new CollisionChecker()
            {
                Width = width / 10,
                Height = height / 3,
                OffsetX = width / 3 - width / 6,
                OffsetY = height / 2
            };
            AddCollider(leftWallChecker);

            rightWallChecker = new CollisionChecker()
            {
                Width = width / 10,
                Height = height / 3,
                OffsetX = width - width / 4,
                OffsetY = height / 2
            };
            AddCollider(rightWallChecker);

            roofChecker = new CollisionChecker()
            {
                Width = width / 3,
                Height = height / 10,
                OffsetX = width / 3,
                OffsetY = -height / 10 - 1
            };
            AddCollider(roofChecker);

            whipWidth = (int)(width * 2.0f);
            swordWidth = (int)(width * 1.0f);
            wandWidth = (int)(width * 0.5f);
            AttackRightCollider = new AttackCollider
            {
                Width = whipWidth,
                Height = height / 3,
                OffsetX = MainCollider.OffsetX + MainCollider.Width + 1,
                OffsetY = 0,
                Disabled = true
            };
            AddCollider(AttackRightCollider);

            AttackLeftCollider = new AttackCollider
            {
                Width = whipWidth,
                Height = height / 3,
                OffsetX = MainCollider.OffsetX - whipWidth - 1,
                OffsetY = 0,
                Disabled = true
            };
            AddCollider(AttackLeftCollider);
        }

        //Helpers------------------------------------------

        public bool IsAttacking()
        {
            return TorsoState == TorsoState.Attack
                || TorsoState == TorsoState.AttackCrouching;
        }

        public bool IsCrouchingOrSweetDreaming()
        {
            return LegState == LegState.Crouching
                || LegState == LegState.SweetDreams;
        }

        public bool IsCrouchingOnTheEdgeFacingBack()
        {
            return LegState == LegState.Crouching
                && IsOnTheEdgeFacingBack();
        }

        public bool IsIdleOnTheEdgeFacingBack()
        {
            return LegState == LegState.Standing
                && IsOnTheEdgeFacingBack();
        }

        private bool IsOnTheEdgeFacingBack()
        {
            return
                  (
                      FacingRight
                      && !LeftGroundAcidentChecker.Colliding<SlidableWall>()
                      && RightGroundAcidentChecker.Colliding<SlidableWall>()
                  )
                  ||
                  (
                      !FacingRight
                      && !RightGroundAcidentChecker.Colliding<SlidableWall>()
                      && LeftGroundAcidentChecker.Colliding<SlidableWall>()
                  );
        }

        public bool IsCrouchingOnTheEdge()
        {
            return
                  LegState == LegState.Crouching
                  && IsOnTheEdge();
        }

        public bool IsCrouching()
        {
            return
                  LegState == LegState.Crouching
                  &&
                  (
                    (
                        RightGroundAcidentChecker.Colliding<SlidableWall>()
                        && LeftGroundAcidentChecker.Colliding<SlidableWall>()
                    )
                    ||
                    (
                        !RightGroundAcidentChecker.Colliding<SlidableWall>()
                        && !LeftGroundAcidentChecker.Colliding<SlidableWall>()
                    )
                  );
        }

        public bool IsIdleOnTheEdge()
        {
            return
                  LegState == LegState.Standing
                  && IsOnTheEdge();
        }

        public bool IsIdle()
        {
            return
                  LegState == LegState.Standing
                  &&
                  (
                      (
                          RightGroundAcidentChecker.Colliding<SlidableWall>()
                          && LeftGroundAcidentChecker.Colliding<SlidableWall>()
                      )
                      ||
                      (
                          !RightGroundAcidentChecker.Colliding<SlidableWall>()
                          && !LeftGroundAcidentChecker.Colliding<SlidableWall>()
                      )
                  );
        }

        private bool IsOnTheEdge()
        {
            return
                   (
                       !FacingRight
                       && !LeftGroundAcidentChecker.Colliding<SlidableWall>()
                       && RightGroundAcidentChecker.Colliding<SlidableWall>()
                   )
                   ||
                   (
                       FacingRight
                       && !RightGroundAcidentChecker.Colliding<SlidableWall>()
                       && LeftGroundAcidentChecker.Colliding<SlidableWall>()
                   );
        }

        private bool ArmorPartIsDestroyed(float percentageOfTime)
        {
            var durationInstantThatBreaks = GetDurationInstantByPercentage(percentageOfTime);

            return HitPoints <= 1
                && DamageDuration <= durationInstantThatBreaks;
        }

        private int GetDurationInstantByPercentage(float percentage)
        {
            return (int)((TakesDamage.DAMAGE_DURATION * percentage));
        }

        public bool IsUsingHelmet()
        {
            return !IsNotUsingHelmet();
        }

        public bool IsUsingBreastPlate()
        {
            return !IsNotUsingBreastPlate();
        }

        public bool IsUsingPlateShoe()
        {
            return !IsNotUsingPlateShoe();
        }

        private const float HELMET_PERCENTAGE = 0.90f;
        private const float BREAST_PERCENTAGE = 0.60f;
        private const float SHOE_PERCENTAGE = 0.30f;

        public bool IsNotUsingHelmet()
        {
            return ArmorPartIsDestroyed(HELMET_PERCENTAGE);
        }

        public bool IsNotUsingBreastPlate()
        {
            return ArmorPartIsDestroyed(BREAST_PERCENTAGE);
        }

        public bool IsNotUsingPlateShoe()
        {
            return ArmorPartIsDestroyed(SHOE_PERCENTAGE);
        }

    }
}
