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
            if ((Player.LegState == LegState.Crouching
                || Player.LegState == LegState.SweetDreams)
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
        private LegState PreviousState;

        public ChangeToHeadBumpState(Humanoid Player, Camera2d Camera)
        {
            this.Player = Player;
            this.Camera = Camera;
        }

        public void Update()
        {
            if (Player.roofChecker.Colliding<BlockVerticalMovement>()
                && Math.Abs(Player.roofChecker.GetGolliders<BlockVerticalMovement>().First().Bottom() - Player.roofChecker.Top()) == 90
                && Player.VerticalSpeed < 0)
            {
                if (Player.LegState == LegState.TakingDamage)
                    return;

                if (PreviousState != LegState.HeadBump)
                {
                    if (Player.VerticalSpeed > -50)
                        return;

                    if (Player is Player)
                        Camera.ShakeUp(-Player.VerticalSpeed / 8);
                }

                Player.LegState = LegState.HeadBump;
                Player.HeadState = HeadState.Bump;
            }

            PreviousState = Player.LegState;
        }
    }
}
