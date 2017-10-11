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




            var WorldMover = new WorldMover(Camera, player);
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
        private const int Speed = 100;
        private int duration;

        public ScreenFader()
        {
            var faderAnimation = GeneratedContent.Create_knight_Flash(-20000, -20000, 40000, 40000);
            faderAnimation.ColorGetter = () => new Color(Red, Green, Blue, Alpha);
            faderAnimation.RenderingLayer = 0f;
            AddAnimation(faderAnimation);

            AddUpdate(() =>
            {
                duration++;
                if (duration > 20)
                    duration = 20;

                Red = UpdateValue(Red, 0);
                Green = UpdateValue(Green, 0);
                Blue = UpdateValue(Blue, 0);
                Alpha = UpdateValue(Alpha, 0);
            });
        }

        private int UpdateValue(int value, int limit)
        {
            if (value > limit)
            {
                value -= (duration * 100) / Speed;
                if (value < limit)
                    value = limit;
            }
            else if (value < limit)
            {
                value += (duration * 100) / Speed;
                if (value > limit)
                    value = limit;
            }

            return value;
        }

        public void Flash(int red, int green, int blue, int x, int y)
        {
            duration = 0;
            X = x;
            Y = y;
            Alpha = 200;

            Red = red;
            Green = green;
            Blue = blue;
        }

        public void Flash(int x, int y)
        {
            Flash(200, 200, 200, x, y);
        }
    }
}
