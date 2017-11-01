using GameCore;

namespace MonoGameProject
{
    public class MoveHorizontallyWithTheWorld : AfterUpdateHandler
    {
        private readonly Thing Parent;
        private readonly int scale;
        private readonly bool ignoreHorizontal;

        public MoveHorizontallyWithTheWorld(Thing Parent, int scale = 1,bool ignoreHorizontal = false)
        {
            this.Parent = Parent;
            this.scale = scale;
            this.ignoreHorizontal = ignoreHorizontal;
        }

        public void Update()
        {
            if (!ignoreHorizontal) 
            Parent.X -= WorldMover.WorldHorizontalSpeed / scale;
            Parent.Y -= WorldMover.WorldVerticalSpeed / scale;
        }
    }
}
