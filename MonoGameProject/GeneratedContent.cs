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
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(0, 0, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching_edge(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(260, 0, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(520, 0, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Sweet_dreams(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 267, Height ?? 261, new Rectangle(781, 0, 267, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1048, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1308, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1308, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1568, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1828, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2088, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2088, 0, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2348, 0, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2084, 785, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 525, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2866, 785, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3127, 785, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3388, 785, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3649, 785, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 1046, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 53, new Rectangle(2609, 0, 54, 53)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_damage_fog(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2088, 1307, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2348, 1307, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2608, 1307, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2868, 1307, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3128, 1307, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3388, 1307, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3648, 1307, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 1568, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 1568, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(3120, 1568, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(3273, 1568, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(3357, 1568, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(3441, 1568, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_top(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(3525, 1568, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3609, 1568, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 264, Height ?? 261, new Rectangle(0, 1829, 264, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(264, 1829, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(524, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(795, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1066, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1337, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1608, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1879, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2150, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2421, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2692, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2963, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3234, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3505, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3776, 1829, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(0, 2090, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(271, 2090, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(542, 2090, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(813, 2090, 271, 256)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 262, new Rectangle(2663, 0, 260, 262)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 262, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_leaf_shield(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(1305, 1046, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(1384, 1046, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(1463, 1046, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(1542, 1046, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(1621, 1046, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(1700, 1046, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(1779, 1046, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(1858, 1046, 79, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number0(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 65, Height ?? 86, new Rectangle(1084, 2090, 65, 86)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 46, Height ?? 90, new Rectangle(1149, 2090, 46, 90)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 76, new Rectangle(1195, 2090, 70, 76)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 68, Height ?? 78, new Rectangle(1265, 2090, 68, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number4(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 62, Height ?? 89, new Rectangle(1333, 2090, 62, 89)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number5(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 88, new Rectangle(1395, 2090, 70, 88)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number6(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 59, Height ?? 84, new Rectangle(1465, 2090, 59, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number7(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 63, Height ?? 85, new Rectangle(1524, 2090, 63, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number8(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 85, new Rectangle(1587, 2090, 54, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number9(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 91, new Rectangle(1641, 2090, 56, 91)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 262, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 262, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 262, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 262, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 262, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 262, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_pilar(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1937, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2198, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2459, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2720, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2981, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3242, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3503, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3764, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 1307, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 1307, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 1568, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1697, 2090, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1958, 2090, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2344, 785, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3640, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 785, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 785, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 785, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 785, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2923, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3183, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3443, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3703, 0, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 262, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 262, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3640, 262, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 525, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spike_dropped(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 1307, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(783, 1307, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1044, 1307, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spike_dropping(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1305, 1307, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1566, 1307, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1827, 1307, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spikes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 100, Height ?? 104, new Rectangle(2218, 2090, 100, 104)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2318, 2090, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2579, 2090, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2840, 2090, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack_part2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(3101, 2090, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(3362, 2090, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(3623, 2090, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2351, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2351, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 2351, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3120, 2351, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 2612, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 2612, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 2612, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 2612, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(0, 262, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(260, 262, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(520, 262, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(780, 262, 260, 263)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 262, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 262, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 525, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 525, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 525, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2605, 785, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1040, 785, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1301, 785, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1562, 785, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1823, 785, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1823, 785, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(783, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1044, 1046, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1044, 1046, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

}
