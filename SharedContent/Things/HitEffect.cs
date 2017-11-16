using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public static class GlobalSettigns
    {
        public const float FIREBALL_Z = Boss.RIGHT_ARM_Z - 0.005f;
        public const float FIREBALL_BORDER_Z = FIREBALL_Z + 0.001f;
        public const float FIREBALL_TRAIL_Z = FIREBALL_Z + 0.002f;
        public const float FIREBALL_TRAIL_BORDER_Z = FIREBALL_Z + 0.003f;
    }

    public class DestroyAfterTime : UpdateHandler
    {
        private readonly Thing Parent;
        private int duration;

        public DestroyAfterTime(Thing Parent, int duration)
        {
            this.Parent = Parent;
            this.duration = duration;
        }

        public void Update()
        {
            if (duration > 0)
                duration--;
            else
                Parent.Destroy();
        }
    }

    public class FireballTrail : Thing
    {
        public FireballTrail(int x, int y, int width, int height, Color color, Func<int, int, int?, int?, bool, Animation> Animation, bool flipped =false)
        {
            var animation = Animation(
            x
            , y
            , width
            , height
            , flipped
            );
            animation.RenderingLayer = GlobalSettigns.FIREBALL_TRAIL_Z;
            animation.ColorGetter = () => color;
            animation.LoopDisabled = true;
            AddAnimation(animation);

            var borderSize = 30;
            var animationBorder = Animation(
             x - (borderSize / 2)
            , y - (borderSize / 2)
            , width + borderSize
            , width + borderSize
            , flipped
            );
            animationBorder.RenderingLayer = GlobalSettigns.FIREBALL_TRAIL_BORDER_Z;
            animationBorder.ColorGetter = () => Color.Black;
            animationBorder.LoopDisabled = true;
            AddAnimation(animationBorder);

            AddUpdate(new DestroyAfterTime(this, 30));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }

    public class HitEffect : Thing
    {
        public Color Color = Color.White;
        public HitEffect(float z = 0.001f, int offsetX = -1000, int offsetY = -500, int width = 2000, int height = 2000)
        {
            var random = new System.Random();

            var animation = GeneratedContent.Create_knight_hit_effect(
                offsetX - random.Next(0, 500)
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
            animation.RenderingLayer = HumanoidAnimatorFactory.FACE_Z - player.PlayerIndex / 100f;
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
