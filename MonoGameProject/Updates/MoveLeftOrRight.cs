using GameCore;

namespace MonoGameProject
{
    public class MoveWhenWalking : UpdateHandler
    {
        private const int VELOCITY = 3;
        private const int INVERSE_BONUS = VELOCITY * 5;
        private readonly ThingWithState Player;
        public const int MAX_SPEED = 80;
        public const int MAX_CROUCH_SPEED = 40;

        public MoveWhenWalking(
            ThingWithState Player)
        {
            this.Player = Player;
        }

        public void Update()
        {
            if (Player.State == PlayerState.crouchingLeft
                || Player.State == PlayerState.crouchingRight)
                if (Player.roofChecker.Colliding && Player.Inputs.ClickedJump)
                    NewMethod(0, MAX_CROUCH_SPEED, MAX_CROUCH_SPEED);
                else
                    return;
            else
                NewMethod(INVERSE_BONUS, VELOCITY, MAX_SPEED);
        }

        private void NewMethod(int inverseBonus, int velocity, int speedLimit)
        {
            if (Player.Inputs.LeftDown)
            {
                if (Player.HorizontalSpeed > inverseBonus)
                    Player.HorizontalSpeed -= inverseBonus;
                Player.HorizontalSpeed -= velocity;
            }
            else if (Player.Inputs.RightDown)
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
