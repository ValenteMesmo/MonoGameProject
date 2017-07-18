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
            if (Thing.X <= -MapModule.WIDTH * 2
                || Thing.X >= MapModule.WIDTH * 4
                )
                Thing.Destroy();
        }
    }
}
