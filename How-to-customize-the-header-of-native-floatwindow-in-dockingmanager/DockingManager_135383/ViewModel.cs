using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DockingManager_135383
{
    public class ViewModel
    {

        private ICommand refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                if (refreshCommand == null)
                {
                    refreshCommand = new DelegateCommand(Refresh, CanRefresh);
                }
                return refreshCommand;
            }
            set { refreshCommand = value; }
        }

        internal bool CanRefresh(object arg)
        {
            return true;
        }

        public void Refresh(object obj)
        {
            MessageBox.Show("Refresh clicked");
        }
    }
}
