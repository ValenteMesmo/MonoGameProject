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
            var size2 = 2800;
            var size1 = 590;
            var y2 = -1880;
            var x2 = -1550;
            var flippedx = -200;

            BodyAnimator(thing, size2, size1, y2, x2, flippedx);
            HeadAnimator(thing, size2, size1, y2, x2, flippedx);
            LegsAnimator(thing, size2, size1, y2, x2, flippedx);
        }

        private static void LegsAnimator(ThingWithState thing, int size2, int size1, int y2, int x2, int flippedx)
        {
            var stand_left2 = new Animation(
                  new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1 * 2, size1, size1, size1)) { RenderingLayer = 0 }
            );
            var stand_right2 = new Animation(
                  new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1 * 2, size1, size1, size1)) { RenderingLayer = 0, Flipped = true }
            );

            var walk_left2 = new Animation(
                    new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, size1 * 2, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1, size1 * 2, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1 * 2, size1 * 2, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, size1 * 3, size1, size1)) { RenderingLayer = 0 }
                );
            var walk_right2 = new Animation(
                    new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, size1 * 2, size1, size1)) { RenderingLayer = 0, Flipped = true }
                    , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1, size1 * 2, size1, size1)) { RenderingLayer = 0, Flipped = true }
                    , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1 * 2, size1 * 2, size1, size1)) { RenderingLayer = 0, Flipped = true }
                    , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, size1 * 3, size1, size1)) { RenderingLayer = 0, Flipped = true }
                );

            var pernas = new Animator(
                new AnimationTransitionOnCondition(walk_left2, () => thing.State == PlayerState.WalkingLeft)
                , new AnimationTransitionOnCondition(walk_right2, () => thing.State == PlayerState.WalkingRight)
                , new AnimationTransitionOnCondition(stand_left2, () => thing.State == PlayerState.StandingLeft)
                , new AnimationTransitionOnCondition(stand_right2, () => thing.State == PlayerState.StandingRight)
            );
            thing.AddAnimation(pernas);
        }

        private static void HeadAnimator(ThingWithState thing, int size2, int size1, int y2, int x2, int flippedx)
        {
            var head_left2 = new Animation(
                            new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1, size1, size1, size1)) { RenderingLayer = 0 }
                        );
            var head_right2 = new Animation(
                new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1, size1, size1, size1)) { RenderingLayer = 0, Flipped = true }
            );
            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(head_right2, () => thing.State == PlayerState.WalkingRight)
                , new AnimationTransitionOnCondition(head_left2, () => thing.State == PlayerState.WalkingLeft)
            ));
        }

        private static void BodyAnimator(ThingWithState thing, int size2, int size1, int y2, int x2, int flippedx)
        {
            var punch_left = new Animation(
                    new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, 0, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1, 0, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1 * 2, 0, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, size1, size1, size1)) { RenderingLayer = 0 }
                );
            var punch_right = new Animation(
                  new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, 0, size1, size1)) { RenderingLayer = 0, Flipped = true }
                  , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1, 0, size1, size1)) { RenderingLayer = 0, Flipped = true }
                  , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1 * 2, 0, size1, size1)) { RenderingLayer = 0, Flipped = true }
                  , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, size1, size1, size1)) { RenderingLayer = 0, Flipped = true }
              );


            var body_standing_right = new Animation(
                new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, size1, size1, size1)) { RenderingLayer = 0, Flipped = true }
            );
            var body_standing_left = new Animation(
                new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, size1, size1, size1)) { RenderingLayer = 0 }
            );
            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(body_standing_right, () => thing.State == PlayerState.WalkingRight)
                , new AnimationTransitionOnCondition(body_standing_left, () => thing.State == PlayerState.WalkingLeft)
                , new AnimationTransitionOnCondition(punch_left, () => thing.Inputs.Action1Down)
                , new AnimationTransitionOnCondition(punch_right, () => thing.Inputs.Action1Down)
            ));
        }
    }
}
