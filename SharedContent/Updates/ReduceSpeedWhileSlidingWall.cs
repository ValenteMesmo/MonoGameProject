using GameCore;

namespace MonoGameProject
{
    public class ReduceSpeedWhileSlidingWall : UpdateHandler
    {
        private readonly Humanoid Player;
        private const int MAX = 20;

        public ReduceSpeedWhileSlidingWall(Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.LegState == LegState.SlidingWall)
                if (Player.VerticalSpeed > MAX)
                    Player.VerticalSpeed = MAX;
        }
    }
}
