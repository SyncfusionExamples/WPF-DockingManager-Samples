using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DockingManager_Sample_164573
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Docking_WindowResizing(object sender, WindowResizingEventArgs e)
        {
            if (sender is DockedElementTabbedHost && (sender as DockedElementTabbedHost).HostedElement != null)
            {
                string header = DockingManager.GetHeader((sender as DockedElementTabbedHost).HostedElement).ToString();
                Console.WriteLine("Resized element header and size is " + header + ", " + e.DesiredHeight + ", " + e.DesiredWidth);
            }
        }   
    }   
}
