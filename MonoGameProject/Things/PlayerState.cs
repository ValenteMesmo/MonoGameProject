using System;
using GameCore;

namespace MonoGameProject
{
    public enum TorsoState
    {
        Standing,
        Attack,
        SlidingWall,
        Crouch,
        AttackCrouching
    }

    public enum HeadState
    {
        Standing,
        Bump,
        TakingDamage
    }

    public enum LegState
    {
        Standing,
        Walking,
        SlidingWall,
        WallJumping,
        Falling,
        HeadBump,
        Crouching,
        TakingDamage
    }
}
