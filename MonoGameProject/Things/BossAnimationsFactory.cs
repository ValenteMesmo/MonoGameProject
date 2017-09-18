using GameCore;

namespace MonoGameProject
{
    public static class BossAnimationsFactory
    {
        private static MyRandom Random = new MyRandom();

        private static int GetHeadBonusX(bool flipped)
        {
            var bonus = 250;

            if (flipped)
                return bonus;
            else
                return -bonus;
        }

        public static Animation HeadAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            X += GetHeadBonusX(Flipped);
            Random.Seed = GameState.PlatformRandomModule.Seed;
            var random = Random.Next(1, 3);
            if (random == 1)
                return GeneratedContent.Create_knight_bills_head(X, Y, Width, Height, Flipped);
            else if (random == 2)
                return GeneratedContent.Create_knight_wolf_head(X, Y, Width, Height, Flipped);
            else
                return GeneratedContent.Create_knight_skull_head(X, Y, Width, Height, Flipped);
        }

        public static Animation HeadAttackAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            X += GetHeadBonusX(Flipped);
            Random.Seed = GameState.PlatformRandomModule.Seed;
            var random = Random.Next(1, 3);
            if (random == 1)
                return GeneratedContent.Create_knight_bills_head_attack(X, Y, Width, Height, Flipped);
            else if (random == 2)
                return GeneratedContent.Create_knight_wolf_head_attack(X, Y, Width, Height, Flipped);
            else
                return GeneratedContent.Create_knight_skull_head_attack(X, Y, Width, Height, Flipped);

        }

        public static Animation HeadShootAnimation(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            X += GetHeadBonusX(Flipped);
            Random.Seed = GameState.PlatformRandomModule.Seed;
            var random = Random.Next(1, 3);
            if (random == 1)
            {
                var animation = GeneratedContent.Create_knight_bills_head_shoot(X, Y, Width, Height, Flipped);
                animation.LoopDisabled = true;
                return animation;
            }
            else if (random == 2)
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
            X += GetHeadBonusX(Flipped);
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
            X += GetHeadBonusX(Flipped);
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