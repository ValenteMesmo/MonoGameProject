using GameCore;

namespace MonoGameProject
{
    public class MoveLeftOrRight : UpdateHandler
    {
        InputRepository InputRepository;
        public MoveLeftOrRight(InputRepository InputRepository)
        {
            this.InputRepository = InputRepository;
        }

        private const int velocity = 2;
        private const int INVERSE_BONUS = velocity*5;

        public override void Update()
        {
            if (InputRepository.LeftDown)
            {
                if (Parent.HorizontalSpeed > INVERSE_BONUS)
                    Parent.HorizontalSpeed -= INVERSE_BONUS;
                Parent.HorizontalSpeed -= velocity;
            }
            else if (InputRepository.RightDown)
            {
                if (Parent.HorizontalSpeed < -INVERSE_BONUS)
                    Parent.HorizontalSpeed += INVERSE_BONUS;
                Parent.HorizontalSpeed += velocity;
            }
        }
    }
}
