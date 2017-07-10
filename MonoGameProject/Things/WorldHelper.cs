using GameCore;

namespace MonoGameProject
{
    public class MoveHorizontallyWithTheWorld : UpdateHandler
    {
        private readonly Thing Parent;

        public MoveHorizontallyWithTheWorld(Thing Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            Parent.X -= WorldMover.WorldHorizontalSpeed;
        }
    }

    public class MoveVerticallyWithTheWorld : UpdateHandler
    {
        private readonly Thing Parent;

        public MoveVerticallyWithTheWorld(Thing Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            Parent.Y -= WorldMover.WorldVerticalSpeed;
        }
    }
}
