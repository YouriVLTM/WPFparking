using parking.Extensions;
using parking.Messages;
using parking.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace parking.ViewModel
{
    public class ParkingViewModel : BaseViewModel
    {
        private ParkingView selectedParkingView;
        public ParkingView SelectedParkingView
        {
            get
            {
                return selectedParkingView;
            }
            set
            {
                selectedParkingView = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                selectedDate = value;
                NotifyPropertyChanged();
            }
        }


        private DateTime selectedTime;
        public DateTime SelectedTime
        {
            get
            {
                return selectedTime;
            }
            set
            {
                selectedTime = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime selectedDateTime;
        public DateTime SelectedDateTime
        {
            get
            {
                return new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, SelectedTime.Hour, SelectedTime.Minute, SelectedTime.Second);
            }
            set
            {
                selectedDateTime = value;
                NotifyPropertyChanged();
            }
        }


        public List<Reservation> PreviousReservation { get; set; }





        private DialogService dialogService;

        public ParkingViewModel()
        {
            //inistialiseer date
            SelectedDate = DateTime.Now;
            SelectedTime = DateTime.Now;



            Messenger.Default.Register<ParkingView>(this, OnCoffeeReceived);

            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            //koppelen commands
            KoppelCommands();


        }

        private void OnCoffeeReceived(ParkingView parkingView)
        {
            SelectedParkingView = parkingView;
        }


        private void KoppelCommands()
        {
            ViewCommand = new BaseParCommand(ViewParkPlaceDetail);
            GetReservationCommand = new BaseCommand(GetReservation);
        }


        public ICommand ViewCommand { get; set; }

        private void ViewParkPlaceDetail(object park)
        {
            if(park != null)
            {
                Messenger.Default.Send<ParkPlaceView>((ParkPlaceView)park);

                dialogService.ShowDetailDialogParkPlace();
            }


        }


        public ICommand GetReservationCommand { get; set; }

        private void GetReservation()
        {
            if (SelectedDateTime != null)
            {
                //remove all list
                RemoveAllReservations();

                ReservationDataService db = new ReservationDataService();

                PreviousReservation = db.GetReservationDate(SelectedDateTime, SelectedParkingView.Parking);

                foreach (Reservation reservation in PreviousReservation)
                {
                    SelectedParkingView.Rows.ElementAt(reservation.ParkPlace.Row - 1).Row.ElementAt(reservation.ParkPlace.Cel - 1).fitlerDateTime = SelectedDateTime;
                    SelectedParkingView.Rows.ElementAt(reservation.ParkPlace.Row - 1).Row.ElementAt(reservation.ParkPlace.Cel - 1).Reservation.Add(reservation);
                }
                
            }


        }

        private void RemoveAllReservations()
        {
            if(PreviousReservation != null )
            {
                if (PreviousReservation.Count != 0)
                {
                    if (PreviousReservation.FirstOrDefault().ParkPlace.Parking.Id == SelectedParkingView.Parking.Id)
                    {
                        foreach (Reservation reservation in PreviousReservation)
                        {
                            SelectedParkingView.Rows.ElementAt(reservation.ParkPlace.Row - 1).Row.ElementAt(reservation.ParkPlace.Cel - 1).Reservation.Clear();
                        }
                    }
                }               
               
            }           
        }





    }
}
