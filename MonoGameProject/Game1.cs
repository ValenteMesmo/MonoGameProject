using GameCore;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new ContentLoader()) { }

        public override void OnStart()
        {
            CreateGround();
            AddThing(new Player(InputRepository, Camera));
        }

        private void CreateGround()
        {
            var ground = new Ground()
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
        }
    }
}
