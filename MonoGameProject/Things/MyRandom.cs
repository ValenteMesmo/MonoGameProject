namespace MonoGameProject
{
    public class MyRandom
    {
        private const long RAND_MAX = int.MaxValue;

        public long Seed { get; set; }

        public MyRandom()
        {
            Seed = 1;
        }

        public MyRandom(long Seed)
        {
            this.Seed = Seed;
        }

        public int Next()
        {
            return (int)Rand();
        }

        private long Rand()
        {
            Seed = (Seed * 1103515245U + 12345U) & 0x7fffffffU;

            return Seed;
        }

        public int Next(int begin, int end)
        {
            long range = (end - begin) + 1;
            long limit = (RAND_MAX + 1) - ((RAND_MAX + 1) % range);

            var randVal = Rand();
            while (randVal >= limit)
                randVal = Rand();

            return (int)(randVal % range) + begin;
        }
    }
}
