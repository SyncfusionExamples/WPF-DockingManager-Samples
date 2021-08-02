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
            this.DockingManager1.Loaded += DockingManager1_Loaded;
        }
        #endregion

        #region Events

        string panelname; 


        /// <summary>
        /// This event will raise when DockingManager is loaded
        /// </summary>
        void DockingManager1_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (SidePanel panel in VisualUtils.EnumChildrenOfType(DockingManager1, typeof(SidePanel)))
            {
                if (panel.Name == "PART_LeftPanel")
                {
                    panel.PreviewMouseDown += Panel_PreviewMouseDown;   
                }
                else if (panel.Name == "PART_RightPanel")
                {
                    panel.PreviewMouseDown += Panel_PreviewMouseDown;   
                }
                else if(panel.Name == "PART_BottomPanel")
                {
                    panel.PreviewMouseDown += Panel_PreviewMouseDown;   
                }
            }
        }

        /// <summary>
        /// This event will be raised when Mouse button is pressed.
        /// </summary>
        private void Panel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            panelname =  (sender as SidePanel).Name;
            Point point = new Point();
            if (e is MouseEventArgs)
                point = (e as MouseEventArgs).GetPosition(this);
            HitTestResult hitTest = VisualTreeHelper.HitTest(this, point);

            if (hitTest != null)
            {
                FrameworkElement visualHit = hitTest.VisualHit as FrameworkElement;

                if (null != visualHit)
                {
                    DependencyObject templatedParent = visualHit.TemplatedParent;

                    if (null != templatedParent
                        && (templatedParent is ContentPresenter) || (templatedParent is TabItem))
                    {
                        switch(panelname)
                        {
                            case "PART_LeftPanel":
                                DockingManager.SetState(this.leftpanel, DockState.Dock);
                                break;
                            case "PART_RightPanel":
                                DockingManager.SetState(this.rightpanel, DockState.Dock);
                                break;
                            case "PART_BottomPanel":
                                DockingManager.SetState(this.bottompanel, DockState.Dock);
                                break;
                        }
                    }
                }
            }
        }

        #endregion
    }
}

