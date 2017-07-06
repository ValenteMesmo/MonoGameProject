using GameCore;

namespace MonoGameProject
{
    public class StopWhenHitsTHeGround 
    {
        public void Handle(Collider Parent, Collider other)
        {
            if (other.Parent is MapModule)
            {
                Parent.Parent.VerticalSpeed = 0;
                Parent.Parent.Y = other.Top() - Parent.Height - 1;
            }
        }
    }

    public class StopWhenHitsTHeLeftWall
    {
        public void Handle(Collider Parent, Collider other)
        {
            if (other.Parent is BackBlocker)
            {
                Parent.Parent.HorizontalSpeed = 0;
                Parent.Parent.X = other.Parent.X + other.Width  - Parent.X +1;
            }
        }
    }
}