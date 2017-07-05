using GameCore;

namespace MonoGameProject
{
    public class MakeCameraFollowPlayer : UpdateHandler
    {
        private Camera2d camera;

        public MakeCameraFollowPlayer(Camera2d camera)
        {
            this.camera = camera;
        }

        public void Update(Thing Parent)
        {
            camera.Pos = new Microsoft.Xna.Framework.Vector2(Parent.X, Parent.Y);
        }
    }
}
