using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class GeneratedContent : ILoadContents
{  
    private string[] spriteNames = new string[] { "knight" };
    private string[] soundNames = new string[]{};

    public IEnumerable<string> GetTextureNames()
    {
        return spriteNames;
    }

    public IEnumerable<string> GetSoundNames()
    {
        return soundNames;
    }
    
    public static Animation Create_knight_Arms_Right_Attack(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 0+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+5, 0+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+5, 0+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Arms_Right_Stand(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1779+5, 0+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(2372+5, 0+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(2965+5, 0+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Standing(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 594+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+5, 594+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+5, 594+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1779+5, 594+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(2372+5, 594+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(2965+5, 594+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 1190+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+5, 1190+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+5, 1190+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg1(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1779+5, 1190+5, 1920-10, 1080-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg2(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 2270+5, 1922-10, 1080-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg3(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1922+5, 2270+5, 1920-10, 1080-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg4(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 3350+5, 1920-10, 1080-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg5(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1920+5, 3350+5, 1920-10, 1080-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg6(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 4430+5, 1920-10, 1080-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1920+5, 4430+5, 112-10, 112-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

}
