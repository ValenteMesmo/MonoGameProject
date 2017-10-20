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

    public static Animation Create_knight_Leg_Crouching(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1048, 261, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1309, 261, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1570, 261, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1570, 261, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1831, 261, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2092, 261, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2353, 261, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2614, 261, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2614, 261, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2875, 261, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(3136, 261, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3397, 261, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3657, 261, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching_edge(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(0, 522, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Crouching_edge_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(260, 522, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(520, 522, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Falling_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(781, 522, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Sweet_dreams(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(1042, 522, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Sweet_dreams_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 262, Height ?? 261, new Rectangle(1302, 522, 262, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1564, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1824, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1824, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2084, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2344, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2604, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2604, 522, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_Walking_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2864, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3124, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3124, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3384, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3644, 522, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 783, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(260, 783, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Legs_slide_wall_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(521, 783, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Slime(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(3880, 1566, 173, 173)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(0, 1827, 173, 173)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Slime_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(173, 1827, 173, 173)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(346, 1827, 173, 173)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(519, 1827, 173, 173)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_SoniicBoom(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(692, 1827, 92, 124)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(784, 1827, 92, 124)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(876, 1827, 92, 124)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(968, 1827, 92, 124)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 92, Height ?? 124, new Rectangle(1060, 1827, 92, 124)){ Flipped = Flipped }
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

    public static Animation Create_knight_arm_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(2469, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(2469, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(2729, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(2989, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3249, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3249, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3509, 0, 260, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(3769, 0, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_arm_idle_cover(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2847, 2872, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(522, 2611, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2350, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1304, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1565, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1826, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2087, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2348, 2611, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 53, new Rectangle(1152, 1827, 54, 53)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_butt_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1302, 783, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_damage_fog(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 3217, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 3217, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 3217, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 3217, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 3217, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2847, 2872, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(1300, 3217, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1453, 3217, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1537, 3217, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1621, 3217, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_top(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1705, 3217, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 261, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 266, Height ?? 261, new Rectangle(261, 261, 266, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(527, 261, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1789, 3217, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2060, 3217, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2331, 3217, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2602, 3217, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2873, 3217, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3144, 3217, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3415, 3217, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(3686, 3217, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(0, 3477, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(271, 3477, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(542, 3477, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(813, 3477, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1084, 3477, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1355, 3477, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1626, 3477, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(1897, 3477, 271, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 271, Height ?? 256, new Rectangle(2168, 3477, 271, 256)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 262, new Rectangle(1206, 1827, 260, 262)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3546, 1827, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_leaf_shield(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3653, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3732, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3811, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3890, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3969, 2611, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(0, 2872, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(79, 2872, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(158, 2872, 79, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number0(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 65, Height ?? 86, new Rectangle(2439, 3477, 65, 86)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 46, Height ?? 90, new Rectangle(2504, 3477, 46, 90)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 76, new Rectangle(2550, 3477, 70, 76)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 68, Height ?? 78, new Rectangle(2620, 3477, 68, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number4(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 62, Height ?? 89, new Rectangle(2688, 3477, 62, 89)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number5(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 88, new Rectangle(2750, 3477, 70, 88)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number6(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 59, Height ?? 84, new Rectangle(2820, 3477, 59, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number7(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 63, Height ?? 85, new Rectangle(2879, 3477, 63, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number8(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 85, new Rectangle(2942, 3477, 54, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number9(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 91, new Rectangle(2996, 3477, 56, 91)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2090, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2090, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_pilar(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(237, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(498, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(759, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1020, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1281, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1542, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1803, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2064, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2325, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2586, 2872, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2847, 2872, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(787, 261, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(782, 783, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_roof_bang_legs_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1042, 783, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(782, 2611, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 2350, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1466, 1827, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1726, 1827, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1986, 1827, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2246, 1827, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3806, 1827, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2090, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 2090, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spike_dropped(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3108, 2872, 261, 345)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3369, 2872, 261, 345)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3630, 2872, 261, 345)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spikes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 100, Height ?? 104, new Rectangle(3052, 3477, 100, 104)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1562, 783, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1823, 783, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2084, 783, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_attack_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2345, 783, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2606, 783, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(2867, 783, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3128, 783, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3388, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3648, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3648, 783, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 1044, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 1044, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 1044, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 1044, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 1044, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 1044, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1040, 1044, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1816, 1044, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2592, 1044, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 1305, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1305, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1566, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 1566, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 1566, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1566, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1566, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1566, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2506, 1827, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2766, 1827, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(3026, 1827, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(3286, 1827, 260, 263)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2090, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 2090, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3640, 2090, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2350, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2350, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1043, 2611, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3380, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3641, 2350, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 2611, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2609, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2870, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3131, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3392, 2611, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3392, 2611, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

}
