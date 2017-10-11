using GameCore;

namespace MonoGameProject
{
    public class MoveHorizontallyWithTheWorld : AfterUpdateHandler
    {
        private readonly Thing Parent;
        private readonly int scale;

        public MoveHorizontallyWithTheWorld(Thing Parent, int scale = 1)
        {
            this.Parent = Parent;
            this.scale = scale;
        }

        public void Update()
        {
            Parent.X -= WorldMover.WorldHorizontalSpeed / scale;
            Parent.Y -= WorldMover.WorldVerticalSpeed / scale;
        }
    }
}
