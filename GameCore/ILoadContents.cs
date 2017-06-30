using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameCore
{
    public interface ILoadContents
    {
        Dictionary<string, Texture2D> LoadTextures();
        Dictionary<string, SoundEffect> LoadSoundEffects();
    }
}
