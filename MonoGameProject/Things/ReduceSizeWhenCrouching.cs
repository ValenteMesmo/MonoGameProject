﻿using System;
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
            if (Player.State == PlayerState.CrouchingLeft
                || Player.State == PlayerState.CrouchingRight)
            {
                Player.MainCollider.Height = OriginalHeight / 2;
                Player.MainCollider.OffsetY = OriginalHeight / 2;
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
            if (Player.State == PlayerState.HeadBumpLeft
                || Player.State == PlayerState.HeadBumpRight)
            {
                Player.MainCollider.Height = OriginalHeight / 2;
            }
        }
    }
}