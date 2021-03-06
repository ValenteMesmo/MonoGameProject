﻿using System;

namespace GameCore
{
    public interface InputChecker : UpdateHandler
    {
        bool Left { get; }
        bool Right { get; }
        bool Up { get; }
        bool Down { get; }
        bool Action { get; }
        bool Jump { get; }

        int ControllerIndex { get; }

        void HandleVibrations(VibrationInfo info);
    }
}

