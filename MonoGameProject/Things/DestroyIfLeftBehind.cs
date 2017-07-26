using GameCore;

namespace MonoGameProject
{
    public class DestroyIfLeftBehind : UpdateHandler
    {
        private readonly Thing Thing;

        public DestroyIfLeftBehind(Thing Thing)
        {
            this.Thing = Thing;
        }

        public void Update()
        {
            if (Thing.X < -MapModule.WIDTH
                || Thing.X > MapModule.WIDTH * 3
                || Thing.Y <= -MapModule.HEIGHT * 2
                || Thing.Y >= MapModule.HEIGHT * 2
                )
                Thing.Destroy();
        }
    }
}
