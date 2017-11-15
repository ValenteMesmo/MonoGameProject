using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class RightFireBallTrap : Thing
    {
        public RightFireBallTrap(Game1 Game1, int startAfter)
        {
            var cooldown = startAfter;
            AddUpdate(() =>
            {
                cooldown--;
                if (cooldown <= 0)
                {
                    Game1.AddToWorld(new FireBall(this,-FireBall.SPEED, 0, Game1) { X = X - 50, Y = Y + 50 });
                    cooldown = 200;
                }
            });
            AddUpdate(new DestroyIfLeftBehind(this));
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }
}
