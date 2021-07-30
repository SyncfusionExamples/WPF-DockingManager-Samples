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

namespace DockingManager_TabListContextMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (dockmgr.DocContainer as DocumentContainer).Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TabControlExt tab = VisualUtils.FindDescendant(sender as Visual, typeof(DocumentTabControl)) as TabControlExt;
            if(tab != null)
            {
                tab.TabListContextMenuItemTemplate = DocumentContainer.GetHeaderTemplate(dockmgr);
            }
        }
    }
}
