using GameCore;
using System;
using System.Linq;

namespace MonoGameProject
{
    public class ChangeToHeadBumpState : UpdateHandler
    {
        private readonly ThingWithState Player;
        private readonly Camera2d Camera;
        private PlayerState PreviousState;

        public ChangeToHeadBumpState(ThingWithState Player, Camera2d Camera)
        {
            this.Player = Player;
            this.Camera = Camera;
        }

        public void Update()
        {
            if (Player.State == PlayerState.TakingDamage)
                return;
            //if (Player.roofChecker.Colliding)
            //Game.LOG += Math.Abs(Player.roofChecker.GetGolliders().First().Bottom() - Player.roofChecker.Top());
            if (Player.roofChecker.Colliding
                && Math.Abs(Player.roofChecker.GetGolliders().First().Bottom() - Player.roofChecker.Top()) == 90
                && Player.VerticalSpeed < 0)
            {
                if (Player.State == PlayerState.WalkingLeft
                   || Player.State == PlayerState.StandingLeft
                   || Player.State == PlayerState.SlidingWallLeft
                   || Player.State == PlayerState.FallingLeft
                )
                {
                    if (PreviousState != PlayerState.HeadBumpLeft
                    && PreviousState != PlayerState.HeadBumpRight)
                    {
                        if (Player is Player)
                            Camera.ShakeUp(-Player.VerticalSpeed / 8);
                    }

                    Player.State = PlayerState.HeadBumpLeft;
                }
                else if (Player.State == PlayerState.WalkingRight
                    || Player.State == PlayerState.StandingRight
                    || Player.State == PlayerState.SlidingWallRight
                    || Player.State == PlayerState.FallingRight                    
                )
                {
                    if (PreviousState != PlayerState.HeadBumpLeft
                    && PreviousState != PlayerState.HeadBumpRight)
                    {
                        if (Player is Player)
                            Camera.ShakeUp(-Player.VerticalSpeed / 8);
                    }

                    Player.State = PlayerState.HeadBumpRight;
                }
            }
            PreviousState = Player.State;
        }
    }
}
