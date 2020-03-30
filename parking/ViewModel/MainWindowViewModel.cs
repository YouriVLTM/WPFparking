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
            ParkingCommand = new BaseCommand(GoToParkingPage);
            HomeCommand = new BaseCommand(GoToHomePage);
            ReserverenCommand = new BaseCommand(GoToReserverenCommand);
            StatistiekCommand = new BaseCommand(GoToStatistiekCommand);

        }

        private ICommand statistiekCommand;
        public ICommand StatistiekCommand
        {
            get
            {
                return statistiekCommand;
            }

            set
            {
                statistiekCommand = value;
            }
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

        private ICommand homeCommand;
        public ICommand HomeCommand
        {
            get
            {
                return homeCommand;
            }

            set
            {
                homeCommand = value;
            }
        }

        private ICommand reserverenCommand;
        public ICommand ReserverenCommand
        {
            get
            {
                return reserverenCommand;
            }

            set
            {
                reserverenCommand = value;
            }
        }

        private void GoToParkingPage()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Parking");

        }

        private void GoToHomePage()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Home");
        }

        private void GoToReserverenCommand()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Reserveren");
        }

        private void GoToStatistiekCommand()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Statistiek");
        }


    }
}
