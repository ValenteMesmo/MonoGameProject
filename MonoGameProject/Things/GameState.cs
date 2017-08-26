using Microsoft.Xna.Framework;
using Newtonsoft.Json;
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
            var tempIndex = State.ColorIndex - 2;
            var newIndex = tempIndex + ((Colors.Length - 1) / 2);
            if (newIndex > Colors.Length - 1)
                newIndex = newIndex - Colors.Length;
            return Colors[newIndex];
        }

        public static Color GetComplimentColor2()
        {
            var tempIndex = State.ColorIndex + 2;
            var newIndex = tempIndex + ((Colors.Length - 1) / 2);
            if (newIndex > Colors.Length - 1)
                newIndex = newIndex - Colors.Length;
            return Colors[newIndex];
        }

        public static Color GetPreviousColor()
        {
            if (State.ColorIndex > 0)
                return Colors[State.ColorIndex - 1];
            else
                return Colors[Colors.Length - 1];
        }

        public static Color GetPreviousColor2()
        {
            if (State.ColorIndex > 1)
                return Colors[State.ColorIndex - 2];
            else
                return Colors[Colors.Length - 2];
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

            if (File.Exists("save.json") == false)
            {
                File.WriteAllText("save.json", JsonConvert.SerializeObject(State));
            }
            var savedContent = File.ReadAllText("save.json");
            var loadedState = JsonConvert.DeserializeObject<GameStateData>(savedContent);
            State = loadedState;
        }

        public static void Save()
        {
            PreSavedData.BossMode = false;
            File.WriteAllText("save.json", JsonConvert.SerializeObject(PreSavedData));
        }

        public static void PreSave()
        {
            PreSavedData.BossMode = false;
            PreSavedData.TopExit= State.TopExit;
            PreSavedData.MidExit= State.MidExit;
            PreSavedData.BotExit= State.BotExit;
            PreSavedData.CaveMode= State.CaveMode;
            PreSavedData.ColorIndex= State.ColorIndex;

            PreSavedData.ArmorColor = ArmorColor.Seed;
            PreSavedData.Tresure = RandomTresure.Seed;
            PreSavedData.Monster = RandomMonster.Seed;
            PreSavedData.Paralax = ParalaxRandomModule.Seed;
            PreSavedData.Platform = PlatformRandomModule.Seed;
        }
    }
}
