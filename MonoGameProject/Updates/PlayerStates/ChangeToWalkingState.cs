using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class ChangeToWalkingState : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeToWalkingState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.TakingDamage)
                return;

            if (Player.groundChecker.Colliding<BlockVerticalMovement>()
                && !Player.roofChecker.Colliding<BlockVerticalMovement>()
                && Player.VerticalSpeed >= 0)
            {
                if (Player.Inputs.Right)
                {
                    Player.State = PlayerState.WalkingRight;
                }
                else if (Player.Inputs.Left)
                {
                    Player.State = PlayerState.WalkingLeft;
                }
            }
        }
    }
}
