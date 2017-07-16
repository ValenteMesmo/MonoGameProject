using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameProject.Updates.PlayerStates
{
    class ChangeToCrouchState : UpdateHandler
    {
        public readonly Player Player;

        public ChangeToCrouchState(Player Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.Inputs.DownDown && Player.groundChecker.Colliding)
            {
                if (Player.Inputs.LeftDown)
                {
                    if (Player.State == PlayerState.StandingRight
                        || Player.State == PlayerState.WalkingRight
                        || Player.State == PlayerState.StandingLeft
                        || Player.State == PlayerState.WalkingLeft
                        || Player.State == PlayerState.FallingLeft
                        )
                    {
                        Player.State = PlayerState.crouchWalkingLeft;
                    }

                }
                else if (Player.Inputs.RightDown)
                {
                    if (Player.State == PlayerState.StandingRight
                    || Player.State == PlayerState.WalkingRight
                    || Player.State == PlayerState.StandingLeft
                    || Player.State == PlayerState.WalkingLeft)
                    {
                        Player.State = PlayerState.crouchWalkingRight;
                    }
                }
                else
                {
                    if (Player.State == PlayerState.StandingRight
                        || Player.State == PlayerState.WalkingRight
                        || Player.State == PlayerState.FallingRight)
                    {
                        Player.State = PlayerState.crouchingRight;
                    }
                    else if (Player.State == PlayerState.StandingLeft
                        || Player.State == PlayerState.WalkingLeft
                        || Player.State == PlayerState.FallingLeft)
                    {
                        Player.State = PlayerState.crouchingLeft;
                    }
                }
            }
        }
    }
}
