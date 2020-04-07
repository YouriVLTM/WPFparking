using parking.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace parking.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel()
        {            
            ParkingCommand = new BaseCommand(GoToParkingPage);
            HomeCommand = new BaseCommand(GoToHomePage);
            ReserverenCommand = new BaseCommand(GoToReserverenCommand);
            StatistiekCommand = new BaseCommand(GoToStatistiekCommand);

        }

        public ICommand ParkingCommand { get; set; }
        private void GoToParkingPage()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Parking");

        }

        public ICommand HomeCommand { get; set; }
        private void GoToHomePage()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Home");
        }

        public ICommand ReserverenCommand { get; set; }
        private void GoToReserverenCommand()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Reserveren");
        }


        public ICommand StatistiekCommand { get; set; }
        private void GoToStatistiekCommand()
        {
            PageNavigationService nav = new PageNavigationService();
            nav.Navigate("Statistiek");
        }


    }
}
