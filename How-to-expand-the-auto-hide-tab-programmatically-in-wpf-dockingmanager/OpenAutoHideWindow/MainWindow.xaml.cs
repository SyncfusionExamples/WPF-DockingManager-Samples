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

namespace OpenAutoHideWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region Open Command
        /// <summary>
        /// Open Command
        /// </summary>
        private ICommand _opencommand;
        /// <summary>
        /// Command to Open the AutoHideWindow
        /// </summary>
        public ICommand OpenCommand
        {
            get
            {
                return _opencommand ?? (_opencommand = new CommandHandler(() => MyAction(), true));
            }
        }

        /// <summary>
        /// Perform action to open Auto Hidden Window
        /// </summary>
        private void MyAction()
        {
            MainHost host = VisualUtils.FindDescendant(Docking, typeof(MainHost)) as MainHost;
            if (host != null)
            {
                SidePanel leftpanel = host.Template.FindName("PART_LeftPanel", host) as SidePanel;
                SidePanel RightPanel = host.Template.FindName("PART_RightPanel", host) as SidePanel;
                SidePanel BottomPanel = host.Template.FindName("PART_BottomPanel", host) as SidePanel;
                SidePanel TopPanel = host.Template.FindName("PART_TopPanel", host) as SidePanel;

                // Call to open the Autohidden Tab
                if (leftpanel.TabChildren.Contains(MyTab))
                    leftpanel.SelectTab(MyTab);
                else if (RightPanel.TabChildren.Contains(MyTab))
                    RightPanel.SelectTab(MyTab);
                else if (BottomPanel.TabChildren.Contains(MyTab))
                    BottomPanel.SelectTab(MyTab);
                else if (TopPanel.TabChildren.Contains(MyTab))
                    TopPanel.SelectTab(MyTab);
            }
        }
        #endregion
    }

    #region Command Helper class

    /// <summary>
    /// Command Helper class
    /// </summary>
    public class CommandHandler : ICommand
	{
		private Action _action;
		public bool _excute;
		public CommandHandler(Action action, bool excute)
		{
			_action = action;
			_excute = excute;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return _excute;
		}

		public void Execute(object parameter)
		{
			_action();
		}
	}

    #endregion
}
