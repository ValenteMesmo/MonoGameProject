﻿using GameCore;

namespace MonoGameProject
{
    public class PreventPlayerFromAccicentlyFalling : UpdateHandler
    {
        private readonly Player Player;
        private const int VELOCITY = 8;

        public PreventPlayerFromAccicentlyFalling(Player Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.StandingLeft
                || Player.State == PlayerState.StandingRight
                || Player.State == PlayerState.crouchingLeft
                || Player.State == PlayerState.crouchingRight)
            {
                if (Player.HorizontalSpeed > 0 
                    && Player.Inputs.RightDown == false                    
                    && Player.RightGroundAcidentChecker.Colliding == false)
                {
                    Player.HorizontalSpeed -= VELOCITY;
                    if (Player.HorizontalSpeed < 0)
                        Player.HorizontalSpeed = 0;
                }
                if (Player.HorizontalSpeed < 0 
                    && Player.Inputs.LeftDown == false
                    && Player.LeftGroundAcidentChecker.Colliding == false)
                {
                    Player.HorizontalSpeed += VELOCITY;
                    if (Player.HorizontalSpeed > 0)
                        Player.HorizontalSpeed = 0;
                }
            }
        }
    }
}
