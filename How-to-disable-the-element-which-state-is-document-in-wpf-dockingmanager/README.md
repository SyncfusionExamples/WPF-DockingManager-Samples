# How to disable the element which state is Document in WPF DockingManager?

By default, child element of DockingManager (which has state as Document) will be added as content of TabItemExt in DocumentTabControl. To disable the document child element of [WPF DockingManager](https://www.syncfusion.com/wpf-controls/docking), we must retrieve the TabItemExt element from DocumentTabControl and set IsEnabled as false to the retrieved element. For instance, we have disabled all the items in the DocumentTabControl, except SelectedItem.

KB article - [How to disable the element which state is Document in WPF DockingManager?](https://www.syncfusion.com/kb/8657/how-to-disable-the-element-which-state-is-document-in-wpf-dockingmanager)
