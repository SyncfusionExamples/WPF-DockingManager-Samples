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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools.MVVM;

namespace DockingManagerCommands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;           
        }
        private ICommand close;

        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new DelegateCommand(CloseWindow, CanClose);
                }

                return close;
            }
            set
            {
                close = value;
            }
        }

        private bool CanClose(object arg)
        {
            return true;
        }

        private void CloseWindow(object obj)
        {
            MessageBox.Show(DockingManager.GetHeader(obj as FrameworkElement)+ " to be closed");
        }

        private ICommand closeall;

        public ICommand CloseAll
        {
            get
            {
                if (closeall == null)
                {
                    closeall = new DelegateCommand(CloseWindow, CanClose);
                }

                return closeall;
            }
            set
            {
                closeall = value;
            }
        }

        private ICommand closeallbutthis;

        public ICommand CloseAllButThis
        {
            get
            {
                if (closeallbutthis == null)
                {
                    closeallbutthis = new DelegateCommand(CloseWindow, CanClose);
                }
                return closeallbutthis;
            }
            set
            {
                closeallbutthis = value;
            }
        }
    }

    }

   
