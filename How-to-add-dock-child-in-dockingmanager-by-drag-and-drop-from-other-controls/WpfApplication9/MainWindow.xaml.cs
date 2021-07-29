using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApplication9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<MainWindow> windowlist = new List<MainWindow>();

        private Point startPoint = new Point();
        private ObservableCollection<ListViewWorkItem> Items = new ObservableCollection<ListViewWorkItem>();
        private int startIndex = -1;

        bool isdragenter;

        public MainWindow()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            // Clear data
            lstView.Items.Clear();
            Items.Clear();
            // Add rows
            Items.Add(new ListViewWorkItem(" Document 1", "Document 1 From ListView"));
            Items.Add(new ListViewWorkItem("Document 2", "Document 2 From ListView"));
            Items.Add(new ListViewWorkItem("Document 3", "Document 3 From ListView"));
            lstView.ItemsSource = Items;
        }

        // Helper to search up the VisualTree
        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        /// <summary>
        /// Invoked when the Mouse LeftButton down on ListView
        /// </summary>
        private void lstView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get current mouse position
            startPoint = e.GetPosition(null);
        }

        /// <summary>
        /// Strores ListView Item
        /// </summary>
        ListViewWorkItem item;

        /// <summary>
        /// Invoked when the Drag entered into ListView
        /// </summary>
        private void lstView_DragEnter(object sender, DragEventArgs e)
        {
            ListView listView = sender as ListView;
            ListViewItem listViewItem = FindAnchestor<ListViewItem>((DependencyObject)e.OriginalSource);
            if (listViewItem == null || isdragenter)
            {
                e.Effects = DragDropEffects.None;
                return;
            }
            // Find the data behind the ListViewItem
            item = (ListViewWorkItem)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

            if (!e.Data.GetDataPresent("WorkItem") || sender != e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
            isdragenter = true;
        }

        /// <summary>
        /// Invoked when the Mouse Drop on ListView
        /// </summary>
        private void lstView_Drop(object sender, DragEventArgs e)
        {
            int index = -1;

            if (e.Data.GetDataPresent("WorkItem") && sender == e.Source)
            {
                // Get the drop ListViewItem destination
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAnchestor<ListViewItem>((DependencyObject)e.OriginalSource);
                if (listViewItem == null)
                {
                    // Abort
                    e.Effects = DragDropEffects.None;
                    return;
                }
                // Find the data behind the ListViewItem
                ListViewWorkItem item = (ListViewWorkItem)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                // Move item into observable collection 
                // (this will be automatically reflected to lstView.ItemsSource)
                e.Effects = DragDropEffects.Move;
                index = Items.IndexOf(item);
                if (startIndex >= 0 && index >= 0)
                {
                    Items.Move(startIndex, index);
                }
                startIndex = -1;        // Done!
            }
        }

        /// <summary>
        /// Invoked when the mouse move on the ListView
        /// </summary>
        private void lstView_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                       Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAnchestor<ListViewItem>((DependencyObject)e.OriginalSource);
                if (listViewItem == null) return;           // Abort
                                                            // Find the data behind the ListViewItem
                ListViewWorkItem item = (ListViewWorkItem)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                if (item == null) return;                   // Abort
                                                            // Initialize the drag & drop operation
                startIndex = lstView.SelectedIndex;
                DataObject dragData = new DataObject("WorkItem", item);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        /// <summary>
        /// Invoked when Drop some control on the DockingManager
        /// </summary>
        private void clientdockingManager_Drop(object sender, DragEventArgs e)
        {
            ContentControl CC = new ContentControl();
            if (item != null)
            {
                CC.Content = new TextBlock() { Text = item.Note };
                DockingManager.SetState(CC, DockState.Document);
                DockingManager.SetHeader(CC, item.Title);

                this.clientdockingManager.Children.Add(CC);
            }
            isdragenter = false;
        }
    }

    public class ListViewWorkItem
    {
        public string Title { get; set; }
        public string Note { get; set; }

        public ListViewWorkItem(string title, string note)
        {
            this.Title = title;
            this.Note = note;
        }
    }

}
