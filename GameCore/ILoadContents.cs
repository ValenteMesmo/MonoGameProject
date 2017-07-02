using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameCore
{
    public interface ILoadContents
    {
        IEnumerable<string> GetTextureNames();
        IEnumerable<string> GetSoundNames();
    }
}
