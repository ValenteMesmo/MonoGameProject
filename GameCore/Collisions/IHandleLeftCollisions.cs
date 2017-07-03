namespace GameCore
{
    public abstract class LeftCollisionHandler
    {
        public Collider Parent { get; internal set; }

        public abstract void Handle(Collider other);
    }
}
