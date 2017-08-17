using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class ChangeToSlidingState : UpdateHandler
    {
        private readonly Humanoid Player;

        public ChangeToSlidingState(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.LegState == LegState.TakingDamage
                || Player.HeadState == HeadState.Bump)
                return;

            if (Player.groundChecker.Colliding<SomeKindOfGround>() == false
                && Player.VerticalSpeed > 0
                && Player.LegState != LegState.WallJumping)
            {
                if (Player.leftWallChecker.Colliding<SomeKindOfGround>()
                    && Player.Inputs.Left)
                {
                    Player.LegState = LegState.SlidingWall;
                    Player.FacingRight = true;
                }
                else if (Player.rightWallChecker.Colliding<SomeKindOfGround>()
                    && Player.Inputs.Right)
                {
                    Player.LegState = LegState.SlidingWall;
                    Player.FacingRight = false;
                }
            }
        }
    }
}
