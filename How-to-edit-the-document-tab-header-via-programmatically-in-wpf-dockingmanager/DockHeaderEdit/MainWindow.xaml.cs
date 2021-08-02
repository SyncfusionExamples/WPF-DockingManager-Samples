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

namespace DockHeaderEdit
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
			(docking.DocContainer as DocumentContainer).Loaded += DocumentContainer_Loaded;
		}

		//Instance
		DocumentTabControl tabcontrol;
		TabLayoutPanel tab1;
		private void DocumentContainer_Loaded(object sender, RoutedEventArgs e)
		{
			tab1 = VisualUtils.FindDescendant(docking as Visual, typeof(TabLayoutPanel)) as TabLayoutPanel;
			tabcontrol = VisualUtils.FindDescendant(docking as Visual, typeof(DocumentTabControl)) as DocumentTabControl;
		}

		private void CustomMenuItem_Click(object sender, RoutedEventArgs e)
		{
			//For Edit Header
			MethodInfo method1 = tab1.GetType().GetMethod("LabelEditStartInternal", BindingFlags.NonPublic | BindingFlags.Instance);
			method1.Invoke(tab1, new object[] { tabcontrol.SelectedItem });

		}
		
	}
}
