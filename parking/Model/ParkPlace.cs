using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class ParkPlace : BaseModel, IDataErrorInfo
    {
        private int id;
        private int parkingId;
        private int buildingId;
        private int row;
        private int cel;
        private string description;

        private Parking parking;
        private Building building;




        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public int ParkingId
        {
            get
            {
                return parkingId;
            }
            set
            {
                parkingId = value;
                NotifyPropertyChanged();
            }
        }

        public Parking Parking
        {
            get { return parking; }
            set
            {
                parking = value;
                if (value != null)
                    ParkingId = value.Id;
                NotifyPropertyChanged();
            }
        }

        public int BuildingId
        {
            get
            {
                return buildingId;
            }
            set
            {
                buildingId = value;
                NotifyPropertyChanged();
            }
        }

        public Building Building
        {
            get { return building; }
            set
            {
                building = value;
                if (value != null)
                    BuildingId = value.Id;
                NotifyPropertyChanged();
            }
        }
        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
                NotifyPropertyChanged();
            }
        }
        public int Cel
        {
            get
            {
                return cel;
            }
            set
            {
                cel = value;
                NotifyPropertyChanged();
            }
        }


        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "ParkingId": if (ParkingId == 0) result = "ParkingId moet ingevuld zijn!"; break;
                    case "BuildingId": if (BuildingId == 0) result = "BuildingId moet ingevuld zijn!"; break;
                    case "Row": if (Row == 0) result = "Row moet ingevuld zijn!"; break;
                    case "Cel": if (Cel == 0) result = "Cel moet ingevuld zijn!"; break;
                    case "Description": if (string.IsNullOrEmpty(Description)) result = "Description moet ingevuld zijn!"; break;
                        
                };
                return result;

            }
        }

    }
}
