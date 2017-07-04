using GameCore;

namespace MonoGameProject
{
    public class AfectedByGravity : UpdateHandler
    {
        public const int FORCE = 25;

        public override void Update()
        {
            Parent.AddVerticalForce(FORCE);
        }
    }
}
