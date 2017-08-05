using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;
using System;

namespace MonoGameProject
{
    public class FireBall : Thing
    {
        public const int SPEED = 150;

        public FireBall(int speedX, int speedY)
        {
            var width = 400;
            var height = 400;
            var animation = GeneratedContent.Create_knight_block(
            0
            , 0
            , 0.4f
            , MapModule.CELL_SIZE
            , MapModule.CELL_SIZE
            );
            AddAnimation(
               animation
            );

            HorizontalSpeed = speedX;
            VerticalSpeed = speedY;
            AddUpdate(new DestroyIfLeftBehind(this));
            AddUpdate(new MoveHorizontallyWithTheWorld(this));

            var collider = new Collider() { Width = width, Height = height };
            Action<Collider, Collider> collisionHandler = (s, t) =>
            {
                if (t.Parent is BlockVerticalMovement)
                    Destroy();
            };
            collider.AddBotCollisionHandler(collisionHandler);
            collider.AddTopCollisionHandler(collisionHandler);
            collider.AddLeftCollisionHandler(collisionHandler);
            collider.AddRightCollisionHandler(collisionHandler);

            Action<Collider, Collider> damageHandler = (s, t) =>
            {
                if (t is AttackCollider)
                {
                    Destroy();
                }
            };
            collider.AddBotCollisionHandler(damageHandler);
            collider.AddLeftCollisionHandler(damageHandler);
            collider.AddRightCollisionHandler(damageHandler);
            collider.AddTopCollisionHandler(damageHandler);
            
            AddCollider(collider);
        }
    }
}
