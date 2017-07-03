namespace GameCore
{
    public abstract class TopCollisionHandler
    {
        public Collider Parent { get; internal set; }

        public abstract void Handle(Collider other);
    }
}
