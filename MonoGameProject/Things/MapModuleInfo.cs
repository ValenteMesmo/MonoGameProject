namespace MonoGameProject
{
    public struct MapModuleInfo
    {
        public readonly bool TopEntry;
        public readonly bool MidEntry;
        public readonly bool BotEntry;
        public readonly bool TopExit;
        public readonly bool MidExit;
        public readonly bool BotExit;
        public readonly string[] Tiles;

        public MapModuleInfo(
            bool TopEntry
            , bool MidEntry
            , bool BotEntry
           , bool TopExit
           , bool MidExit
           , bool BotExit
           , params string[] Tiles
            )
        {
            this.TopEntry = TopEntry;
            this.MidEntry = MidEntry;
            this.BotEntry = BotEntry;
            this.TopExit = TopExit;
            this.MidExit = MidExit;
            this.BotExit = BotExit;
            this.Tiles = Tiles;
        }
    }
}