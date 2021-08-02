using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
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

namespace IsDisableUnloadTabItemContent_Sample
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

        private void tab1_Unloaded(object sender, RoutedEventArgs e)
        {
            // This event will trigger while selecting "DockTabItem2", if the property IsDisableUnloadTabItemContent is false.
        }

        private void tab2_Unloaded(object sender, RoutedEventArgs e)
        {
            // This event will trigger while selecting "DockTabItem1", if the property IsDisableUnloadTabItemContent is false.
        }
    }
}
