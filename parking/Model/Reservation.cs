using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class Reservation : BaseModel
    {
        private int id;
        private int userId;
        private int parkPlaceId;
        private string status;
        private DateTime date;
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



    }
}
