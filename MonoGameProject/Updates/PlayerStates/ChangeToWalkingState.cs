using GameCore;

namespace MonoGameProject
{
    public class ChangeToWalkingState : UpdateHandler
    {
        private readonly ThingWithState Player;

        public ChangeToWalkingState(ThingWithState Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.groundChecker.Colliding
                && !Player.roofChecker.Colliding)
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
