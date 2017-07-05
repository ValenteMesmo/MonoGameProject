using GameCore;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new ContentLoader()) { }

        public override void OnStart()
        {
            var WorldMover = new WorldMover(Camera);
            CreateGround(WorldMover);
            AddThing(new Player(InputRepository, WorldMover));
        }

        private void CreateGround(WorldMover WorldMover)
        {
            var ground = new Ground(WorldMover)
            {
                X = 1000,
                Y = 9000
            };

            ground.AddCollider(new Collider()
            {
                Width = 12000,
                Height = 2000
            });

            AddThing(ground);
            AddThing(WorldMover);
        }
    }
}
