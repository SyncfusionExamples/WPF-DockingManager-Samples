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

using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
namespace DockingManager_155889
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
            (Docking.DocContainer as DocumentContainer).Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DocumentTabControl tabcontrol = VisualUtils.FindDescendant(Docking, typeof(DocumentTabControl)) as DocumentTabControl;
            if (tabcontrol != null)
            {
                ContentPresenter content = tabcontrol.Template.FindName("PART_SelectedContentHost", tabcontrol) as ContentPresenter;
                Border border = tabcontrol.Template.FindName("PART_ContentPanelInnerBorder", tabcontrol) as Border;
                if (border != null && !border.Margin.Equals(new Thickness(0)))
                {
                    border.Margin = new Thickness(0);
                }

                if (content != null && !content.Margin.Equals(new Thickness(0)))
                {
                    content.Margin = new Thickness(0);
                }
            }
        }       
    }
}
