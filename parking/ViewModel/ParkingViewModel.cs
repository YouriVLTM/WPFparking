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

        private ObservableCollection<ParkPlace> parkPlaces;

        public ObservableCollection<ParkPlace> ParkPlaces
        {
            get
            {
                return parkPlaces;
            }
            set
            {
                parkPlaces = value;
                NotifyPropertyChanged();
            }
        }


        private List<ParkPlaceRow> rowViewParkPlaces;

        public List<ParkPlaceRow> RowViewParkPlaces
        {
            get{
                return ViewParkPlaces();
            }
            set
            {
                rowViewParkPlaces = value;
                NotifyPropertyChanged();
            }
        }


        private List<ParkPlaceRow> viewParkPlaces;

        public List<ParkPlaceRow> ViewParkPlaces()
        {
                ParkPlaceRow parkrow = new ParkPlaceRow();
                viewParkPlaces = new List<ParkPlaceRow>();
                foreach (ParkPlace parkPlace in ParkPlaces)
                {
                    if (viewParkPlaces.Count() != parkPlace.Row)
                    {
                        parkrow = new ParkPlaceRow();
                        parkrow.ParkPlace.Add(parkPlace);
                        parkrow.RowNumber = parkPlace.Row;
                        parkrow.ParkingName = parkPlace.Parking.Name;

                        // lijst toevoegen
                        //park view
                        viewParkPlaces.Add(parkrow);
                    }
                    else
                    {
                        parkrow.ParkPlace.Add(parkPlace);
                        parkrow.RowNumber = parkPlace.Row;
                    }
                }

                return viewParkPlaces;
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


        private DialogService dialogService;

        public ParkingViewModel()
        {
            //laden data
            ParkPlaceDataService ds = new ParkPlaceDataService();
            parkPlaces = ds.GetParkPlace();

            rowViewParkPlaces = ViewParkPlaces();

            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            //koppelen commands
            KoppelCommands();

            //luisteren naar messages vanuit detailvenster
            //Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);

        }

        private void KoppelCommands()
        {
            ViewCommand = new BaseParCommand(ViewParkPlaceDetail);
        }


        public ICommand ViewCommand { get; set; }

        private void ViewParkPlaceDetail(object name)
        {
            ParkPlace park = selectedParkPlace;


        }


        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            //na update of delete mag detailvenster sluiten
            dialogService.CloseDetailDialog();

            //na Delete/Insert moet collectie Koffies terug ingeladen worden
            if (message.Type != UpdateFinishedMessage.MessageType.Updated)
            {
                ParkPlaceDataService ds = new ParkPlaceDataService();
                parkPlaces = ds.GetParkPlace();
            }

        }


    }
}
