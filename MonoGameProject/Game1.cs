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
            if (runningOnGoodPc)
            {
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_bg5(x, y, z, width, height), 5));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_bg4(x, y, z, width, height), 10));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_bg3(x, y, z, width, height), 15));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_bg2(x, y, z, width, height), 20));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_bg6(x, y, z, width, height), 50));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, z, width, height) => GeneratedContent.Create_knight_bg1(x, y, z, width, height), 99));
            }
        }
    }
}
