using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class Building : BaseModel, IDataErrorInfo
    {
        private int id;
        private string place;
        private string description;
        private string location;

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

        public string Place
        {
            get
            {
                return place;
            }
            set
            {
                place = value;
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
                    case "Place": if (string.IsNullOrEmpty(Place)) result = "Place moet ingevuld zijn!"; break;
                    case "Description": if (string.IsNullOrEmpty(Description)) result = "Description moet ingevuld zijn!"; break;
                    case "Location": if (string.IsNullOrEmpty(Location)) result = "Location moet ingevuld zijn!"; break;
                };
                return result;

            }
        }

    }
}
