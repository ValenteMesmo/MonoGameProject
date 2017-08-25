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
        public bool CheckpointTopOpen;
        public bool CheckpointMidOpen;
        public bool CheckpointBotOpen;
        public bool BossMode;

        public GameStateData()
        {
            CheckpointTopOpen = true;
            CheckpointMidOpen = true;
            CheckpointBotOpen = true;

            ArmorColor = 1;
            Tresure = 666;
            Monster = 999;
            Paralax = 1;
            Platform = 1;
            ColorIndex = 0;
            CaveMode = false;
            CheckpointTopOpen = true;
            CheckpointMidOpen = true;
            CheckpointBotOpen = true;
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

        public static GameStateData State = new GameStateData();

        public static MyRandom ArmorColor = new MyRandom(State.ArmorColor);
        public static MyRandom RandomTresure = new MyRandom(State.Tresure);
        public static MyRandom RandomMonster = new MyRandom(State.Monster);
        public static MyRandom ParalaxRandomModule = new MyRandom(State.Paralax);
        public static MyRandom PlatformRandomModule = new MyRandom(State.Platform);

        public static void Load()
        {
            State = new GameStateData();
            ArmorColor.Seed = State.ArmorColor;
            RandomTresure.Seed = State.Tresure;
            RandomMonster.Seed = State.Monster;
            ParalaxRandomModule.Seed = State.Paralax;
            PlatformRandomModule.Seed = State.Platform;

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

        static GameStateData PreSavedData;
        public static void PreSave()
        {            
            PreSavedData = State;
        }
    }
}
