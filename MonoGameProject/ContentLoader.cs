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
            return new string[] { "wallslide","block","jump", "stand", "walk0", "walk1", "walk2" };
        }
    }
}
