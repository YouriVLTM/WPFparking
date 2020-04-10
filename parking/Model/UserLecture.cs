using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class UserLecture : BaseModel, IDataErrorInfo
    {
        private int id;
        private int lectureId;
        private int userId;

        private Lecture lecture;
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

        public int LectureId
        {
            get
            {
                return lectureId;
            }
            set
            {
                lectureId = value;
                NotifyPropertyChanged();
            }
        }

        public Lecture Lecture
        {
            get { return lecture; }
            set
            {
                lecture = value;
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
                    case "LectureId": if (LectureId == 0) result = "LectureId moet ingevuld zijn!"; break;
                    case "UserId": if (UserId == 0) result = "UserId moet ingevuld zijn!"; break;
                };
                return result;

            }
        }
    }
}
