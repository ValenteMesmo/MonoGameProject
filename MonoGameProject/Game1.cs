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
            AddThing(new Player(InputRepository2, WorldMover));
            AddThing(new PlatformCreator(WorldMover, AddThing));
        }
    }

    public class PLayerCreator : Thing
    {
        public PLayerCreator(
            PlayerInputs input1
            , PlayerInputs input2
            , WorldMover worldMover)
        {
            AddUpdate(() =>
            {
                if (input1.Action1Down)
                {

                }
            });
        }
    }
}
