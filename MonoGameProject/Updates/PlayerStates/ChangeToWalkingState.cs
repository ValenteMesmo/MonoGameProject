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
            if (Player.LegState == LegState.TakingDamage)
                return;

            //|| Player.roofChecker.Colliding<BlockVerticalMovement>()

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
                    Player.TorsoState = TorsoState.Standing;

                //TODO: move this to ohter class
                if (Player.Inputs.Right && !Player.Inputs.Left)
                {
                    Player.FacingRight = true;
                }
                else if (!Player.Inputs.Right && Player.Inputs.Left)
                {
                    Player.FacingRight = false;
                }
            }
        }
    }
}
