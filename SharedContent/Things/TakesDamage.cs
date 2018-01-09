using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class TakesDamage : UpdateHandler
    {
        public const int DAMAGE_DURATION = 100;
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
            Parent.MainCollider.AddBotCollisionHandler(Handle);
            Parent.MainCollider.AddTopCollisionHandler(Handle);
            Parent.MainCollider.AddLeftCollisionHandler(Handle);
            Parent.MainCollider.AddRightCollisionHandler(Handle);
        }
        
        public void Handle(Collider source, Collider target)
        {

            if (target.Parent is MagicProjectile)
            {
                if (target.Parent is FireBall)
                {
                    if ((target.Parent as FireBall).Owner is Player)
                        return;
                }

                if (Parent.DamageDuration > 0)
                {
                    Game1.Camera.ShakeUp(40);
                }

                DefaultDamageHandler(source, target);
                target.Disabled = true;
                target.Parent.Destroy();
            }
            else if (target is AttackCollider)
            {
                DefaultDamageHandler(source, target);
            }
            else if (target.Parent is Spikes)
            {
                //duplicated
                Game1.Camera.ShakeUp(40);
                Game1.Sleep();
                Game1.VibrationCenter.Vibrate(Parent.Inputs, 20, 0.3f);
                //TODO: if hascolor... flash color
                Game1.ScreenFader.Flash((int)Parent.MainCollider.CenterX(), (int)Parent.MainCollider.CenterY());
                Parent.Destroy();
            }
        }

        private void DefaultDamageHandler(Collider source, Collider target)
        {
            if (target.Parent is Player && source.Parent is Player)
                return;

            if (Parent.DamageDuration == 0)
            {
                Parent.HitPoints--;
                Parent.DamageDuration = DAMAGE_DURATION;

                //duplicated
                Game1.Camera.ShakeUp(40);
                Game1.Sleep();
                Game1.VibrationCenter.Vibrate(Parent.Inputs, 20, 0.3f);
                //TODO: if hascolor... flash color
                Game1.ScreenFader.Flash((int)Parent.MainCollider.CenterX(), (int)Parent.MainCollider.CenterY());

                if (Parent.HitPoints <= 0)
                {
                    Parent.Destroy();
                }
            }
        }

        public void Update()
        {
            if (Parent.DamageDuration > 0)
                Parent.DamageDuration--;
        }
    }
}
