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
            Messenger.Default.Register<ParkPlace>(this, OnParkPlaceReceived);

        }

        private ParkPlace selectedParkPlace;
        public ParkPlace SelectedParkPlace
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



        private void OnParkPlaceReceived(ParkPlace parkplace)
        {
            SelectedParkPlace = parkplace;

            // get reservations         

            if (SelectedParkPlace != null)
            {
                ReservationDataService db = new ReservationDataService();
                Reservations = db.GetReservationParkPlace(SelectedParkPlace);
            }
        }
    }
}
