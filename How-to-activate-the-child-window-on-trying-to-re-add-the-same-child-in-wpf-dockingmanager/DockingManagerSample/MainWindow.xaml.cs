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

namespace DockingManagerSample
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Content.ToString();                 
            bool childexist = false;
            foreach(FrameworkElement child in docking.Children)
            {
                if(child.Name == name)
                {
                    docking.ActivateWindow(child.Name);
                    //docking.ActiveWindow = child;
                    childexist = true;
                    break;
                }
            }
            if(!childexist)
            {
                var child = new ContentControl();
                child.Name = name;
                DockingManager.SetHeader(child, name);
                DockingManager.SetState(child as FrameworkElement, DockState.Document);
                docking.Children.Add(child as FrameworkElement);
            }
        }
    }
}
