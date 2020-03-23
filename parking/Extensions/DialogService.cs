using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using parking.View;

namespace parking.Extensions
{
    class DialogService
    {
        Window parkingDetailView = null;

        public DialogService() { }

        public void ShowDetailDialog()
        {
            parkingDetailView = new MainWindow();
            parkingDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (parkingDetailView != null)
                parkingDetailView.Close();
        }
    }
}
