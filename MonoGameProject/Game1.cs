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
            if (GameState.State.BotExit)
                player.Y = (14 * MapModule.CELL_SIZE) + 1000;
            else if (GameState.State.MidExit)
                player.Y = (8 * MapModule.CELL_SIZE) + 1000;
            else
                player.Y = 2 * MapModule.CELL_SIZE + 1000;

            var WorldMover = new WorldMover(Camera);
            AddThing(WorldMover);
            AddThing(player);
            AddThing(new PlatformCreator(WorldMover, AddThing, this));

            var roof = new Thing();
            roof.AddCollider(new SolidCollider { OffsetY = - MapModule.CELL_SIZE, Height = 4*MapModule.CELL_SIZE, Width = 16*2 * MapModule.CELL_SIZE });
            AddThing(roof);
            var runningOnGoodPc = false;
            {
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 3, 0.91f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 2, 0.90f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, 500, 400), 1, 0.0f));
            }
        }
    }
}
