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
            if (Player.groundChecker.Colliding)
            {
                if (Player.Inputs.RightDown)
                {
                    Player.State = PlayerState.WalkingRight;
                }
                else if (Player.Inputs.LeftDown)
                {
                    Player.State = PlayerState.WalkingLeft;
                }
            }
        }
    }
}
