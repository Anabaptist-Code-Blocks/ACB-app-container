using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Webkit;

namespace ACB;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
        LoadApplication(new App());

        WebView webView = FindViewById<WebView>(Resource.Id.webview);
        webView.SetWebViewClient(new CustomWebViewClient());
    }

    private class CustomWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            string url = request.Url.ToString();
            if (!url.StartsWith("https://codeblocks.olivetree.software/"))
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(url);
                Intent intent = new Intent(Intent.ActionView, uri);
                view.Context.StartActivity(intent);
                return true;
            }

            return false;
        }
    }
}
