using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using KlingenRestaurant.Helpers;
using KlingenRestaurant.Helpers.MessageWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.ViewModel.Login
{
    public class RegistrationViewModel : ViewModelBase
    {

        private IFrameNavigationService _navigationService;

        private User user;

        private string name;

        private string login;


        public User User
        {
            get
            {
                return user;
            }
            set
            {
                if (user == value)
                {
                    return;
                }
                user = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == value)
                {
                    return;
                }
                name = value;
                RaisePropertyChanged();
            }
        }
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (login == value)
                {
                    return;
                }
                login = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                    ?? (_loginCommand = new RelayCommand(
                    () =>
                    {

                        _navigationService.NavigateTo("Login");

                    }));
            }
        }

        private RelayCommand _registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand
                    ?? (_registerCommand = new RelayCommand(
                    () =>
                    {
                        user = new User(name, login, "password");
                        Messenger.Default.Send<OpenWindowMessage>(
                            new OpenWindowMessage() { Type = WindowType.kMain, Argument = user });

                    }));
            }
        }

        public RegistrationViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
