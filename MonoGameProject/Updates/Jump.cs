using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class Jump : UpdateHandler
    {
        GameInputs InputRepository;
        int jumpImpulseTime = 0;
        int jumpAvailave = 0;
        int minJumpSpeed = -60;
        int maxJumpSpeed = -140;
        private CollisionChecker groundChecker;
        private readonly Humanoid Parent;
        private int cooldown;

        public Jump(
            Humanoid Parent,
            GameInputs InputRepository,
            CollisionChecker groundChecker)
        {
            this.Parent = Parent;
            this.groundChecker = groundChecker;
            this.InputRepository = InputRepository;
        }

        public void Update()
        {
            if (groundChecker.Colliding<BlockVerticalMovement>())
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
