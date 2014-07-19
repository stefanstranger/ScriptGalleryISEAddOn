using System.Windows;
using System.Windows.Navigation;
using Microsoft.PowerShell.Host.ISE;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
// using System.Management.Automation; use for AST
// using System.Management.Automation.Language;

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
            // MessageBox.Show("File Name copied to clipboard");
        }

        private void GetScriptContent(object sender, RoutedEventArgs e)
        {
            var scriptContent = HostObject.CurrentPowerShellTab.Files.SelectedFile.Editor.Text;
            StringBuilder sb = new System.Text.StringBuilder();
            //MessageBox.Show(scriptContent,"Content");
            try
            {
                Regex regexObj = new Regex(@"^#.*?$", RegexOptions.Singleline | RegexOptions.Multiline);
                Match matchResults = regexObj.Match(scriptContent);
                while (matchResults.Success)
                {
                    // matched text: matchResults.Value
                    // match start: matchResults.Index
                    // match length: matchResults.Length
                    sb.AppendLine(matchResults.Value);
                    matchResults = matchResults.NextMatch();
                    
                }

                // MessageBox.Show(sb.ToString(),"Script Comments");
                string pattern = "(\r\n)";
                string replacement = "";
                Regex rgx = new Regex(pattern);
                string result = rgx.Replace(sb.ToString(), replacement);
                MessageBox.Show(result,"Script Comments fixed");

;

                // MessageBox.Show("Script Comments copied to clipboard");
                Clipboard.SetData(DataFormats.Text, (Object)result);
                
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
        }
    }
}