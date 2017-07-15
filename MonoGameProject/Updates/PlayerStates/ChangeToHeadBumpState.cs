using GameCore;
using System;
using System.Linq;

namespace MonoGameProject
{
    public class ChangeToHeadBumpState : UpdateHandler
    {
        private readonly Player Player;
        private readonly PlayerInputs Input;
        private readonly Camera2d Camera;
        private PlayerState PreviousState;

        public ChangeToHeadBumpState(Player Player, PlayerInputs Input, Camera2d Camera)
        {
            this.Player = Player;
            this.Input = Input;
            this.Camera = Camera;
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
                    if (PreviousState != PlayerState.HeadBumpLeft
                    && PreviousState != PlayerState.HeadBumpRight)
                        Camera.ShakeUp(-Player.VerticalSpeed / 8);
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
                    if (PreviousState != PlayerState.HeadBumpLeft
                    && PreviousState != PlayerState.HeadBumpRight)
                        Camera.ShakeUp(-Player.VerticalSpeed/8);
                    Player.State = PlayerState.HeadBumpRight;
                }
            }
            PreviousState = Player.State;
        }
    }
}
