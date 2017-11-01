using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class ItemChest : Thing
    {
        private int hitPoints = 5;
        private readonly Action<Thing> AddToWOrld;

        public ItemChest(Action<Thing> AddToWOrld)
        {
            this.AddToWOrld = AddToWOrld;
            var collider = new Collider();
            collider.Width = MapModule.CELL_SIZE;
            collider.Height = MapModule.CELL_SIZE;
            AddCollider(collider);

            var animation = GeneratedContent.Create_knight_head_armor1(-400, -200);
            animation.RenderingLayer = 0.49f;
            animation.ScaleX = animation.ScaleY = 5;

            animation.ColorGetter = () => Color.Yellow;
            AddAnimation(animation);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
            collider.AddHandler(HandleDamage);

            AddUpdate(UpdateDamageCooldown);
        }

        private void HandleDamage(Collider s, Collider t)
        {
            if (t is AttackCollider && t.Parent is Player)
            {
                Hit(t.Parent as Player);
            }
            else if (t.Parent is FireBall && (t.Parent as FireBall).Owner is Player)
            {
                Hit((t.Parent as FireBall).Owner as Player);
                t.Parent.Destroy();
            }
        }

        int damageCooldown = 0;
        private void UpdateDamageCooldown()
        {
            if (damageCooldown > 0)
                damageCooldown--;
        }

        private void Hit(Humanoid player)
        {
            if (damageCooldown > 0)
                return;

            damageCooldown = 25;

            hitPoints--;

            AddToWOrld(new HitEffect() { X = X, Y = Y });

            if (hitPoints <= 0)
            {
                Thing item = null;

                if (player.IsNotUsingHelmet())
                {
                    item = new Armor();
                }
                else
                {
                    var index = GameState.RandomTresure.Next(0, 1);
                    if (index == 0)
                    {
                        if (player.weaponType == WeaponType.Sword)
                        {
                            item = new Weapon(WeaponType.Whip);
                        }
                        else if (player.weaponType == WeaponType.Whip)
                        {
                            item = new Weapon(WeaponType.Wand);
                        }
                        else
                        {
                            item = new Weapon(WeaponType.Sword);
                        }
                    }
                    else if (index == 1)
                    {
                        if (player.weaponType == WeaponType.Sword)
                        {
                            item = new Weapon(WeaponType.Wand);
                        }
                        else if (player.weaponType == WeaponType.Whip)
                        {
                            item = new Weapon(WeaponType.Sword);
                        }
                        else
                        {
                            item = new Weapon(WeaponType.Whip);
                        }
                    }

                }

                item.X = X;
                item.Y = Y;

                AddToWOrld(item);
                Destroy();
            }
        }
    }

    public class Armor : Thing
    {
        public Color Color;
        public Armor()
        {
            var collider = new Collider();
            collider.Width = MapModule.CELL_SIZE;
            collider.Height = MapModule.CELL_SIZE;
            AddCollider(collider);

            var animation = GeneratedContent.Create_knight_head_armor1(-400, -200);
            animation.RenderingLayer = 0.49f;
            animation.ScaleX = animation.ScaleY = 5;
            Color = GameState.GetComplimentColor2();//Colors[GameState.ArmorColor.Next(0, Colors.Length - 1)];
            animation.ColorGetter = () => Color;
            AddAnimation(animation);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }

    public enum WeaponType
    {
        Sword,
        Whip,
        Wand
    }
    public class Weapon : Thing
    {
        public Color Color;
        public readonly WeaponType Type;

        public Weapon(WeaponType Type)
        {
            this.Type = Type;
            var collider = new Collider();
            collider.Width = MapModule.CELL_SIZE;
            collider.Height = MapModule.CELL_SIZE;
            AddCollider(collider);

            var animation = GeneratedContent.Create_knight_head_face(-400, -200);
            animation.RenderingLayer = 0.49f;
            animation.ScaleX = animation.ScaleY = 5;
            Color = GameState.GetComplimentColor2();
            animation.ColorGetter = () => Color;
            AddAnimation(animation);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }
}
