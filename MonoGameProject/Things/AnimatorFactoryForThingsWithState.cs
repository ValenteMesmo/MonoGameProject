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
            var size2 = 2800;
            var size1 = 590;
            var y2 = -1880;
            var x2 = -1550;
            var flippedx = -200;

            BodyAnimator(thing, size2, size1, y2, x2, flippedx);
            HeadAnimator(thing, size2, size1, y2, x2, flippedx);
            LegsAnimator(thing, size2, size1, y2, x2, flippedx);
        }

        private static void LegsAnimator(Humanoid thing, int size2, int size1, int y2, int x2, int flippedx)
        {
            var stand_left = new Animation(
                  new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1 * 2, size1, size1, size1)) { RenderingLayer = 0 }
            );
            var stand_right = new Animation(
                  new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1 * 2, size1, size1, size1)) { RenderingLayer = 0, Flipped = true }
            );

            var walk_left = new Animation(
                    new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, size1 * 2, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1, size1 * 2, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1 * 2, size1 * 2, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, size1 * 3, size1, size1)) { RenderingLayer = 0 }
            );
            var walk_right = new Animation(
                    new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, size1 * 2, size1, size1)) { RenderingLayer = 0, Flipped = true }
                    , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1, size1 * 2, size1, size1)) { RenderingLayer = 0, Flipped = true }
                    , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1 * 2, size1 * 2, size1, size1)) { RenderingLayer = 0, Flipped = true }
                    , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, size1 * 3, size1, size1)) { RenderingLayer = 0, Flipped = true }
            );

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(walk_left, () => thing.State == PlayerState.WalkingLeft)
                , new AnimationTransitionOnCondition(walk_right, () => thing.State == PlayerState.WalkingRight)
                , new AnimationTransitionOnCondition(stand_left, () => thing.State == PlayerState.StandingLeft)
                , new AnimationTransitionOnCondition(stand_right, () => thing.State == PlayerState.StandingRight)
            ));
        }

        private static void HeadAnimator(Humanoid thing, int size2, int size1, int y2, int x2, int flippedx)
        {
            var head_left2 = new Animation(
                            new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1, size1, size1, size1)) { RenderingLayer = 0 }
                        );
            var head_right2 = new Animation(
                new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1, size1, size1, size1)) { RenderingLayer = 0, Flipped = true }
            );
            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(head_right2, () => thing.State == PlayerState.WalkingRight)
                , new AnimationTransitionOnCondition(head_left2, () => thing.State == PlayerState.WalkingLeft)
            ));
        }

        private static void BodyAnimator(Humanoid thing, int size2, int size1, int y2, int x2, int flippedx)
        {
            var punch_left = new Animation(
                    new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, 0, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1, 0, size1, size1)) { RenderingLayer = 0 }
                    , new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(size1 * 2, 0, size1, size1)) { RenderingLayer = 0 }
                )
            { LoopDisabled = true };
            var punch_right = new Animation(
                  new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, 0, size1, size1)) { RenderingLayer = 0, Flipped = true }
                  , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1, 0, size1, size1)) { RenderingLayer = 0, Flipped = true }
                  , new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(size1 * 2, 0, size1, size1)) { RenderingLayer = 0, Flipped = true }
              )
            { LoopDisabled = true };


            var body_standing_right = new Animation(
                new AnimationFrame("knight", flippedx, y2, size2, size2, new Rectangle(0, size1, size1, size1)) { RenderingLayer = 0, Flipped = true }
            );
            var body_standing_left = new Animation(
                new AnimationFrame("knight", x2, y2, size2, size2, new Rectangle(0, size1, size1, size1)) { RenderingLayer = 0 }
            );

            thing.AddAnimation(new Animator(
                new AnimationTransitionOnCondition(body_standing_right, () => thing.BodyState == HumanoidBodyState.StandRight)
                , new AnimationTransitionOnCondition(body_standing_left, () => thing.BodyState == HumanoidBodyState.StandLeft)
                , new AnimationTransitionOnCondition(punch_left, () => thing.BodyState == HumanoidBodyState.AttackLeft)
                , new AnimationTransitionOnCondition(punch_right, () => thing.BodyState == HumanoidBodyState.AttackRight)
            ));
        }
    }
}
