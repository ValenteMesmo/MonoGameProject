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

    public class SolidCollider : Collider, BlockHorizontalMovement, BlockVerticalMovement
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

    public class GroundCollider : Collider, SomeKindOfGround, BlockVerticalMovement, BlockHorizontalMovement
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

    public class AttackCollider : Collider
    {

    }

    public class Humanoid : Thing
    {
        public HeadState HeadState { get; set; }
        public TorsoState TorsoState { get; set; }
        public LegState LegState { get; set; }
        public bool FacingRight { get; set; }
        public int PlayerIndex { get; set; }

        private const int width = 1000;
        private const int height = 900;

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
            , Camera2d Camera
            , VibrationCenter VibrationCenter
            , Action<Thing> AddToWorld)
        {
            this.Inputs = Inputs;

            CreateColliders();

            AddUpdate(this.Inputs);
            AddUpdate(new ChangeDirectionOnInput(this));

            AddUpdate(new ChangeToStandingState(this));
            AddUpdate(new ChangeToWalkingState(this));
            AddUpdate(new ChangeToFallingState(this));
            AddUpdate(new ChangeToSlidingState(this));
            AddUpdate(new ChangeToWallJumping(this));
            AddUpdate(new ChangeToHeadBumpState(this, Camera, VibrationCenter));
            AddUpdate(new ChangeToCrouchState(this, Camera, VibrationCenter));
            AddUpdate(new ChangeToAttackState(this));

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
                if (DamageDuration == 100)
                    NewMethod(
                        HumanoidAnimatorFactory.HEAD_Z - 0.001f,
                        HumanoidAnimatorFactory.feet_y * 2,
                        AddToWorld);
                else if (DamageDuration == 51)
                    NewMethod(
                        HumanoidAnimatorFactory.HEAD_Z - 0.001f,
                        HumanoidAnimatorFactory.feet_y,
                        AddToWorld);
                else if (DamageDuration == 2)
                    NewMethod(
                        HumanoidAnimatorFactory.HEAD_Z - 0.001f,
                        0,
                        AddToWorld);

            }
        });
        }

        private void NewMethod(float z, int bonus, Action<Thing> AddToWorld)
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

            var whipWidth = (int)(width * 1.5f);
            AttackRightCollider = new AttackCollider
            {
                Width = whipWidth,
                Height = height / 3,
                OffsetX = MainCollider.OffsetX + MainCollider.Width + 1,
                OffsetY = 0,
                Disabled = true
            };
            AttackRightCollider.AddHandler(DestroyFireball);
            AddCollider(AttackRightCollider);

            AttackLeftCollider = new AttackCollider
            {
                Width = whipWidth,
                Height = height / 3,
                OffsetX = MainCollider.OffsetX - whipWidth - 1,
                OffsetY = 0,
                Disabled = true
            };
            AttackLeftCollider.AddHandler(DestroyFireball);
            AddCollider(AttackLeftCollider);
        }

        private void DestroyFireball(Collider arg1, Collider arg2)
        {
            if (arg2.Parent is FireBall)
                arg2.Parent.Destroy();
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
                      && !LeftGroundAcidentChecker.Colliding<GroundCollider>()
                  )
                  ||
                  (
                      !FacingRight
                      && !RightGroundAcidentChecker.Colliding<GroundCollider>()
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
                  && RightGroundAcidentChecker.Colliding<GroundCollider>()
                  && LeftGroundAcidentChecker.Colliding<GroundCollider>();
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
                  && RightGroundAcidentChecker.Colliding<GroundCollider>()
                  && LeftGroundAcidentChecker.Colliding<GroundCollider>();
        }

        private bool IsOnTheEdge()
        {
            return
                   (
                       !FacingRight
                       && !LeftGroundAcidentChecker.Colliding<GroundCollider>()
                   )
                   ||
                   (
                       FacingRight
                       && !RightGroundAcidentChecker.Colliding<GroundCollider>()
                   );
        }


        private bool ArmorPartIsDestroyed(int indexToDestroy)
        {
            return HitPoints <= 1
                && DamageDuration <= TakesDamage.DAMAGE_DURATION - indexToDestroy;
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

        public bool IsNotUsingHelmet()
        {
            return ArmorPartIsDestroyed(5);
        }

        public bool IsNotUsingBreastPlate()
        {
            return ArmorPartIsDestroyed(TakesDamage.DAMAGE_DURATION / 2);
        }

        public bool IsNotUsingPlateShoe()
        {
            return ArmorPartIsDestroyed(TakesDamage.DAMAGE_DURATION);
        }

    }
}
