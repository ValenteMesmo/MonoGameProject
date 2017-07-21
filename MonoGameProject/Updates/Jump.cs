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
        private readonly Humanoid Parent;
        private int cooldown;

        public Jump(
            Humanoid Parent,
            PlayerInputs InputRepository,
            CheckIfCollidingWith<IBlockPlayerMovement> groundChecker)
        {
            this.Parent = Parent;
            this.groundChecker = groundChecker;
            this.InputRepository = InputRepository;
        }

        public void Update()
        {
            if (Parent.State == PlayerState.TakingDamage)
                return;

            if (groundChecker.Colliding)
            {
                jumpAvailave = 10;
            }

            if (InputRepository.ClickedJump && jumpAvailave > 0 && cooldown <= 0)
            {
                Parent.VerticalSpeed = maxJumpSpeed;
                jumpImpulseTime = 50;
                cooldown = 20;
                jumpAvailave = 0;
            }

            if (jumpImpulseTime > 0
                && InputRepository.ClickedJump == false
                && InputRepository.JumpDown == false
                && Parent.VerticalSpeed < minJumpSpeed)
            {
                Parent.VerticalSpeed = minJumpSpeed;
            }

            cooldown--;
            jumpAvailave--;
            jumpImpulseTime--;
        }
    }
}
