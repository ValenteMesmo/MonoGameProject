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
            AddThing(new PlatformCreator(WorldMover, AddThing));
        }
    }
}
