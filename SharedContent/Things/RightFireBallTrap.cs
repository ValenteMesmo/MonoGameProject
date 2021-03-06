﻿using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class RightFireBallTrap : Thing
    {
        public RightFireBallTrap(Game1 Game1, int startAfter)
        {
            var cooldown = startAfter;

            var shouldplay = startAfter == 0;

            var sound = Game1.MusicController.GetSoundEffect("beat1", this, ()=> X, () => Y);

            AddUpdate(() =>
            {
                //cooldown--;
                //if (cooldown <= 0)
                if (Game1.MusicController.CanPlayBumbo())
                {
                    if (shouldplay)
                    {
                        Game1.AddToWorld(
                            new FireballCloud(
                                this
                                , -FireBall.SPEED
                                , 0
                                , Game1
                                , GameState.GetColor())
                            {
                                X = X - 50,
                                Y = Y + 50
                            });
                        //cooldown = 200;
                        shouldplay = false;

                        sound.Play();
                    }
                    else
                        shouldplay = true;
                }
            });
            AddUpdate(new DestroyIfLeftBehind(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }
}
