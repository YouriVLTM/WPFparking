using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    class Lecture
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string startTime;
        private string endTime;
        private string location;
        private string course;
        private string date;
        private int buildingId;

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

        public string StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
                NotifyPropertyChanged();
            }
        }

        public string EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
                NotifyPropertyChanged();
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                NotifyPropertyChanged();
            }
        }

        public string Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
                NotifyPropertyChanged();
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
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


        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }








    }
}
