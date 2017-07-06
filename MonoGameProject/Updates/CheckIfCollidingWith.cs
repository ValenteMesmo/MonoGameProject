using GameCore;

namespace MonoGameProject
{
    public class CheckIfCollidingWith<T> : Collider, UpdateHandler
    {
        public bool Colliding { get; set; }

        public CheckIfCollidingWith()
        {
            AddBotCollisionHandler(Handle);
            AddTopCollisionHandler(Handle);
            AddLeftCollisionHandler(Handle);
            AddRightCollisionHandler(Handle);
        }

        public void Update(Thing Parent)
        {
            Colliding = false;
        }

        private void Handle(Collider Parent, Collider Other)
        {
            if (Other.Parent is T)
                Colliding = true;
        }
    }
}
