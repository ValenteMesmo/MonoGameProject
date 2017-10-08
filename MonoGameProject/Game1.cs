using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new GeneratedContent()) { }

        public ScreenFader ScreenFader;

        protected override void OnStart()
        {
            GameState.Load();

            ScreenFader = new ScreenFader();
            AddToWorld(ScreenFader);



            var player = new Player(this, 0, AddThing);
            player.X = 1000;
            AddThing(player);

            if (GameState.State.BotExit)
                player.Y = (14 * MapModule.CELL_SIZE) + 1000;
            else if (GameState.State.MidExit)
                player.Y = (8 * MapModule.CELL_SIZE) + 1000;
            else
                player.Y = 2 * MapModule.CELL_SIZE + 1000;

            //for (var i = 1; i < 7; i++)
            //{
            //    var player2 = new Player(this, 0, AddThing);
            //    player2.X = player.X + 200 * i;
            //    player2.Y = player.Y;
            //    AddThing(player2);
            //}




            var WorldMover = new WorldMover(Camera);
            AddThing(WorldMover);
            AddThing(new PlatformCreator(WorldMover, AddThing, this));

            var roof = new Thing();
            roof.AddCollider(new SolidCollider
            {
                OffsetY = -MapModule.CELL_SIZE,
                Height = 4 * MapModule.CELL_SIZE,
                Width = 16 * 2 * MapModule.CELL_SIZE
            });
            AddThing(roof);

            {
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 3, 0.91f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 2, 0.90f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, 500, 400), 1, 0.01f));
            }
        }
    }

    public class ScreenFader : Thing
    {
        private int Red;
        private int Green;
        private int Blue;
        private int Alpha;
        private const int Speed = 80;

        public ScreenFader()
        {
            var faderAnimation = new Animation(new AnimationFrame("pixel", 0, 0, 14000, 10000));
            faderAnimation.ColorGetter = () => new Color(Red, Green, Blue, Alpha);
            faderAnimation.RenderingLayer = 0.001f;
            AddAnimation(faderAnimation);

            AddUpdate(() =>
            {
                Red = UpdateValue(Red, 0);
                Green = UpdateValue(Green, 0);
                Blue = UpdateValue(Blue, 0);
                Alpha = UpdateValue(Alpha, 30);
            });
        }

        private int UpdateValue(int value, int limit)
        {
            if (value > limit)
            {
                value -= Speed;
                if (value < limit)
                    value = limit;
            }
            else if (value < limit)
            {
                value += Speed;
                if (value > limit)
                    value = limit;
            }

            return value;
        }

        public void Flash(int red, int green, int blue)
        {
            Alpha = 255;

            Red = red;
            Green = green;
            Blue = blue;
        }

        public void Flash()
        {
            Alpha = 200;

            Red =
            Green =
            Blue = 200;
        }
    }
}
