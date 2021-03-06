﻿using GameCore;
using System;

namespace MonoGameProject
{
    public class ChangeToWallJumping : UpdateHandler
    {
        private readonly Humanoid Parent;

        public ChangeToWallJumping(Humanoid Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (Parent.Inputs.ClickedJump
                && Parent.LegState == LegState.SlidingWall)
            {
                Parent.LegState = LegState.WallJumping;
            }
        }
    }
}
