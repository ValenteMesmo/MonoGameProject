namespace MonoGameProject
{
    public enum TorsoState
    {
        StandingLeft,
        StandingRight,
        AttackLeft,
        AttackRight,
        SlidingWallLeft,
        SlidingWallRight,
        CrouchLeft,
        CrouchRight,
        AttackCrouchingLeft,
        AttackCrouchingRight,
    }

    public enum HeadState
    {
        StandingLeft,
        StandingRight,
        BumpLeft,
        BumpRight,
        TakingDamage
    }

    public enum LegState
    {
        StandingLeft,
        StandingRight,
        WalkingLeft,
        WalkingRight,
        SlidingWallLeft,
        SlidingWallRight,
        WallJumpingToTheLeft,
        WallJumpingToTheRight,
        FallingLeft,
        FallingRight,
        HeadBumpLeft,
        HeadBumpRight,
        CrouchingLeft,
        CrouchingRight,
        TakingDamage
    }
}
