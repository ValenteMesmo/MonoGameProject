using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public static class GameState
    {
        private static Color[] Colors = new Color[] {
              new Color(0.6f,1.0f,0.6f)//GREEN
            , new Color(0.8f,1.0f,0.6f)
            , new Color(1.0f,1.0f,0.6f)//YELLOW
            , new Color(1.0f,0.8f,0.6f)
            , new Color(1.0f,0.6f,0.6f)//RED
            , new Color(1.0f,0.6f,0.8f)
            , new Color(1.0f,0.6f,1.0f)//MAGENTA
            , new Color(0.8f,0.6f,1.0f)
            , new Color(0.6f,0.6f,1.0f)//BLUE
            , new Color(0.6f,0.8f,1.0f)
            , new Color(0.6f,1.0f,1.0f)//CYAN
            , new Color(0.6f,1.0f,0.8f)
        };
        private static int ColorIndex = 0;
        public static void ChangeColor()
        {
            ColorIndex++;
            if (ColorIndex >= Colors.Length)
                ColorIndex = 0;
        }

        public static Color GetColor()
        {
            return Colors[ColorIndex];
        }

        public static Color GetComplimentColor()
        {
            var tempIndex = ColorIndex - 2;
            var newIndex = tempIndex + ((Colors.Length - 1) / 2);
            if (newIndex > Colors.Length - 1)
                newIndex = newIndex - Colors.Length;
            return Colors[newIndex];
        }

        public static Color GetComplimentColor2()
        {
            var tempIndex = ColorIndex + 2;
            var newIndex = tempIndex + ((Colors.Length - 1) / 2);
            if (newIndex > Colors.Length - 1)
                newIndex = newIndex - Colors.Length;
            return Colors[newIndex];
        }

        public static Color GetPreviousColor()
        {
            if (ColorIndex > 0)
                return Colors[ColorIndex - 1];
            else
                return Colors[Colors.Length - 1];
        }
        public static Color GetPreviousColor2()
        {
            if (ColorIndex > 1)
                return Colors[ColorIndex - 2];
            else
                return Colors[Colors.Length - 2];
        }

        public static bool BossMode = false;
        public static MyRandom ArmorColor = new MyRandom();
        public static MyRandom RandomTresure = new MyRandom();
        public static MyRandom RandomMonster = new MyRandom();
        public static MyRandom ParalaxRandomModule = new MyRandom();
        public static MyRandom PlatformRandomModule = new MyRandom();
        public static bool CaveMode;

        public static bool TopExit = true;
        public static bool MidExit = true;
        public static bool BotExit = true;

        private static long SavedArmorColor = 1;
        private static long SavedTresure = 666;
        private static long SavedMonster = 999;
        private static long SavedParalax = 1;
        private static long SavedPlatform = 1;
        private static int SavedColorIndex = 0;
        public static bool SavedCaveMode = false;
        private static bool SavedCheckpointTopOpen = true;
        private static bool SavedCheckpointMidOpen = true;
        private static bool SavedCheckpointBotOpen = true;
        private static bool SavedBossMode = false;


        private static long PreSavedArmorColor;
        private static bool PreSavedCheckpointBotOpen;
        private static long PreSavedMonster;
        private static long PreSavedParalax;
        private static long PreSavedPlatform;
        private static long PreSavedTresure;
        private static int PreSavedColorIndex;
        private static bool PreSavedCaveMode;
        private static bool PreSavedCheckpointTopOpen;
        private static bool PreSavedCheckpointMidOpen;
        private static bool PreSavedBossMode ;

        public static void Load()
        {
            ArmorColor.Seed = SavedArmorColor;
            RandomTresure.Seed = SavedTresure;
            RandomMonster.Seed =SavedMonster;
            ParalaxRandomModule.Seed = SavedParalax;
            PlatformRandomModule.Seed = SavedPlatform;
            ColorIndex = SavedColorIndex;
            CaveMode = SavedCaveMode;
            TopExit = SavedCheckpointTopOpen;
            MidExit = SavedCheckpointMidOpen;
            BotExit = SavedCheckpointBotOpen;
            BossMode = SavedBossMode;
        }

        public static void Save()
        {
            SavedArmorColor = PreSavedArmorColor;
            SavedTresure = PreSavedTresure;
            SavedMonster = PreSavedMonster;
            SavedParalax = PreSavedParalax;
            SavedPlatform = PreSavedPlatform;
            SavedColorIndex = PreSavedColorIndex;
            SavedCaveMode = PreSavedCaveMode;
            SavedCheckpointTopOpen = PreSavedCheckpointTopOpen;
            SavedCheckpointMidOpen = PreSavedCheckpointMidOpen;
            SavedCheckpointBotOpen = PreSavedCheckpointBotOpen;
            SavedBossMode = PreSavedBossMode;
        }

        public static void PreSave()
        {
            PreSavedArmorColor = ArmorColor.Seed;
            PreSavedTresure = RandomTresure.Seed;
            PreSavedMonster = RandomMonster.Seed;
            PreSavedParalax = ParalaxRandomModule.Seed;
            PreSavedPlatform = PlatformRandomModule.Seed;
            PreSavedColorIndex = ColorIndex;
            PreSavedCaveMode = CaveMode;
            PreSavedCheckpointTopOpen = TopExit;
            PreSavedCheckpointMidOpen = MidExit;
            PreSavedCheckpointBotOpen = BotExit;
            PreSavedBossMode = false;
        }
    }
}
