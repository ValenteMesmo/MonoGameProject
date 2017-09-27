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
                    AddToWorld(new FireBall(FireBall.SPEED, 0, AddToWorld) { X = X + 100, Y = Y + 50 });
                    cooldown = 200;
                }
            });
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }
}
