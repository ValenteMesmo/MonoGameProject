using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class Jump : UpdateHandler
    {
        int jumpImpulseTime = 0;
        int jumpAvailave = 0;
        public const int minJumpSpeed = -40;
        public const int maxJumpSpeed = -140;
        private readonly Humanoid Parent;
        private int cooldown;

        public Jump(
            Humanoid Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (Parent.roofChecker.Colliding<BlockVerticalMovement>()
                && Parent.Inputs.ClickedJump)
            {
                Parent.HorizontalSpeed = Parent.FacingRight ? 50 : -50;
                return;
            }

            if (Parent.groundChecker.Colliding<BlockVerticalMovement>())
            {
                jumpAvailave = 10;
            }
            
            if (Parent.Inputs.ClickedJump
                && jumpAvailave > 0
                && cooldown <= 0)
            {
                Parent.VerticalSpeed = maxJumpSpeed;
                jumpImpulseTime = 50;
                cooldown = 20;
                jumpAvailave = 0;
            }

            if (jumpImpulseTime > 0
                && Parent.Inputs.ClickedJump == false
                && Parent.Inputs.JumpDown == false
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
