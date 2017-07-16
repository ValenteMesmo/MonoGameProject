using System;
using GameCore;

namespace MonoGameProject
{
    public class ResetSizeAndOffsetY : UpdateHandler
    {
        private readonly Player Player;
        private readonly int OriginalHeight;

        public ResetSizeAndOffsetY(Player Player)
        {
            this.Player = Player;
            OriginalHeight = Player.HeadCollider.Height;
        }

        public void Update()
        {
            Player.HeadCollider.Height = OriginalHeight;
            Player.HeadCollider.OffsetY = 0;
        }
    }

    public class ReduceSizeWhenCrouching : UpdateHandler
    {
        private readonly Player Player;
        private readonly int OriginalHeight;

        public ReduceSizeWhenCrouching(Player Player)
        {
            this.Player = Player;
            OriginalHeight = Player.HeadCollider.Height;
        }

        public void Update()
        {
            if (Player.State == PlayerState.crouchingLeft
                || Player.State == PlayerState.crouchingRight)
            {
                Player.HeadCollider.Height = OriginalHeight / 2;
                Player.HeadCollider.OffsetY = OriginalHeight / 2;
            }
        }
    }

    public class ReduceSizeWhenHeadBumping : UpdateHandler
    {
        private readonly Player Player;
        private readonly int OriginalHeight;

        public ReduceSizeWhenHeadBumping(Player Player)
        {
            this.Player = Player;
            OriginalHeight = Player.HeadCollider.Height;
        }

        public void Update()
        {
            if (Player.State == PlayerState.HeadBumpLeft
                || Player.State == PlayerState.HeadBumpRight)
            {
                Player.HeadCollider.Height = OriginalHeight / 2;
            }
        }
    }
}
