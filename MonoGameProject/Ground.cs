using GameCore;

namespace MonoGameProject
{
    public class Ground : Thing
    {
        public Ground(WorldMover WorldMover)
        {
            AddUpdate(t =>
            {
                X -= WorldMover.WorldSpeed;
            });
        }
    }
}
