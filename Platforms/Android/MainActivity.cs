﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;

namespace ACB;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
    {
        if (keyCode == Keycode.Back)
        {
            var web = MainPage.webview.Handler.PlatformView as Android.Webkit.WebView;
            if (web.CanGoBack())
            {
                web.GoBack();
                return true;
            }
        }
        return base.OnKeyDown(keyCode, e);
    }
}