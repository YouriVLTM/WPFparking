using parking.Model;
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

        

        private String location;
        public String Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                NotifyPropertyChanged();
            }
        }

        private Reservation reservation;
        public Reservation Reservation
        {
            get
            {
                return reservation;
            }
            set
            {
                reservation = value;
                NotifyPropertyChanged();
            }
        }


        public ReserverenViewModel()
        {
            //new reserveren
            User user = new User();
            ParkPlace parkPlace = new ParkPlace();
            reservation = new Reservation();

            Reservation.User = user;
            Reservation.ParkPlace = parkPlace;




            //Command Kopellen
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
            //kijken welke paringPlaats
            ReservationDataService ds = new ReservationDataService();

        }


        public ICommand SaveReserverenCommand { get; set; }

        private void SaveReserveren()
        {
            //Be
            Reservation test = Reservation;

        }

       


    }
}
