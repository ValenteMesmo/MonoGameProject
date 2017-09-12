using GameCore;

namespace MonoGameProject
{
    public static class BossAnimationsFactory
    {
        private static MyRandom Random = new MyRandom();

        public static Animation HeadAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            Random.Seed = GameState.PlatformRandomModule.Seed;
            if (Random.Next(0, 100) > 50)
                return GeneratedContent.Create_knight_bills_head(X, Y, Width, Height, Flipped);
            else
                return GeneratedContent.Create_knight_wolf_head(X, Y, Width, Height, Flipped);
        }

        public static Animation HeadAttackAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            Random.Seed = GameState.PlatformRandomModule.Seed;
            if (Random.Next(0, 100) > 50)
                return GeneratedContent.Create_knight_bills_head_attack(X, Y, Width, Height, Flipped);
            else
                return GeneratedContent.Create_knight_wolf_head_attack(X, Y, Width, Height, Flipped);

        }

        public static Animation HeadShootAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            Random.Seed = GameState.PlatformRandomModule.Seed;
            if (Random.Next(0, 100) > 50)
            {
                var animation = GeneratedContent.Create_knight_wolf_head_shoot(X, Y, Width, Height, Flipped);
                animation.LoopDisabled = true;
                return animation;
            }
            else
            {
                var animation = GeneratedContent.Create_knight_wolf_head_shoot(X, Y, Width, Height, Flipped);
                animation.LoopDisabled = true;
                return animation;
            }

        }

        public static Animation EyeAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            Random.Seed = GameState.PlatformRandomModule.Seed;
            Random.Next();

            Animation result;
            var index = Random.Next(0, 2);
            if (index == 0)
                result = GeneratedContent.Create_knight_spider_eye(X, Y, Width, Height, Flipped);
            else if (index == 1)
                result = GeneratedContent.Create_knight_wolf_eye(X, Y, Width, Height, Flipped);
            else
                result = GeneratedContent.Create_knight_one_eye(X, Y, Width, Height, Flipped);

            result.ColorGetter = GameState.GetColor;
            return result;
        }

        public static Animation EyeAttackAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            Random.Seed = GameState.PlatformRandomModule.Seed;
            Random.Next();

            Animation result;
            var index = Random.Next(0, 2);
            if (index == 0)
                result = GeneratedContent.Create_knight_spider_eye_attack(X, Y, Width, Height, Flipped);
            else if (index == 1)
                result = GeneratedContent.Create_knight_wolf_eye_attack(X, Y, Width, Height, Flipped);
            else
                result = GeneratedContent.Create_knight_one_eye_attack(X, Y, Width, Height, Flipped);
            result.ColorGetter = GameState.GetColor;

            return result;
        }
    }
}