using GameCore;
using System;
using System.Linq;

namespace MonoGameProject
{
    public class ChangeToHeadBumpState : UpdateHandler
    {
        private readonly Player Player;
        private readonly PlayerInputs Input;

        public ChangeToHeadBumpState(Player Player, PlayerInputs Input)
        {
            this.Player = Player;
            this.Input = Input;
        }

        public void Update()
        {
            if (Player.roofChecker.Colliding
                && Math.Abs(Player.roofChecker.GetGolliders().First().Bottom() - Player.roofChecker.Top()) == 99
                && Player.VerticalSpeed < 0)
            {
                if (Player.State.Is(
                   PlayerState.WalkingLeft
                   , PlayerState.StandingLeft
                   , PlayerState.SlidingWallLeft
                   , PlayerState.FallingLeft
                   )
                )
                {
                    Player.State = PlayerState.HeadBumpLeft;
                }
                else if (Player.State.Is(
                    PlayerState.WalkingRight
                    , PlayerState.StandingRight
                    , PlayerState.SlidingWallRight
                    , PlayerState.FallingRight
                    )
                )
                {
                    Player.State = PlayerState.HeadBumpRight;
                }
            }
        }
    }
}
