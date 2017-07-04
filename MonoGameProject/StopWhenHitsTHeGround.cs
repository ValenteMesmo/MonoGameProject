using GameCore;

namespace MonoGameProject
{
    public class StopWhenHitsTHeGround : BotCollisionHandler
    {
        public override void Handle(Collider other)
        {
            Parent.Parent.Y = other.Top() - Parent.Height;
        }
    }
}