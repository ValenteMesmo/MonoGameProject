using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public static class GlobalSettigns
    {
        public const int FIREBALL_HEALTH = 3;
        public const float FIREBALL_Z = Boss.RIGHT_ARM_Z - 0.004f;
        public const float FIREBALL_BORDER_Z = Boss.RIGHT_ARM_Z - 0.003f;
        public const float FIREBALL_TRAIL_Z = Boss.RIGHT_ARM_Z - 0.002f;
        public const float FIREBALL_TRAIL_BORDER_Z = Boss.RIGHT_ARM_Z - 0.001f;
        public const float FIRERING_BACK_Z = 0.13f;
        public const float FIRERING_FRONT_Z = FIREBALL_Z;
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

    public class BloodHitEffect : HitEffect
    {
        public BloodHitEffect()
        {
            //var random = new System.Random();


            var offset = -1000;
            var size = 2000;
            var animation = GeneratedContent.Create_knight_blood(
                offset
                , offset
                , size
                , size
            );

            animation.LoopDisabled = true;
            animation.ColorGetter = () => Color;
            animation.FrameDuration = 1;
            animation.RenderingLayer = GlobalSettigns.FIREBALL_BORDER_Z;
            AddAnimation(animation);

        }
    }

    public class SmokeHitEffect : HitEffect
    {
        public SmokeHitEffect(float z)
        {
            var offset = -250;
            var size = 1000;
            var animation = GeneratedContent.Create_knight_hit_effect(
                offset
                , offset
                , size
                , size
            );

            animation.LoopDisabled = true;
            animation.ColorGetter = () => Color;
            animation.RenderingLayer = z;
            AddAnimation(animation);

        }
    }

    public abstract class HitEffect : Thing
    {
        public Color Color = Color.White;
        public HitEffect()
        {
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
