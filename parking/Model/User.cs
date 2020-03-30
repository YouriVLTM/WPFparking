using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace parking.Model
{
    public class User : BaseModel, IDataErrorInfo
    {
        private int id;
        private string prename;
        private string lastname;
        private string phoneNumber;
        private string email;


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

        public string Prename
        {
            get
            {
                return prename;
            }
            set
            {
                prename = value;
                NotifyPropertyChanged();
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                NotifyPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
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
                    case "Prename": if (string.IsNullOrEmpty(Prename)) result = "Prename moet ingevuld zijn!"; break;
                    case "lastname": if (string.IsNullOrEmpty(Lastname)) result = "Prijs moet een positief getal zijn."; break;
                };
                return result;

            }
        }

    }
}
