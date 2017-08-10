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
            
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 106, new Rectangle(394, 0, 170, 106)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 106, new Rectangle(564, 0, 170, 106)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 106, new Rectangle(734, 0, 170, 106)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 106, new Rectangle(0, 106, 170, 106)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 142, Height ?? 112, new Rectangle(170, 106, 142, 112)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 102, Height ?? 101, new Rectangle(312, 106, 102, 101)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(414, 106, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 112, Height ?? 106, new Rectangle(567, 106, 112, 106)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 98, Height ?? 102, new Rectangle(679, 106, 98, 102)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 110, Height ?? 95, new Rectangle(777, 106, 110, 95)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 302, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(175, 302, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(350, 302, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(525, 302, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(700, 302, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 472, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(175, 472, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(350, 472, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(525, 472, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(0, 302, 175, 170)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 132, Height ?? 93, new Rectangle(700, 472, 132, 93)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 133, Height ?? 64, new Rectangle(832, 472, 133, 64)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sky(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 113, Height ?? 113, new Rectangle(0, 642, 113, 113)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 220, Height ?? 99, new Rectangle(113, 642, 220, 99)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 220, Height ?? 99, new Rectangle(333, 642, 220, 99)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 220, Height ?? 99, new Rectangle(553, 642, 220, 99)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 184, Height ?? 87, new Rectangle(773, 642, 184, 87)){ Flipped = Flipped }
        );

        return animation;
    }

}
