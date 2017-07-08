using GameCore;
using System.Linq;

namespace MonoGameProject
{
    public class CheckIfCollidingWith<T> : Collider
    {
        public CheckIfCollidingWith()
        {
            AddBotCollisionHandler((a, b) => { });
        }

        public bool Colliding
        {
            get
            {
                return CollidingWith.Any(f => f.Parent is T);
            }
        }
    }
}
