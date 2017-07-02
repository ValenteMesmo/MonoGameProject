namespace GameCore
{
    public abstract class UpdateHandler
    {
        public Thing Parent { get; internal set; }

        public abstract void Update();
    }
}
