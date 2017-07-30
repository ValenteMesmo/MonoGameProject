using GameCore;

namespace MonoGameProject
{
    public class MoveLeftOrRight : UpdateHandler
    {
        private const int VELOCITY = 3;
        private const int INVERSE_BONUS = VELOCITY * 5;
        private readonly Humanoid Player;
        public const int MAX_SPEED = 80;
        public const int MAX_CROUCH_SPEED = 40;

        public MoveLeftOrRight(
            Humanoid Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.CrouchingLeft
                || Player.State == PlayerState.CrouchingRight)
                if (Player.roofChecker.Colliding && Player.Inputs.ClickedJump)
                    NewMethod(0, MAX_CROUCH_SPEED, MAX_CROUCH_SPEED);
                else
                    return;
            else if (Player.State == PlayerState.TakingDamage)
                return;
            else
                NewMethod(INVERSE_BONUS, VELOCITY, MAX_SPEED);
        }

        private void NewMethod(int inverseBonus, int velocity, int speedLimit)
        {
            if (Player.Inputs.Left)
            {
                if (Player.HorizontalSpeed > inverseBonus)
                    Player.HorizontalSpeed -= inverseBonus;
                Player.HorizontalSpeed -= velocity;
            }
            else if (Player.Inputs.Right)
            {
                if (Player.HorizontalSpeed < -inverseBonus)
                    Player.HorizontalSpeed += inverseBonus;
                Player.HorizontalSpeed += velocity;
            }

            if (Player.HorizontalSpeed > speedLimit)
                Player.HorizontalSpeed -= velocity;
            if (Player.HorizontalSpeed < -speedLimit)
                Player.HorizontalSpeed += velocity;
        }
    }
}
