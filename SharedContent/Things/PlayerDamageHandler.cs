using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class PlayerDamageHandler : UpdateHandler
    {
        public int damageCooldown;
        private readonly Game1 Game1;
        private readonly Action<Player, Collider, Collider> OnHit;
        private readonly Action<Player, Collider, Collider> OnKill;
        public int damageTaken = 0;
        public int HEALTH = 3;
        private readonly Color DamageColor;
        public bool CausesSleep = true;

        public PlayerDamageHandler(Game1 Game1, Color DamageColor, Action<Player, Collider, Collider> OnHit, Action<Player, Collider, Collider> OnKill)
        {
            this.DamageColor = DamageColor;
            this.Game1 = Game1;
            this.OnHit = OnHit;
            this.OnKill = OnKill;
        }

        public void CollisionHandler(Collider source, Collider t)
        {
            var sourceIsNotPlayerFireball =
                    (
                        (source.Parent is FireBall) == false
                        || ((source.Parent as FireBall).Owner is Player) == false
                    );

            if (
                (
                    t is AttackCollider
                    && t.Parent is Player
                    && sourceIsNotPlayerFireball
                )
                ||
                (
                    t.Parent is FireBall
                    && (t.Parent as FireBall).Owner is Player
                    && sourceIsNotPlayerFireball
                )
            )
            {
                if (t.Parent is MagicProjectile)
                    t.Parent.Destroy();

                if (damageCooldown > 0)
                    return;

                Player player = GetPlayerFromCollider(t);

                Game1.VibrationCenter.Vibrate(player.Inputs, 10, 0.25f);

                damageCooldown = 20;

                if (player.weaponType == WeaponType.Sword)
                    damageTaken += 3;
                else if (player.weaponType == WeaponType.Whip)
                    damageTaken += 2;
                else if (player.weaponType == WeaponType.Wand)
                    damageTaken += 1;

                if (CausesSleep)
                    Game1.Sleep();
                Game1.Camera.ShakeUp(20);

                if (Dead())
                {
                    OnKill(player, source, t);
                    source.Parent.Destroy();
                }
                else
                {
                    OnHit(player, source, t);
                }
            }

        }

        public bool Dead()
        {
            return damageTaken >= HEALTH;
        }

        private Player GetPlayerFromCollider(Collider t)
        {
            if (t.Parent is Player)
                return t.Parent as Player;
            else if (t.Parent is FireBall && (t.Parent as FireBall).Owner is Player)
                return (t.Parent as FireBall).Owner as Player;
            return null;
        }

        public void Update()
        {
            if (damageCooldown > 0)
                damageCooldown--;
        }
    }
}