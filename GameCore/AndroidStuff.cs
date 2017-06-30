using System;

namespace GameCore
{
    public static class AndroidStuff
    {
        public static Action<long> Vibrate = f => { };
        public static bool RunningOnAndroid;
    }
}
