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
                X = 1000,
                Y = -510,
                Width = 6000,
                Height = 4000
            };

            rightCollider.AddLeftCollisionHandler(StoreTheMovementCause);
            rightCollider.AddRightCollisionHandler(StoreTheMovementCause);
            rightCollider.AddTopCollisionHandler(StoreTheMovementCause);
            rightCollider.AddBotCollisionHandler(StoreTheMovementCause);

            AddCollider(rightCollider);

            AddUpdate(t =>
            {
                if (MovingRightBy != null && MovingRightBy.HorizontalSpeed > 0)
                    WorldSpeed = MovingRightBy.HorizontalSpeed;
            });
            AddUpdate(t => MovingRightBy = null);
        }

        private void CreateLeftCollider()
        {
            var leftCollider = new Collider
            {
                X = -7000,
                Y = -510,
                Width = 6000,
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
