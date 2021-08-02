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

namespace DockingManager_135325
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (dockingManager.DocContainer as DocumentContainer).Loaded += MainWindow_Loaded;            
        }

        DocumentTabControl documenttab = null;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            documenttab = VisualUtils.FindDescendant(sender as Visual, typeof(DocumentTabControl)) as DocumentTabControl;            
        }
       
        private void btnDisable_Click(object sender, RoutedEventArgs e)
        {
            string header = (documenttab.SelectedItem as TabItemExt).Header.ToString();
            DisableOtherTabs(header, false);               
        }

        private void DisableOtherTabs(string nameForFind, bool value)
        {
            foreach (TabItemExt element in documenttab.Items)
            {
                if (nameForFind != element.Header.ToString())
                {
                    element.IsEnabled = value;                  
                }
            }         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string header = (documenttab.SelectedItem as TabItemExt).Header.ToString();
            DisableOtherTabs(header, true);            
        }
    }
}
