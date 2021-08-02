using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace DockingManager_196091
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GeneratingItems();
        }
                                              
        private void GeneratingItems()
        {
            for(int i = 0; i < 5; i++)
            {
                ContentControl content = new ContentControl();
                content.Content = "Content of" + dockingmanager.Children.Count;
                DockingManager.SetHeader(content, "DocumentItem" + dockingmanager.Children.Count);
                DockingManager.SetState(content, DockState.Document);
                dockingmanager.Children.Add(content);
            }           
        }
    }
}
