using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class HitEffect : Thing
    {
        public Color Color = Color.White;
        public HitEffect(float z = 0.001f, int offsetX = -1000, int offsetY=-500, int width=2000, int height=2000)
        {
            var random = new System.Random();

            var animation = GeneratedContent.Create_knight_hit_effect(
                offsetX- random.Next(0, 500)
                , offsetY - random.Next(0, 500)
                , width
                , height
            );

            animation.LoopDisabled = true;
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
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
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
            animation.ColorGetter = player.GetArmorColor;
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

                Y = player.Y + yBonus;
            });

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new HitEffectFriction(this));
        }
    }
}
