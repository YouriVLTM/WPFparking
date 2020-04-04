using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class ParkPlaceRow : BaseModel
    {
        public ParkPlaceRow()
        {
            parkPlace = new List<ParkPlace>();
        }

        private String parkingName;
        public String ParkingName
        {
            get
            {
                return parkingName;
            }
            set
            {
                parkingName = value;
                NotifyPropertyChanged();
            }
        }

        private int rowNumber;
        public int RowNumber
        {
            get
            {
                return rowNumber;
            }
            set
            {
                rowNumber = value;
                NotifyPropertyChanged();
            }
        }

        private List<ParkPlace> parkPlace;

        public List<ParkPlace> ParkPlace
        {
            get
            {
                return parkPlace;
            }
            set
            {
                parkPlace = value;
                NotifyPropertyChanged();
            }
        }
    };
}
