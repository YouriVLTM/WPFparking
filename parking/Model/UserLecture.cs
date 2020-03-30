using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class UserLecture : BaseModel
    {
        private int id;
        private int lectureId;
        private string userId;

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

        public string UserId
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
    }
}
