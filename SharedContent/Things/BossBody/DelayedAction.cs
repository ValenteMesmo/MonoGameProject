using System;

namespace MonoGameProject
{
    public class DelayedAction
    {
        private Action action = () => { };
        private int delay;

        public void Execute(Action action, int delay)
        {
            if (this.action == action)
            {
                Update();
                return;
            }
            this.action = action;
            this.delay = delay;
        }

        private void Update()
        {
            delay--;
            if (delay <= 0)
            {
                action();
                action = () => { };
            }
        }
    }
}