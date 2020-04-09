using parking.Extensions;
using parking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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


        private DialogService dialogService;

        public ReserverenViewModel()
        {
            //new reserveren
            NewForm();

            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            //Command Kopellen
            KoppelCommands();
        }

        private void KoppelCommands()
        {
            GetUserCommand = new BaseCommand(GetUser);
            SaveReserverenCommand = new BaseCommand(SaveReserveren);
            GetParkingPlaceCommand = new BaseCommand(GetParkingPlace);
            ViewParkingPlaceCommand = new BaseParCommand(ViewParkingPlace);

        }

        public ICommand GetUserCommand { get; set; }
        private void GetUser()
        {
            //user already exist 
            UserDataService dbUser = new UserDataService();
            User us = dbUser.UserExist(Reservation.User);

            if (us == null)
            {
                MessageBox.Show("User didn't exist");
            }
            else
            {
                Reservation.User = us;
            }
        }


        public ICommand ViewParkingPlaceCommand { get; set; }
        private void ViewParkingPlace(object parkplace)
        {
            if (parkplace != null)
            {
                Messenger.Default.Send<ParkPlaceView>( new ParkPlaceView((ParkPlace)parkplace));

                dialogService.ShowDetailDialogParkPlace();
            }
        }


        public ICommand GetParkingPlaceCommand { get; set; }

        private void GetParkingPlace()
        {
            //kijken welke paringPlaats
            ReservationDataService ds = new ReservationDataService();
            ParkPlace reservationPark = ds.GetNewParkPlaces(Reservation, Location);

            if(reservationPark == null)
            {
                //geen parking gevonden
                MessageBox.Show("Geen parkingplaatsen gevonden!");

            }
            else
            {
                Reservation.ParkPlace = reservationPark;
            }

        }


        public ICommand SaveReserverenCommand { get; set; }

        private void SaveReserveren()
        {
            //Be
            Reservation test = Reservation;
            Reservation.Status = "reserved";

            //user already exist 
            /*UserDataService dbUser = new UserDataService();

            User us = dbUser.UserExist(Reservation.User);

            if (us == null)
            {
                //creat New User
                dbUser.InsertUser(Reservation.User);
                us = dbUser.UserExist(Reservation.User);
            }
            Reservation.User = us;*/

            //reservation
            ReservationDataService dbReservation = new ReservationDataService();

            dbReservation.InsertReservation(Reservation);

            MessageBox.Show("Reservatie is voltooid");
            NewForm();
        }


        private void NewForm()
        {
            //new reserveren
            User user = new User();
            ParkPlace parkPlace = new ParkPlace();
            Reservation = new Reservation();

            Reservation.User = user;
            Reservation.ParkPlace = parkPlace;
            Reservation.BeginTime = DateTime.Now;
            Reservation.EndTime = DateTime.Now;
            Location = "";
        }

       


    }
}
