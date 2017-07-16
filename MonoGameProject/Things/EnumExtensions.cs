namespace MonoGameProject
{
    public static class EnumExtensions
    {
        public static bool Is(this PlayerState a, params PlayerState[] states)
        {
            foreach (var b in states)
            {
                if (a == b)
                    return true;
            }
            return false;
        }
    }
}
