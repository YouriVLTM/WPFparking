using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class Lecture : BaseModel, IDataErrorInfo
    {
        private int id;
        private DateTime startTime;
        private DateTime endTime;
        private string location;
        private string course;
        private DateTime date;
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

        public DateTime StartTime
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

        public DateTime EndTime
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

        public DateTime Date
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
                    case "Location": if (string.IsNullOrEmpty(Location)) result = "Location moet ingevuld zijn!"; break;
                    case "BuildingId": if (BuildingId == 0) result = "BuildingId moet ingevuld zijn!"; break;
                };
                return result;

            }
        }

    }
}
