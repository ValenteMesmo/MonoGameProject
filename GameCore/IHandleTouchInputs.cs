using Microsoft.Xna.Framework;
using System;

namespace GameCore
{
    public class TouchAreas : BaseRectangle
    {
        private Vector2? WasTouching;
        //public Action TouchContinue = () => { };
        //public Action TouchBegin = () => { };
        //public Action TouchEnded = () => { };

        public bool IsPressed()
        {
            return WasTouching != null;
        }

        public Vector2? GetTouchPoint()
        {
            return WasTouching;
        }

        internal void SetTouch(Vector2? IsTouching)
        {
            //if (WasTouching && !IsTouching)
            //    TouchEnded();
            //else if (!WasTouching && IsTouching)
            //    TouchBegin();
            //else if (WasTouching && IsTouching)
            //    TouchContinue();

            WasTouching = IsTouching;
        }
    }
}
