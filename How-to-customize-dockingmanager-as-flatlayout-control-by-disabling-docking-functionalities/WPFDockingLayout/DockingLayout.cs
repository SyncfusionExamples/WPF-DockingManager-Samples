using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.Windows.Media;

namespace WPFDockingLayout
{
    public class DockingLayout : DependencyObject
    {

        public static bool GetEnableFlatLayout(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableFlatLayoutProperty);
        }

        public static void SetEnableFlatLayout(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableFlatLayoutProperty, value);
        }

        // Using a DependencyProperty as the backing store for EnableFlatLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableFlatLayoutProperty =
            DependencyProperty.RegisterAttached("EnableFlatLayout", typeof(bool), typeof(DockingLayout), new PropertyMetadata(false,OnEnableLayoutChanged));

        private static void OnEnableLayoutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var docking = d as DockingManager;

            if (docking != null)
            {
                if ((bool)e.NewValue)
                {
                    docking.AutoHideVisibility = false;
                    docking.IsContextMenuButtonVisible = false;
                    docking.CollapseDefaultContextMenuItems = true;
                    docking.IsContextMenuVisible = false;
                    docking.TabGroupEnabled = false;
                    docking.ShowTabItemContextMenu = false;
                    docking.ShowTabListContextMenu = false;                    
                    docking.DocumentCloseButtonType = CloseButtonType.Hide;

                    docking.Loaded += (args, s) =>
                    {
                        if (GetEnableFlatLayout(docking))
                        {
                            foreach (var child in docking.Children)
                            {
                                var depChild = child as DependencyObject;
                                if (depChild != null)
                                {
                                    DockingManager.SetCanClose(depChild, false);
                                    DockingManager.SetCanFloat(depChild, false);

                                    if (DockingManager.GetSideInDockedMode(depChild) == DockSide.Bottom || DockingManager.GetSideInDockedMode(depChild) == DockSide.Top)
                                        DockingManager.SetCanResizeHeightInDockedState(depChild, false);
                                    else if (DockingManager.GetSideInDockedMode(depChild) == DockSide.Right || DockingManager.GetSideInDockedMode(depChild) == DockSide.Left)
                                        DockingManager.SetCanResizeWidthInDockedState(depChild, false);
                                }
                            }
                        }
                    };                   
                }
                else
                {
                    docking.AutoHideVisibility = true;
                    docking.IsContextMenuButtonVisible = true;
                    docking.CollapseDefaultContextMenuItems = false;
                    docking.IsContextMenuVisible = true;
                    docking.TabGroupEnabled = true;
                    docking.ShowTabItemContextMenu = true;
                    docking.ShowTabListContextMenu = true;
                    docking.DocumentCloseButtonType = CloseButtonType.Common;

                    foreach (var child in docking.Children)
                    {
                        var depChild = child as DependencyObject;
                        if (depChild != null)
                        {
                            DockingManager.SetCanClose(depChild, true);
                            DockingManager.SetCanFloat(depChild, true);

                            if (DockingManager.GetSideInDockedMode(depChild) == DockSide.Bottom || DockingManager.GetSideInDockedMode(depChild) == DockSide.Top)
                                DockingManager.SetCanResizeHeightInDockedState(depChild, true);
                            else if (DockingManager.GetSideInDockedMode(depChild) == DockSide.Right || DockingManager.GetSideInDockedMode(depChild) == DockSide.Left)
                                DockingManager.SetCanResizeWidthInDockedState(depChild, true);
                        }
                    }
                }
            }
        }
    }
}
