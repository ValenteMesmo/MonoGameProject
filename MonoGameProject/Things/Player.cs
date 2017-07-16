using GameCore;
using MonoGameProject.Things;
using MonoGameProject.Updates.PlayerStates;
using System;

namespace MonoGameProject
{
    public class Player : Thing
    {
        //abaixar
        //spawn de zumbis

        //vilarejo em chamas... pessoas sendo atacaDas?
        //arvore seca, cheia de criaturas voadoras que parecem passaros... faz barulho perto, que elas voam
        //monstro que vira criaturas voadoras quando apanhas
        //modulos de transicao... tipo castlevania entrando no castelo
        //ficar espada na parede, enquanto faz o slide.... isso vai servir para matar boss no estilo shadow of collosus
        //bad status... slow
        //plataforma "barco"... igual mario....
        //breakable blocks
        //criar mapas para cima e para baixo também.
        //traps
        // fire balls (horizontal e vertical)
        private const int width = 1000;
        private const int height = 900;

        public PlayerState State { get; set; }
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> leftWallChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> rightWallChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> roofChecker;

        public readonly Collider HeadCollider;
        //public readonly Collider ButtCollider;
        public readonly PlayerInputs Inputs;

        public Player(PlayerInputs InputRepository, WorldMover WorldMover)
        {
            this.Inputs = InputRepository;
            X = 1000;
            Y = 7000;

            HeadCollider = new Collider()
            {
                OffsetX = width / 3,
                Width = width / 3,
                Height = height - 10
            };
            HeadCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            HeadCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            HeadCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            HeadCollider.AddTopCollisionHandler(StopsWhenHitting.Top);
            AddCollider(HeadCollider);

            groundChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 3,
                Height = height / 4,
                OffsetX = width / 3,
                OffsetY = height + 1
            };
            AddCollider(groundChecker);

            leftWallChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 10,
                Height = height / 3,
                OffsetX = width / 3 - width / 6,
                OffsetY = height / 3
            };
            AddCollider(leftWallChecker);

            rightWallChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 10,
                Height = height / 3,
                OffsetX = width - width / 4,
                OffsetY = height / 3
            };
            AddCollider(rightWallChecker);

            roofChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 3,
                Height = height / 10,
                OffsetX = width / 3,
                OffsetY = -height / 10 - 1
            };
            AddCollider(roofChecker);

            AddUpdate(new ChangeToStandingState(this));
            AddUpdate(new ChangeToWalkingState(this));
            AddUpdate(new ChangeToFallingState(this, InputRepository));
            AddUpdate(new ChangeToSlidingState(this, InputRepository));
            AddUpdate(new ChangeToWallJumping(this, () => InputRepository.ClickedJump));
            AddUpdate(new ChangeToHeadBumpState(this, InputRepository, WorldMover.Camera));
            AddUpdate(new ChangeToCrouchState(this));

            //AddUpdate(() => HeadCollider.Disabled = ButtCollider.Disabled = false);

            AddUpdate(new ResetSizeAndOffsetY(this));
            AddUpdate(new ReduceSizeWhenHeadBumping(this));
            AddUpdate(new ReduceSizeWhenCrouching(this));
            AddUpdate(new HorizontalFriction(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(new MoveWhenWalking(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new Jump(this, InputRepository, groundChecker));

            AddUpdate(new WallJump(this, () => InputRepository.ClickedJump, () => !InputRepository.ClickedJump && !InputRepository.JumpDown));
            AddUpdate(new WallJump(this, () => InputRepository.ClickedJump, () => !InputRepository.ClickedJump && !InputRepository.JumpDown));
            AddUpdate(new ReduceSpeedWhileSlidingWall(this));
            //AddUpdate(new HorizontalSpeedLimit(this).Update);

            //AddUpdate(() => { if (State == PlayerState.HeadBumpLeft || State == PlayerState.HeadBumpRight) ButtCollider.Disabled = true; });
            //AddUpdate(() => { if (State == PlayerState.crouchingLeft || State == PlayerState.crouchingRight || State == PlayerState.crouchWalkingLeft || State == PlayerState.crouchWalkingRight) HeadCollider.Disabled = true; });

            //AddUpdate(() => HorizontalSpeed = 80);
#if DEBUG
            AddUpdate(() => Game.LOG += State.ToString() + Environment.NewLine);
#endif
            CreateAnimator(groundChecker);
        }

        private void CreateAnimator(CheckIfCollidingWith<IBlockPlayerMovement> groundChecker)
        {
            var z = 0.4f;

            var jump_left = new Animation(
                new AnimationFrame("jump", 0, 0, width, height) { RenderingLayer = z }
            );

            var jump_right = new Animation(
               new AnimationFrame("jump", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            );

            var crouching_left = new Animation(
                new AnimationFrame("crouching", 0, 0, width, height) { RenderingLayer = z }
            );

            var crouching_right = new Animation(
               new AnimationFrame("crouching", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            );

            var headbump_left = new Animation(
                new AnimationFrame("headbump", 0, 0, width, height) { RenderingLayer = z }
            );

            var headbump_right = new Animation(
               new AnimationFrame("headbump", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            );

            var stand_left = new Animation(
                new AnimationFrame("stand", 0, 0, width, height) { RenderingLayer = z }
            );

            var stand_right = new Animation(
                new AnimationFrame("stand", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            );

            var wallslide_left = new Animation(
                new AnimationFrame("wallslide", 0, 0, width, height) { RenderingLayer = z }
            );

            var wallslide_right = new Animation(
                new AnimationFrame("wallslide", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            );

            var walk_left = new Animation(
                new AnimationFrame("walk0", 0, 0, width, height) { RenderingLayer = z }
                , new AnimationFrame("walk1", 0, 0, width, height) { RenderingLayer = z }
                , new AnimationFrame("walk2", 0, 0, width, height) { RenderingLayer = z }
            );

            var walk_right = new Animation(
                new AnimationFrame("walk0", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
                , new AnimationFrame("walk1", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
                , new AnimationFrame("walk2", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            );

            AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(stand_right, () => State == PlayerState.StandingRight)
                    , new AnimationTransitionOnCondition(stand_left, () => State == PlayerState.StandingLeft)
                    , new AnimationTransitionOnCondition(walk_right, () => State == PlayerState.WalkingRight)
                    , new AnimationTransitionOnCondition(walk_left, () => State == PlayerState.WalkingLeft)
                    , new AnimationTransitionOnCondition(jump_right, () => State == PlayerState.FallingRight || State == PlayerState.WallJumpingToTheRight)
                    , new AnimationTransitionOnCondition(jump_left, () => State == PlayerState.FallingLeft || State == PlayerState.WallJumpingToTheLeft)
                    , new AnimationTransitionOnCondition(wallslide_left, () => State == PlayerState.SlidingWallLeft)
                    , new AnimationTransitionOnCondition(wallslide_right, () => State == PlayerState.SlidingWallRight)
                    , new AnimationTransitionOnCondition(headbump_left, () => State == PlayerState.HeadBumpLeft)
                    , new AnimationTransitionOnCondition(headbump_right, () => State == PlayerState.HeadBumpRight)
                    , new AnimationTransitionOnCondition(crouching_left, () => State == PlayerState.crouchingLeft)
                    , new AnimationTransitionOnCondition(crouching_right, () => State == PlayerState.crouchingRight)
                )
            );
        }
    }
}
