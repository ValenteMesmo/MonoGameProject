using System;
using GameCore;

namespace MonoGameProject
{
    public class ResetSizeAndOffsetY : UpdateHandler
    {
        private readonly Humanoid Player;
        private readonly int OriginalHeight;

        public ResetSizeAndOffsetY(Humanoid Player)
        {
            this.Player = Player;
            OriginalHeight = Player.MainCollider.Height;
        }

        public void Update()
        {
            Player.MainCollider.Height = OriginalHeight;
            Player.MainCollider.OffsetY = 0;
        }
    }

    public class ReduceSizeWhenCrouching : UpdateHandler
    {
        private readonly Humanoid Player;
        private readonly int OriginalHeight;

        public ReduceSizeWhenCrouching(Humanoid Player)
        {
            this.Player = Player;
            OriginalHeight = Player.MainCollider.Height;
        }

        public void Update()
        {
            if (Player.LegState == LegState.Crouching 
                || Player.LegState == LegState.SweetDreams)
            {
                Player.MainCollider.Height = OriginalHeight / 2;
                Player.MainCollider.OffsetY = OriginalHeight / 2;

                Player.AttackLeftCollider.OffsetY = OriginalHeight - OriginalHeight / 2;
                Player.AttackRightCollider.OffsetY = OriginalHeight - OriginalHeight / 2;
            }
            else
            {
                Player.AttackLeftCollider.OffsetY = 0;
                Player.AttackRightCollider.OffsetY = 0;
            }
        }
    }

    public class ReduceSizeWhenHeadBumping : UpdateHandler
    {
        private readonly Humanoid Player;
        private readonly int OriginalHeight;

        public ReduceSizeWhenHeadBumping(Humanoid Player)
        {
            this.Player = Player;
            OriginalHeight = Player.MainCollider.Height;
        }

        public void Update()
        {
            if (Player.LegState == LegState.HeadBump)
            {
                Player.MainCollider.Height = OriginalHeight / 2;
            }
        }
    }
}
