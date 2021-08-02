using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;

namespace HideDockPreview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Docking.Loaded += new RoutedEventHandler(Docking_Loaded);
        }

        void Docking_Loaded(object sender, RoutedEventArgs e)
        {
            CustomMenuItemCollection CustomMenuitem = new CustomMenuItemCollection();
            CustomMenuItem menu = new CustomMenuItem() { Header = "ReDock" };
            menu.Click += new RoutedEventHandler(menu_Click);
            CustomMenuitem.Add(menu);
            DockingManager.SetCustomMenuItems(Dock1, CustomMenuitem);
            DockingManager.SetCustomMenuItems(Dock2, CustomMenuitem);
            DockingManager.SetCustomMenuItems(Dock3, CustomMenuitem);
            DockingManager.SetCustomMenuItems(Dock4, CustomMenuitem);
            DockingManager.SetCustomMenuItems(Dock5, CustomMenuitem); 
        }

        void menu_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CustomMenuItem) != null && ((sender as CustomMenuItem).Parent as CustomContextMenu) != null && ((sender as CustomMenuItem).Parent as CustomContextMenu).TargetElement != null)
            {                
                FrameworkElement TargetElement = ((sender as CustomMenuItem).Parent as CustomContextMenu).TargetElement;                
                DockingManager.SetCanDock(TargetElement, true);
                DockingManager.SetState(TargetElement, DockState.Dock);
            }               
        }

        private void Docking_DockStateChanged(FrameworkElement sender, DockStateEventArgs e)
        {
            if (sender != null && e.NewState != DockState.Dock)
            {
                DockingManager.SetCanDock(sender, false);
            }
        }

        
    }
}
