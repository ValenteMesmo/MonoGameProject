using System;

namespace GameCore
{
    internal static class AndroidStuff
    {
        public static Action<long> Vibrate = f => { };
        public static bool RunningOnAndroid;
    }
}
