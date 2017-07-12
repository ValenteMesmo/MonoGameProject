using GameCore;

namespace MonoGameProject
{
    public class ChangeToWalkingState : UpdateHandler
    {
        private readonly Player Player;

        public ChangeToWalkingState(Player Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.groundChecker.Colliding && Player.VerticalSpeed == 0)
            {
                if (Player.HorizontalSpeed > 0)
                {
                    Player.State = PlayerState.WalkingRight;
                }
                else if (Player.HorizontalSpeed < 0)
                {
                    Player.State = PlayerState.WalkingLeft;
                }
            }
        }
    }
}
