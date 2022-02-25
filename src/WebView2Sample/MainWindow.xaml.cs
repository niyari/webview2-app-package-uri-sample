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
            await myWebView2.EnsureCoreWebView2Async(); // Wait until the components are ready.
            if (myWebView2.CoreWebView2 is not null)
            {
                // If exception handling occurs, please check "ItemGroup > Content Include" in the .csproj file.
                // Error example:
                //  Exception thrown Microsoft C++ : winrt::hresult_error
                //  System.IO.DirectoryNotFoundException: 'The system cannot find the path specified. (0x80070003)'
                myWebView2.CoreWebView2.SetVirtualHostNameToFolderMapping(
                    "appassets.example", "AppAssets", CoreWebView2HostResourceAccessKind.DenyCors);
                // <Content Include="AppAssets\res\html\index.html" />
                myWebView2.Source = new Uri("https://appassets.example/res/html/index.html");
            }
        }
    }
}
