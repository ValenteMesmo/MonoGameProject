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
                || Player.LegState == LegState.HeadBump
                || Player.LegState == LegState.TakingDamage)
                return;

            if (Player.Inputs.Left && !Player.Inputs.Right)
                Player.FacingRight = false;
            else if (!Player.Inputs.Left && Player.Inputs.Right)
                Player.FacingRight = true;
        }
    }

    public class SolidCollider : Collider, BlockHorizontalMovement
    {

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
        public Color ArmorColor { get; internal set; }

        public Humanoid(GameInputs Inputs, Camera2d Camera)
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
            AddUpdate(new ChangeToHeadBumpState(this, Camera));
            AddUpdate(new ChangeToCrouchState(this));
            AddUpdate(new ChangeToAttackState(this));

            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new PreventPlayerFromAccicentlyFalling(this));
            AddUpdate(new ResetSizeAndOffsetY(this));
            AddUpdate(new ReduceSizeWhenHeadBumping(this));
            AddUpdate(new ReduceSizeWhenCrouching(this));
            AddUpdate(new HorizontalFriction(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(new MoveLeftOrRight(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new Jump(this));
            AddUpdate(new ForceOriginalHeightAndOffsetWhenCrouchJumping(this));

            AddUpdate(new WallJump(this));

            AddUpdate(new ReduceSpeedWhileSlidingWall(this));
#if DEBUG
            AddUpdate(() =>
                Game.LOG +=
                $@"{GetType().Name} {LegState.ToString()} {FacingRight} {Environment.NewLine}");
#endif
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
                Width = width / 3,
                Height = height / 4,
                OffsetX = width / 3,
                OffsetY = height + 1
            };
            AddCollider(groundChecker);

            RightGroundAcidentChecker = new CollisionChecker()
            {
                Width = width / 3,
                Height = height / 4,
                OffsetX = width / 3 + width / 3 + 1,
                OffsetY = height + 1
            };
            AddCollider(RightGroundAcidentChecker);

            LeftGroundAcidentChecker = new CollisionChecker()
            {
                Width = width / 3,
                Height = height / 4,
                OffsetX = width / 3 - width / 3 - 1,
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

            var whipx = 800;
            AttackRightCollider = new AttackCollider
            {
                Width = width / 2,
                Height = height / 3,
                OffsetX = width + whipx,
                OffsetY = 0,
                Disabled = true
            };
            AddCollider(AttackRightCollider);

            AttackLeftCollider = new AttackCollider
            {
                Width = width / 2,
                Height = height / 3,
                OffsetX = -width / 2 - whipx,
                OffsetY = 0,
                Disabled = true
            };
            AddCollider(AttackLeftCollider);
        }
    }
}
