using System;
using GameCore;

namespace MonoGameProject
{
    public class AfectedByGravity : UpdateHandler
    {
        public const int FORCE = 5;
        public const int MAX_SPEED = 150;
        private readonly Thing Parent;

        public AfectedByGravity(Thing Parent)
        {
            this.Parent = Parent;
        }

        public void Update()
        {
            Parent.VerticalSpeed += FORCE;
            if (Parent.VerticalSpeed > MAX_SPEED)
                Parent.VerticalSpeed = MAX_SPEED;
        }
    }
}
