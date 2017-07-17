using GameCore;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new ContentLoader()) { }

        public override void OnStart()
        {
            var WorldMover = new WorldMover(Camera);
            AddThing(WorldMover);
            AddThing(new Player(InputRepository, WorldMover));
            //AddThing(new Player(InputRepository2, WorldMover));
            AddThing(new PlatformCreator(WorldMover, AddThing));

            AddThing(new FireBallTrap(AddThing) { Y = 8000, X = 500 });
            AddThing(new FireBallTrap(AddThing) { Y = 7500, X = 500 });
        }
    }
}
