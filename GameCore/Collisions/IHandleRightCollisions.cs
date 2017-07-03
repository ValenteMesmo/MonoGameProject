namespace GameCore
{
    public abstract class RightCollisionHandler
    {
        public Collider Parent { get; internal set; }

        public abstract void Handle(Collider other);
    }
}
