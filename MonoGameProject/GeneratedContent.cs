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
            new AnimationFrame("knight", X, Y, Width ?? 170, Height ?? 107, new Rectangle(904, 0, 170, 107)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 67, Height ?? 112, new Rectangle(1074, 0, 67, 112)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_NakedCrouch(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 55, new Rectangle(1141, 0, 79, 55)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_NakedCrouchAttack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 99, Height ?? 56, new Rectangle(1220, 0, 99, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 99, Height ?? 56, new Rectangle(1319, 0, 99, 56)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_NakedHeadBump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 87, Height ?? 64, new Rectangle(1418, 0, 87, 64)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_NakedJump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 112, Height ?? 82, new Rectangle(1505, 0, 112, 82)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_NakedStand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 66, Height ?? 105, new Rectangle(1617, 0, 66, 105)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_NakedStandAttack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 94, Height ?? 94, new Rectangle(1683, 0, 94, 94)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 94, Height ?? 94, new Rectangle(1777, 0, 94, 94)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_NakedWalk(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 101, Height ?? 96, new Rectangle(1871, 0, 101, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 101, Height ?? 96, new Rectangle(0, 112, 101, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 101, Height ?? 96, new Rectangle(101, 112, 101, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 101, Height ?? 96, new Rectangle(202, 112, 101, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 101, Height ?? 96, new Rectangle(303, 112, 101, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 101, Height ?? 96, new Rectangle(404, 112, 101, 96)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Template(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 1075, Height ?? 347, new Rectangle(505, 112, 1075, 347)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 102, Height ?? 101, new Rectangle(1580, 112, 102, 101)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(1682, 112, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 112, Height ?? 106, new Rectangle(1835, 112, 112, 106)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 98, Height ?? 102, new Rectangle(1947, 112, 98, 102)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 110, Height ?? 95, new Rectangle(0, 459, 110, 95)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(110, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(285, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(460, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(635, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(810, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(985, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(1160, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(1335, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(1510, 459, 175, 170)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 175, Height ?? 170, new Rectangle(110, 459, 175, 170)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 132, Height ?? 92, new Rectangle(1685, 459, 132, 92)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 133, Height ?? 64, new Rectangle(1817, 459, 133, 64)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sky(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 113, Height ?? 113, new Rectangle(0, 629, 113, 113)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 223, Height ?? 102, new Rectangle(113, 629, 223, 102)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 223, Height ?? 102, new Rectangle(336, 629, 223, 102)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 223, Height ?? 102, new Rectangle(559, 629, 223, 102)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 184, Height ?? 87, new Rectangle(782, 629, 184, 87)){ Flipped = Flipped }
        );

        return animation;
    }

}
