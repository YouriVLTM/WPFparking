using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace parking.ViewModel
{
    public class ReserverenViewModel : BaseViewModel
    {
        public ReserverenViewModel()
        {
            KoppelCommands();
        }

        private void KoppelCommands()
        {
            SaveReserverenCommand = new BaseCommand(SaveReserveren);
            ViewParkingPlaceCommand = new BaseCommand(ViewParkingPlace);
        }



        public ICommand ViewParkingPlaceCommand { get; set; }

        private void ViewParkingPlace()
        {

        }


        public ICommand SaveReserverenCommand { get; set; }

        private void SaveReserveren()
        {

        }

       


    }
}
