using GameCore;

namespace MonoGameProject
{
    public class MoveLeftOrRight : UpdateHandler
    {
        PlayerInputs InputRepository;
        private const int velocity = 3;
        private const int INVERSE_BONUS = velocity * 5;
        private readonly Player Parent;

        public MoveLeftOrRight(
            Player Parent
            , PlayerInputs InputRepository)
        {
            this.Parent = Parent;
            this.InputRepository = InputRepository;
        }

        public void Update()
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
