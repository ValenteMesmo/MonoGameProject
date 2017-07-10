using GameCore;
using MonoGameProject.Things;

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
        FallingLeft,
        FallingRight
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
        private const int width = 1000;
        private const int height = 900;

        //public PlayerState State { get; set; }
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> leftWallChecker;
        public readonly CheckIfCollidingWith<IBlockPlayerMovement> rightWallChecker;

        public Player(InputRepository InputRepository, WorldMover WorldMover)
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
                Width = width / 3,
                Height = height / 3,
                OffsetX = -10,
                OffsetY = height / 3
            };
            AddCollider(leftWallChecker);

            rightWallChecker = new CheckIfCollidingWith<IBlockPlayerMovement>()
            {
                Width = width / 3,
                Height = height / 3,
                OffsetX = ((width / 3) * 2) + 10,
                OffsetY = height / 3
            };
            AddCollider(rightWallChecker);

            //AddUpdate(new UpdatePlayerStatus(this).Update);
            AddUpdate(new HorizontalFriction().Update);
            AddUpdate(new AfectedByGravity().Update);
            AddUpdate(new MoveLeftOrRight(InputRepository).Update);
            AddUpdate(WorldHelper.MoveWithTheWord);
            AddUpdate(new Jump(InputRepository, groundChecker).Update);
            AddUpdate(new WallJump(this, () => InputRepository.LeftDown, () => InputRepository.ClickedJump, () => !InputRepository.ClickedJump && !InputRepository.JumpDown, () => 120, groundChecker, leftWallChecker).Update);
            AddUpdate(new WallJump(this, () => InputRepository.RightDown, () => InputRepository.ClickedJump, () => !InputRepository.ClickedJump && !InputRepository.JumpDown, () => -120, groundChecker, rightWallChecker).Update);
            AddUpdate(new HorizontalSpeedLimit().Update);

            //AddUpdate(t => HorizontalSpeed = 80);

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
            var jump_left = new Animation(
                new AnimationFrame("jump", 0, 0, width, height)
            );

            var jump_right = new Animation(
               new AnimationFrame("jump", 0, 0, width, height) { Flipped = true }
           );

            var stand_left = new Animation(
                new AnimationFrame("stand", 0, 0, width, height)
            );

            var stand_right = new Animation(
                new AnimationFrame("stand", 0, 0, width, height) { Flipped = true }
            );

            var walk_left = new Animation(
                new AnimationFrame("walk0", 0, 0, width, height)
                , new AnimationFrame("walk1", 0, 0, width, height)
                , new AnimationFrame("walk2", 0, 0, width, height)
            );

            var walk_right = new Animation(
                new AnimationFrame("walk0", 0, 0, width, height) { Flipped = true }
                , new AnimationFrame("walk1", 0, 0, width, height) { Flipped = true }
                , new AnimationFrame("walk2", 0, 0, width, height) { Flipped = true }
            );

            AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(new[] { walk_right, jump_right }, stand_right, () => HorizontalSpeed == 0 && groundChecker.Colliding)
                    , new AnimationTransitionOnCondition(new[] { walk_left, jump_left }, stand_left, () => HorizontalSpeed == 0 && groundChecker.Colliding)
                    , new AnimationTransitionOnCondition(new[] { stand_left, stand_right, walk_left, jump_left, jump_right }, walk_right, () => HorizontalSpeed > 0 && groundChecker.Colliding)
                    , new AnimationTransitionOnCondition(new[] { stand_left, stand_right, walk_right, jump_left, jump_right }, walk_left, () => HorizontalSpeed < 0 && groundChecker.Colliding)
                    , new AnimationTransitionOnCondition(new[] { stand_left, stand_right, walk_left, walk_right, jump_left }, jump_right, () => HorizontalSpeed > 0 && groundChecker.Colliding == false)
                    , new AnimationTransitionOnCondition(new[] { stand_left, stand_right, walk_left, walk_right, jump_right }, jump_left, () => HorizontalSpeed < 0 && groundChecker.Colliding == false)
                    , new AnimationTransitionOnCondition(new[] { stand_right, walk_right }, jump_right, () => HorizontalSpeed == 0 && groundChecker.Colliding == false)
                    , new AnimationTransitionOnCondition(new[] { stand_left, walk_left }, jump_left, () => HorizontalSpeed == 0 && groundChecker.Colliding == false)
                )
            );
        }
    }
}
