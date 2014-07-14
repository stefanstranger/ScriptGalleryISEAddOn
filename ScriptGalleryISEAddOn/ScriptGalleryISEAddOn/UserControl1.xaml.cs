using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.PowerShell.Host.ISE;

namespace ScriptGalleryISEAddOn
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ScriptGallery : UserControl, IAddOnToolHostObject
    {
        public ScriptGallery()
        {
            InitializeComponent();
        }

        // Populated by the ISE because we implement the IAddOnToolHostObject interface.
        // Represents the entry-point to the ISE object model.
        public ObjectModelRoot HostObject
        {
            get;
            set;
        }
    }
}
