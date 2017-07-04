using GameCore;
using System.Collections.Generic;

namespace MonoGameProject
{
    class ContentLoader : ILoadContents
    {
        public IEnumerable<string> GetSoundNames()
        {
            return new string[] { };
        }

        public IEnumerable<string> GetTextureNames()
        {
            return new string[] { "a", "b", "c" };
        }
    }
}
