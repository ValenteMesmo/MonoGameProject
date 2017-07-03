namespace GameCore
{
    public abstract class BotCollisionHandler
    {
        public Collider Parent { get; internal set; }

        public abstract void Handle(Collider other);
    }
}
