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

            Humanoid.AttackLeftCollider.Disabled = true;
            Humanoid.AttackRightCollider.Disabled = true;

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
            if (Humanoid.TorsoState == TorsoState.AttackLeft)
            {
                Humanoid.TorsoState = TorsoState.StandingLeft;
                return;
            }

            if (Humanoid.TorsoState == TorsoState.AttackRight)
            {
                Humanoid.TorsoState = TorsoState.StandingRight;
                return;
            }

            if (Humanoid.TorsoState == TorsoState.AttackCrouchingLeft)
            {
                Humanoid.TorsoState = TorsoState.CrouchLeft;
                return;
            }

            if (Humanoid.TorsoState == TorsoState.AttackCrouchingRight)
            {                
                Humanoid.TorsoState = TorsoState.CrouchRight;
                return;
            }
        }

        private void ChangeToAttackMode()
        {
            var enableDuration = 15;

            if (Humanoid.LegState == LegState.FallingLeft
                || Humanoid.LegState == LegState.HeadBumpLeft
                || Humanoid.LegState == LegState.SlidingWallRight
                || Humanoid.LegState == LegState.StandingLeft
                || Humanoid.LegState == LegState.WalkingLeft
                || Humanoid.LegState == LegState.WallJumpingToTheLeft
                )
            {
                if (AttackDuration < enableDuration)
                    Humanoid.AttackLeftCollider.Disabled = false;

                Humanoid.TorsoState = TorsoState.AttackLeft;
                return;
            }

            if (Humanoid.LegState == LegState.FallingRight
               || Humanoid.LegState == LegState.HeadBumpRight
               || Humanoid.LegState == LegState.SlidingWallLeft
               || Humanoid.LegState == LegState.StandingRight
               || Humanoid.LegState == LegState.WalkingRight
               || Humanoid.LegState == LegState.WallJumpingToTheRight
               )
            {
                if (AttackDuration < enableDuration)
                    Humanoid.AttackRightCollider.Disabled = false;

                Humanoid.TorsoState = TorsoState.AttackRight;
                return;
            }

            if (Humanoid.LegState == LegState.CrouchingRight
            )
            {
                if (AttackDuration < enableDuration)
                    Humanoid.AttackRightCollider.Disabled = false;

                Humanoid.TorsoState = TorsoState.AttackCrouchingRight;
                return;
            }

            if (Humanoid.LegState == LegState.CrouchingLeft)
            {
                if (AttackDuration < enableDuration)
                    Humanoid.AttackLeftCollider.Disabled = false;

                Humanoid.TorsoState = TorsoState.AttackCrouchingLeft;
                return;
            }
        }
    }

    public class Humanoid : Thing
    {
        public HeadState HeadState { get; set; }
        public TorsoState TorsoState { get; set; }
        public LegState LegState { get; set; }

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
            AddUpdate(new ForceOriginalHeightAndOffsetWhenCrouchJumping(this));

            AddUpdate(new WallJump(this));

            AddUpdate(new ReduceSpeedWhileSlidingWall(this));
#if DEBUG
            AddUpdate(() =>
                Game.LOG +=
                GetType().Name
                + " "
                + LegState.ToString()
                + Environment.NewLine);
#endif
        }
    }
}
