using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class HumanoidAnimatorFactory
    {
        public void CreateAnimator(
            int width
            , int height
            , Humanoid thing)
        {
            LegsAnimator(thing);
            TorsoAnimator(thing);
            HeadAnimator(thing);
        }

        private static void LegsAnimator(Humanoid thing)
        {
            int scale = 5;
            int feet_y = 400;
            int knee_y = 600;
            int x = 150;
            int flippedx = 150;

            var stand_left = GeneratedContent.Create_knight_Legs_Standing(
                x
                , feet_y
                , 0);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;

            var stand_right = GeneratedContent.Create_knight_Legs_Standing(
                flippedx
                , feet_y
                , 0
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;

            var fall_left = GeneratedContent.Create_knight_Legs_Falling(
                x
                , feet_y
                , 0);
            fall_left.ScaleX = scale;
            fall_left.ScaleY = scale;

            var fall_right = GeneratedContent.Create_knight_Legs_Falling(
                flippedx
                , feet_y
                , 0
                , null
                , null
                , true);
            fall_right.ScaleX = scale;
            fall_right.ScaleY = scale;

            var crouch_left = GeneratedContent.Create_knight_Legs_Crouching(
                x
                , knee_y
                , 0);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;

            var crouch_right = GeneratedContent.Create_knight_Legs_Crouching(
                flippedx
                , knee_y
                , 0
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;

            var walk_left = GeneratedContent.Create_knight_Legs_Walking(
                x
                , feet_y
                , 0);
            walk_left.ScaleX = scale;
            walk_left.ScaleY = scale;

            var walk_right = GeneratedContent.Create_knight_Legs_Walking(
                flippedx
                , feet_y
                , 0
                , null
                , null
                , true);
            walk_right.ScaleX = scale;
            walk_right.ScaleY = scale;

            var headbang_left = GeneratedContent.Create_knight_roof_bang_legs(
                x
                , feet_y
                , 0);
            headbang_left.ScaleX = scale;
            headbang_left.ScaleY = scale;

            var headbang_right = GeneratedContent.Create_knight_roof_bang_legs(
                flippedx
                , feet_y
                , 0
                , null
                , null
                , true);
            headbang_right.ScaleX = scale;
            headbang_right.ScaleY = scale;

            //var attack_left = GeneratedContent.Create_knight_Attack(
            //    x
            //    , y
            //    , 0
            //    , size
            //    , size);
            //attack_left.LoopDisabled = true;
            //var attack_right = GeneratedContent.Create_knight_Attack(
            //    flippedx
            //    , y
            //    , 0
            //    , size
            //    , size
            //    , true);
            //attack_right.LoopDisabled = true;

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(walk_left, () => thing.LegState == LegState.WalkingLeft)
                , new AnimationTransitionOnCondition(walk_right, () => thing.LegState == LegState.WalkingRight)
                , new AnimationTransitionOnCondition(stand_left, () => thing.LegState == LegState.StandingLeft)
                , new AnimationTransitionOnCondition(stand_right, () => thing.LegState == LegState.StandingRight)
                , new AnimationTransitionOnCondition(crouch_left, () => thing.LegState == LegState.CrouchingLeft)
                , new AnimationTransitionOnCondition(crouch_right, () => thing.LegState == LegState.CrouchingRight)
                , new AnimationTransitionOnCondition(fall_left, () => thing.LegState == LegState.FallingLeft)
                , new AnimationTransitionOnCondition(fall_right, () => thing.LegState == LegState.FallingRight)
                , new AnimationTransitionOnCondition(fall_left, () => thing.LegState == LegState.WallJumpingToTheRight)
                , new AnimationTransitionOnCondition(fall_right, () => thing.LegState == LegState.WallJumpingToTheLeft)
                , new AnimationTransitionOnCondition(headbang_left, () => thing.LegState == LegState.HeadBumpLeft)
                , new AnimationTransitionOnCondition(headbang_right, () => thing.LegState == LegState.HeadBumpRight)
                //, new AnimationTransitionOnCondition(attack_left, () => thing.State == PlayerState.AttackLeft)
                //, new AnimationTransitionOnCondition(attack_right, () => thing.State == PlayerState.AttackRight)
                , new AnimationTransitionOnCondition(fall_left, () => thing.LegState == LegState.TakingDamage)
            ));
        }

        private static void HeadAnimator(Humanoid thing)
        {
            int scale = 5;
            int feet_y = -250;
            int knee_y = -30;
            int roof_y = -80;
            int x = 50;
            int flippedx = 400;

            var stand_left = GeneratedContent.Create_knight_head(
                x
                , feet_y
                , 0);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;

            var stand_right = GeneratedContent.Create_knight_head(
                flippedx
                , feet_y
                , 0
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;

            var crouch_left = GeneratedContent.Create_knight_head(
                x
                , knee_y
                , 0);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;

            var crouch_right = GeneratedContent.Create_knight_head(
                flippedx
                , knee_y
                , 0
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;

            var headbang_left = GeneratedContent.Create_knight_roof_bang_head(
                x
                , roof_y
                , 0);
            headbang_left.ScaleX = scale;
            headbang_left.ScaleY = scale;

            var headbang_right = GeneratedContent.Create_knight_roof_bang_head(
                flippedx
                , roof_y
                , 0
                , null
                , null
                , true);
            headbang_right.ScaleX = scale;
            headbang_right.ScaleY = scale;

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(stand_left, () => thing.LegState == LegState.WalkingLeft)
                , new AnimationTransitionOnCondition(stand_right, () => thing.LegState == LegState.WalkingRight)
                , new AnimationTransitionOnCondition(stand_left, () => thing.LegState == LegState.StandingLeft)
                , new AnimationTransitionOnCondition(stand_right, () => thing.LegState == LegState.StandingRight)
                , new AnimationTransitionOnCondition(crouch_left, () => thing.LegState == LegState.CrouchingLeft)
                , new AnimationTransitionOnCondition(crouch_right, () => thing.LegState == LegState.CrouchingRight)
                , new AnimationTransitionOnCondition(stand_left, () => thing.LegState == LegState.FallingLeft)
                , new AnimationTransitionOnCondition(stand_right, () => thing.LegState == LegState.FallingRight)
                , new AnimationTransitionOnCondition(stand_left, () => thing.LegState == LegState.WallJumpingToTheRight)
                , new AnimationTransitionOnCondition(stand_right, () => thing.LegState == LegState.WallJumpingToTheLeft)
                , new AnimationTransitionOnCondition(headbang_left, () => thing.LegState == LegState.HeadBumpLeft)
                , new AnimationTransitionOnCondition(headbang_right, () => thing.LegState == LegState.HeadBumpRight)
                , new AnimationTransitionOnCondition(stand_left, () => thing.LegState == LegState.SlidingWallLeft)
                , new AnimationTransitionOnCondition(stand_right, () => thing.LegState == LegState.SlidingWallRight)
                , new AnimationTransitionOnCondition(stand_left, () => thing.LegState == LegState.TakingDamage)
            ));
        }

        private static void TorsoAnimator(Humanoid thing)
        {
            int scale = 5;
            int feet_y = -150;
            int knee_y = 100;
            int x = 60;
            int flippedx = 50;
            var x_attack_flipped = 0;
            var x_attack = -1050;

            var stand_left = GeneratedContent.Create_knight_torso_stand(
                x
                , feet_y
                , 0);
            stand_left.ScaleX = scale;
            stand_left.ScaleY = scale;

            var stand_right = GeneratedContent.Create_knight_torso_stand(
                flippedx
                , feet_y
                , 0
                , null
                , null
                , true);
            stand_right.ScaleX = scale;
            stand_right.ScaleY = scale;

            var crouch_left = GeneratedContent.Create_knight_torso_stand(
                x
                , knee_y
                , 0);
            crouch_left.ScaleX = scale;
            crouch_left.ScaleY = scale;

            var crouch_right = GeneratedContent.Create_knight_torso_stand(
                flippedx
                , knee_y
                , 0
                , null
                , null
                , true);
            crouch_right.ScaleX = scale;
            crouch_right.ScaleY = scale;

            var stand_attack_left = GeneratedContent.Create_knight_torso_attack(
                x_attack
                , feet_y
                , 0);
            stand_attack_left.ScaleX = scale;
            stand_attack_left.ScaleY = scale;
            stand_attack_left.LoopDisabled = true;

            var stand_attack_right = GeneratedContent.Create_knight_torso_attack(
                x_attack_flipped
                , feet_y
                , 0
                , null
                , null
                , true);
            stand_attack_right.ScaleX = scale;
            stand_attack_right.ScaleY = scale;
            stand_attack_right.LoopDisabled = true;

            var crouch_attack_left = GeneratedContent.Create_knight_torso_attack(
                x_attack
                , knee_y
                , 0);
            crouch_attack_left.ScaleX = scale;
            crouch_attack_left.ScaleY = scale;
            crouch_attack_left.LoopDisabled = true;

            var crouch_attack_right = GeneratedContent.Create_knight_torso_attack(
                x_attack_flipped
                , knee_y
                , 0
                , null
                , null
                , true);
            crouch_attack_right.ScaleX = scale;
            crouch_attack_right.ScaleY = scale;
            crouch_attack_right.LoopDisabled = true;


            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(stand_left,
                    () =>
                    thing.TorsoState == TorsoState.StandingLeft
                )
                , new AnimationTransitionOnCondition(stand_right,
                    () =>
                    thing.TorsoState == TorsoState.StandingRight
                )
                , new AnimationTransitionOnCondition(crouch_left,
                    () =>
                    thing.TorsoState == TorsoState.CrouchLeft
                )
                , new AnimationTransitionOnCondition(crouch_right,
                    () =>
                    thing.TorsoState == TorsoState.CrouchRight
                )
                , new AnimationTransitionOnCondition(stand_attack_left,
                    () =>
                    thing.TorsoState == TorsoState.AttackLeft
                    )
                , new AnimationTransitionOnCondition(stand_attack_right,
                    () =>
                    thing.TorsoState == TorsoState.AttackRight
                    )
                , new AnimationTransitionOnCondition(crouch_attack_left,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouchingLeft
                    )
                , new AnimationTransitionOnCondition(crouch_attack_right,
                    () =>
                    thing.TorsoState == TorsoState.AttackCrouchingRight
                )
            ));
        }

    }
}
