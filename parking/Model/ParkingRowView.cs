using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class ParkingRowView :BaseModel
    {

        public int RowNumber { get; set; }

        public ObservableCollection<ParkPlaceView> Rows { get; set; }

        public Parking Parking { get; set; }
    }
}
