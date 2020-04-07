using LiveCharts;
using LiveCharts.Wpf;
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
    public class StatistiekViewModel : BaseViewModel
    {
        private ParkPlace mostUsedParkPlace;
        public ParkPlace MostUsedParkPlace { 
            get { return mostUsedParkPlace; } 
            set { mostUsedParkPlace = value; NotifyPropertyChanged(); } 
        }

        private User mostUsedUser;
        public User MostUsedUser
        {
            get { return mostUsedUser; }
            set { mostUsedUser = value; NotifyPropertyChanged(); }
        }

        private SeriesCollection countReservationsPerDay;
        public SeriesCollection CountReservationsPerDay
        {
            get { return countReservationsPerDay; }
            set { countReservationsPerDay = value; NotifyPropertyChanged(); }
        }

        private List<string> countReservationPerDayLabel;
        public List<string> CountReservationPerDayLabel
        {
            get { return countReservationPerDayLabel; }
            set { countReservationPerDayLabel = value; NotifyPropertyChanged(); }
        }


        public Func<double, string> CountReservationPerDayFormat { get; set; }


        private DialogService dialogService;
        public StatistiekViewModel()
        {
            ReservationDataService dbReservation = new ReservationDataService();
            MostUsedParkPlace = dbReservation.GetMostReservedParkingPlace();
            MostUsedUser = dbReservation.GetMostReservedUser();

            //Barchart 
            CountReservationsPerDay = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Reservation \n per day",
                    Values = new ChartValues<int> {}
                }
            };

            CountReservationPerDayFormat = value => value.ToString("0");
            countReservationPerDayLabel = new List<String>();

            List<Graph<string, int>> countReservationsPerDayData = dbReservation.GetCountReservationEveryDay();

            foreach (Graph<string,int> data in countReservationsPerDayData)
            {
                CountReservationsPerDay.First().Values.Add((int)data.YValue);
                countReservationPerDayLabel.Add(data.XValue);
            }
            //endBarchart

            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            KoppelCommands();

        }
        private void KoppelCommands()
        {
            ViewParkingPlaceCommand = new BaseParCommand(ViewParkingPlace);
        }
        public ICommand ViewParkingPlaceCommand { get; set; }
        private void ViewParkingPlace(object parkplace)
        {
            if (parkplace != null)
            {
                Messenger.Default.Send<ParkPlace>((ParkPlace)parkplace);

                dialogService.ShowDetailDialogParkPlace();
            }
        }

        private string[] GetDaysOfWeek()
        {
            DateTime days = DateTime.Now;
            string[] weekDays = new string[7];
            for (int i = 0; i < weekDays.Length; i++)
            {
                weekDays[i] = string.Format("{0:dddd}", days.AddDays(i));
            }

            return weekDays;
        }
    }
}
