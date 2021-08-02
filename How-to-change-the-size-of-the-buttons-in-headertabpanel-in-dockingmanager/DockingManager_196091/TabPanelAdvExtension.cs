using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace DockingManager_196091
{
    public class TabPanelAdvExtension
    {
        private static DocumentContainer container = null;
        private static Size value;
        private static DockingManager manager = null;
        public static Size GetCloseButtonSize(DependencyObject obj)
        {
            return (Size)obj.GetValue(CloseButtonSizeProperty);
        }

        public static void SetCloseButtonSize(DependencyObject obj, Size value)
        {
            obj.SetValue(CloseButtonSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for CloseButtonSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseButtonSizeProperty =
            DependencyProperty.RegisterAttached("CloseButtonSize", typeof(Size), typeof(TabPanelAdvExtension), new PropertyMetadata(new Size(6, 8)));

        public static Size GetMenuButtonSize(DependencyObject obj)
        {
            return (Size)obj.GetValue(MenuButtonSizeProperty);
        }

        public static void SetMenuButtonSize(DependencyObject obj, Size value)
        {
            obj.SetValue(MenuButtonSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for MenuButtonSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuButtonSizeProperty =
            DependencyProperty.RegisterAttached("MenuButtonSize", typeof(Size), typeof(TabPanelAdvExtension), new PropertyMetadata(new Size(6, 8)));

        public static Size GetTabButtonSize(DependencyObject obj)
        {
            return (Size)obj.GetValue(TabButtonSizeProperty);
        }

        public static void SetTabButtonSize(DependencyObject obj, Size value)
        {
            obj.SetValue(TabButtonSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for PreviousTabButtonSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabButtonSizeProperty =
            DependencyProperty.RegisterAttached("TabButtonSize", typeof(Size), typeof(TabPanelAdvExtension), new PropertyMetadata(new Size(6, 8), new PropertyChangedCallback(OnTabButtonSizeChanged)));
        private static void OnTabButtonSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            manager = d as DockingManager;
            (manager.DocContainer as DocumentContainer).Loaded += Dockingmanager_Loaded;
            value = (Size)e.NewValue;
        }

        private static void Dockingmanager_Loaded(object sender, RoutedEventArgs e)
        {
            container = sender as DocumentContainer;
            if (container != null)
                TabPanelAdvExtension.UpdateButtonSize(manager, container, value);
        }

        public static void UpdateButtonSize(DockingManager manager, DocumentContainer container, Size size)
        {
            TabControlExt tab = VisualUtils.FindDescendant(container as Visual, typeof(DocumentTabControl)) as TabControlExt;

            if (tab != null)
            {
                TabPanelAdv tabpanel = tab.Template.FindName("PART_TabPanel", tab) as TabPanelAdv;

                if (tabpanel != null)
                {
                    Border border = tabpanel.Template.FindName("Bord", tabpanel) as Border;
                    if (border != null)
                    {
                        Decorator decorator = border.Child as Decorator;
                        DockPanel panel = null;
                        if (decorator == null)
                        {
                            panel = border.Child as DockPanel;
                        }
                        else if (decorator.Child is DockPanel)
                        {
                            panel = decorator.Child as DockPanel;
                        }

                        foreach (var child in panel.Children)
                        {
                            if (typeof(Button) == child.GetType())
                            {
                                Button button = tabpanel.Template.FindName((child as Button).Name, tabpanel) as Button;
                                if (button != null && button.Visibility != Visibility.Collapsed)
                                    ChangeTabButtonSize(button, size);
                            }
                            else if (typeof(ToggleButton) == child.GetType())
                            {
                                ToggleButton togglebutton = tabpanel.Template.FindName((child as ToggleButton).Name, tabpanel) as ToggleButton;
                                Path buttonpath = togglebutton.Template.FindName("pathButton", togglebutton) as Path;
                                if (buttonpath != null && togglebutton.Name == "PART_CloseButton")
                                {
                                    buttonpath.Width = (TabPanelAdvExtension.GetCloseButtonSize(manager)).Width;
                                    buttonpath.Height = (TabPanelAdvExtension.GetCloseButtonSize(manager)).Height;
                                }
                                else if (buttonpath != null && togglebutton.Name == "PART_MenuButton")
                                {
                                    buttonpath.Width = (TabPanelAdvExtension.GetMenuButtonSize(manager)).Width;
                                    buttonpath.Height = (TabPanelAdvExtension.GetMenuButtonSize(manager)).Height;
                                }
                            }
                        }
                    }
                }
            }
        }
        private static void ChangeTabButtonSize(Button button, Size size)
        {
            Canvas canvas = button.Template.FindName("canvas", button) as Canvas;
            if (canvas != null)
            {
                canvas.Height = size.Height;
                canvas.Width = size.Width;
                foreach (Path path in canvas.Children)
                {
                    path.Stretch = Stretch.Fill;
                    path.Width = size.Width;
                    path.Height = size.Height;
                }
            }
        }
    }
}
