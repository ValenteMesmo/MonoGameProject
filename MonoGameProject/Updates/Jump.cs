using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class Jump : UpdateHandler
    {
        InputRepository InputRepository;
        int jumpImpulseTime = 0;
        int minJumpSpeed = -60;
        int maxJumpSpeed = -120;
        private CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;

        public Jump(
            InputRepository InputRepository,
            CheckIfCollidingWith<IBlockPlayerMovement> groundChecker)
        {
            this.groundChecker = groundChecker;
            this.InputRepository = InputRepository;
        }

        public void Update(Thing Parent)
        {
            if (InputRepository.ClickedJump && groundChecker.Colliding)
            {
                Parent.VerticalSpeed = maxJumpSpeed;
                jumpImpulseTime = 100;
            }

            if (jumpImpulseTime > 0
                && InputRepository.ClickedJump == false
                && InputRepository.JumpDown == false
                && Parent.VerticalSpeed < minJumpSpeed)
            {
                Parent.VerticalSpeed = minJumpSpeed;
            }

            jumpImpulseTime--;
            if (jumpImpulseTime < 0)
                jumpImpulseTime = 0;
        }
    }

    public class LeftWallJump : UpdateHandler
    {
        InputRepository InputRepository;
        //int jumpImpulseTime = 0;
        //int minJumpSpeed = -60;
        int maxJumpSpeed = -120;
        private CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;
        private readonly CheckIfCollidingWith<IBlockPlayerMovement> leftWallChecker;

        public LeftWallJump(
            InputRepository InputRepository
            , CheckIfCollidingWith<IBlockPlayerMovement> groundChecker
            , CheckIfCollidingWith<IBlockPlayerMovement> leftWallChecker
            )
        {
            this.groundChecker = groundChecker;
            this.InputRepository = InputRepository;
            this.leftWallChecker = leftWallChecker;
        }

        public void Update(Thing Parent)
        {
            if (InputRepository.ClickedJump && !groundChecker.Colliding && leftWallChecker.Colliding)
            {
                Parent.VerticalSpeed = maxJumpSpeed;
                Parent.HorizontalSpeed = -maxJumpSpeed;
                //jumpImpulseTime = 100;
            }

            //if (jumpImpulseTime > 0
            //    && InputRepository.ClickedJump == false
            //    && InputRepository.JumpDown == false
            //    && Parent.VerticalSpeed < minJumpSpeed)
            //{
            //    Parent.VerticalSpeed = minJumpSpeed;
            //    Parent.HorizontalSpeed = -minJumpSpeed;
            //}

            //jumpImpulseTime--;
            //if (jumpImpulseTime < 0)
            //    jumpImpulseTime = 0;
        }
    }

    public class RightWallJump : UpdateHandler
    {
        InputRepository InputRepository;
        //int jumpImpulseTime = 0;
        //int minJumpSpeed = -60;
        int maxJumpSpeed = -120;
        private CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;
        private readonly CheckIfCollidingWith<IBlockPlayerMovement> rightWallChecker;

        public RightWallJump(
            InputRepository InputRepository
            , CheckIfCollidingWith<IBlockPlayerMovement> groundChecker
            , CheckIfCollidingWith<IBlockPlayerMovement> rightWallChecker
            )
        {
            this.groundChecker = groundChecker;
            this.InputRepository = InputRepository;
            this.rightWallChecker = rightWallChecker;
        }

        public void Update(Thing Parent)
        {
            if (InputRepository.ClickedJump && !groundChecker.Colliding && rightWallChecker.Colliding)
            {
                Parent.VerticalSpeed = maxJumpSpeed;
                Parent.HorizontalSpeed = maxJumpSpeed;
                //jumpImpulseTime = 100;
            }

            //if (jumpImpulseTime > 0
            //    && InputRepository.ClickedJump == false
            //    && InputRepository.JumpDown == false
            //    && Parent.VerticalSpeed < minJumpSpeed)
            //{
            //    Parent.VerticalSpeed = minJumpSpeed;
            //    Parent.HorizontalSpeed = minJumpSpeed;
            //}

            //jumpImpulseTime--;
            //if (jumpImpulseTime < 0)
            //    jumpImpulseTime = 0;
        }
    }
}
