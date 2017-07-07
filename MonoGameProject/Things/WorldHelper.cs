using GameCore;

namespace MonoGameProject
{
    public static class WorldHelper
    {
        public static void MoveWithTheWord(Thing thing)
        {
            MoveHorizontallyWithTheWord(thing);
            MoveVerticallyWithTheWord(thing);
        }

        public static void MoveHorizontallyWithTheWord(Thing thing)
        {
            thing.X -= WorldMover.WorldHorizontalSpeed;
        }

        public static void MoveVerticallyWithTheWord(Thing thing)
        {
            thing.Y -= WorldMover.WorldVerticalSpeed;
        }
    }
}
