﻿using GameCore;
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

            if (Player.groundChecker.Colliding<BlockVerticalMovement>()
                && Player.VerticalSpeed >= 0)
            {
                if (Player.Inputs.Right && !Player.Inputs.Left)
                {
                    Player.LegState = LegState.Walking;
                    Player.FacingRight = true;
                    if (Player.TorsoState == TorsoState.Attack
                        || Player.TorsoState == TorsoState.AttackCrouching)
                        return;
                    Player.TorsoState = TorsoState.Standing;
                }
                else if (!Player.Inputs.Right && Player.Inputs.Left)
                {
                    Player.LegState = LegState.Walking;
                    Player.FacingRight = false;
                    if (Player.TorsoState == TorsoState.Attack
                        || Player.TorsoState == TorsoState.AttackCrouching)
                        return;
                    Player.TorsoState = TorsoState.Standing;
                }
            }
        }
    }
}
