using GameCore;

namespace MonoGameProject
{
    public class SpeedLimit : UpdateHandler
    {
        private readonly int SPEEDLIMIT = 70;

        public void Update(Thing Parent)
        {
            if (Parent.HorizontalSpeed > SPEEDLIMIT)
                Parent.HorizontalSpeed = SPEEDLIMIT;
            if (Parent.HorizontalSpeed < -SPEEDLIMIT)
                Parent.HorizontalSpeed = -SPEEDLIMIT;
        }
    }
}
