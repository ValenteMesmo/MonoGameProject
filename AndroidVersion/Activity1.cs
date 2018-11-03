using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using MonoGameProject;

namespace AndroidVersion
{
    [Activity(Label = "Knight Mary"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Landscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        private Game1 game;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            game = Game1.Instance;
            Game1.Instance.BaseGame.RuningOnAndroid = true;
            SetViewFullScreen();

            Vibrator vibrator = (Vibrator)GetSystemService(VibratorService);
            game.AndroidVibrate = f => { }; //vibrator.Vibrate(f);

            game.Run();

            //Window.AddFlags( WindowManagerFlags.DrawsSystemBarBackgrounds);
            //Window.SetStatusBarColor(new Android.Graphics.Color(255,0,0));
        }

        private void SetViewFullScreen()
        {
            var view = (View)game.BaseGame.Services.GetService(typeof(View));
            view.SystemUiVisibility = (StatusBarVisibility)
                (SystemUiFlags.LayoutStable
                | SystemUiFlags.LayoutHideNavigation
                | SystemUiFlags.LayoutFullscreen
                | SystemUiFlags.HideNavigation
                | SystemUiFlags.Fullscreen
                | SystemUiFlags.ImmersiveSticky
                );

            SetContentView(view);
        }

        protected override void OnResume()
        {
            base.OnResume();
            SetViewFullScreen();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            SetViewFullScreen();
        }
    }
}

