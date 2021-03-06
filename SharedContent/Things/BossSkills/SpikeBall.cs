﻿using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject;
using MonoGameProject.Things;

namespace SharedContent.Things.BossSkills
{
    public class SpikeBall : BaseFireBall
    {
        public SpikeBall(Game1 Game1, Boss Boss, Color Color, bool toTheRIght) : base(Boss, Game1, Color)
        {
            X = Boss.facingRight ? Boss.X + 1000 : Boss.X - 200;
            Y = Boss.Y - 1200;

            var size = 1500;
            collider.Width = size / 2 - (size / 3) / 2;
            collider.Height = size / 3 - (size / 6);
            collider.OffsetY = size / 3 + (size / 6);
            collider.OffsetX = (size / 3) / 4;

            var anim = GeneratedContent.Create_knight_spike_dropped(
                -size / 4
                , -size / 6,
                size,
                size);
            anim.RenderingLayer = Boss.RIGHT_ARM_Z - 0.001f;
            anim.ColorGetter = () => Color;
            AddAnimation(anim);

            var speed = 60;

            var mod = toTheRIght ? -1 : 1;
            VerticalSpeed = speed;

            collider.AddBotCollisionHandler(StopsWhenHitting.Bot<SomeKindOfGround>());
            collider.AddLeftCollisionHandler(StopsWhenHitting.Left<SomeKindOfGround>());
            collider.AddRightCollisionHandler(StopsWhenHitting.Right<SomeKindOfGround>());
            collider.AddTopCollisionHandler(StopsWhenHitting.Top<SomeKindOfGround>());

            DamageHandler.OnHit += (a, s, d) =>
            {
                VerticalSpeed = -VerticalSpeed;
                HorizontalSpeed = -HorizontalSpeed;
            };

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
            var duration = 500;
            AddUpdate(() =>
            {
                duration--;
                if (duration <= 0)
                {
                    Destroy();
                }
            });
        }

        private static bool AttackedByPlayer(Collider t)
        {
            return (t.Parent is Player && t is AttackCollider);
        }
    }
}
