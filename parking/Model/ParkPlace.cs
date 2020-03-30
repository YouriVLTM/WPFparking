using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    class ParkPlace : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private int parkingId;
        private int buildingId;
        private int row;
        private int cel;
        private string description;
       

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

        public Parking parking
        {
            get { return parking; }
            set
            {
                parking = value;
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

        public Building building
        {
            get { return building; }
            set
            {
                building = value;
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


        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
