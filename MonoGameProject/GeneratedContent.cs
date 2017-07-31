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
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1779+5, 0+5, 212-10, 164-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Border(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 594+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Head(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+5, 594+5, 112-10, 106-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(705+5, 594+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1298+5, 594+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Standing(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 1188+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+5, 1188+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+5, 1188+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 1784+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+5, 1784+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+5, 1784+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 2380+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(593+5, 2380+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1186+5, 2380+5, 593-10, 596-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(1779+5, 2380+5, 112-10, 112-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(0+5, 2976+5, 256-10, 256-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_bang(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(256+5, 2976+5, 593-10, 594-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sky(int X, int Y, float Z, int Width, int Height, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width, Height, new Rectangle(849+5, 2976+5, 113-10, 113-10)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

}
