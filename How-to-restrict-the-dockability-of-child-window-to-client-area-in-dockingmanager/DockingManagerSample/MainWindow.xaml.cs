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
           
            dockingmanager.PreviewMouseDown += Dockingmanager_PreviewMouseDown;
            dockingmanager.PreviewMouseUp += Dockingmanager_PreviewMouseUp;
            dockingmanager.PreviewMouseMove += Dockingmanager_PreviewMouseMove;            
        }       
       
        bool isMouseDown = false;
        bool isDragging = false;
        Point mouseDownPoint;
        Point mousePoint;
        DockedElementTabbedHost draggedelement = null;
        List<FrameworkElement> tabs = null;
        private void Dockingmanager_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedelement != null && tabs != null)
            {
                foreach(var element in tabs)
                {
                    if (DockingManager.GetDockAbility(element as FrameworkElement) == DockAbility.None)
                        DockingManager.SetState(element as FrameworkElement, DockState.Dock);
                    DockingManager.SetDockAbility(element as FrameworkElement, DockAbility.All);
                }                
            }

            isMouseDown = false;
            isDragging = false;                      
            tabs = null;
            draggedelement = null;
        }

        internal bool IsPointInsideElement(UIElement element)
        {
            Point pt = Mouse.GetPosition(element);
            Point point =  element.TranslatePoint(new Point(0, 0), this.dockingmanager);

            return pt.X > -5 && pt.Y > -5 && pt.X < point.X + element.RenderSize.Width && pt.Y < point.Y + element.RenderSize.Height;
        }
       
        private void Dockingmanager_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                mousePoint = e.GetPosition(e.OriginalSource as IInputElement);
                draggedelement = VisualUtils.FindAncestor(dockingmanager.ActiveWindow, typeof(DockedElementTabbedHost)) as DockedElementTabbedHost;

                if (Math.Abs(mousePoint.X - mouseDownPoint.X) > 4 || Math.Abs(mousePoint.Y - mouseDownPoint.Y) > 4)
                {
                    isDragging = true;
                }

                if (isDragging)
                {
                    if (draggedelement != null && draggedelement.TabChildren != null && draggedelement.TabChildren.Count > 0)
                    {
                        tabs = new List<FrameworkElement>(draggedelement.TabChildren);
                        if (tabs != null)
                        {
                            if (IsPointInsideElement(ClientArea))
                            {                               
                                foreach (var element in tabs)
                                {
                                    DockingManager.SetDockAbility(element as FrameworkElement, DockAbility.None);
                                }

                            }
                            else if (!IsPointInsideElement(ClientArea))
                            {                                
                                foreach (var element in tabs)
                                {
                                    DockingManager.SetDockAbility(element as FrameworkElement, DockAbility.All);
                                }
                            }
                        }
                    }
                }
            }
        }
             
        private void Dockingmanager_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;            
            mouseDownPoint = e.GetPosition(e.OriginalSource as IInputElement);
        }
    }
}
