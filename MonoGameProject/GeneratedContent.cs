using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class GeneratedContent : ILoadContents
{  
    private string[] spriteNames = new string[] { "knight" };
    private string[] soundNames = new string[] { "beat", "clap", "pata", "pom", "tumtum" };

    public IEnumerable<string> GetTextureNames()
    {
        return spriteNames;
    }

    public IEnumerable<string> GetSoundNames()
    {
        return soundNames;
    }
    
    public static Animation Create_knight_Flash(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 129, Height ?? 129, new Rectangle(0, 0, 129, 129)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3517, 0, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3777, 0, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching_edge(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(0, 261, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching_edge_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(260, 261, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(520, 261, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(781, 261, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Sweet_dreams(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(1042, 261, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Sweet_dreams_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 262, Height ?? 261, new Rectangle(1302, 261, 262, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1564, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1824, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1824, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2084, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2344, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2604, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2604, 261, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2864, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3124, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3124, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3384, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3644, 261, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 522, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(260, 522, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(521, 522, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_SoniicBoom(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(776, 1566, 92, 124)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(868, 1566, 92, 124)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(960, 1566, 92, 124)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(1052, 1566, 92, 124)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(1144, 1566, 92, 124)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Arm(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(129, 0, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Arm_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(129, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(389, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(649, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(909, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1169, 0, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Back(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1429, 0, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1689, 0, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_turtle_feet(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1949, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1949, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1949, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2209, 0, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2209, 0, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(783, 2350, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 2089, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1565, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1826, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2087, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2348, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2609, 2350, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 53, new Rectangle(1236, 1566, 54, 53)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_damage_fog(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2956, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2956, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2956, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2956, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2956, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2956, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(1560, 2956, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1713, 2956, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1797, 2956, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1881, 2956, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_top(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1965, 2956, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2469, 0, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 266, Height ?? 261, new Rectangle(2730, 0, 266, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(2996, 0, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2049, 2956, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2320, 2956, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2591, 2956, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2862, 2956, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3133, 2956, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3404, 2956, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3675, 2956, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(0, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(271, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(542, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(813, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1084, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1355, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1626, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1897, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2168, 3216, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2439, 3216, 271, 256)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 262, new Rectangle(1290, 1566, 260, 262)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3630, 1566, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_leaf_shield(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3914, 2350, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3993, 2350, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(0, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(79, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(158, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(237, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(316, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(395, 2611, 79, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number0(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 65, Height ?? 86, new Rectangle(2710, 3216, 65, 86)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 46, Height ?? 90, new Rectangle(2775, 3216, 46, 90)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 76, new Rectangle(2821, 3216, 70, 76)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 68, Height ?? 78, new Rectangle(2891, 3216, 68, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number4(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 62, Height ?? 89, new Rectangle(2959, 3216, 62, 89)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number5(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 88, new Rectangle(3021, 3216, 70, 88)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number6(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 59, Height ?? 84, new Rectangle(3091, 3216, 59, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number7(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 63, Height ?? 85, new Rectangle(3150, 3216, 63, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number8(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 85, new Rectangle(3213, 3216, 54, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number9(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 91, new Rectangle(3267, 3216, 56, 91)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 1829, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 1829, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_pilar(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(474, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(735, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(996, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1257, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1518, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1779, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2040, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2301, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2562, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2823, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2956, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3256, 0, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(782, 522, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1042, 522, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1043, 2350, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 2089, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1550, 1566, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1810, 1566, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2070, 1566, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2330, 1566, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 1829, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 1829, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 1829, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spike_dropped(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3084, 2611, 261, 345)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3345, 2611, 261, 345)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3606, 2611, 261, 345)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spikes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 100, Height ?? 104, new Rectangle(3323, 3216, 100, 104)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1302, 522, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1563, 522, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1824, 522, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2085, 522, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2346, 522, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2607, 522, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2868, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3128, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3128, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3388, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3648, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 783, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 783, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2080, 783, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2856, 783, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1044, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 1044, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 1044, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1044, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1044, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1566, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2590, 1566, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2850, 1566, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(3110, 1566, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(3370, 1566, 260, 263)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 1829, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 1829, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3640, 1829, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2089, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2089, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1304, 2350, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3640, 2089, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 2350, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2870, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3131, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3392, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3653, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3653, 2350, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

}
