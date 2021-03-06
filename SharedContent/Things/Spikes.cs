﻿using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class Spikes : Thing
    {
        public Spikes(Game1 Game1, Color Color, int width, int height)
        {
            var collider = new AttackCollider();
            collider.OffsetY = MapModule.CELL_SIZE / 2;
            collider.Width = width * MapModule.CELL_SIZE;
            collider.Height = height * MapModule.CELL_SIZE / 2;
            AddCollider(collider);

            var baseTrigger = true;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var shouldTrigger = !baseTrigger;
                    baseTrigger = shouldTrigger;

                    var animation = GeneratedContent.Create_knight_spikes2(
                        i * MapModule.CELL_SIZE
                        , j * MapModule.CELL_SIZE
                        , MapModule.CELL_SIZE
                        , MapModule.CELL_SIZE).AsAutoRewindable();
                    animation.RenderingLayer = 0.49f;
                    animation.ColorGetter = () => Color;
                    animation.FrameDuration = 2;
                    AddAnimation(animation);

                    var sound = Game1.MusicController.GetSoundEffect("beat2", this, () => (int)collider.CenterX(), () => (int)collider.CenterY());
                    AddUpdate(() =>
                    {
                        if(Game1.MusicController.PrepareTarol() && shouldTrigger)
                            animation.Restart();

                        if (Game1.MusicController.CanPlayTarol())
                        {
                            if (shouldTrigger == false)
                            {
                                shouldTrigger = true;
                                return;
                            }
                            sound.Play();
                            shouldTrigger = false;

                        }
                    });
                }
            }

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }
}
