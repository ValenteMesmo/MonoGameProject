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
    
    public static Animation Create_knight_Arm_Attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(261, 620, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(3120, 360, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Arm_Attack_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(3381, 360, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(3642, 360, 261, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(0, 620, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Arm_Idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(261, 620, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Arm_Idle_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(522, 620, 261, 260)){ Flipped = Flipped }
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
            
            new AnimationFrame("knight", X, Y, Width ?? 129, Height ?? 129, new Rectangle(414, 3576, 129, 129)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Ice_Wing(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(1238, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(1521, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(1804, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(2087, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(2370, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(2653, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(2936, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(3219, 0, 283, 360)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 283, Height ?? 360, new Rectangle(3502, 0, 283, 360)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ItemChest1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 206, Height ?? 207, new Rectangle(273, 0, 206, 207)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ItemChest2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 206, Height ?? 207, new Rectangle(479, 0, 206, 207)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ItemChest3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 206, Height ?? 207, new Rectangle(685, 0, 206, 207)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_KnightMary(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 347, Height ?? 285, new Rectangle(891, 0, 347, 285)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Crouching(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Crouching_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Crouching_edge(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(783, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Crouching_edge_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1044, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Fall_back(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1305, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Fall_back_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1566, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Fall_front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1827, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Fall_front_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2088, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Roof_bang(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2349, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Roof_bang_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2610, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_SweetDreams_back(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2871, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_SweetDreams_back_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3132, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_SweetDreams_front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 267, Height ?? 261, new Rectangle(3393, 881, 267, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_SweetDreams_front_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 264, Height ?? 261, new Rectangle(3660, 881, 264, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(783, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1044, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1305, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1305, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1566, 1142, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_Walking_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1827, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2088, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2088, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2349, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2610, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2871, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3132, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3132, 1142, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3393, 1142, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(3654, 1142, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_idle_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 260, new Rectangle(0, 1403, 261, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_wall_back(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 1403, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 1403, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_wall_back_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 1403, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_wall_front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(783, 1403, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Leg_wall_front_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1044, 1403, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_PressToStart(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 386, Height ?? 109, new Rectangle(0, 2186, 386, 109)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Slime(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(386, 2186, 173, 173)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(559, 2186, 173, 173)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Slime_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(732, 2186, 173, 173)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(905, 2186, 173, 173)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 173, Height ?? 173, new Rectangle(1078, 2186, 173, 173)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Arm(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3785, 0, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Arm_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_Shell_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Humanoid_turtle_feet(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 360, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Snake_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Statue_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Strong_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Treel_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Wolf_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_Torso_Worm_Front(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 360, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_actionsInput(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 74, Height ?? 73, new Rectangle(1251, 2186, 74, 73)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(783, 2970, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 2709, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_bills_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1565, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1826, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2087, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2348, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2609, 2970, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_block(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 53, new Rectangle(1325, 2186, 54, 53)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_blood(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(543, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(687, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(831, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(975, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1119, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1263, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1407, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1551, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1695, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1839, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(1983, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(2127, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(2271, 3576, 144, 127)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 144, Height ?? 127, new Rectangle(2415, 3576, 144, 127)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_damage_fog(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2559, 3576, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2819, 3576, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3079, 3576, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3339, 3576, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3599, 3576, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3084, 3231, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_dead_tree(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 196, new Rectangle(261, 3576, 153, 196)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_fireball(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 36, Height ?? 34, new Rectangle(3859, 3576, 36, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 36, Height ?? 34, new Rectangle(3895, 3576, 36, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 36, Height ?? 34, new Rectangle(3931, 3576, 36, 34)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_fireball2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(3967, 3576, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(4023, 3576, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(0, 3921, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(56, 3921, 56, 56)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_fireball3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(3967, 3576, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(4023, 3576, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(0, 3921, 56, 56)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 56, new Rectangle(56, 3921, 56, 56)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_fireball_trail(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(112, 3921, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(149, 3921, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(186, 3921, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(223, 3921, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(260, 3921, 37, 34)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 37, Height ?? 34, new Rectangle(297, 3921, 37, 34)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1864, 3921, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(1948, 3921, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(2032, 3921, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_ground_top(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 84, Height ?? 84, new Rectangle(2116, 3921, 84, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 266, Height ?? 261, new Rectangle(783, 620, 266, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_armor_bang1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 261, new Rectangle(1049, 620, 260, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_bang_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1309, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_bang_face(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1570, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_bang_hair(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1831, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_eyes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2092, 620, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2353, 620, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2614, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_face(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2875, 620, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3136, 620, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3397, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_hair(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3658, 620, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_head_hair_bonus(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 881, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_hit_effect(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(334, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(487, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(640, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(793, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(946, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1099, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1252, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1405, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1558, 3921, 153, 148)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 153, Height ?? 148, new Rectangle(1711, 3921, 153, 148)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 262, new Rectangle(1379, 2186, 260, 262)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_human_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3719, 2186, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_leaf_shield(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3914, 2970, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(3993, 2970, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(0, 3231, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(79, 3231, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(158, 3231, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(237, 3231, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(316, 3231, 79, 78)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 79, Height ?? 78, new Rectangle(395, 3231, 79, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_movementInput(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 74, Height ?? 73, new Rectangle(2200, 3921, 74, 73)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number0(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 65, Height ?? 86, new Rectangle(2274, 3921, 65, 86)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number1(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 46, Height ?? 90, new Rectangle(2339, 3921, 46, 90)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number2(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 76, new Rectangle(2385, 3921, 70, 76)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number3(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 68, Height ?? 78, new Rectangle(2455, 3921, 68, 78)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number4(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 62, Height ?? 89, new Rectangle(2523, 3921, 62, 89)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number5(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 70, Height ?? 88, new Rectangle(2585, 3921, 70, 88)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number6(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 59, Height ?? 84, new Rectangle(2655, 3921, 59, 84)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number7(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 63, Height ?? 85, new Rectangle(2714, 3921, 63, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number8(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 54, Height ?? 85, new Rectangle(2777, 3921, 54, 85)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_number9(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 56, Height ?? 91, new Rectangle(2831, 3921, 56, 91)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2449, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_one_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1040, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1300, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1560, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1820, 2449, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_pilar(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(474, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(735, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(996, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1257, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1518, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1779, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2040, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2301, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2562, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2823, 3231, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3084, 3231, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1043, 2970, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_skull_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 2709, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1639, 2186, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1899, 2186, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2159, 2186, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2419, 2186, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2449, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2080, 2449, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spider_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2340, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2600, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(2860, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3120, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3380, 2449, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spike_dropped(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3345, 3231, 261, 345)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(3606, 3231, 261, 345)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 345, new Rectangle(0, 3576, 261, 345)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_spikes(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 100, Height ?? 104, new Rectangle(2887, 3921, 100, 104)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sword_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1825, 1403, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2601, 1403, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1664, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_sword_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 1664, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1305, 1403, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_torso_walking_armored(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(1565, 1403, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wand_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 1664, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1664, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1664, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wand_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(0, 1925, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(776, 1925, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(1552, 1925, 776, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(2328, 1925, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_whip_idle(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 776, Height ?? 261, new Rectangle(3104, 1925, 776, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2679, 2186, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(2939, 2186, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(3199, 2186, 260, 263)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 263, new Rectangle(3459, 2186, 260, 263)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_body_jump(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2449, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2449, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(3640, 2449, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_eye_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(0, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(260, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(520, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2709, 260, 260)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 260, Height ?? 260, new Rectangle(780, 2709, 260, 260)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(1304, 2970, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_attack(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3640, 2709, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(0, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(261, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(522, 2970, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

    public static Animation Create_knight_wolf_head_shoot(int X, int Y, int? Width = null, int? Height = null, bool Flipped = false)
    {
        var animation = new Animation(
            
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(2870, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3131, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3392, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3653, 2970, 261, 261)){ Flipped = Flipped },
            new AnimationFrame("knight", X, Y, Width ?? 261, Height ?? 261, new Rectangle(3653, 2970, 261, 261)){ Flipped = Flipped }
        );

        return animation;
    }

}
