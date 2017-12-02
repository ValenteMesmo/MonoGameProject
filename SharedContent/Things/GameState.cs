using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Threading;

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

        public int Player1_ArmorRed = 255;
        public int Player1_ArmorGreen = 255;
        public int Player1_ArmorBlue = 255;
        public int Player2_ArmorRed = 255;
        public int Player2_ArmorGreen = 255;
        public int Player2_ArmorBlue = 255;
        public int Player3_ArmorRed = 255;
        public int Player3_ArmorGreen = 255;
        public int Player3_ArmorBlue = 255;
        public int Player4_ArmorRed = 255;
        public int Player4_ArmorGreen = 255;
        public int Player4_ArmorBlue = 255;

        public WeaponType Player1_WeaponType = WeaponType.Whip;
        public WeaponType Player2_WeaponType = WeaponType.Whip;
        public WeaponType Player3_WeaponType = WeaponType.Whip;
        public WeaponType Player4_WeaponType = WeaponType.Whip;

        public GameStateData()
        {
            TopExit = true;
            MidExit = true;
            BotExit = true;

            ArmorColor = 666666666;
            Tresure = 666999666;
            Monster = 999666999;
            Paralax = 999999999;
            Platform = 666999999;
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
        public static bool PreSaved;

        public static void Load()
        {
            PreSaved = false;
            State = new GameStateData();

            var saveFile =
                Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)
                    , "main.save");

            if (File.Exists(saveFile) == false)
            {
                File.WriteAllText(saveFile, JsonConvert.SerializeObject(State));
            }
            var savedContent = File.ReadAllText(saveFile);
            var loadedState = JsonConvert.DeserializeObject<GameStateData>(savedContent);
            State = loadedState;
        }

        public static void Save()
        {
            PreSaved = false;
            new Thread(() =>
            {
                 var saveFile =
                  Path.Combine(
                      Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                      , "main.save");
                 PreSavedData.BossMode = false;
                 File.WriteAllText(saveFile, JsonConvert.SerializeObject(PreSavedData));
            }).Start();
        }

        public static void PreSave()
        {
            PreSaved = true;

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

            PreSavedData.Player1_ArmorRed = State.Player1_ArmorRed;
            PreSavedData.Player1_ArmorGreen = State.Player1_ArmorGreen;
            PreSavedData.Player1_ArmorBlue = State.Player1_ArmorBlue;
            PreSavedData.Player1_WeaponType = State.Player1_WeaponType;

            PreSavedData.Player2_ArmorRed = State.Player2_ArmorRed;
            PreSavedData.Player2_ArmorGreen = State.Player2_ArmorGreen;
            PreSavedData.Player2_ArmorBlue = State.Player2_ArmorBlue;
            PreSavedData.Player2_WeaponType = State.Player2_WeaponType;

            PreSavedData.Player3_ArmorRed = State.Player3_ArmorRed;
            PreSavedData.Player3_ArmorGreen = State.Player3_ArmorGreen;
            PreSavedData.Player3_ArmorBlue = State.Player3_ArmorBlue;
            PreSavedData.Player3_WeaponType = State.Player3_WeaponType;

            PreSavedData.Player4_ArmorRed = State.Player4_ArmorRed;
            PreSavedData.Player4_ArmorGreen = State.Player4_ArmorGreen;
            PreSavedData.Player4_ArmorBlue = State.Player4_ArmorBlue;
            PreSavedData.Player4_WeaponType = State.Player4_WeaponType;
        }

        internal static void SetWeaponType(WeaponType type, int playerIndex)
        {
            if (playerIndex == 0)
                PreSavedData.Player1_WeaponType = State.Player1_WeaponType = type;
            else if (playerIndex == 1)
                PreSavedData.Player2_WeaponType = State.Player2_WeaponType = type;
            else if (playerIndex == 2)
                PreSavedData.Player3_WeaponType = State.Player3_WeaponType = type;
            else if (playerIndex == 3)
                PreSavedData.Player4_WeaponType = State.Player4_WeaponType = type;
        }

        internal static void SetPlayer1ArmorColor(Color armorColor, int playerIndex)
        {
            if (playerIndex == 0)
            {
                PreSavedData.Player1_ArmorRed = State.Player1_ArmorRed = armorColor.R;
                PreSavedData.Player1_ArmorGreen = State.Player1_ArmorGreen = armorColor.G;
                PreSavedData.Player1_ArmorBlue = State.Player1_ArmorBlue = armorColor.B;
            }
            else if (playerIndex == 1)
            {
                PreSavedData.Player2_ArmorRed = State.Player2_ArmorRed = armorColor.R;
                PreSavedData.Player2_ArmorGreen = State.Player2_ArmorGreen = armorColor.G;
                PreSavedData.Player2_ArmorBlue = State.Player2_ArmorBlue = armorColor.B;
            }
            else if (playerIndex == 2)
            {
                PreSavedData.Player3_ArmorRed = State.Player3_ArmorRed = armorColor.R;
                PreSavedData.Player3_ArmorGreen = State.Player3_ArmorGreen = armorColor.G;
                PreSavedData.Player3_ArmorBlue = State.Player3_ArmorBlue = armorColor.B;
            }
            else if (playerIndex == 3)
            {
                PreSavedData.Player4_ArmorRed = State.Player4_ArmorRed = armorColor.R;
                PreSavedData.Player4_ArmorGreen = State.Player4_ArmorGreen = armorColor.G;
                PreSavedData.Player4_ArmorBlue = State.Player4_ArmorBlue = armorColor.B;
            }
        }
    }
}
