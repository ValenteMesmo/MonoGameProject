using GameCore;
using System;

namespace MonoGameProject
{
    public class TakesDamage : UpdateHandler
    {
        private readonly Humanoid Parent;
        private readonly Game1 Game1;
        private int DamageDuration;
        private readonly Action<Thing> AddToTheWorld;

        public TakesDamage(Humanoid Parent, Game1 Game1, Action<Thing> AddToTheWorld)
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
            if (target.Parent is FireBall
                || target.Parent is WavedFireBall
                || target.Parent is SeekerFireBall)
            {
                if (Parent.LegState == LegState.TakingDamage)
                    return;

                NewMethod(source);

                Parent.HitPoints--;
                Parent.LegState = LegState.TakingDamage;
                Parent.HorizontalSpeed = target.Parent.HorizontalSpeed / 2;
                Parent.VerticalSpeed = -50;

                DamageDuration = 25;
                target.Disabled = true;
                target.Parent.Destroy();
                if (Parent is Player)
                {
                    Game1.Sleep();
                    Game1.Camera.ShakeUp(20);
                }
            }
            else if (target is AttackCollider ||
                target.Parent is Spikes)
            {
                if (Parent.LegState == LegState.TakingDamage)
                    return;

                NewMethod(source);

                Parent.HitPoints--;
                Parent.LegState = LegState.TakingDamage;
                Parent.HorizontalSpeed = target.Parent.HorizontalSpeed / 2;
                Parent.VerticalSpeed = Jump.maxJumpSpeed;

                DamageDuration = 25;
               // if (target.Parent is Player)
                {
                    Game1.Sleep();
                    Game1.Camera.ShakeUp(20);
                }

                if (Parent.HitPoints < 0 && target.Parent is Player)
                {
                    if ((target.Parent as Player).TorsoState == TorsoState.Attack
                        || (target.Parent as Player).TorsoState == TorsoState.AttackCrouching)
                    {
                        if ((target.Parent as Player).FacingRight)
                            Parent.HorizontalSpeed = +100;
                        else
                            Parent.HorizontalSpeed = -100;
                    }

                    source.Disabled = true;
                }
            }
        }

        private void NewMethod(Collider source)
        {
            AddToTheWorld(new HitEffect() { X = source.X, Y = source.Y });
        }

        public void Update()
        {
            if (Parent.LegState == LegState.TakingDamage)
            {
                DamageDuration--;
                if (DamageDuration <= 0)
                {
                    DamageDuration = 0;
                    Parent.LegState = LegState.Falling;
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
}
