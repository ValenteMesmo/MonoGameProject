using GameCore;

namespace MonoGameProject
{
    public class StopWhenHitsTHeGround 
    {
        public void Handle(Collider Parent, Collider other)
        {
            Parent.Parent.VerticalSpeed = 0;
            Parent.Parent.Y = other.Top() - Parent.Height - 1;
        }
    }
}