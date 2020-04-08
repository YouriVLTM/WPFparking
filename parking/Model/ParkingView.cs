using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class ParkingView : BaseModel
    {
        public ParkingView()
        {
            Rows = new ObservableCollection<ParkingRowView>();
        }

        public ObservableCollection<ParkingRowView> Rows { get; set; }
        public Parking Parking { get; set; }
    }
}
