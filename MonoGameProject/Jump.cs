using GameCore;

namespace MonoGameProject
{
    public class Jump : UpdateHandler
    {
        InputRepository InputRepository;
        public Jump(InputRepository InputRepository)
        {
            this.InputRepository = InputRepository;
        }

        int jumpImpulseTime = 0;
        int minJumpSpeed =-40;
        public void Update(Thing Parent)
        {
            if (InputRepository.ClickedJump)
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
