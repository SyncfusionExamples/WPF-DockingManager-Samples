using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MDI_TDI_ToolTip
{
    public class ToolTipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MDIWindow mdiwindow = VisualUtils.FindAncestor(value as Visual, typeof(MDIWindow)) as MDIWindow;
            if (mdiwindow != null)
            {
                return DocumentContainer.GetTabCaptionToolTip(mdiwindow.Content as DependencyObject);
            }
            else if (DockingManager.GetInternalDataContext(value as TextBlock) != null && DocumentContainer.GetTabCaptionToolTip(DockingManager.GetInternalDataContext(value as TextBlock)) != null)
            {
                TabItem tab = VisualUtils.FindAncestor(value as Visual, typeof(TabItem)) as TabItem;
                if (tab != null && tab.Content != null)
                {
                    return DocumentContainer.GetTabCaptionToolTip(tab.Content as DependencyObject);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
