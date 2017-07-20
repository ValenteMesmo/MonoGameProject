using GameCore;
using System.Linq;

namespace MonoGameProject.Updates.PlayerStates
{
    class ChangeToCrouchState : UpdateHandler
    {
        public readonly ThingWithState Player;

        public ChangeToCrouchState(ThingWithState Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.TakingDamage)
                return;

            if ( Player.Inputs.DownDown
                && Player.groundChecker.Colliding)
            {
                if (Player.State == PlayerState.StandingRight
                    || Player.State == PlayerState.WalkingRight
                    || Player.State == PlayerState.FallingRight)
                {
                    Player.State = PlayerState.CrouchingRight;
                }
                else if (Player.State == PlayerState.StandingLeft
                    || Player.State == PlayerState.WalkingLeft
                    || Player.State == PlayerState.FallingLeft)
                {
                    Player.State = PlayerState.CrouchingLeft;
                }
            }
        }
    }
}
