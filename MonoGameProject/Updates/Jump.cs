using GameCore;
using MonoGameProject.Things;
using System;

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
                jumpImpulseTime = 50;
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

    public class WallJump : UpdateHandler
    {
        int jumpImpulseTime = 0;
        //int duration;
        private CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;
        private readonly CheckIfCollidingWith<IBlockPlayerMovement> WallChecker;
        private readonly Func<bool> DirectionButtonPressed;
        private readonly Func<bool> JumpButtonClicked;
        private readonly Func<int> GetSpeed;
        private readonly Func<bool> JumpButtonReleased;

        public WallJump(
            Player player
            , Func<bool> DirectionButtonPressed
            , Func<bool> JumpButtonClicked
            , Func<bool> JumpButtonReleased
            , Func<int> GetSpeed
            , CheckIfCollidingWith<IBlockPlayerMovement> groundChecker
            , CheckIfCollidingWith<IBlockPlayerMovement> WallChecker
            )
        {
            this.groundChecker = groundChecker;
            this.DirectionButtonPressed = DirectionButtonPressed;
            this.JumpButtonClicked = JumpButtonClicked;
            this.JumpButtonReleased = JumpButtonReleased;
            this.WallChecker = WallChecker;
            this.GetSpeed = GetSpeed;
        }

        public void Update(Thing Parent)
        {
            if (JumpButtonClicked() && !groundChecker.Colliding && WallChecker.Colliding)
            {
                Parent.HorizontalSpeed = GetSpeed();
                Parent.VerticalSpeed = -Math.Abs(GetSpeed());
                jumpImpulseTime = 25;
            }

            if (jumpImpulseTime > 0
                // && JumpButtonReleased()
                //&& Parent.VerticalSpeed <GetSpeed()/3
                )
            {
                if (JumpButtonReleased()
                    //&& jumpImpulseTime > 10
                    )
                {
                    Parent.HorizontalSpeed = GetSpeed();
                    jumpImpulseTime = 0;
                }
                else
                    Parent.HorizontalSpeed = GetSpeed();
                //Parent.VerticalSpeed = GetSpeed() / 3;
                jumpImpulseTime--;
            }


            //if (JumpButtonPressed() && !groundChecker.Colliding && WallChecker.Colliding)
            //{
            //    Parent.VerticalSpeed = -Math.Abs(GetSpeed());
            //    duration = 50;
            //}

            //if (duration > 0
            //&& JumpButtonReleased()
            //)
            //{
            //    if (DirectionButtonPressed())
            //        Parent.HorizontalSpeed = -GetSpeed() / 3;
            //    else
            //        Parent.HorizontalSpeed = GetSpeed() / 3;

            //    duration = 0;
            //}
            //else if (duration > 0)
            //{
            //    Parent.HorizontalSpeed = GetSpeed();
            //}

            //duration--;
        }
    }
}
