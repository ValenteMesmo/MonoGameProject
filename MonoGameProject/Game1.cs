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
            AddThing(new Enemy(new AIInput(), this));
            AddThing(new PlatformCreator(WorldMover, AddThing));

            //AddThing(new LeftFireBallTrap(AddThing, 50) { Y = 8000, X = 500 });
            //AddThing(new LeftFireBallTrap(AddThing, 100) { Y = 7500, X = 500 });
        }
    }
}
