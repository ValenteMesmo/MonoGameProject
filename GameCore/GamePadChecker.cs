using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GameCore
{
    public class TouchScreenChecker : InputChecker
    {
        private readonly TouchAreas btn;
        private readonly TouchAreas btn2;

        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Action { get; private set; }
        public bool Jump { get; private set; }
        public int ControllerIndex { get; private set; }

        public TouchScreenChecker(Action<Thing> AddToWorld)
        {
            var touchController = new Thing();

            btn = new TouchAreas();
            btn.OffsetX = 450;
            btn.OffsetY = 4550;
            btn.Width = 2500;
            btn.Height = 2500;
            touchController.AddTouchArea(btn);

            btn2 = new TouchAreas();
            btn2.OffsetX = 7050;
            btn2.OffsetY = 4550;
            btn2.Width = 2500;
            btn2.Height = 2500;
            touchController.AddTouchArea(btn2);

            AddToWorld(touchController);
        }

        Vector2? lastTouch;
        public void Update()
        {
            HandleMovement();
            HandleJumpAndAttack();
        }

        private void HandleJumpAndAttack()
        {
            var touch = btn2.GetTouchPoint();
            if (touch.HasValue == false)
            {
                Jump = false;
                Action = false;
                return;
            }

            Jump = touch.Value.X > btn2.CenterX() - 100;
            Action = touch.Value.X < btn2.CenterX() + 100;
        }

        private void HandleMovement()
        {
            var distance = 250;

            var touch = btn.GetTouchPoint();
            if (touch.HasValue == false)
            {
                Left = false;
                Right = false;
                Down = false;
                Up = false;
                return;
            }

            if (touch.Value.X >= btn.CenterX() + distance)
            {
                Right = true;
                Left = false;
            }
            else if (touch.Value.X <= btn.CenterX() - distance)
            {
                Left = true;
                Right = false;
            }

            if (touch.Value.Y >= btn.CenterY() + distance)
            {
                Up = false;
                Down = true;
            }
            else if (touch.Value.Y <= btn.CenterY() - distance)
            {
                Up = true;
                Down = false;
            }

            if (lastTouch.HasValue)
            {

            }
            else
            {

            }

            lastTouch = touch;
        }
    }

    public class GamePadChecker : InputChecker
    {
        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Action { get; private set; }
        public bool Jump { get; private set; }
        public int ControllerIndex { get; private set; }

        public GamePadChecker(int ControllerIndex)
        {
            this.ControllerIndex = ControllerIndex;
        }

        public void Update()
        {
            var controller = GamePad.GetState(ControllerIndex);

            Left = controller.DPad.Left == ButtonState.Pressed
                || controller.ThumbSticks.Left.X < -0.5f;

            Right = controller.DPad.Right == ButtonState.Pressed
                || controller.ThumbSticks.Left.X > 0.5f;

            Jump = controller.Buttons.A == ButtonState.Pressed
                || controller.ThumbSticks.Left.Y > 0.5f;

            Down = controller.DPad.Down == ButtonState.Pressed
                || controller.ThumbSticks.Left.Y < -0.5f;

            Action = controller.Buttons.X == ButtonState.Pressed
                || controller.Buttons.B == ButtonState.Pressed;

            Up = controller.DPad.Up == ButtonState.Pressed
                    || controller.ThumbSticks.Right.Y < -0.5f
                    || controller.ThumbSticks.Right.Y > 0.5f;
        }
    }
}

