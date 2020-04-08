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
        public ObservableCollection<Reservation> Reservation { get; set; }
    }
}
