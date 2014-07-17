using System.Windows;
using System.Windows.Navigation;
using Microsoft.PowerShell.Host.ISE;
using System;

namespace ScriptGalleryISEAddOn
{
    public partial class ScriptGallery : IAddOnToolHostObject
    {
        public ScriptGallery()
        {
            InitializeComponent();
        }

        // Populated by the ISE because we implement the IAddOnToolHostObject interface.
        // Represents the entry-point to the ISE object model.
        public ObjectModelRoot HostObject { get; set; }


        private void FowardButtonClick(object sender, RoutedEventArgs e)
        {
            MyWebBrowser.GoForward();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MyWebBrowser.GoBack();
        }

        private void BrowserOnNavigated(object sender, NavigationEventArgs e)
        {
            BackButton.IsEnabled = MyWebBrowser.CanGoBack;
            ForwardButton.IsEnabled = MyWebBrowser.CanGoForward;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileName = HostObject.CurrentPowerShellTab.Files.SelectedFile.FullPath;
            Clipboard.SetData(DataFormats.Text, (Object)fileName);
            MessageBox.Show("File Name copied to clipboard");
        }
    }
}