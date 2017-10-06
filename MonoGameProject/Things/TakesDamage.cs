using GameCore;
using System;

namespace MonoGameProject
{
    public class TakesDamage : UpdateHandler
    {
        private const int DAMAGE_DURATION = 100;
        private readonly Humanoid Parent;
        private readonly Game1 Game1;
        private readonly Action<Thing> AddToTheWorld;

        public TakesDamage(
            Humanoid Parent
            , Game1 Game1
            , Action<Thing> AddToTheWorld)
        {
            this.Parent = Parent;
            this.Game1 = Game1;
            this.AddToTheWorld = AddToTheWorld;
            Parent.MainCollider.AddBotCollisionHandler(HandleFireball);
            Parent.MainCollider.AddTopCollisionHandler(HandleFireball);
            Parent.MainCollider.AddLeftCollisionHandler(HandleFireball);
            Parent.MainCollider.AddRightCollisionHandler(HandleFireball);
        }

        public void HandleFireball(Collider source, Collider target)
        {
            if (target.Parent is BaseFireBall)
            {
                DefaultDamageHandler(source, target);

                target.Disabled = true;
                target.Parent.Destroy();
            }
            else if (target is AttackCollider
                || target.Parent is Spikes)
            {
                DefaultDamageHandler(source, target);
            }
        }

        private void DefaultDamageHandler(Collider source, Collider target)
        {
            if (Parent.DamageDuration == 0)
            {                
                Parent.HitPoints--;

                if (target.Parent is Player || source.Parent is Player)
                {
                    Game1.Sleep();
                    Game1.Camera.ShakeUp(40);
                    Game1.VibrationCenter.Vibrate(Parent.PlayerIndex, 20);
                }

                Parent.DamageDuration = DAMAGE_DURATION;
            }
        }

        public void Update()
        {
            if (Parent.DamageDuration > 0)
                Parent.DamageDuration--;

            if (Parent.DamageDuration == 1)
            {
                if (Parent.HitPoints <= 0)
                {
                    if (Parent is Player)
                        Game1.Restart();
                    else
                        Parent.Destroy();
                }
            }
        }
    }
}
