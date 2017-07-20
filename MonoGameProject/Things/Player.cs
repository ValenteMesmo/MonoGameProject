using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using MonoGameProject.Updates.PlayerStates;
using System;

namespace MonoGameProject
{
    public class AIInput : PlayerInputs, UpdateHandler
    {
        public bool ClickedLeft { get; private set; }
        public bool ClickedRight { get; private set; }
        public bool ClickedUp { get; private set; }
        public bool ClickedDown { get; private set; }
        public bool ClickedAction1 { get; private set; }
        public bool ClickedJump { get; private set; }

        private bool WasPressedLeft { get; set; }
        private bool WasPressedRight { get; set; }
        private bool WasPressedUp { get; set; }
        private bool WasPressedDown { get; set; }
        private bool WasPressedAction1 { get; set; }
        private bool WasPressedJump { get; set; }

        public bool LeftDown { get; set; }
        public bool RightDown { get; set; }
        public bool UpDown { get; set; }
        public bool DownDown { get; set; }
        public bool Action1Down { get; set; }
        public bool JumpDown { get; set; }

        public void Update()
        {
            ClickedLeft = !WasPressedLeft && LeftDown;
            ClickedRight = !WasPressedRight && RightDown;
            ClickedUp = !WasPressedUp && UpDown;
            ClickedDown = !WasPressedDown && DownDown;
            ClickedAction1 = !WasPressedAction1 && Action1Down;
            ClickedJump = !WasPressedJump && JumpDown;

            WasPressedLeft = LeftDown;
            WasPressedRight = RightDown;
            WasPressedUp = UpDown;
            WasPressedDown = DownDown;
            WasPressedAction1 = Action1Down;
            WasPressedJump = JumpDown;
        }

    }

    public class Enemy : ThingWithState
    {
        private const int width = 1000;
        private const int height = 900;

        public Enemy(AIInput inputs, Game1 WorldMover) : base(inputs, WorldMover)
        {
            X = 2000;
            Y = 7000;

            var time = 0;
            inputs.RightDown = true;
            AddUpdate(() =>
            {
                time++;

                if (time >= 50)
                {
                    time = 0;
                    inputs.JumpDown = true;
                    inputs.LeftDown = inputs.RightDown;
                    inputs.RightDown = !inputs.LeftDown;
                }
                else
                    inputs.JumpDown = false;
            });

            AddUpdate(inputs);

            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            new MyClass().CreateAnimator(width, height, this, Color.Purple);
        }
    }

    public class Player : ThingWithState
    {
        //animacao de beirada (quase caindo)
        //incluir misc stuff ... coisas que da para quebrar! caso voce erre um ataque, por exemplo.

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
        public int DamageDuration = 0;

        public Player(PlayerInputs InputRepository, Game1 Game1) : base(InputRepository, Game1)
        {
            X = 1000;
            Y = 7000;

            var count = 0;
            Action<Collider, Collider> HandleFireball = (s, t) =>
            {
                if (t.Parent is FireBall && State != PlayerState.TakingDamage)
                {
                    State = PlayerState.TakingDamage;
                    HorizontalSpeed = t.Parent.HorizontalSpeed;
                    VerticalSpeed = -50;

                    DamageDuration = 25;
                    t.Disabled = true;
                    t.Parent.Destroy();
                    
                }
            };
            AddUpdate(() =>
            {
                if (State == PlayerState.TakingDamage)
                {
                    DamageDuration--;
                    if (DamageDuration <= 0)
                    {
                        DamageDuration = 0;
                        State = PlayerState.FallingRight;
                        if (count == 1)
                            Game1.Restart();
                    count++;
                    }
                }
            });

            //AddUpdate(() => Game.LOG += X);

            MainCollider.AddBotCollisionHandler(HandleFireball);
            MainCollider.AddTopCollisionHandler(HandleFireball);
            MainCollider.AddLeftCollisionHandler(HandleFireball);
            MainCollider.AddRightCollisionHandler(HandleFireball);

            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            new MyClass().CreateAnimator(width, height, this, Color.White);
        }
    }

    public class ThingWithState : Thing
    {
        public PlayerState State { get; set; }

        private const int width = 1000;
        private const int height = 900;

        public readonly CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> leftWallChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> rightWallChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> roofChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> RightGroundAcidentChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> LeftGroundAcidentChecker;

        public readonly Collider MainCollider;
        public readonly PlayerInputs Inputs;

        public ThingWithState(PlayerInputs InputRepository, Game1 WorldMover)
        {
            this.Inputs = InputRepository;

            MainCollider = new Collider()
            {
                OffsetX = width / 3,
                Width = width / 3,
                Height = height - 10
            };

            AddCollider(MainCollider);

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
                OffsetX = width / 3 + width / 3 + 1,
                OffsetY = height + 1
            };
            AddCollider(RightGroundAcidentChecker);
            LeftGroundAcidentChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 3,
                Height = height / 4,
                OffsetX = width / 3 - width / 3 - 1,
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
            AddUpdate(new ChangeToFallingState(this));
            AddUpdate(new ChangeToSlidingState(this));
            AddUpdate(new ChangeToWallJumping(this));
            AddUpdate(new ChangeToHeadBumpState(this, WorldMover.Camera));
            AddUpdate(new ChangeToCrouchState(this));
            AddUpdate(new DestroyIfLeftBehind(this));

