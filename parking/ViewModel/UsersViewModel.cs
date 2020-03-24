using parking.Extensions;
using parking.Messages;
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
    public class UsersViewModel : BaseViewModel
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


        private DialogService dialogService;

        public UsersViewModel()
        {
            //laden data
            UserDataService ds = new UserDataService();
            users = ds.GetUsers();

            //instantiëren DialogService als singleton
            dialogService = new DialogService();

            //koppelen commands
            WijzigenCommand = new BaseCommand(WijzigenUser);
            ToevoegenCommand = new BaseCommand(ToevoegenUser);

            //luisteren naar messages vanuit detailvenster
            Messenger.Default.Register<UpdateFinishedMessage>(this, OnMessageReceived);

        }

        private void OnMessageReceived(UpdateFinishedMessage message)
        {
            //na update of delete mag detailvenster sluiten
            dialogService.CloseDetailDialog();

            //na Delete/Insert moet collectie Koffies terug ingeladen worden
            if (message.Type != UpdateFinishedMessage.MessageType.Updated)
            {
                UserDataService ds = new UserDataService();
                users = ds.GetUsers();
            }

        }

        private void ToevoegenUser()
        {
            SelectedUser = new User();

            Messenger.Default.Send<User>(SelectedUser);

            dialogService.ShowDetailDialog();

        }

        private void WijzigenUser()
        {
            if (SelectedUser != null)
            {
                Messenger.Default.Send<User>(SelectedUser);

                dialogService.ShowDetailDialog();
            }
        }

    }
}
