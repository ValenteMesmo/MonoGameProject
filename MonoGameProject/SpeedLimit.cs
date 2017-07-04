using GameCore;

namespace MonoGameProject
{
    public class SpeedLimit : UpdateHandler
    {
        private readonly int SPEEDLIMIT = 70;

        public override void Update()
        {
            if (Parent.HorizontalSpeed > SPEEDLIMIT)
                Parent.HorizontalSpeed = SPEEDLIMIT;
            if (Parent.HorizontalSpeed < -SPEEDLIMIT)
                Parent.HorizontalSpeed = -SPEEDLIMIT;
        }
    }
}
