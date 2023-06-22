﻿namespace ACB;

public partial class MainPage : ContentPage
{
#if ANDROID
    public static WebView webview;
#endif
    public MainPage()
	{
		InitializeComponent();
        webView.Navigating += WebView_Navigating;
#if ANDROID
        webview = webView;
#endif
    }

    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        Uri requestedUri = new Uri(e.Url);
        Uri allowedDomain = new Uri("https://codeblocks.olivetree.software/");

        if (requestedUri.Host != allowedDomain.Host)
        {
            e.Cancel = true;
            LaunchBrowser(e.Url);
        }
    }

    private async void LaunchBrowser(string url)
    {
        if (await Launcher.CanOpenAsync(url))
        {
            await Launcher.OpenAsync(url);
        }
        else
        {
            await DisplayAlert("Error", "Unable to open the link in the default browser.", "OK");
        }
    }
}

