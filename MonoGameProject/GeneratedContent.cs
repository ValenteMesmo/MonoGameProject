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
    
    public static Animation Create_knight_Legs_Crouching(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 99, Height ?? 60, new Rectangle(0, 0, 99, 60)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 126, Height ?? 101, new Rectangle(99, 0, 126, 101)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Standing(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 102, new Rectangle(225, 0, 144, 102)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(369, 0, 154, 105)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(523, 0, 154, 105)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(677, 0, 154, 105)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(831, 0, 154, 105)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 105, new Rectangle(0, 105, 154, 105)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 77, Height ?? 114, new Rectangle(154, 105, 77, 114)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 102, Height ?? 101, new Rectangle(231, 105, 102, 101)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_crouching_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 99, Height ?? 60, new Rectangle(0, 0, 99, 60)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(333, 105, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 112, Height ?? 106, new Rectangle(486, 105, 112, 106)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 89, Height ?? 107, new Rectangle(598, 105, 89, 107)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(687, 105, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 301, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(175, 301, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(350, 301, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(525, 301, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(700, 301, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 471, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(175, 471, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(350, 471, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(687, 105, 175, 170)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 132, Height ?? 93, new Rectangle(525, 471, 132, 93)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 154, Height ?? 53, new Rectangle(657, 471, 154, 53)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sky(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 113, Height ?? 113, new Rectangle(811, 471, 113, 113)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 414, Height ?? 169, new Rectangle(0, 641, 414, 169)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 414, Height ?? 169, new Rectangle(414, 641, 414, 169)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 414, Height ?? 169, new Rectangle(0, 810, 414, 169)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 182, Height ?? 132, new Rectangle(414, 810, 182, 132)){ Flipped = Flipped }
        );

        return animation;
    }

}
