using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MonoGameProject
{
    public class GameStateData
    {
        public long ArmorColor;
        public long Monster;
        public long Tresure;
        public long Paralax;
        public long Platform;
        public int ColorIndex;
        public bool CaveMode;
        public bool TopExit;
        public bool MidExit;
        public bool BotExit;
        public bool BossMode;
        public long StageNumber;
        public bool ShowStageNumber;

        public GameStateData()
        {
            TopExit = true;
            MidExit = true;
            BotExit = true;

            ArmorColor = 1;
            Tresure = 666;
            Monster = 999;
            Paralax = 1;
            Platform = 1;
            ColorIndex = 0;
            CaveMode = false;
            TopExit = true;
            MidExit = true;
            BotExit = true;
            BossMode = false;
            StageNumber = 1;
            ShowStageNumber = true;
        }
    }

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

        private static Color[] Colors2 = new Color[] {
              new Color(1.0f,0.6f,0.6f)//RED
            , new Color(1.0f,0.6f,0.8f)
            , new Color(1.0f,0.6f,1.0f)//MAGENTA
            , new Color(0.8f,0.6f,1.0f)
            , new Color(0.6f,0.6f,1.0f)//BLUE
            , new Color(0.6f,0.8f,1.0f)
            , new Color(0.6f,1.0f,1.0f)//CYAN
            , new Color(0.6f,1.0f,0.8f)
            , new Color(0.6f,1.0f,0.6f)//GREEN
            , new Color(0.8f,1.0f,0.6f)
            , new Color(1.0f,1.0f,0.6f)//YELLOW
            , new Color(1.0f,0.8f,0.6f)
        };

        private static Color[] Colors3 = new Color[] {
              new Color(1.0f,0.6f,1.0f)//MAGENTA
            , new Color(0.8f,0.6f,1.0f)
            , new Color(0.6f,0.6f,1.0f)//BLUE
            , new Color(0.6f,0.8f,1.0f)
            , new Color(0.6f,1.0f,1.0f)//CYAN
            , new Color(0.6f,1.0f,0.8f)
            , new Color(0.6f,1.0f,0.6f)//GREEN
            , new Color(0.8f,1.0f,0.6f)
            , new Color(1.0f,1.0f,0.6f)//YELLOW
            , new Color(1.0f,0.8f,0.6f)
            , new Color(1.0f,0.6f,0.6f)//RED
            , new Color(1.0f,0.6f,0.8f)
        };

        private static Color[] Colors4 = new Color[] {
              new Color(0.6f,1.0f,1.0f)//CYAN
            , new Color(0.6f,1.0f,0.8f)
            , new Color(0.6f,1.0f,0.6f)//GREEN
            , new Color(0.8f,1.0f,0.6f)
            , new Color(1.0f,1.0f,0.6f)//YELLOW
            , new Color(1.0f,0.8f,0.6f)
            , new Color(1.0f,0.6f,0.6f)//RED
            , new Color(1.0f,0.6f,0.8f)
            , new Color(1.0f,0.6f,1.0f)//MAGENTA
            , new Color(0.8f,0.6f,1.0f)
            , new Color(0.6f,0.6f,1.0f)//BLUE
            , new Color(0.6f,0.8f,1.0f)
        };

        public static void ChangeColor()
        {
            State.ColorIndex++;
            if (State.ColorIndex >= Colors.Length)
                State.ColorIndex = 0;
        }

        public static Color GetColor()
        {
            return Colors[State.ColorIndex];
        }

        public static Color GetComplimentColor()
        {
            return Colors2[State.ColorIndex];
        }

        public static Color GetComplimentColor2()
        {
            return Colors3[State.ColorIndex];
        }

        public static Color GetPreviousColor2()
        {
            return Colors4[State.ColorIndex];
        }

        private static GameStateData _state;
        public static GameStateData State
        {
            get { return _state; }
            set
            {
                _state = value;

                ArmorColor.Seed = _state.ArmorColor;
                RandomTresure.Seed = _state.Tresure;
                RandomMonster.Seed = _state.Monster;
                ParalaxRandomModule.Seed = _state.Paralax;
                PlatformRandomModule.Seed = _state.Platform;
            }
        }

        private static GameStateData PreSavedData = new GameStateData();

        public static MyRandom ArmorColor = new MyRandom();
        public static MyRandom RandomTresure = new MyRandom();
        public static MyRandom RandomMonster = new MyRandom();
        public static MyRandom ParalaxRandomModule = new MyRandom();
        public static MyRandom PlatformRandomModule = new MyRandom();

        public static void Load()
        {
            State = new GameStateData();

            if (File.Exists("main.save") == false)
            {
                File.WriteAllText("main.save", JsonConvert.SerializeObject(State));
            }
            var savedContent = File.ReadAllText("main.save");
            var loadedState = JsonConvert.DeserializeObject<GameStateData>(savedContent);
            State = loadedState;
        }

        public static void Save()
        {
            PreSavedData.BossMode = false;
            File.WriteAllText("main.save", JsonConvert.SerializeObject(PreSavedData));
        }

        public static void PreSave()
        {
            PreSavedData.BossMode = false;
            PreSavedData.TopExit = State.TopExit;
            PreSavedData.MidExit = State.MidExit;
            PreSavedData.BotExit = State.BotExit;
            PreSavedData.CaveMode = State.CaveMode;
            PreSavedData.ColorIndex = State.ColorIndex;
            PreSavedData.StageNumber = State.StageNumber;
            PreSavedData.ShowStageNumber = true;

            PreSavedData.ArmorColor = ArmorColor.Seed;
            PreSavedData.Tresure = RandomTresure.Seed;
            PreSavedData.Monster = RandomMonster.Seed;
            PreSavedData.Paralax = ParalaxRandomModule.Seed;
            PreSavedData.Platform = PlatformRandomModule.Seed;
        }
    }
}
