using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class GeneratedContent : ILoadContents
{  
    private string[] spriteNames = new string[] { "knight" };
    private string[] soundNames = new string[] { "beat", "beat1", "beat146", "beat147", "beat2", "beat3", "clap", "pata", "pom", "tumtum" };

    public IEnumerable<string> GetTextureNames()
    {
        return spriteNames;
    }

    public IEnumerable<string> GetSoundNames()
    {
        return soundNames;
    }
    
    public static Animation Create_knight_Arm_Attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(282, 620, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(543, 620, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Arm_Attack_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(804, 620, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1065, 620, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1326, 620, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Arm_Idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(282, 620, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Arm_Idle_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(1587, 620, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Bone(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 30, Height ?? 30, new Rectangle(4044, 3229, 30, 30)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 30, Height ?? 30, new Rectangle(0, 3574, 30, 30)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Checkpoint(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 51, Height ?? 256, new Rectangle(0, 0, 51, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 51, Height ?? 256, new Rectangle(51, 0, 51, 256)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 51, Height ?? 256, new Rectangle(102, 0, 51, 256)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_CheckpointFlag(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 120, Height ?? 99, new Rectangle(153, 0, 120, 99)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Flash(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 129, Height ?? 129, new Rectangle(30, 3574, 129, 129)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Ice_Wing(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(1386, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(1669, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(1952, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(2235, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(2518, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(2801, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(3084, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(3367, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(3650, 0, 283, 360)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ItemChest1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 206, Height ?? 207, new Rectangle(421, 0, 206, 207)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ItemChest2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 206, Height ?? 207, new Rectangle(627, 0, 206, 207)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ItemChest3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 206, Height ?? 207, new Rectangle(833, 0, 206, 207)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_KnightMary(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 347, Height ?? 285, new Rectangle(1039, 0, 347, 285)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_PressToStart(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 386, Height ?? 109, new Rectangle(776, 2184, 386, 109)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Slime(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 104, Height ?? 102, new Rectangle(3380, 360, 104, 102)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Slime_Attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 104, Height ?? 102, new Rectangle(3380, 360, 104, 102)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 104, Height ?? 102, new Rectangle(3484, 360, 104, 102)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 104, Height ?? 102, new Rectangle(3588, 360, 104, 102)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Arm(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Arm_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_turtle_feet(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Snake_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Statue_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Strong_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Treel_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Wolf_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Worm_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_actionsInput(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 74, Height ?? 73, new Rectangle(273, 0, 74, 73)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(522, 2968, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2707, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1304, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1565, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1826, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2087, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2348, 2968, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_blood(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(159, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(303, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(447, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(591, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(735, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(879, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1023, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1167, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1311, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1455, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1599, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1743, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1887, 3574, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(2031, 3574, 144, 127)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_damage_fog(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2175, 3574, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2435, 3574, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2695, 3574, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2955, 3574, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3215, 3574, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2847, 3229, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(3891, 3229, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_fireball(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 36, Height ?? 34, new Rectangle(3475, 3574, 36, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 36, Height ?? 34, new Rectangle(3511, 3574, 36, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 36, Height ?? 34, new Rectangle(3547, 3574, 36, 34)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_fireball2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(3583, 3574, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(3639, 3574, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(3695, 3574, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(3751, 3574, 56, 56)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_fireball3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 39, new Rectangle(3807, 3574, 79, 39)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 39, new Rectangle(3886, 3574, 79, 39)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 39, new Rectangle(3965, 3574, 79, 39)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 39, new Rectangle(0, 3834, 79, 39)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_fireball_trail(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(79, 3834, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(116, 3834, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(153, 3834, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(190, 3834, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(227, 3834, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(264, 3834, 37, 34)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 38, Height ?? 38, new Rectangle(1831, 3834, 38, 38)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 39, Height ?? 39, new Rectangle(1869, 3834, 39, 39)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_top(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 40, Height ?? 27, new Rectangle(1908, 3834, 40, 27)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 266, Height ?? 261, new Rectangle(1848, 620, 266, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(2114, 620, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_bang_hair(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2374, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_eyes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2635, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_face(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2896, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_hair(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3157, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_hair_bonus(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3418, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(301, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(454, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(607, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(760, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(913, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1066, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1219, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1372, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1525, 3834, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1678, 3834, 153, 148)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 262, new Rectangle(1162, 2184, 260, 262)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3502, 2184, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_leaf_shield(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3653, 2968, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3732, 2968, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3811, 2968, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3890, 2968, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3969, 2968, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(0, 3229, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(79, 3229, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(158, 3229, 79, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_movementInput(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 74, Height ?? 73, new Rectangle(347, 0, 74, 73)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number0(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 65, Height ?? 86, new Rectangle(1948, 3834, 65, 86)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 46, Height ?? 90, new Rectangle(2013, 3834, 46, 90)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 76, new Rectangle(2059, 3834, 70, 76)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 68, Height ?? 78, new Rectangle(2129, 3834, 68, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number4(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 62, Height ?? 89, new Rectangle(2197, 3834, 62, 89)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number5(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 88, new Rectangle(2259, 3834, 70, 88)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number6(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 59, Height ?? 84, new Rectangle(2329, 3834, 59, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number7(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 63, Height ?? 85, new Rectangle(2388, 3834, 63, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number8(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 85, new Rectangle(2451, 3834, 54, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number9(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 91, new Rectangle(2505, 3834, 56, 91)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2447, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2447, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_pilar(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(237, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(498, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(759, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1020, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1281, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1542, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1803, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2064, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2325, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2586, 3229, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2847, 3229, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(782, 2968, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 2707, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_mob_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 93, Height ?? 96, new Rectangle(3692, 360, 93, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 93, Height ?? 96, new Rectangle(3785, 360, 93, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 93, Height ?? 96, new Rectangle(3878, 360, 93, 96)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_mob_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 94, Height ?? 96, new Rectangle(3971, 360, 94, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 94, Height ?? 96, new Rectangle(0, 620, 94, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 94, Height ?? 96, new Rectangle(94, 620, 94, 96)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 94, Height ?? 96, new Rectangle(188, 620, 94, 96)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1422, 2184, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1682, 2184, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1942, 2184, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2202, 2184, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3762, 2184, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2447, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 2447, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spike_dropped(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3108, 3229, 261, 345)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3369, 3229, 261, 345)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3630, 3229, 261, 345)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spikes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 100, Height ?? 104, new Rectangle(2561, 3834, 100, 104)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spikes2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 167, Height ?? 119, new Rectangle(2661, 3834, 167, 119)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 167, Height ?? 119, new Rectangle(2828, 3834, 167, 119)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 167, Height ?? 119, new Rectangle(2995, 3834, 167, 119)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 167, Height ?? 119, new Rectangle(3162, 3834, 167, 119)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 167, Height ?? 119, new Rectangle(3329, 3834, 167, 119)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sword_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2860, 1401, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1662, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 1662, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sword_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 1662, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_crouch(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3679, 620, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_crouch_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_edgecrouch(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_edgecrouch_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_edgecrouchback(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_edgecrouchback_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_edgestand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_edgestand_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_edgestandback(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_edgestandback_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_fall(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_fall_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_headbump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_headbump_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_jump_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3640, 881, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 1141, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_stand_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 1141, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_sweetdreams(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 1141, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_sweetdreams_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 1141, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3640, 1141, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 1401, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 1401, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 1401, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 1401, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 1401, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 1401, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 1401, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 1401, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 1401, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_wallslide(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 1401, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_wallslide_armor(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 1401, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wand_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1662, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1662, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1923, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wand_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 1923, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 1923, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1923, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1923, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 2184, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2462, 2184, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2722, 2184, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2982, 2184, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(3242, 2184, 260, 263)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2447, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 2447, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3640, 2447, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2707, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2707, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1043, 2968, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3380, 2707, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3641, 2707, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 2968, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2609, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2870, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3131, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3392, 2968, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3392, 2968, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

}
