using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GameCore
{
    public class TouchInputHandler
    {
        private List<IHandleTouchInputs> PreviouslyTouched = new List<IHandleTouchInputs>();
        private List<IHandleTouchInputs> CurrentlyTouched = new List<IHandleTouchInputs>();

        public readonly InputRepository PlayerInputs;

        public TouchInputHandler(InputRepository PlayerInputs)
        {
            this.PlayerInputs = PlayerInputs;
        }

        public void Handle(List<IHandleTouchInputs> Touchables)
        {
            List<Vector2> touches = GetTouches();

            Touchables.ForEach(item =>
                HandleTouchable(touches, item)
            );
        }

        private List<Vector2> GetTouches()
        {
            var touches = PlayerInputs.GetTouches();

            PreviouslyTouched.Clear();
            PreviouslyTouched.AddRange(CurrentlyTouched);
            CurrentlyTouched.Clear();
            return touches;
        }

        private void HandleTouchable(List<Vector2> touches, IHandleTouchInputs item)
        {
            foreach (var touch in touches)
            {
                if (item.Left() <= touch.X
                    && item.Right() >= touch.X
                    && item.Top() <= touch.Y
                    && item.Bottom() >= touch.Y)
                {
                    if (CurrentlyTouched.Contains(item) == false)
                    {
                        CurrentlyTouched.Add(item);
                    }
                }
            }

            if (PreviouslyTouched.Contains(item) == false
                && CurrentlyTouched.Contains(item) == true)
            {
                item.TouchBegin();
            }
            else if (PreviouslyTouched.Contains(item) == true
                && CurrentlyTouched.Contains(item) == true)
            {
                item.TouchContinue();
            }
            else if (PreviouslyTouched.Contains(item) == true
                && CurrentlyTouched.Contains(item) == false)
            {
                item.TouchEnded();
            }
        }
    }
}
