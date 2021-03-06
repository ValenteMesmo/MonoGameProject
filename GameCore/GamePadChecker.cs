﻿using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GameCore
{
    interface TouchController
    {
        void Update();
        void Destroy();
    }

    public class SimpleTouchInput : Thing, TouchController
    {
        private readonly TouchAreas btn;
        private readonly TouchScreenChecker Parent;
        private readonly Func<bool> GameStarted;
        private readonly Action Callback;
        private bool choosen;

        public SimpleTouchInput(TouchScreenChecker Parent, Func<bool> GameStarted, Action Callback)
        {
            this.Parent = Parent;
            this.GameStarted = GameStarted;
            this.Callback = Callback;
            btn = new TouchAreas();
            btn.Width = 10000;
            btn.Height = 8000;
            AddTouchArea(btn);
        }

        public void Update()
        {
            var touch = btn.GetTouchPoint();
            if (touch.HasValue)
            {
                choosen = true;
                Parent.HandleVibrations(new VibrationInfo { PowerPercentage = 0.2f });
            }
            Parent.Action = touch.HasValue;
            if (GameStarted() && choosen)
            {
                Callback();
            }
        }
    }

    public class InGameTouchInput : Thing, TouchController
    {
        private readonly TouchAreas btn;
        private readonly TouchAreas btn2;
        Vector2 lastTouch;
        Vector2 lastTouch2;
        private readonly TouchScreenChecker Parent;

        bool wasGoingLeft;
        bool wasGoingRight;
        bool wasPressingJump;
        bool wasPressingAction;

        private readonly int smallPart;

        private readonly float rightArea;
        private readonly float leftArea;
        private readonly float downArea;
        private readonly float upArea;
        private readonly float attackArea;
        private readonly float jumpArea;

        public InGameTouchInput(
            TouchScreenChecker Parent
            , Func<int, int, int, int, Animation> CreateDpadAnimation
            , Func<int, int, int, int, Animation> CreateActionAnimation)
        {
            this.Parent = Parent;

            btn = new TouchAreas();
            btn.OffsetX = 450;
            btn.OffsetY = 4550;
            btn.Width = 2500;
            btn.Height = 2500;
            AddTouchArea(btn);
            var animationn = CreateDpadAnimation(btn.OffsetX, btn.OffsetY, btn.Width, btn.Height);
            animationn.RenderingLayer = 0.001f;
            AddAnimation(animationn);

            btn2 = new TouchAreas();
            btn2.OffsetX = 7050;
            btn2.OffsetY = 4550;
            btn2.Width = 2500;
            btn2.Height = 2500;
            AddTouchArea(btn2);
            var animationn2 = CreateActionAnimation(btn2.OffsetX, btn2.OffsetY, btn2.Width, btn2.Height);
            animationn2.RenderingLayer = 0.001f;
            AddAnimation(animationn2);

            lastTouch = new Vector2(btn.CenterX(), btn.CenterY());
            lastTouch2 = new Vector2(btn2.CenterX(), btn2.CenterY());

            smallPart = btn.Width / 6;
            rightArea = btn.CenterX() + smallPart;
            leftArea = btn.CenterX() - smallPart;
            downArea = btn.CenterY() + smallPart;
            upArea = btn.CenterY() - smallPart;

            attackArea = btn2.CenterX() - smallPart;
            jumpArea = btn2.CenterX() + smallPart;
        }

        public void Update()
        {
            HandleMovement();
            HandleJumpAndAttack();
        }

        private void HandleJumpAndAttack()
        {
            var touch = btn2.GetTouchPoint();

            if (touch.HasValue)
            {
                HandleActionTouch(touch.Value);
            }
            else
            {
                Parent.Jump = false;
                Parent.Action = false;
            }
        }

        private void HandleActionTouch(Vector2 touch)
        {
            var distanceX = touch.X - lastTouch2.X;
            var distanceXAbs = Math.Abs(distanceX);

            var isPressingJump = touch.X >= jumpArea;
            var isPressingAttack = touch.X <= attackArea;

            if (!isPressingJump && !isPressingAttack)
            {
                if (wasPressingAction)
                {
                    var shouldGoRight = distanceX > smallPart;

                    Parent.Jump = shouldGoRight;
                    Parent.Action = !shouldGoRight;
                }
                if (wasPressingJump)
                {
                    var shoudGoLeft = distanceX < -smallPart;
                    Parent.Jump = !shoudGoLeft;
                    Parent.Action = shoudGoLeft;
                }
            }
            else
            {
                Parent.Action = isPressingAttack;
                Parent.Jump = isPressingJump;
            }

            wasPressingJump = Parent.Jump;
            wasPressingAction = Parent.Action;

            lastTouch2 = touch;
        }

        private void HandleMovement()
        {
            var touch = btn.GetTouchPoint();

            if (touch.HasValue)
            {
                HandleMovementTouch(touch.Value);
            }
            else
            {
                Parent.Left = false;
                Parent.Right = false;
                Parent.Down = false;
                Parent.Up = false;
            }
        }

        private void HandleMovementTouch(Vector2 touch)
        {
            var distanceX = touch.X - lastTouch.X;
            var distanceY = touch.Y - lastTouch.Y;
            var distanceXAbs = Math.Abs(distanceX);
            var distanceYAbs = Math.Abs(distanceY);

            var isGoingRight = touch.X >= rightArea;
            var isGoingLeft = touch.X <= leftArea;
            var isGoingDown = touch.Y >= downArea;
            var isGoingUp = touch.Y <= upArea;

            if (!isGoingRight && !isGoingLeft && distanceYAbs < smallPart)
            {
                if (wasGoingLeft)
                {
                    var shouldGoRight = distanceX > smallPart;

                    Parent.Right = shouldGoRight;
                    Parent.Left = !shouldGoRight;
                }
                if (wasGoingRight)
                {
                    var shoudGoLeft = distanceX < -smallPart;
                    Parent.Right = !shoudGoLeft;
                    Parent.Left = shoudGoLeft;
                }
            }
            else
            {
                Parent.Left = isGoingLeft;
                Parent.Right = isGoingRight;
            }

            Parent.Up = isGoingUp;
            Parent.Down = isGoingDown;

            wasGoingRight = Parent.Right;
            wasGoingLeft = Parent.Left;

            lastTouch = touch;
        }
    }

    public class TouchScreenChecker : InputChecker
    {
        VibrationInfo VibrationInfo = new VibrationInfo { PowerPercentage = 0.2f };
        private bool _Left;
        private bool _Right;
        private bool _Up;
        private bool _Down;
        private bool _Action;
        private bool _Jump;

        private void VibrateOnChange(bool oldValue, bool newValue)
        {
            if ((!oldValue && newValue) || (oldValue && !newValue))
                HandleVibrations(VibrationInfo);
        }

        public bool Left
        {
            get
            {
                return _Left;
            }
            set
            {
                VibrateOnChange(_Left, value);
                _Left = value;
            }
        }

        public bool Right
        {
            get
            {
                return _Right;
            }
            set
            {
                VibrateOnChange(_Right, value);
                _Right = value;
            }
        }
        public bool Up
        {
            get
            {
                return _Up;
            }
            set
            {
                VibrateOnChange(_Up, value);
                _Up = value;
            }
        }
        public bool Down
        {
            get
            {
                return _Down;
            }
            set
            {
                VibrateOnChange(_Down, value);
                _Down = value;
            }
        }
        public bool Action
        {
            get
            {
                return _Action;
            }
            set
            {
                VibrateOnChange(_Action, value);
                _Action = value;
            }
        }
        public bool Jump
        {
            get
            {
                return _Jump;
            }
            set
            {
                VibrateOnChange(_Jump, value);
                _Jump = value;
            }
        }
        public int ControllerIndex { get; set; }

        TouchController controller;
        private readonly Game Game;

        public TouchScreenChecker(
            Game Game
            , Func<int, int, int, int, Animation> CreateDpadAnimation
            , Func<int, int, int, int, Animation> CreateActionAnimation
            , Func<bool> GameStarted
            )
        {
            this.Game = Game;
            controller = new SimpleTouchInput(
                this
                , GameStarted
                , () => OnTouchControllerSelected(CreateDpadAnimation, CreateActionAnimation));

            Game.AddToWorld(controller as Thing);
        }

        private void OnTouchControllerSelected(
             Func<int, int, int, int, Animation> CreateDpadAnimation
            , Func<int, int, int, int, Animation> CreateActionAnimation)
        {
            controller.Destroy();
            controller = new InGameTouchInput(this, CreateDpadAnimation, CreateActionAnimation);
            Game.AddToWorld(controller as Thing);
        }

        public void Update()
        {
            controller.Update();
        }

        public void HandleVibrations(VibrationInfo info)
        {
            //TODO:
            Game.AndroidVibrate(
                (int)(60f * info.PowerPercentage)
                );
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

        public void HandleVibrations(VibrationInfo info)
        {
            GamePad.SetVibration(
                  ControllerIndex
                  , info.PowerPercentage
                  , info.PowerPercentage);
        }
    }
}

