namespace GameCore
{
    public class GameInputs : UpdateHandler
    {
        private readonly InputChecker InputChecker;

        public int ControllerIndex { get { return InputChecker.ControllerIndex; } }

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

        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Action { get; private set; }
        public bool JumpDown { get; private set; }

        public bool Disabled { get; set; }

        public GameInputs(InputChecker InputChecker)
        {
            this.InputChecker = InputChecker;
        }

        public void Update()
        {
            if (Disabled)
            {
                Left = false;
                Right = false;
                Up = false;
                Down = false;
                Action = false;
                JumpDown = false;
                WasPressedLeft = false;
                WasPressedRight = false;
                WasPressedUp = false;
                WasPressedDown = false;
                WasPressedAction1 = false;
                WasPressedJump = false;
                ClickedLeft = false;
                ClickedRight = false;
                ClickedUp = false;
                ClickedDown = false;
                ClickedAction1 = false;
                ClickedJump = false;
                return;
            }

            InputChecker.Update();

            Left = InputChecker.Left;
            Right = InputChecker.Right;
            Up = InputChecker.Up;
            Down = InputChecker.Down;
            Action = InputChecker.Action;
            JumpDown = InputChecker.Jump;

            ClickedLeft = !WasPressedLeft && Left;
            ClickedRight = !WasPressedRight && Right;
            ClickedUp = !WasPressedUp && Up;
            ClickedDown = !WasPressedDown && Down;
            ClickedAction1 = !WasPressedAction1 && Action;
            ClickedJump = !WasPressedJump && JumpDown;

            WasPressedLeft = Left;
            WasPressedRight = Right;
            WasPressedUp = Up;
            WasPressedDown = Down;
            WasPressedAction1 = Action;
            WasPressedJump = JumpDown;
        }
    }
}