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
    
    public static Animation Create_knight_Legs_Crouching(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 99, Height ?? 60, new Rectangle(260, 105, 99, 60)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 126, Height ?? 101, new Rectangle(0, 0, 126, 101)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Standing(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 102, new Rectangle(126, 0, 144, 102)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(270, 0, 154, 105)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(424, 0, 154, 105)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(578, 0, 154, 105)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(732, 0, 154, 105)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(0, 105, 154, 105)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 106, Height ?? 106, new Rectangle(154, 105, 106, 106)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_crouching_legs(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 99, Height ?? 60, new Rectangle(260, 105, 99, 60)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(359, 105, 153, 196)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 112, Height ?? 106, new Rectangle(512, 105, 112, 106)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 132, Height ?? 93, new Rectangle(624, 105, 132, 93)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 53, new Rectangle(756, 105, 154, 53)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sky(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 113, Height ?? 113, new Rectangle(910, 105, 113, 113)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 414, Height ?? 169, new Rectangle(0, 301, 414, 169)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 414, Height ?? 169, new Rectangle(414, 301, 414, 169)){ RenderingLayer = Z, Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 414, Height ?? 169, new Rectangle(0, 470, 414, 169)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand(int X, int Y, float Z, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 182, Height ?? 132, new Rectangle(414, 470, 182, 132)){ RenderingLayer = Z, Flipped = Flipped }
        );

        return animation;
    }

}
