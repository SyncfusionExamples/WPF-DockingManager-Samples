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

namespace DockingManager_CenterDragProvider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            docking.Loaded += Docking_Loaded;
        }

        private void Docking_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(var child in docking.Children)
            {
                DockingManager.SetDockAbility(child as DependencyObject, DockAbility.Horizontal | DockAbility.Vertical);
            }
        }
    }
}
