using parking.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace parking.ViewModel
{
    class MainWindowViewModel
    {

        public MainWindowViewModel()
        {
            ParkingCommand = new BaseCommand(NaarParkingPage);
        }

        private ICommand parkingCommand;
        public ICommand ParkingCommand
        {
            get
            {
                return parkingCommand;
            }

            set
            {
                parkingCommand = value;
            }
        }

        private void NaarParkingPage()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Parking");

        }


    }
}
