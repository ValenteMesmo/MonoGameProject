using GameCore;

namespace MonoGameProject
{
    class Player : Thing
    {
        public Player(InputRepository InputRepository, WorldMover WorldMover)
        {
            X = 1000;
            Y = 7000;

            var width = 1000;
            var height = 1000;

            CreateMainCollider(width, height);

            var groundChecker = new CheckIfCollidingWith<Ground>()
            {
                Width = width / 3,
                Height = height / 4,
                X = width / 3,
                Y = height + 1
            };

            AddCollider(groundChecker);

            AddUpdate(new HorizontalFriction().Update);
            AddUpdate(new AfectedByGravity().Update);
            AddUpdate(new MoveLeftOrRight(InputRepository).Update);
            AddUpdate(t => X -= WorldMover.WorldSpeed);
            AddUpdate(new Jump(InputRepository).Update);
            AddUpdate(new SpeedLimit().Update);

            CreateAnimator(groundChecker);
            AddUpdate(groundChecker.Update);
        }

        private void CreateMainCollider(int width, int height)
        {
            var collider = new Collider()
            {
                X = width / 3,
                Width = width / 3,
                Height = height
            };
            collider.AddBotCollisionHandler(new StopWhenHitsTHeGround().Handle);

            AddCollider(collider);
        }

        private void CreateAnimator(CheckIfCollidingWith<Ground> groundChecker)
        {
            var jump_left = new Animation(
                new AnimationFrame("jump", 0, 0, 1000, 1000)
            );

            var jump_right = new Animation(
               new AnimationFrame("jump", 0, 0, 1000, 1000) { Flipped = true }
           );

            var stand_left = new Animation(
                new AnimationFrame("stand", 0, 0, 1000, 1000)
            );

            var stand_right = new Animation(
                new AnimationFrame("stand", 0, 0, 1000, 1000) { Flipped = true }
            );

            var walk_left = new Animation(
                new AnimationFrame("walk0", 0, 0, 1000, 1000)
                , new AnimationFrame("walk1", 0, 0, 1000, 1000)
                , new AnimationFrame("walk2", 0, 0, 1000, 1000)
            );

            var walk_right = new Animation(
                new AnimationFrame("walk0", 0, 0, 1000, 1000) { Flipped = true }
                , new AnimationFrame("walk1", 0, 0, 1000, 1000) { Flipped = true }
                , new AnimationFrame("walk2", 0, 0, 1000, 1000) { Flipped = true }
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
