using Microsoft.UI.Xaml;
using Microsoft.Web.WebView2.Core;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebView2Sample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            myWebView2_InitializeAsync();
        }

        private async void myWebView2_InitializeAsync()
        {
            await myWebView2.EnsureCoreWebView2Async();
            if (myWebView2.CoreWebView2 != null)
            {
                myWebView2.CoreWebView2.SetVirtualHostNameToFolderMapping(
                    "appassets.example", "AppAssets", CoreWebView2HostResourceAccessKind.DenyCors);
                myWebView2.Source = new Uri("https://appassets.example/res/html/index.html");
            }
        }
    }
}
