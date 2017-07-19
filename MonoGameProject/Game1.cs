using GameCore;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new ContentLoader()) { }

        protected override void OnStart()
        {
            var player = new Player(InputRepository, this);
            var WorldMover = new WorldMover(Camera);
            AddThing(WorldMover);
            AddThing(player);
            AddThing(new PlatformCreator(WorldMover, AddThing, this));
            AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, "bg5", 5));
            AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, "bg4", 10));
            AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, "bg3", 15));
            AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, "bg2", 20));
            AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, "bg6", 50));
            AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, "bg1", 99));
            //AddThing(new LeftFireBallTrap(AddThing, 50) { Y = 8000, X = 500 });
            //AddThing(new LeftFireBallTrap(AddThing, 100) { Y = 7500, X = 500 });
        }
    }
}
