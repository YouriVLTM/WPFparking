using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class Reservation : BaseModel, IDataErrorInfo
    {
        private int id;
        private int userId;
        private int parkPlaceId;
        private string status;
        private DateTime beginTime;
        private DateTime endTime;

        private ParkPlace parkPlace;
        private User user;


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

        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                NotifyPropertyChanged();
            }
        }

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                UserId = value.Id;
                NotifyPropertyChanged();
            }
        }

        public int ParkPlaceId
        {
            get
            {
                return parkPlaceId;
            }
            set
            {
                parkPlaceId = value;
                NotifyPropertyChanged();
            }
        }

        public ParkPlace ParkPlace
        {
            get { return parkPlace; }
            set
            {
                parkPlace = value;
                ParkPlaceId = value.Id;
                NotifyPropertyChanged();
            }
        }


        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }


        public DateTime BeginTime
        {
            get
            {
                return beginTime;
            }
            set
            {
                beginTime = value;
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
                    case "BeginTime": if (DateTime.Now > (BeginTime)) result = "BeginTime moet later zijn!"; break;
                    case "EndTime": if (DateTime.Now > (EndTime) || endTime == beginTime) result = "EndTime moet later zijn!"; break;
                    case "ParkPlaceId": if ( (ParkPlaceId) == null || (ParkPlaceId) == 0) result = "ParkPlace moet geselecteed worden!"; break;
                };
                return result;

            }
        }



    }
}
