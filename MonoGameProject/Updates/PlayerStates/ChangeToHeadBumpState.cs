using GameCore;
using MonoGameProject.Things;
using System;
using System.Linq;

namespace MonoGameProject
{
    public class ForceOriginalHeightAndOffsetWhenCrouchJumping : UpdateHandler
    {
        private readonly int OriginalHeight;
        private readonly int OriginalOffsetY;
        private readonly Humanoid Player;

        public ForceOriginalHeightAndOffsetWhenCrouchJumping(Humanoid Player)
        {
            this.Player = Player;
            this.OriginalHeight = Player.MainCollider.Height;
            this.OriginalOffsetY = Player.MainCollider.OffsetY;
        }

        public void Update()
        {
            if ((Player.State == PlayerState.CrouchingLeft
                  || Player.State == PlayerState.CrouchingRight)
                  && Player.VerticalSpeed < 0)
            {
                Player.MainCollider.Height = OriginalHeight;
                Player.MainCollider.OffsetY = OriginalOffsetY;
            }
        }
    }

    public class ChangeToHeadBumpState : UpdateHandler
    {
        private readonly Humanoid Player;
        private readonly Camera2d Camera;
        private PlayerState PreviousState;

        public ChangeToHeadBumpState(Humanoid Player, Camera2d Camera)
        {
            this.Player = Player;
            this.Camera = Camera;
        }

        public void Update()
        {
            if (Player.State == PlayerState.TakingDamage)
                return;

            if (Player.roofChecker.Colliding<BlockVerticalMovement>()
                && Math.Abs(Player.roofChecker.GetGolliders<BlockVerticalMovement>().First().Bottom() - Player.roofChecker.Top()) == 90
                && Player.VerticalSpeed < 0)
            {
                if (Player.State == PlayerState.WalkingLeft
                   || Player.State == PlayerState.StandingLeft
                   || Player.State == PlayerState.SlidingWallLeft
                   || Player.State == PlayerState.FallingLeft
                   || Player.State == PlayerState.CrouchingLeft
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
                    || Player.State == PlayerState.CrouchingRight
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
