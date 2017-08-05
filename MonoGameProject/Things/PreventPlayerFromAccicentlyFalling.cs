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
            if (Player.LegState == LegState.Standing
                || Player.LegState == LegState.Crouching)
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
