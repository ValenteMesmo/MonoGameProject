using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class HitEffect : Thing
    {
        public Color Color = Color.White;
        public HitEffect()
        {
            var animation = GeneratedContent.Create_knight_hit_effect(-400, -400);
            animation.LoopDisabled = true;
            animation.ScaleX = animation.ScaleY = 10;
            animation.ColorGetter = () => Color;
            animation.FrameDuration = 2;
            animation.RenderingLayer = 0f;
            AddAnimation(animation);

            var duration = 100;
            AddUpdate(() =>
            {
                duration--;
                if (duration <= 0)
                    Destroy();
            });
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }
}
