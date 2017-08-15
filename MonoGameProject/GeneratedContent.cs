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
            
            new AnimationFrame("knight", X, Y, Width ?? 267, Height ?? 261, new Rectangle(0, 0, 267, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(267, 0, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Standing(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(528, 0, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(0, 261, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(261, 261, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(522, 261, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(0, 521, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 521, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 53, new Rectangle(522, 521, 54, 53)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(576, 521, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(729, 521, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 782, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(261, 782, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(521, 782, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(696, 782, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 1043, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(175, 1043, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(350, 1043, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(525, 1043, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(700, 1043, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 1213, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(175, 1213, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(521, 782, 175, 170)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(350, 1213, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(611, 1213, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sky(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 113, Height ?? 113, new Rectangle(871, 1213, 113, 113)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spikes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 100, Height ?? 104, new Rectangle(0, 1474, 100, 104)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(100, 1474, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(361, 1474, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(622, 1474, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 1734, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

}
