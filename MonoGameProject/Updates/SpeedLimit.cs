using GameCore;

namespace MonoGameProject
{
    public class HorizontalSpeedLimit : UpdateHandler
    {
        private readonly int SPEEDLIMIT = 80;
        private readonly Thing Parent;

        public HorizontalSpeedLimit(Thing Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            if (Parent.HorizontalSpeed > SPEEDLIMIT)
                Parent.HorizontalSpeed = SPEEDLIMIT;
            if (Parent.HorizontalSpeed < -SPEEDLIMIT)
                Parent.HorizontalSpeed = -SPEEDLIMIT;
        }
    }
}
