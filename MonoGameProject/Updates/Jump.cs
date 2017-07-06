using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class Jump : UpdateHandler
    {
        InputRepository InputRepository;
        int jumpImpulseTime = 0;
        int minJumpSpeed = -40;
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
                Parent.VerticalSpeed = -100;
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
}
