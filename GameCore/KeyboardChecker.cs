using System;
using Microsoft.Xna.Framework.Input;

namespace GameCore
{
    public class KeyboardChecker : InputChecker
    {
        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Action { get; private set; }
        public bool Jump { get; private set; }
        public int ControllerIndex { get; }

        public void HandleVibrations(VibrationInfo info)
        {
        }

        public void Update()
        {
            var keyboard = Keyboard.GetState();

            Left = keyboard.IsKeyDown(Keys.A)
                    || keyboard.IsKeyDown(Keys.Left)
                    ;

            Right = keyboard.IsKeyDown(Keys.D)
                || keyboard.IsKeyDown(Keys.Right)
                ;

            Jump = keyboard.IsKeyDown(Keys.W)
                || keyboard.IsKeyDown(Keys.Up)
                ;

            Down = keyboard.IsKeyDown(Keys.S)
                || keyboard.IsKeyDown(Keys.Down)
                ;

            Action = keyboard.IsKeyDown(Keys.J)
                || keyboard.IsKeyDown(Keys.LeftControl)
                ;

            Up = keyboard.IsKeyDown(Keys.K)
                || keyboard.IsKeyDown(Keys.Space)
                ;
        }
    }

    public class MirroredKeyboardChecker : InputChecker
    {
        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Action { get; private set; }
        public bool Jump { get; private set; }
        public int ControllerIndex { get; private set; }

        public void HandleVibrations(VibrationInfo info)
        {
        }

        public void Update()
        {
            var keyboard = Keyboard.GetState();

            Right = keyboard.IsKeyDown(Keys.A)
                    || keyboard.IsKeyDown(Keys.Left)
                    ;

            Left = keyboard.IsKeyDown(Keys.D)
                || keyboard.IsKeyDown(Keys.Right)
                ;

            Jump = keyboard.IsKeyDown(Keys.W)
                || keyboard.IsKeyDown(Keys.Up)
                ;

            Down = keyboard.IsKeyDown(Keys.S)
                || keyboard.IsKeyDown(Keys.Down)
                ;

            Action = keyboard.IsKeyDown(Keys.J)
                || keyboard.IsKeyDown(Keys.LeftControl)
                ;

            Up = keyboard.IsKeyDown(Keys.K)
                || keyboard.IsKeyDown(Keys.Space)
                ;
        }
    }

}

