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
            
            new AnimationFrame("knight", X, Y, Width ?? 114, Height ?? 60, new Rectangle(0, 0, 114, 60)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 150, Height ?? 99, new Rectangle(114, 0, 150, 99)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Standing(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 130, Height ?? 101, new Rectangle(264, 0, 130, 101)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 107, new Rectangle(394, 0, 170, 107)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 107, new Rectangle(564, 0, 170, 107)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 107, new Rectangle(734, 0, 170, 107)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 107, new Rectangle(0, 107, 170, 107)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 67, Height ?? 112, new Rectangle(170, 107, 67, 112)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 100, Height ?? 99, new Rectangle(237, 107, 100, 99)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(337, 107, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 112, Height ?? 106, new Rectangle(490, 107, 112, 106)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 98, Height ?? 102, new Rectangle(602, 107, 98, 102)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 130, Height ?? 82, new Rectangle(700, 107, 130, 82)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(830, 107, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 303, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(175, 303, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(350, 303, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(525, 303, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(700, 303, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 473, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(175, 473, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(350, 473, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(830, 107, 175, 170)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 132, Height ?? 92, new Rectangle(525, 473, 132, 92)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 133, Height ?? 64, new Rectangle(657, 473, 133, 64)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sky(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 113, Height ?? 113, new Rectangle(790, 473, 113, 113)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 223, Height ?? 102, new Rectangle(0, 643, 223, 102)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 223, Height ?? 102, new Rectangle(223, 643, 223, 102)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 223, Height ?? 102, new Rectangle(446, 643, 223, 102)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 184, Height ?? 87, new Rectangle(669, 643, 184, 87)){ Flipped = Flipped }
        );

        return animation;
    }

}
