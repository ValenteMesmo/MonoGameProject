using GameCore;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public enum PlayerState
    {
        StandingLeft,
        StandingRight,
        WalkingLeft,
        WalkingRight,
        SlidingWallLeft,
        SlidingWallRight,
        WallJumpingToTheLeft,
        WallJumpingToTheRight,
        FallingLeft,
        FallingRight,
        HeadBumpLeft,
        HeadBumpRight
    }

    public static class EnumExtensions
    {
        public static bool Is(this PlayerState a, params PlayerState[] states)
        {
            foreach (var b in states)
            {
                if (a == b)
                    return true;
            }
            return false;
        }
    }

    public class Player : Thing
    {
        //vilarejo em chamas... pessoas sendo atacaDas?
        //arvore seca, cheia de criaturas voadoras que parecem passaros... faz barulho perto, que elas voam
        //modulos de transicao... tipo castlevania entrando no castelo
        //ficar espada na parede, enquanto faz o slide.... isso vai servir para matar boss no estilo shadow of collosus
        //bad status... slow
        //plataforma "barco"... igual mario....
        //breakable blocks
        //criar mapas para cima e para baixo também.

        private const int width = 1000;
        private const int height = 900;

        public PlayerState State { get; set; }
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> leftWallChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> rightWallChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> roofChecker;

        public Player(PlayerInputs InputRepository, WorldMover WorldMover)
        {
            X = 1000;
            Y = 7000;

            CreateMainCollider(width, height);

            groundChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 3,
                Height = height / 4,
                OffsetX = width / 3,
                OffsetY = height + 1//por que + 1?????
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
                OffsetY = -height / 10 - 10
            };
            AddCollider(roofChecker);

            AddUpdate(new ChangeToStandingState(this));
            AddUpdate(new ChangeToWalkingState(this));
            AddUpdate(new ChangeToFallingState(this, InputRepository));
            AddUpdate(new ChangeToSlidingState(this, InputRepository));
            AddUpdate(new ChangeToWallJumping(this, () => InputRepository.ClickedJump));
            AddUpdate(new ChangeToHeadBumpState(this, InputRepository));

            AddUpdate(new HorizontalFriction(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(new MoveLeftOrRight(this, InputRepository));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new Jump(this, InputRepository, groundChecker));

            AddUpdate(new WallJump(this, () => InputRepository.ClickedJump, () => !InputRepository.ClickedJump && !InputRepository.JumpDown));
            AddUpdate(new WallJump(this, () => InputRepository.ClickedJump, () => !InputRepository.ClickedJump && !InputRepository.JumpDown));
            AddUpdate(new ReduceSpeedWhileSlidingWall(this));
            AddUpdate(new HorizontalSpeedLimit(this).Update);

            //AddUpdate(() => HorizontalSpeed = 80);
#if DEBUG
            AddUpdate(() => Game.LOG += State.ToString() + Environment.NewLine);
#endif
            CreateAnimator(groundChecker);
        }

        private void CreateMainCollider(int width, int height)
        {
            var collider = new Collider()
            {
                OffsetX = width / 3,
                Width = width / 3,
                Height = height
            };
            collider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            collider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            collider.AddRightCollisionHandler(StopsWhenHitting.Right);
            collider.AddTopCollisionHandler(StopsWhenHitting.Top);
            AddCollider(collider);
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
                    , new AnimationTransitionOnCondition(headbump_left, () =>  State == PlayerState.HeadBumpLeft  )
                    , new AnimationTransitionOnCondition(headbump_right, () =>  State == PlayerState.HeadBumpRight  )
                )
            );
        }
    }
}
