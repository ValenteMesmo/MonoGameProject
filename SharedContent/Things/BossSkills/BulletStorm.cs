using GameCore;
using MonoGameProject;

namespace SharedContent
{
    class BulletStorm : Thing
    {
        public BulletStorm(Game1 Game1, Boss Boss)
        {
            var duration = 50;

            var MAX = 50;
            var MIN = 4;

            var hspeed = 0;
            var vspeed = MAX;
            var hvelocity = MIN;
            var vvelocity = -MIN;

            AddUpdate(() =>
            {
                if (duration % 3 == 0)
                {
                    Game1.AddToWorld(
                        new FireBall(
                            this
                            , hspeed
                            , vspeed
                            , Game1
                        )
                        {
                            X = Boss.X + (Boss.facingRight ? 600 : 0),
                            Y = Boss.Y - 600,
                            ColorGetter = GameState.GetColor
                        }
                    );
                }

                vspeed += vvelocity;
                hspeed += hvelocity;

                if (vspeed >= MAX)
                {
                    vvelocity = -MIN;
                }
                if (vspeed <= -MAX)
                {
                    vvelocity = MIN;
                }

                if (hspeed >= MAX)
                {
                    hvelocity = -MIN;
                }
                if (hspeed <= -MAX)
                {
                    hvelocity = MIN;
                }

                duration--;
                if (duration == 0 || Boss.PlayerDamageHandler.Dead())
                {
                    Destroy();
                }
            });
        }
    }
}
