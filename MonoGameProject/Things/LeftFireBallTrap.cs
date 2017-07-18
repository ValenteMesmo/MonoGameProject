using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class LeftFireBallTrap : Thing
    {
        public LeftFireBallTrap(Action<Thing> AddToWorld, int startAfter)
        {
            var cooldown = startAfter;
            AddUpdate(() =>
            {
                cooldown--;
                if (cooldown <= 0)
                {
                    AddToWorld(new FireBall(50, 0) { X = X + 100, Y = Y + 50 });
                    cooldown = 200;
                }
            });
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
            AddAnimation(new Animation(
                                new AnimationFrame(
                                    "block"
                                    , 0
                                    , 0
                                    , MapModule.CELL_SIZE
                                    , MapModule.CELL_SIZE
                                )
                                { RenderingLayer = 1 })
            { Color = Color.Orange });
        }
    }
}
