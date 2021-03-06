﻿using GameCore;

namespace MonoGameProject
{
    public static class BossAnimationsFactory
    {
        private static MyRandom Random = new MyRandom();

        public static int GetHeadBonusX(bool flipped)
        {
            if (flipped)
                return 150;
            else
                return -450;
        }

        public static Animation HeadAnimation(int random, int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            X += GetHeadBonusX(Flipped);
            if (random == 1)
                return GeneratedContent.Create_knight_bills_head(X, Y, Width, Height, Flipped);
            else if (random == 2)
                return GeneratedContent.Create_knight_wolf_head(X, Y, Width, Height, Flipped);
            else
                return GeneratedContent.Create_knight_skull_head(X, Y, Width, Height, Flipped);
        }

        public static Animation HeadAttackAnimation(int random, int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            X += GetHeadBonusX(Flipped);
            if (random == 1)
                return GeneratedContent.Create_knight_bills_head_attack(X, Y, Width, Height, Flipped);
            else if (random == 2)
                return GeneratedContent.Create_knight_wolf_head_attack(X, Y, Width, Height, Flipped);
            else
                return GeneratedContent.Create_knight_skull_head_attack(X, Y, Width, Height, Flipped);

        }

        public static Animation HeadShootAnimation(int random, int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            X += GetHeadBonusX(Flipped);
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

        public static Animation EyeAnimation(int random, int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            X += GetHeadBonusX(Flipped);
            Animation result;
            if (random == 1)
                result = GeneratedContent.Create_knight_spider_eye(X, Y, Width, Height, Flipped);
            else if (random == 2)
                result = GeneratedContent.Create_knight_wolf_eye(X, Y, Width, Height, Flipped);
            else
                result = GeneratedContent.Create_knight_one_eye(X, Y, Width, Height, Flipped);

            result.ColorGetter = GameState.GetColor;
            return result;
        }

        public static Animation EyeAttackAnimation(int random, int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
        {
            X += GetHeadBonusX(Flipped);

            Animation result;
            if (random == 1)
                result = GeneratedContent.Create_knight_spider_eye_attack(X, Y, Width, Height, Flipped);
            else if (random == 2)
                result = GeneratedContent.Create_knight_wolf_eye_attack(X, Y, Width, Height, Flipped);
            else
                result = GeneratedContent.Create_knight_one_eye_attack(X, Y, Width, Height, Flipped);
            result.ColorGetter = GameState.GetColor;

            return result;
        }
    }
}