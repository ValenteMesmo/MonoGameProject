using GameCore;
using MonoGameProject;
using MonoGameProject.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContent.Things.BossSkills
{
    public class SpikeBall : Thing
    {
        public SpikeBall(Game1 Game1, Boss Boss)
        {
            X = Boss.facingRight ? Boss.X + 1000 : Boss.X - 200;
            Y = Boss.Y - 1200;

            var size = 1500;
            var collider = new AttackCollider
            {
                Width = size / 2 - (size / 3) / 2
                ,
                Height = size / 3 - (size / 6)
                ,
                OffsetY = size / 3 + (size / 6)
                ,
                OffsetX = (size / 3) / 4
            };
            AddCollider(collider);

            var PlayerDamageHandler = new PlayerDamageHandler(
                Game1
                , GameState.GetColor()
                , _ => { }
                , _ => { }
            );
            PlayerDamageHandler.HEALTH = 3;
            PlayerDamageHandler.CausesSleep = false;
            collider.AddHandler(PlayerDamageHandler.CollisionHandler);
            AddUpdate(PlayerDamageHandler.Update);

            var anim = GeneratedContent.Create_knight_spike_dropped(
                -size / 4
                , -size / 6,
                size,
                size);
            anim.RenderingLayer = Boss.RIGHT_ARM_Z - 0.001f;
            anim.ColorGetter = GameState.GetColor;
            AddAnimation(anim);

            var speed = 40;

            var mod = Boss.facingRight ? -1 : 1;
            VerticalSpeed = speed;


            collider.AddBotCollisionHandler(StopsWhenHitting.Bot<SomeKindOfGround>());
            collider.AddLeftCollisionHandler(StopsWhenHitting.Left<SomeKindOfGround>());
            collider.AddRightCollisionHandler(StopsWhenHitting.Right<SomeKindOfGround>());
            collider.AddTopCollisionHandler(StopsWhenHitting.Top<SomeKindOfGround>());


            collider.AddBotCollisionHandler((s, t) =>
            {
                if (t is SomeKindOfGround)
                {
                    VerticalSpeed = 0;
                    HorizontalSpeed = speed * mod;
                }
            });
            collider.AddRightCollisionHandler((s, t) =>
            {
                if (t is SomeKindOfGround)
                {
                    VerticalSpeed = -speed * mod;
                    HorizontalSpeed = 0;
                }
            });
            collider.AddTopCollisionHandler((s, t) =>
            {
                if (t is SomeKindOfGround)
                {
                    VerticalSpeed = 0;
                    HorizontalSpeed = -speed * mod;
                }
            });
            collider.AddLeftCollisionHandler((s, t) =>
            {
                if (t is SomeKindOfGround)
                {
                    VerticalSpeed = speed * mod;
                    HorizontalSpeed = 0;
                }
            });

            
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            var duration = 800;
            AddUpdate(() =>
            {
                duration--;
                if (duration <= 0)
                {
                    Destroy();
                }
            });
        }
    }
}
