using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class ButtonStatus
    {
        public bool Pressed { get; private set; }
        public bool Tapped { get; private set; }

        public void SetPressed(bool value)
        {
            Tapped = value && !Pressed;
            Pressed = value;
        }
    }

    public class KeyBoardInput
    {
        public ButtonStatus F1 = new ButtonStatus();
        public ButtonStatus F2 = new ButtonStatus();
        public ButtonStatus F3 = new ButtonStatus();
        public ButtonStatus F4 = new ButtonStatus();
        public ButtonStatus F5 = new ButtonStatus();
        public ButtonStatus F6 = new ButtonStatus();
        public ButtonStatus F7 = new ButtonStatus();
        public ButtonStatus F8 = new ButtonStatus();
        public ButtonStatus F9 = new ButtonStatus();
        public ButtonStatus F10 = new ButtonStatus();
        public ButtonStatus F11 = new ButtonStatus();
        public ButtonStatus F12 = new ButtonStatus();

        public void Update()
        {
            var kb = Microsoft.Xna.Framework.Input.Keyboard.GetState();

            F1.SetPressed(kb.IsKeyDown(Keys.F1));
            F2.SetPressed(kb.IsKeyDown(Keys.F2));
            F3.SetPressed(kb.IsKeyDown(Keys.F3));
            F4.SetPressed(kb.IsKeyDown(Keys.F4));
            F5.SetPressed(kb.IsKeyDown(Keys.F5));
            F6.SetPressed(kb.IsKeyDown(Keys.F6));
            F7.SetPressed(kb.IsKeyDown(Keys.F7));
            F8.SetPressed(kb.IsKeyDown(Keys.F8));
        }
    }

    public static class InputWrapper
    {
        public static KeyBoardInput KeyBoard = new KeyBoardInput();
        public static void Update()
        {
            KeyBoard.Update();
        }
    }
}
