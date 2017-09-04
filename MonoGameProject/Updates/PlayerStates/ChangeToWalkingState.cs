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
            if (Player.LegState == LegState.TakingDamage
                || Player.TorsoState == TorsoState.AttackCrouching)
                return;
            
            if (Player.groundChecker.Colliding<BlockVerticalMovement>()
                && Player.VerticalSpeed >= 0)
            {
                var shouldWalk = !Player.roofChecker.Colliding<BlockVerticalMovement>()
                    && 
                    ((Player.Inputs.Right && !Player.Inputs.Left)
                    || (!Player.Inputs.Right && Player.Inputs.Left));

                if (shouldWalk)
                    Player.LegState = LegState.Walking;

                if (Player.TorsoState == TorsoState.Attack
                    || Player.TorsoState == TorsoState.AttackCrouching
                    || Player.LegState == LegState.WallJumping)
                    return;

                if (shouldWalk)
                {
                    Player.TorsoState = TorsoState.Standing;
                    Player.HeadState = HeadState.Standing;
                }
            }
        }
    }
}
