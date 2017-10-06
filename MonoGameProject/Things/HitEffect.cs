using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class HitEffect : Thing
    {
        public Color Color = Color.White;
        public HitEffect(float z = 0f, bool randomv = true)
        {
            var random = new System.Random();


            var animation = GeneratedContent.Create_knight_hit_effect(
                -1000 - (randomv ? random.Next(0, 500) : 0)
                , -500 - (randomv ? random.Next(0, 500) : 0)
                , 2000
                , 2000
            );

            animation.LoopDisabled = true;
            //animation.ScaleX = animation.ScaleY = 5;            
            animation.ColorGetter = () => Color;
            animation.FrameDuration = 2;
            animation.RenderingLayer = z;
            AddAnimation(animation);

            var duration = 100;
            AddUpdate(() =>
            {
                duration--;
                if (duration <= 0)
                    Destroy();
            });
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new HitEffectFriction(this));
        }
    }


    public class ArmorBreaking : Thing
    {
        public ArmorBreaking(Humanoid player, int yBonus)
        {
            var animation = GeneratedContent.Create_knight_damage_fog(0, 0, null, null, player.FacingRight);
            animation.ScaleX = animation.ScaleY = HumanoidAnimatorFactory.scale;
            animation.LoopDisabled = true;
            animation.ColorGetter = () => player.ArmorColor;
            //animation.FrameDuration = 2;
            animation.RenderingLayer = HumanoidAnimatorFactory.HEAD_Z - 0.01f;
            AddAnimation(animation);

            var duration = 100;
            AddUpdate(() =>
            {
                duration--;
                if (duration <= 0)
                    Destroy();

                X = player.X - 250;
                
                //if crouching
                Y = player.Y + yBonus;
            });

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new HitEffectFriction(this));
        }
    }
}
