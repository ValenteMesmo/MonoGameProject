using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class FireBall : Thing
    {
        public FireBall(int speedX, int speedY)
        {
            var width = 400;
            var height = 400;
            AddAnimation(
                new Animation(
                    new AnimationFrame("block", 0, 0, width, height) { RenderingLayer = 0.4f })
                {
                    Color = Color.Yellow
                });

            AddUpdate(() => X += speedX);
            AddUpdate(() => Y += speedY);
            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            var collider = new Collider() { Width = width, Height = height };
            Action<Collider, Collider> collisionHandler = (s, t) => { if (t.Parent is IBlockPlayerMovement) Destroy(); };
            collider.AddBotCollisionHandler(collisionHandler);
            collider.AddTopCollisionHandler(collisionHandler);
            collider.AddLeftCollisionHandler(collisionHandler);
            collider.AddRightCollisionHandler(collisionHandler);
            AddCollider(collider);
        }
    }
}