            //AddUpdate(() => HeadCollider.Disabled = ButtCollider.Disabled = false);
            AddUpdate(new PreventPlayerFromAccicentlyFalling(this));
            AddUpdate(new ResetSizeAndOffsetY(this));
            AddUpdate(new ReduceSizeWhenHeadBumping(this));
            AddUpdate(new ReduceSizeWhenCrouching(this));
            AddUpdate(new HorizontalFriction(this));
            AddUpdate(new AfectedByGravity(this));
            AddUpdate(new MoveLeftOrRight(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new Jump(this, InputRepository, groundChecker));

            AddUpdate(new WallJump(this));

            AddUpdate(new ReduceSpeedWhileSlidingWall(this));
#if DEBUG
            AddUpdate(() => Game.LOG += GetType().Name + " " + State.ToString() + Environment.NewLine);
#endif
        }
    }
    class MyClass
    {
        public void CreateAnimator(int width, int height, ThingWithState thing, Color Color)
        {
            var z = 0.45f;

            var jump_left = new Animation(
                new AnimationFrame("jump", 0, 0, width, height) { RenderingLayer = z }
            )
            { Color = Color };

            var jump_right = new Animation(
               new AnimationFrame("jump", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            )
            { Color = Color };

            var crouching_left = new Animation(
                new AnimationFrame("crouching", 0, 0, width, height) { RenderingLayer = z }
            )
            { Color = Color };

            var crouching_right = new Animation(
               new AnimationFrame("crouching", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            )
            { Color = Color };

            var headbump_left = new Animation(
                new AnimationFrame("headbump", 0, 0, width, height) { RenderingLayer = z }
            )
            { Color = Color };

            var headbump_right = new Animation(
               new AnimationFrame("headbump", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            )
            { Color = Color };

            var stand_left = new Animation(
                new AnimationFrame("stand", 0, 0, width, height) { RenderingLayer = z }
            )
            { Color = Color };

            var stand_right = new Animation(
                new AnimationFrame("stand", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            )
            { Color = Color };

            var wallslide_left = new Animation(
                new AnimationFrame("wallslide", 0, 0, width, height) { RenderingLayer = z }
            )
            { Color = Color };

            var wallslide_right = new Animation(
                new AnimationFrame("wallslide", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            )
            { Color = Color };

            var walk_left = new Animation(
                new AnimationFrame("walk0", 0, 0, width, height) { RenderingLayer = z }
                , new AnimationFrame("walk1", 0, 0, width, height) { RenderingLayer = z }
                , new AnimationFrame("walk2", 0, 0, width, height) { RenderingLayer = z }
            )
            { Color = Color };

            var walk_right = new Animation(
                new AnimationFrame("walk0", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
                , new AnimationFrame("walk1", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
                , new AnimationFrame("walk2", 0, 0, width, height) { Flipped = true, RenderingLayer = z }
            )
            { Color = Color };

            //thing.AddAnimation(
            //    new Animator(
            //        new AnimationTransitionOnCondition(stand_right, () => thing.State == PlayerState.StandingRight)
            //        , new AnimationTransitionOnCondition(stand_left, () => thing.State == PlayerState.StandingLeft)
            //        , new AnimationTransitionOnCondition(walk_right, () => thing.State == PlayerState.WalkingRight)
            //        , new AnimationTransitionOnCondition(walk_left, () => thing.State == PlayerState.WalkingLeft)
            //        , new AnimationTransitionOnCondition(jump_right, () => thing.State == PlayerState.FallingRight || thing.State == PlayerState.WallJumpingToTheRight)
            //        , new AnimationTransitionOnCondition(jump_left, () => thing.State == PlayerState.FallingLeft || thing.State == PlayerState.WallJumpingToTheLeft)
            //        , new AnimationTransitionOnCondition(wallslide_left, () => thing.State == PlayerState.SlidingWallLeft)
            //        , new AnimationTransitionOnCondition(wallslide_right, () => thing.State == PlayerState.SlidingWallRight)
            //        , new AnimationTransitionOnCondition(headbump_left, () => thing.State == PlayerState.HeadBumpLeft)
            //        , new AnimationTransitionOnCondition(headbump_right, () => thing.State == PlayerState.HeadBumpRight)
            //        , new AnimationTransitionOnCondition(crouching_left, () => thing.State == PlayerState.CrouchingLeft)
            //        , new AnimationTransitionOnCondition(crouching_right, () => thing.State == PlayerState.CrouchingRight)
            //        , new AnimationTransitionOnCondition(jump_right, () => thing.State == PlayerState.TakingDamage)
            //    )
            //    { Color = Color }
            //);

            //AddAnimation(new Animation(new AnimationFrame("head", 0, 0, 1000, 1000) {RenderingLayer=0 }) );
            var size2 = 1400;
            var y2 = -480;
            thing.AddAnimation(
                new Animation(
                    new AnimationFrame("knight", 0, y2, size2, size2 , new Rectangle(0, 0, 316, 316)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", 0, y2, size2 , size2 , new Rectangle(316, 0, 316, 316)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", 0, y2, size2 , size2 , new Rectangle(316*2, 0, 316, 316)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", 0, y2, size2 , size2 , new Rectangle(0, 316, 316, 316)) { RenderingLayer = 0 }
                ));
            thing.AddAnimation(
                new Animation(
                    new AnimationFrame("knight", 0, y2, size2 , size2 , new Rectangle(316, 316, 316, 316)) { RenderingLayer = 0 }
                ));
            thing.AddAnimation(
                new Animation(
                    new AnimationFrame("knight", 0, y2, size2 , size2 , new Rectangle(316 * 2, 316 , 316, 316)) { RenderingLayer = 0 }
                ));
        }
    }
}
