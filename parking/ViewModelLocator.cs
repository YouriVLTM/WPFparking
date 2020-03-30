using parking.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking
{
    class ViewModelLocator
    {
        private static ParkingViewModel parkingViewModel = new ParkingViewModel();
        private static ParkingDetailsViewModel parkingDetailsViewModel = new ParkingDetailsViewModel();
        private static MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

        public static ParkingViewModel ParkingViewModel
        {
            get
            {
                return parkingViewModel;
            }
        }

        public static ParkingDetailsViewModel ParkingDetailsViewModel
        {
            get
            {
                return parkingDetailsViewModel;
            }
        }

        public static MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return mainWindowViewModel;
            }
        }
    }
}
