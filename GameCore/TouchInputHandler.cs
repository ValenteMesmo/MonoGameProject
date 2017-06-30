using GameCore.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GameCore
{
    public class TouchInputHandler
    {
        private List<TouchableThing> PreviouslyTouched = new List<TouchableThing>();
        private List<TouchableThing> CurrentlyTouched = new List<TouchableThing>();

        public readonly InputRepository PlayerInputs;

        public TouchInputHandler(InputRepository PlayerInputs)
        {
            this.PlayerInputs = PlayerInputs;
        }

        public void Handle(IEnumerable<TouchableThing> Touchables)
        {
            List<Vector2> touches = GetTouches();

            var currentTouchables = Touchables.ToList();
            foreach (var item in currentTouchables)
            {
                HandleTouchable(touches, item);
            }
        }

        private List<Vector2> GetTouches()
        {
            var touches = PlayerInputs.GetTouches();

            PreviouslyTouched.Clear();
            PreviouslyTouched.AddRange(CurrentlyTouched);
            CurrentlyTouched.Clear();
            return touches;
        }

        private void HandleTouchable(List<Vector2> touches, TouchableThing item)
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
