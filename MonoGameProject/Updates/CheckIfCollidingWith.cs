using GameCore;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameProject
{
    public class CollisionChecker : Collider
    {
        public CollisionChecker()
        {
            AddBotCollisionHandler((a, b) => { });
        }

        public bool Colliding<T>()
        {
            return CollidingWith.Any(f => f is T);
        }

        public IEnumerable<Collider> GetGolliders<T>()
        {
            return CollidingWith.Where(f => f is T);
        }
    }
}
