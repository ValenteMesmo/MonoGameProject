using GameCore;
using System.Collections.Generic;

namespace MonoGameProject
{
    class ContentLoader : ILoadContents
    {
        public IEnumerable<string> GetSoundNames()
        {
            return new string[] { };
        }

        public IEnumerable<string> GetTextureNames()
        {
            return new string[] { "a", "b", "c" };
        }
    }

    public class MoveLeftAndRight : UpdateHandler
    {
        private int speed = 5;

        public override void Update()
        {
            if (Parent.X > 6000)
                speed = -5;
            if (Parent.X < 2000)
                speed = 5;

            Parent.X += speed;
        }
    }

    public class Game1 : Game
    {
        public Game1() : base(new ContentLoader()) { }

        public override void OnStart()
        {
            var player = new Thing();
            player.X = player.Y = 4000;
            player.AddCollider(new Collider()
            {
                Width = 4000,
                Height = 4000
            });
            player.AddUpdate(new MoveLeftAndRight());

            var a = new Animation(
                new AnimationFrame("a", 0, 0, 2000, 2000)
            );

            var b = new Animation(
                 new AnimationFrame("b", 0, 0, 2000, 2000)
            );

            var c = new Animation(
                 new AnimationFrame("c", 0, 0, 2000, 2000)
            );

            player.AddAnimation(
                new Animator(
                    new AnimationTransitionOnCondition(new Animation[] { a, c }, b, () => InputRepository.ClickedLeft)
                    , new AnimationTransitionOnCondition(new Animation[] { b, a }, c, () => InputRepository.ClickedRight)
                    , new AnimationTransitionOnCondition(new Animation[] { c, b }, a, () => InputRepository.ClickedDown)
                )
            );

            AddThing(player);
        }
    }
}
