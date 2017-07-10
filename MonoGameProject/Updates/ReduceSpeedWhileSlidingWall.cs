using GameCore;

namespace MonoGameProject
{
    public class ReduceSpeedWhileSlidingWall : UpdateHandler
    {
        private readonly Player Player;
        private const int MAX = 40;

        public ReduceSpeedWhileSlidingWall(Player Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.SlidingWallLeft
                || Player.State == PlayerState.SlidingWallRight)
                if (Player.VerticalSpeed > MAX)
                    Player.VerticalSpeed = MAX;

        }
    }
}
