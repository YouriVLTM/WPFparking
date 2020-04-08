using parking.Extensions;
using parking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace parking.ViewModel
{
    class ParkingsViewModel : BaseViewModel
    {
        private ParkingsView parkingsView;
        public ParkingsView ParkingsView
        {
            get
            {
                return parkingsView;
            }
            set
            {
                parkingsView = value;
                NotifyPropertyChanged();
            }
        }

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

        private DialogService dialogService;
        public ParkingsViewModel()
        {
            ParkPlaceDataService ds = new ParkPlaceDataService();
            ParkingsView = ds.GetParkingsView();

            //dialogService
            dialogService = new DialogService();


            KoppelCommands();


        }

        private void KoppelCommands()
        {
            GetParkingCommand = new BaseCommand(ViewParking);
        }


        public ICommand GetParkingCommand { get; set; }

        private void ViewParking()
        {
            if (selectedParkingView != null)
            {
                Messenger.Default.Send<ParkingView>(selectedParkingView);

                PageNavigationService nav = new PageNavigationService();
                nav.Navigate("Parking");
            }


        }
    }
}
