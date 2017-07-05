using GameCore;

namespace MonoGameProject
{
    public class WorldMover : Thing
    {
        public int WorldSpeed;
        private Thing MovingRightBy;
        private Thing MovingLeftBy;
        public WorldMover(Camera2d Camera)
        {
            X = (int)Camera.Pos.X;
            Y = (int)Camera.Pos.Y;

            AddUpdate(_ =>
            {
                if (MovingRightBy == null && MovingLeftBy == null)
                    WorldSpeed = 0;
            });

            CreateLeftCollider();
            CreateRightCollider();

         
        }

        private void CreateRightCollider()
        {
            var rightCollider = new Collider
            {
                X = 2000,
                Y = -500,
                Width = 4000,
                Height = 4000
            };

            rightCollider.AddLeftCollisionHandler(StoreTheMovementCause);
            rightCollider.AddRightCollisionHandler(StoreTheMovementCause);
            rightCollider.AddTopCollisionHandler(StoreTheMovementCause);
            rightCollider.AddBotCollisionHandler(StoreTheMovementCause);

            AddCollider(rightCollider);

            AddUpdate(t =>
            {
                if (MovingRightBy != null)
                    WorldSpeed = MovingRightBy.HorizontalSpeed;
                //else if (MovingLeftBy == null) WorldSpeed = 0;
            });
            AddUpdate(t => MovingRightBy = null);
        }

        private void CreateLeftCollider()
        {
            var leftCollider = new Collider
            {
                X = -6000,
                Y = -500,
                Width = 4000,
                Height = 4000
            };

            leftCollider.AddLeftCollisionHandler(StoreTheMovementCause2);
            leftCollider.AddRightCollisionHandler(StoreTheMovementCause2);
            leftCollider.AddTopCollisionHandler(StoreTheMovementCause2);
            leftCollider.AddBotCollisionHandler(StoreTheMovementCause2);

            AddCollider(leftCollider);

            AddUpdate(t =>
            {
                if (MovingLeftBy != null && MovingLeftBy.HorizontalSpeed < 0)
                    WorldSpeed = MovingLeftBy.HorizontalSpeed;
                // else if (MovingRightBy == null) WorldSpeed = 0;
            });
            AddUpdate(t => MovingLeftBy = null);
        }

        private void StoreTheMovementCause(Collider c1, Collider c2)
        {
            if (c2.Parent is Player)
                MovingRightBy = c2.Parent;
        }

        private void StoreTheMovementCause2(Collider c1, Collider c2)
        {
            if (c2.Parent is Player)
                MovingLeftBy = c2.Parent;
        }
    }
}
