using parking.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace parking.ViewModel
{
    class UsersViewModel : BaseViewModel
    {

        private ObservableCollection<User> users;

        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                NotifyPropertyChanged();
            }
        }

        private User selectedUser;
        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                NotifyPropertyChanged();
            }
        }


        private ICommand toevoegenCommand;
        public ICommand ToevoegenCommand
        {
            get
            {
                return toevoegenCommand;
            }

            set
            {
                toevoegenCommand = value;
            }
        }

        private ICommand wijzigenCommand;
        public ICommand WijzigenCommand
        {
            get
            {
                return wijzigenCommand;
            }

            set
            {
                wijzigenCommand = value;
            }
        }


        public UsersViewModel()
        {
            //laden data
            UserDataService ds = new UserDataService();
            users = ds.GetUsers();

            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            //koppelen commands
            WijzigenCommand = new BaseCommand(WijzigenKoffie);
            ToevoegenCommand = new BaseCommand(ToevoegenKoffie);

            //luisteren naar messages vanuit detailvenster
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);

        }

        private void ToevoegenKoffie()
        {
            SelectedUser = new User();

            Messenger.Default.Send<Koffie>(SelectedKoffie);

            dialogService.ShowDetailDialog();

        }

        private void WijzigenKoffie()
        {
            if (SelectedKoffie != null)
            {
                Messenger.Default.Send<Koffie>(SelectedKoffie);

                dialogService.ShowDetailDialog();
            }
        }

    }
}
