using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
			//set docking window header backcolor
			dockingmanager.HeaderBackground = Brushes.Gray;
			//set selected docking window header backcolor
			dockingmanager.SelectedHeaderBackground = Brushes.Green;
			//set docking window header for hovering
			dockingmanager.HeaderMouseOverBackground = Brushes.Yellow;
			//set docking window Header foreground color
			dockingmanager.HeaderForeground = Brushes.Red;
			//set selected docking window header fore color 
			dockingmanager.HeaderForegroundSelected = Brushes.Yellow;
			
		}
	}
}
