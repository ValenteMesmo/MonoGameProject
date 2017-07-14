using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class Jump : UpdateHandler
    {
        PlayerInputs InputRepository;
        int jumpImpulseTime = 0;
        int jumpAvailave = 0;
        int minJumpSpeed = -60;
        int maxJumpSpeed = -120;
        private CheckIfCollidingWith<IBlockPlayerMovement> groundChecker;
        private readonly Thing Parent;

        public Jump(
            Thing Parent,
            PlayerInputs InputRepository,
            CheckIfCollidingWith<IBlockPlayerMovement> groundChecker)
        {
            this.Parent = Parent;
            this.groundChecker = groundChecker;
            this.InputRepository = InputRepository;
        }

        public void Update()
        {
            if (groundChecker.Colliding)
            {
                jumpAvailave = 10;
            }

            if (InputRepository.ClickedJump && jumpAvailave > 0)
            {
                Parent.VerticalSpeed = maxJumpSpeed;
                jumpImpulseTime = 50;
                jumpAvailave = 0;
            }

            if (jumpImpulseTime > 0
                && InputRepository.ClickedJump == false
                && InputRepository.JumpDown == false
                && Parent.VerticalSpeed < minJumpSpeed)
            {
                Parent.VerticalSpeed = minJumpSpeed;
            }

            jumpAvailave--;
            jumpImpulseTime--;
        }
    }
}
