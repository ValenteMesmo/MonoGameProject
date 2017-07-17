using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using MonoGameProject.Updates.PlayerStates;
using System;

namespace MonoGameProject
{
    public class DestroyIfLeftBehind : UpdateHandler
    {
        private readonly Thing Thing;

        public DestroyIfLeftBehind(Thing Thing)
        {
            this.Thing = Thing;
        }

        public void Update()
        {
            if (Thing.X <= -MapModule.WIDTH * 2
                || Thing.X >= MapModule.WIDTH * 3
                )
                Thing.Destroy();
        }
    }

    public class LeftFireBallTrap : Thing
    {
        public LeftFireBallTrap(Action<Thing> AddToWorld, int startAfter)
        {
            var cooldown = startAfter;
            AddUpdate(() =>
            {
                cooldown--;
                if (cooldown <= 0)
                {
                    AddToWorld(new FireBall(50, 0) { X = X + 50, Y = Y + 50 });
                    cooldown = 200;
                }
            });
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
            AddAnimation(new Animation(
                                new AnimationFrame(
                                    "block"
                                    , 0
                                    , 0
                                    , MapModule.CELL_SIZE
                                    , MapModule.CELL_SIZE
                                )
                                { RenderingLayer = 1 })
            { Color = Color.Orange });
        }
    }

    public class RightFireBallTrap : Thing
    {
        public RightFireBallTrap(Action<Thing> AddToWorld, int startAfter)
        {
            var cooldown = startAfter;
            AddUpdate(() =>
            {
                cooldown--;
                if (cooldown <= 0)
                {
                    AddToWorld(new FireBall(-50, 0) { X = X - 50, Y = Y + 50 });
                    cooldown = 200;
                }
            });
            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddAnimation(new Animation(
                               new AnimationFrame(
                                   "block"
                                   , 0
                                   , 0
                                   , MapModule.CELL_SIZE
                                   , MapModule.CELL_SIZE
                               )
                               { RenderingLayer = 1 })
            { Color = Color.Orange });
        }
    }

    public class FireBall : Thing
    {
        public FireBall(int speedX, int speedY)
        {
            var width = 400;
            var height = 400;
            AddAnimation(
                new Animation(
                    new AnimationFrame("block", 0, 0, width, height) { RenderingLayer = 0.4f })
                {
                    Color = Color.Yellow
                });

            AddUpdate(() => X += speedX);
            AddUpdate(() => Y += speedY);
            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            var collider = new Collider() { Width = width, Height = height };
            Action<Collider, Collider> collisionHandler = (s, t) => { if (t.Parent is IBlockPlayerMovement) Destroy(); };
            collider.AddBotCollisionHandler(collisionHandler);
            collider.AddTopCollisionHandler(collisionHandler);
            collider.AddLeftCollisionHandler(collisionHandler);
            collider.AddRightCollisionHandler(collisionHandler);
            AddCollider(collider);
        }
    }

    public class PreventPlayerFromAccicentlyFalling : UpdateHandler
    {
        private readonly Player Player;
        private const int VELOCITY = 8;

        public PreventPlayerFromAccicentlyFalling(Player Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.StandingLeft
                || Player.State == PlayerState.StandingRight
                || Player.State == PlayerState.crouchingLeft
                || Player.State == PlayerState.crouchingRight)
            {
                if (Player.HorizontalSpeed > 0 
                    && Player.Inputs.RightDown == false                    
                    && Player.RightGroundAcidentChecker.Colliding == false)
                {
                    Player.HorizontalSpeed -= VELOCITY;
                    if (Player.HorizontalSpeed < 0)
                        Player.HorizontalSpeed = 0;
                }
                if (Player.HorizontalSpeed < 0 
                    && Player.Inputs.LeftDown == false
                    && Player.LeftGroundAcidentChecker.Colliding == false)
                {
                    Player.HorizontalSpeed += VELOCITY;
                    if (Player.HorizontalSpeed > 0)
                        Player.HorizontalSpeed = 0;
                }
            }
        }
    }

    public class Player : Thing
    {
        //spawn de zumbis
        //3 i/o   (2 é pouco)

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
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> RightGroundAcidentChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> LeftGroundAcidentChecker;

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

            Action<Collider, Collider> HandleFireball = (s, t) =>
            {
                if (t.Parent is FireBall)
                {
                    t.Parent.Destroy();
                }
            };

            HeadCollider.AddBotCollisionHandler(HandleFireball);
            HeadCollider.AddTopCollisionHandler(HandleFireball);
            HeadCollider.AddLeftCollisionHandler(HandleFireball);
            HeadCollider.AddRightCollisionHandler(HandleFireball);

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

            RightGroundAcidentChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 3,
                Height = height / 4,
                OffsetX = width / 3 + width / 3 +1,
                OffsetY = height + 1
            };
            AddCollider(RightGroundAcidentChecker);
            LeftGroundAcidentChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 3,
                Height = height / 4,
                OffsetX = width / 3 - width / 3 -1,
                OffsetY = height + 1
            };
            AddCollider(LeftGroundAcidentChecker);


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
            AddUpdate(new PreventPlayerFromAccicentlyFalling(this));
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
            var z = 0.45f;

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
