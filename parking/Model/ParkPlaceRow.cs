using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class ParkPlaceRow
    {
        public ParkPlaceRow()
        {
            parkPlace = new List<ParkPlace>();
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
            }
        }
    };
}
