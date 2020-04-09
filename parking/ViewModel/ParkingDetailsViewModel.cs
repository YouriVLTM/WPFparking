using parking.Extensions;
using parking.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.ViewModel
{
    public class ParkingDetailsViewModel : BaseViewModel
    {
        public ParkingDetailsViewModel()
        {
            Messenger.Default.Register<ParkPlaceView>(this, OnParkPlaceReceived);

        }

        private ParkPlaceView selectedParkPlace;
        public ParkPlaceView SelectedParkPlace
        {
            get
            {
                return selectedParkPlace;
            }
            set
            {
                selectedParkPlace = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Reservation> reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get
            {
                return reservations;
            }
            set
            {
                reservations = value;
                NotifyPropertyChanged();
            }
        }



        private void OnParkPlaceReceived(ParkPlaceView parkplace)
        {
            if(parkplace.Building == null || parkplace.Parking == null)
            {
                ParkPlaceDataService dbParkPlace = new ParkPlaceDataService();
                SelectedParkPlace = (ParkPlaceView)dbParkPlace.GetParkPlaceWithFK(parkplace);

            }
            else
            {
                SelectedParkPlace = parkplace;
            }

            // get reservations
            if (SelectedParkPlace != null)
            {
                ReservationDataService db = new ReservationDataService();
                Reservations = db.GetReservationParkPlace(SelectedParkPlace);
            }
        }


    }
}
