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
            return new string[] {
                "crouching" 
                ,"bg1"
                ,"bg2"
                ,"bg3"
                ,"bg4"
                ,"bg5"
                ,"bg6"
                ,"headbump"
                ,"wallslide"
                ,"block"
                ,"jump"
                , "stand"
                , "walk0"
                , "walk1"
                , "walk2" };
        }
    }
}
