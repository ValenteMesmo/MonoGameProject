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

        public SimpleTouchInput(TouchScreenChecker Parent ,Func<bool> GameStarted, Action Callback)
        {
            this.Parent = Parent;
            this.GameStarted = GameStarted;
            this.Callback = Callback;
            btn = new TouchAreas();
            btn.OffsetX = 450;
            btn.OffsetY = 4550;
            btn.Width = 2500;
            btn.Height = 2500;
            AddTouchArea(btn);
        }

        public void Update()
        {
            var touch = btn.GetTouchPoint();
            if (touch.HasValue)
            {
                choosen = true;
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
        private readonly TouchScreenChecker Parent;

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
        }

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
                Parent.Jump = false;
                Parent.Action = false;
                return;
            }

            Parent.Jump = touch.Value.X > btn2.CenterX() - 100;
            Parent.Action = touch.Value.X < btn2.CenterX() + 100;
        }

        private void HandleMovement()
        {
            var touch = btn.GetTouchPoint();

            if (touch.HasValue)
            {
                //touch = ChangeTouchIfSimilarToTheLast(touch.Value);

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

        //private Vector2 ChangeTouchIfSimilarToTheLast(Vector2 touch)
        //{
        //    var distanceX = Math.Abs(touch.X - lastTouch.X);
        //    var distanceY = Math.Abs(touch.Y - lastTouch.Y);

        //    var newPosition = lastTouch;

        //    if (distanceX > 200)
        //        newPosition.X = touch.X;

        //    if (distanceY > 200)
        //        newPosition.Y = touch.Y;

        //    return newPosition;
        //}
        bool previousRightValue;
        bool previousLeftValue;

        private void HandleMovementTouch(Vector2 touch)
        {
            var distanceX = touch.X - lastTouch.X;
            var distanceY = touch.Y - lastTouch.Y;

            var bonusX = 0;
            var bonusY = btn.Width / 3;

            var isOnLeftArea = touch.X <= btn.CenterX();
            var isOnRightArea = touch.X >= btn.CenterX();

            var isTryingToGoLeft = distanceX < -250;
            var isTryingToGoRight = distanceX > 250;

            var isNotTryingToChange = !isTryingToGoLeft && !isTryingToGoRight;

            if (isNotTryingToChange)
            {
                Parent.Left = previousLeftValue;
                Parent.Right = previousRightValue;
            }
            else
            {
                if (isTryingToGoRight)
                {
                    Parent.Right = true;
                    Parent.Left = false;
                }
                if (isTryingToGoLeft)
                {
                    Parent.Right = false;
                    Parent.Left = true;
                }
            }

            previousLeftValue = Parent.Left;
            previousRightValue = Parent.Right;

            if (touch.Y >= btn.CenterY() + bonusY)
            {
                Parent.Up = false;
                Parent.Down = true;
            }
            else if (touch.Y <= btn.CenterY() - bonusY)
            {
                Parent.Up = true;
                Parent.Down = false;
            }

            lastTouch = touch;
        }
    }

    public class TouchScreenChecker : InputChecker
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Action { get; set; }
        public bool Jump { get; set; }
        public int ControllerIndex { get; set; }

        TouchController controller;

        public TouchScreenChecker(
            Action<Thing> AddToWorld
            , Func<int, int, int, int, Animation> CreateDpadAnimation
            , Func<int, int, int, int, Animation> CreateActionAnimation
            , Func<bool> GameStarted
            )
        {
            controller = new SimpleTouchInput(
                this
                ,GameStarted
                , () => OnTouchControllerSelected(AddToWorld, CreateDpadAnimation, CreateActionAnimation));
            AddToWorld(controller as Thing);
        }

        private void OnTouchControllerSelected(
            Action<Thing> AddToWorld
            , Func<int, int, int, int, Animation> CreateDpadAnimation
            , Func<int, int, int, int, Animation> CreateActionAnimation)
        {
            controller.Destroy();
            controller = new InGameTouchInput(this, CreateDpadAnimation, CreateActionAnimation);
            AddToWorld(controller as Thing);
        }

        public void Update()
        {
            controller.Update();
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

