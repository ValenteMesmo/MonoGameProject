using GameCore;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new GeneratedContent()) { }

        protected override void OnStart()
        {
            var player = new Player(this);
            var WorldMover = new WorldMover(Camera);
            AddThing(WorldMover);
            AddThing(player);
            AddThing(new PlatformCreator(WorldMover, AddThing, this));

            var runningOnGoodPc = false;
            //if (runningOnGoodPc)
            {
                //AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, z, width/2, height/2), 5));
                //AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, z, width/2, height/2), 10));
                //AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, z, width/2, height/2), 15));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, z, width/2, height/2), 20));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, z, width/2, height/2), 50));
                //AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, z, width/2, height/2), 99));
            }
        }
    }
}
