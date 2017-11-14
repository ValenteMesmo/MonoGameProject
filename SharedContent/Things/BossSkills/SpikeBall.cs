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
        public SpikeBall(Boss Boss)
        {
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

            var anim = GeneratedContent.Create_knight_spike_dropped(
                -size / 4
                , -size / 6,
                size,
                size);
            anim.RenderingLayer = Boss.RIGHT_ARM_Z - 0.001f;
            anim.ColorGetter = GameState.GetColor;
            AddAnimation(anim);
            X = Boss.facingRight ? X + 1000 : X - 200;
            Y = Y - 1200;

            collider.AddBotCollisionHandler(StopsWhenHitting.Bot<BlockVerticalMovement>());
            collider.AddLeftCollisionHandler(StopsWhenHitting.Left<BlockHorizontalMovement>());
            collider.AddRightCollisionHandler(StopsWhenHitting.Right<BlockHorizontalMovement>());
            collider.AddTopCollisionHandler(StopsWhenHitting.Top<BlockVerticalMovement>());
            var speed = 40;

            var mod = Boss.facingRight ? -1 : 1;
            VerticalSpeed = speed;

            collider.AddBotCollisionHandler((s, t) =>
            {
                if (t is GroundCollider)
                {
                    VerticalSpeed = 0;
                    HorizontalSpeed = speed * mod;
                }
            });
            collider.AddRightCollisionHandler((s, t) =>
            {
                if (t is GroundCollider)
                {
                    VerticalSpeed = -speed * mod;
                    HorizontalSpeed = 0;
                }
            });
            collider.AddTopCollisionHandler((s, t) =>
            {
                if (t is GroundCollider)
                {
                    VerticalSpeed = 0;
                    HorizontalSpeed = -speed * mod;
                }
            });
            collider.AddLeftCollisionHandler((s, t) =>
            {
                if (t is GroundCollider)
                {
                    VerticalSpeed = speed * mod;
                    HorizontalSpeed = 0;
                }
            });

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            var duration = 1000;
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
