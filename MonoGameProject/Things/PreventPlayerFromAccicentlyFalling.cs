using GameCore;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class PreventPlayerFromAccicentlyFalling : UpdateHandler
    {
        private readonly Humanoid Player;
        private const int VELOCITY = 8;

        public PreventPlayerFromAccicentlyFalling(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.StandingLeft
                || Player.State == PlayerState.StandingRight
                || Player.State == PlayerState.CrouchingLeft
                || Player.State == PlayerState.CrouchingRight)
            {
                if (Player.HorizontalSpeed > 0 
                    && Player.Inputs.Right == false                    
                    && Player.RightGroundAcidentChecker.Colliding<SomeKindOfGround>() == false)
                {
                    Player.HorizontalSpeed -= VELOCITY;
                    if (Player.HorizontalSpeed < 0)
                        Player.HorizontalSpeed = 0;
                }
                if (Player.HorizontalSpeed < 0 
                    && Player.Inputs.Left == false
                    && Player.LeftGroundAcidentChecker.Colliding<SomeKindOfGround>() == false)
                {
                    Player.HorizontalSpeed += VELOCITY;
                    if (Player.HorizontalSpeed > 0)
                        Player.HorizontalSpeed = 0;
                }
            }
        }
    }
}
