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
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+10, 0+10, 593-20, 594-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+10, 0+10, 593-20, 594-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+10, 0+10, 593-20, 594-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Arms_Right_Stand(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1779+10, 0+10, 593-20, 594-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(2372+10, 0+10, 593-20, 594-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(2965+10, 0+10, 593-20, 594-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Standing(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+10, 594+10, 593-20, 594-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+10, 594+10, 593-20, 596-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+10, 594+10, 593-20, 596-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1779+10, 594+10, 593-20, 596-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(2372+10, 594+10, 593-20, 596-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(2965+10, 594+10, 593-20, 596-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+10, 1190+10, 593-20, 596-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+10, 1190+10, 593-20, 596-20)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+10, 1190+10, 593-20, 596-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg1(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1779+10, 1190+10, 1920-20, 1080-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg2(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+10, 2270+10, 1922-20, 1080-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg3(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1922+10, 2270+10, 1920-20, 1080-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg4(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+10, 3350+10, 1920-20, 1080-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg5(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1920+10, 3350+10, 1920-20, 1080-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bg6(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+10, 4430+10, 1920-20, 1080-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1920+10, 4430+10, 100-20, 100-20)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

}
