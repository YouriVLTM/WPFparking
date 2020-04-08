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

        public void ShowDetailDialogParkPlace()
        {
            parkingDetailView = new ParkingDetails();
            parkingDetailView.ShowDialog();
        }

        public void CloseDetailDialogParkPlace()
        {
            if (parkingDetailView != null)
                parkingDetailView.Close();
        }

        public void ShowDetailDialog(String win)
        {
            switch (win)
            {
                case "ParkingDetails":
                    parkingDetailView = new ParkingDetails();
                    parkingDetailView.ShowDialog();
                    break;


                default:
                    break;
            }
        }

        public void CloseDetailDialog(String win)
        {
            switch (win)
            {
                case "ParkingDetails":
                    if (parkingDetailView != null)
                        parkingDetailView.Close();
                    break;


                default:
                    break;
            }
        }
    }
}
