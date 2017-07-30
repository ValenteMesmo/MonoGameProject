using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GameCore
{
    public class InputCheckerAggregation : InputChecker
    {
        private readonly InputChecker[] InputCheckers;

        public InputCheckerAggregation(params InputChecker[] InputCheckers)
        {
            this.InputCheckers = InputCheckers;
        }

        public bool Action()
        {
            var result = false;

            foreach (var item in InputCheckers)
            {
                result = result || item.Action();
            }

            return result;
        }

        public bool Down()
        {
            var result = false;

            foreach (var item in InputCheckers)
            {
                result = result || item.Down();
            }

            return result;
        }

        public bool Jump()
        {
            var result = false;

            foreach (var item in InputCheckers)
            {
                result = result || item.Jump();
            }

            return result;
        }

        public bool Left()
        {
            var result = false;

            foreach (var item in InputCheckers)
            {
                result = result || item.Left();
            }

            return result;
        }

        public bool Right()
        {
            var result = false;

            foreach (var item in InputCheckers)
            {
                result = result || item.Right();
            }

            return result;
        }

        public bool Up()
        {
            var result = false;

            foreach (var item in InputCheckers)
            {
                result = result || item.Up();
            }

            return result;
        }

        public void Update()
        {
            foreach (var item in InputCheckers)
            {
                item.Update();
            }
        }
    }

    public class GamePadChecker : InputChecker
    {
        private readonly int index;

        public GamePadChecker(int index)
        {
            this.index = index;
        }

        public void Update()
        {
            var state = GamePad.GetState(index);

        }

        public bool Action()
        {
            throw new NotImplementedException();
        }

        public bool Down()
        {
            throw new NotImplementedException();
        }

        public bool Jump()
        {
            throw new NotImplementedException();
        }

        public bool Left()
        {
            throw new NotImplementedException();
        }

        public bool Right()
        {
            throw new NotImplementedException();
        }

        public bool Up()
        {
            throw new NotImplementedException();
        }

    }

    public interface InputChecker: UpdateHandler
    {
        bool Left();
        bool Right();
        bool Up();
        bool Down();
        bool Action();
        bool Jump();
    }

    public class RenameThisClass: UpdateHandler
    {
        private readonly InputChecker InputChecker;

        public RenameThisClass(InputChecker InputChecker)
        {
            this. InputChecker = InputChecker;
        }

        public bool ClickedLeft { get; private set; }
        public bool ClickedRight { get; private set; }
        public bool ClickedUp { get; private set; }
        public bool ClickedDown { get; private set; }
        public bool ClickedAction1 { get; private set; }
        public bool ClickedJump { get; private set; }

        private bool WasPressedLeft { get; set; }
        private bool WasPressedRight { get; set; }
        private bool WasPressedUp { get; set; }
        private bool WasPressedDown { get; set; }
        private bool WasPressedAction1 { get; set; }
        private bool WasPressedJump { get; set; }

        public bool LeftDown { get; private set; }
        public bool RightDown { get; private set; }
        public bool UpDown { get; private set; }
        public bool DownDown { get; private set; }
        public bool Action1Down { get; private set; }
        public bool JumpDown { get; private set; }

        public void Update()
        {
            InputChecker.Update();

            LeftDown = InputChecker.Left();
            RightDown = InputChecker.Right();
            UpDown = InputChecker.Up();
            DownDown = InputChecker.Down();
            Action1Down = InputChecker.Action();
            JumpDown = InputChecker.Jump();

            ClickedLeft = !WasPressedLeft && LeftDown;
            ClickedRight = !WasPressedRight && RightDown;
            ClickedUp = !WasPressedUp && UpDown;
            ClickedDown = !WasPressedDown && DownDown;
            ClickedAction1 = !WasPressedAction1 && Action1Down;
            ClickedJump = !WasPressedJump && JumpDown;

            WasPressedLeft = LeftDown;
            WasPressedRight = RightDown;
            WasPressedUp = UpDown;
            WasPressedDown = DownDown;
            WasPressedAction1 = Action1Down;
            WasPressedJump = JumpDown;
        }
    }

    public class InputRepository : PlayerInputs
    {
        private readonly Camera2d Camera2d;

        public bool ClickedLeft { get; private set; }
        public bool ClickedRight { get; private set; }
        public bool ClickedUp { get; private set; }
        public bool ClickedDown { get; private set; }
        public bool ClickedAction1 { get; private set; }
        public bool ClickedJump { get; private set; }

        private bool WasPressedLeft { get; set; }
        private bool WasPressedRight { get; set; }
        private bool WasPressedUp { get; set; }
        private bool WasPressedDown { get; set; }
        private bool WasPressedAction1 { get; set; }
        private bool WasPressedJump { get; set; }

        public bool LeftDown { get; set; }
        public bool RightDown { get; set; }
        public bool UpDown { get; set; }
        public bool DownDown { get; set; }
        public bool Action1Down { get; set; }
        public bool JumpDown { get; set; }

        public InputRepository(Camera2d Camera2d)
        {
            this.Camera2d = Camera2d;
        }

        public void Update()
        {
            SetState(Keyboard.GetState(), GamePad.GetState(0));
            SetState(TouchPanel.GetState(), Mouse.GetState());

            ClickedLeft = !WasPressedLeft && LeftDown;
            ClickedRight = !WasPressedRight && RightDown;
            ClickedUp = !WasPressedUp && UpDown;
            ClickedDown = !WasPressedDown && DownDown;
            ClickedAction1 = !WasPressedAction1 && Action1Down;
            ClickedJump = !WasPressedJump && JumpDown;

            WasPressedLeft = LeftDown;
            WasPressedRight = RightDown;
            WasPressedUp = UpDown;
            WasPressedDown = DownDown;
            WasPressedAction1 = Action1Down;
            WasPressedJump = JumpDown;
        }

        private void SetState(KeyboardState keyboard, GamePadState controller)
        {
            if (touches.Count == 0)
            {
                LeftDown =
                    (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
                    ||
                    (controller.DPad.Left == ButtonState.Pressed || controller.ThumbSticks.Left.X < -0.5f)
                    ;
                RightDown =
                    (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
                    ||
                    (controller.DPad.Right == ButtonState.Pressed || controller.ThumbSticks.Left.X > 0.5f)
                    ;
                JumpDown =
                    (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
                    ||
                    (controller.Buttons.A == ButtonState.Pressed || controller.ThumbSticks.Left.Y > 0.5f);
                DownDown =
                    (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
                    ||
                    (controller.DPad.Down == ButtonState.Pressed || controller.ThumbSticks.Left.Y < -0.5f);
                Action1Down =
                    (keyboard.IsKeyDown(Keys.J) || keyboard.IsKeyDown(Keys.LeftControl))
                    ||
                    (controller.Buttons.X == ButtonState.Pressed || controller.Buttons.B == ButtonState.Pressed);
                UpDown = (keyboard.IsKeyDown(Keys.K) || keyboard.IsKeyDown(Keys.Space))
                    ||
                    (
                        controller.DPad.Up == ButtonState.Pressed
                        || controller.ThumbSticks.Right.Y < -0.5f
                        || controller.ThumbSticks.Right.Y > 0.5f
                    );
            }
        }

        List<Vector2> touches = new List<Vector2>();
        private void SetState(TouchCollection touchCollection, MouseState mouseState)
        {
            touches.Clear();
            foreach (TouchLocation tl in touchCollection)
            {
                if ((tl.State == TouchLocationState.Pressed)
                    || (tl.State == TouchLocationState.Moved))
                {
                    touches.Add(
                        Camera2d.ToWorldLocation(tl.Position));
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed)
                touches.Add(
                    Camera2d.ToWorldLocation(mouseState.Position.ToVector2()));
        }

        public List<Vector2> GetTouches()
        {
            return touches.ToList();
        }
    }

    public class InputsSetByGamePad : UpdateHandler
    {
        private readonly GameInputs GameInputs;
        private readonly int controlIndex;

        public InputsSetByGamePad(GameInputs GameInputs, int controlIndex)
        {
            this.GameInputs = GameInputs;
            this.controlIndex = controlIndex;
        }

        public void Update()
        {
            SetState(GamePad.GetState(controlIndex));

            GameInputs.ClickedLeft = !GameInputs.WasPressedLeft && GameInputs.LeftDown;
            GameInputs.ClickedRight = !GameInputs.WasPressedRight && GameInputs.RightDown;
            GameInputs.ClickedUp = !GameInputs.WasPressedUp && GameInputs.UpDown;
            GameInputs.ClickedDown = !GameInputs.WasPressedDown && GameInputs.DownDown;
            GameInputs.ClickedAction1 = !GameInputs.WasPressedAction1 && GameInputs.Action1Down;
            GameInputs.ClickedJump = !GameInputs.WasPressedJump && GameInputs.JumpDown;

            GameInputs.WasPressedLeft = GameInputs.LeftDown;
            GameInputs.WasPressedRight = GameInputs.RightDown;
            GameInputs.WasPressedUp = GameInputs.UpDown;
            GameInputs.WasPressedDown = GameInputs.DownDown;
            GameInputs.WasPressedAction1 = GameInputs.Action1Down;
            GameInputs.WasPressedJump = GameInputs.JumpDown;
        }

        private void SetState(GamePadState controller)
        {
            GameInputs.LeftDown =
                (controller.DPad.Left == ButtonState.Pressed || controller.ThumbSticks.Left.X < -0.5f)
                ;
            GameInputs.RightDown =
                (controller.DPad.Right == ButtonState.Pressed || controller.ThumbSticks.Left.X > 0.5f)
                ;
            GameInputs.JumpDown =
                (controller.Buttons.A == ButtonState.Pressed || controller.ThumbSticks.Left.Y > 0.5f);
            GameInputs.DownDown =
                (controller.DPad.Down == ButtonState.Pressed || controller.ThumbSticks.Left.Y < -0.5f);
            GameInputs.Action1Down =
                (controller.Buttons.X == ButtonState.Pressed || controller.Buttons.B == ButtonState.Pressed);
            GameInputs.UpDown =
                (
                    controller.DPad.Up == ButtonState.Pressed
                    || controller.ThumbSticks.Right.Y < -0.5f
                    || controller.ThumbSticks.Right.Y > 0.5f
                );
        }
    }

}

