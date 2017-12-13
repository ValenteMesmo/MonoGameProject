using Microsoft.Xna.Framework;
using MonoGameProject;

namespace SharedContent.Things
{
    public class ColorPattern
    {
        public Color Main { get; set; }
        public Color Sub { get; set; }
        public Color Background { get; set; }

        public Color Sky { get; set; }

        public Color CaveMain { get; set; }
        public Color CaveSub { get; set; }
        public Color CaveBackground { get; set; }
    }

    public static class ColorsOfTheStage
    {
        private static ColorPattern SnowStage = new ColorPattern
        {
            Main = new Color(188, 204, 205),
            Sub = new Color(233, 252, 255),
            Background = new Color(188 - 60, 204 - 60, 205 - 60),

            Sky = new Color(94, 129, 162),

            CaveMain = new Color(170, 233, 239),
            CaveSub = new Color(201, 237, 240),
            CaveBackground = new Color(170 - 60, 233 - 60, 239 - 60)
        };

        private static ColorPattern GrassStage = new ColorPattern
        {
            Main = new Color(201, 152, 105),
            Sub = new Color(128, 190, 31),
            Background = new Color(201 - 60, 152 - 60, 105 - 60),

            Sky = new Color(161, 231, 238),

            CaveMain = new Color(191, 206, 208),
            CaveSub = new Color(177, 192, 193),
            CaveBackground = new Color(191 - 60, 206 - 60, 208 - 60)
        };

        private static ColorPattern YellowGrass = new ColorPattern
        {
            Main = new Color(63, 159, 110),
            Sub = new Color(254, 217, 68),
            Background = new Color(63 - 60, 159 - 60, 110 - 60),

            Sky = new Color(84, 67, 123),

            CaveMain = new Color(254, 217, 68),
            CaveSub = new Color(254, 217, 68),
            CaveBackground = new Color(254 - 60, 217 - 60, 68 - 60)
        };

        private static ColorPattern BlueGrass = new ColorPattern
        {
            Sub = new Color(33, 133, 213),
            Main = new Color(47, 56, 64),
            Background = new Color(47 - 60, 56 - 60, 64 - 60),

            Sky = new Color(255, 238, 188),

            CaveSub = new Color(33, 133, 213),
            CaveMain = new Color(33, 133, 213),
            CaveBackground = new Color(33 - 60, 133 - 60, 213 - 60)
        };

        private static ColorPattern DarkBlueGrass = new ColorPattern
        {
            Sub = new Color(43, 84, 96),
            Main = new Color(88, 162, 49),
            Background = new Color(88 - 60, 162 - 60, 49 - 60),

            Sky = new Color(141, 110, 82),

            CaveSub = new Color(58, 111, 128),
            CaveMain = new Color(58, 111, 128),
            CaveBackground = new Color(58 - 60, 111 - 60, 128 - 60)
        };

        private static ColorPattern GetColorPattern()
        {
            var index = GameState.State.StageNumber;

            if (index % 10 == 0)
                return DarkBlueGrass;
            if (index % 9 == 0)
                return SnowStage;
            if (index % 8 == 0)
                return BlueGrass;
            if (index % 7 == 0)
                return YellowGrass;
            if (index % 6 == 0)
                return GrassStage;
            if (index % 5 == 0)
                return DarkBlueGrass;
            if (index % 4 == 0)
                return SnowStage;
            if (index % 3 == 0)
                return BlueGrass;
            if (index % 2 == 0)
                return YellowGrass;

            return GrassStage;
        }

        public static Color Sky()
        {
            return GetColorPattern().Sky;
        }

        public static Color Background()
        {
            if (GameState.State.CaveMode)
                return GetColorPattern().CaveBackground;
            else
                return GetColorPattern().Background;
        }

        public static Color Main()
        {
           
            if (GameState.State.CaveMode)
                return GetColorPattern().CaveMain;
            else
                return GetColorPattern().Main;

        }

        public static Color Sub()
        {            
            if (GameState.State.CaveMode)
                return GetColorPattern().CaveSub;
            else
                return GetColorPattern().Sub;
        }
    }
}
