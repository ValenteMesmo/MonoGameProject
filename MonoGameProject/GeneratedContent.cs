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
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(789, 0, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1050, 0, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1311, 0, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1572, 0, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 261, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1616, 261, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 650, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 53, new Rectangle(261, 261, 54, 53)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(520, 911, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(673, 911, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_top(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(757, 911, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(841, 911, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 264, Height ?? 261, new Rectangle(1102, 911, 264, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(1366, 911, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1626, 911, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(0, 1172, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(271, 1172, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(542, 1172, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(813, 1172, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1084, 1172, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1355, 1172, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1626, 1172, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(0, 1428, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(271, 1428, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(542, 1428, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(813, 1428, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1084, 1428, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1355, 1428, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1626, 1428, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(0, 1684, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(271, 1684, 271, 256)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 389, new Rectangle(315, 261, 261, 389)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(576, 261, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number0(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 65, Height ?? 86, new Rectangle(542, 1684, 65, 86)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 46, Height ?? 90, new Rectangle(607, 1684, 46, 90)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 76, new Rectangle(653, 1684, 70, 76)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 68, Height ?? 78, new Rectangle(723, 1684, 68, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number4(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 62, Height ?? 89, new Rectangle(791, 1684, 62, 89)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number5(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 88, new Rectangle(853, 1684, 70, 88)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number6(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 59, Height ?? 84, new Rectangle(923, 1684, 59, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number7(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 63, Height ?? 85, new Rectangle(982, 1684, 63, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number8(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 85, new Rectangle(1045, 1684, 54, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number9(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 91, new Rectangle(1099, 1684, 56, 91)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(782, 650, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1042, 650, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1155, 1684, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1416, 1684, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(836, 261, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1096, 261, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1302, 650, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1562, 650, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spikes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 100, Height ?? 104, new Rectangle(1676, 1684, 100, 104)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1776, 1684, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(0, 1945, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(261, 1945, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(522, 1945, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(782, 1945, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 2206, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 2206, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 2467, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 2467, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1356, 261, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(576, 261, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 911, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 911, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(260, 650, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(521, 650, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

}
