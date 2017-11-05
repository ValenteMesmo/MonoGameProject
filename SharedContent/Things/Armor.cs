using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class ItemChest : Thing
    {
        private readonly Action<Thing> AddToWOrld;

        public ItemChest(Game1 Game1)
        {
            this.AddToWOrld = Game1.AddToWorld;
            var offset = (int)(-MapModule.CELL_SIZE * 0.5f);
            var size = (int)(MapModule.CELL_SIZE * 1.5f);
            var collider = new Collider();
            collider.OffsetX = offset;
            collider.OffsetY = offset;
            collider.Width = size;
            collider.Height = size;
            AddCollider(collider);

            var animation = GeneratedContent.Create_knight_head_armor1(offset, offset);
            animation.RenderingLayer = 0.49f;
            animation.ScaleX = animation.ScaleY = 5;

            animation.ColorGetter = () => Color.Yellow;
            AddAnimation(animation);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));

            var PlayerDamageHandler = new PlayerDamageHandler(
                Game1
                , _ => { }
                , Hit
            );
            collider.AddHandler(PlayerDamageHandler.CollisionHandler);

            AddUpdate(PlayerDamageHandler.Update);
        }

        private void Hit(Humanoid player)
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
