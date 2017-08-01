using GameCore;
using MonoGameProject.Things;
using MonoGameProject.Updates.PlayerStates;
using System;

namespace MonoGameProject
{
    public class SolidCollider : Collider, BlockHorizontalMovement
    {

    }

    public class GroundCollider : Collider, SomeKindOfGround, BlockVerticalMovement, BlockHorizontalMovement
    {

    }

    public class AttackCollider : Collider
    {

    }

    public class ChangeToAttackState : UpdateHandler
    {
        private readonly Humanoid Humanoid;
        private int AttackDuration = 0;

        public ChangeToAttackState(Humanoid Humanoid)
        {
            this.Humanoid = Humanoid;
        }

        public void Update()
        {
            if (Humanoid.Inputs.ClickedAction1
                && AttackDuration <= 0)
            {
                AttackDuration = 20;
            }

            if (AttackDuration > 0)
            {
                ChangeToAttackMode();
                AttackDuration--;
                if (AttackDuration <= 0)
                {
                    ChangeToNotAttackMode();
                }
            }
        }

        private void ChangeToNotAttackMode()
        {
            if(Humanoid.State== PlayerState.AttackLeft)
                Humanoid.State = PlayerState.StandingLeft;
            else if (Humanoid.State == PlayerState.AttackRight)
                Humanoid.State = PlayerState.StandingRight;
        }

        private void ChangeToAttackMode()
        {
            if(Humanoid.State == PlayerState.CrouchingLeft
                || Humanoid.State == PlayerState.FallingLeft
                || Humanoid.State == PlayerState.HeadBumpLeft
                || Humanoid.State == PlayerState.SlidingWallRight
                || Humanoid.State == PlayerState.StandingLeft
                || Humanoid.State == PlayerState.WalkingLeft
                || Humanoid.State == PlayerState.WallJumpingToTheLeft
                )
            Humanoid.State = PlayerState.AttackLeft;
            else if (Humanoid.State == PlayerState.CrouchingRight
                || Humanoid.State == PlayerState.FallingRight
                || Humanoid.State == PlayerState.HeadBumpRight
                || Humanoid.State == PlayerState.SlidingWallLeft
                || Humanoid.State == PlayerState.StandingRight
                || Humanoid.State == PlayerState.WalkingRight
                || Humanoid.State == PlayerState.WallJumpingToTheRight
                )
                Humanoid.State = PlayerState.AttackRight;
        }
    }

    public class Humanoid : Thing
    {
        public PlayerState State { get; set; }

        private const int width = 1000;
        private const int height = 900;

        public readonly AttackCollider AttackRightCollider;
        public readonly AttackCollider AttackLeftCollider;

        public readonly CollisionChecker groundChecker;
        public readonly CollisionChecker leftWallChecker;
        public readonly CollisionChecker rightWallChecker;
        public readonly CollisionChecker roofChecker;
        public readonly CollisionChecker RightGroundAcidentChecker;
        public readonly CollisionChecker LeftGroundAcidentChecker;

        public readonly Collider MainCollider;
        public readonly GameInputs Inputs;

        public Humanoid(GameInputs Inputs, Game1 WorldMover)
        {
            this.Inputs = Inputs;

            AddUpdate(Inputs);

            MainCollider = new SolidCollider()
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
                OffsetY = height / 3
            };
            AddCollider(leftWallChecker);

            rightWallChecker = new CollisionChecker()
            {
                Width = width / 10,
                Height = height / 3,
                OffsetX = width - width / 4,
                OffsetY = height / 3
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



            AttackRightCollider = new AttackCollider
            {
                Width = width / 2,
                Height = height / 3,
                OffsetX = width,
                OffsetY = 0,
                Disabled = true
            };
            AddCollider(AttackRightCollider);

            AttackLeftCollider = new AttackCollider
            {
                Width = width / 2,
                Height = height / 3,
                OffsetX = -width / 2,
                OffsetY = 0,
                Disabled = true
            };
            AddCollider(AttackLeftCollider);


            AddUpdate(new ChangeToStandingState(this));
            AddUpdate(new ChangeToWalkingState(this));
            AddUpdate(new ChangeToFallingState(this));
            AddUpdate(new ChangeToSlidingState(this));
            AddUpdate(new ChangeToWallJumping(this));
            AddUpdate(new ChangeToHeadBumpState(this, WorldMover.Camera));
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
            AddUpdate(new Jump(this, Inputs, groundChecker));

            AddUpdate(new WallJump(this));

            AddUpdate(new ReduceSpeedWhileSlidingWall(this));
#if DEBUG
            AddUpdate(() =>
                Game.LOG +=
                GetType().Name
                + " "
                + State.ToString()
                + Environment.NewLine);
#endif
        }
    }
}
