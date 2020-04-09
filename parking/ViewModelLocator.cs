using parking.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace parking
{
    class ViewModelLocator
    {
        private static ParkingsViewModel parkingsViewModel = new ParkingsViewModel();
        private static ParkingViewModel parkingViewModel = new ParkingViewModel();
        private static ParkingDetailsViewModel parkingDetailsViewModel = new ParkingDetailsViewModel();
        private static MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        private static ReserverenViewModel reserverenViewModel = new ReserverenViewModel();
        private static StatistiekViewModel statistiekViewModel = new StatistiekViewModel();



        public static ParkingsViewModel ParkingsViewModel
        {
            get
            {
                return parkingsViewModel;
            }
        }


        public static StatistiekViewModel StatistiekViewModel
        {
            get
            {
                return statistiekViewModel;
            }
        }

        public static ReserverenViewModel ReserverenViewModel
        {
            get
            {
                return reserverenViewModel;
            }
        }

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
