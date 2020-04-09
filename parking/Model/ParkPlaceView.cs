using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class ParkPlaceView : ParkPlace
    {
        public ParkPlaceView(ParkPlace parkplace)
        {
            Id = parkplace.Id;
            Parking = parkplace.Parking;
            Building = parkplace.Building;
            Row = parkplace.Row;
            Cel = parkplace.Cel;
            Description = parkplace.Description;

            Reservation = new ObservableCollection<Reservation>();

        }
        public ObservableCollection<Reservation> Reservation { get; set; }

        public DateTime fitlerDateTime { get; set; }
    }
}
