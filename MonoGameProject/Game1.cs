using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new GeneratedContent()) { }

        protected override void OnStart()
        {
            GameState.Load();
            var player = new Player(this, AddThing);
            player.X = 1000;
            if (GameState.BotExit)
                player.Y = (14 * MapModule.CELL_SIZE) + 1000;
            else if (GameState.MidExit)
                player.Y = (8 * MapModule.CELL_SIZE) + 1000;
            else
                player.Y = 2 * MapModule.CELL_SIZE + 1000;

            var WorldMover = new WorldMover(Camera);
            AddThing(WorldMover);
            AddThing(player);
            AddThing(new PlatformCreator(WorldMover, AddThing, this));
            //var background = new Thing();

            //for (int i = 0; i < MapModule.CELL_SIZE; i++)
            //{
            //    for (int j = 0; j < MapModule.CELL_SIZE; j++)
            //    {

            //        background.AddAnimation(
            //        GeneratedContent.Create_knight_block(
            //            j * MapModule.CELL_SIZE
            //            , 1500 + i * MapModule.CELL_SIZE
            //            , 1
            //            , (int)(MapModule.CELL_SIZE)
            //            , (int)(MapModule.CELL_SIZE)));

            //    }
            //}
            //AddThing(background);
            var runningOnGoodPc = false;
            //if (runningOnGoodPc)
            {
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 3, 0.91f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 2, 0.90f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, 500, 400), 1, 0.0f));
            }
        }
    }
}
