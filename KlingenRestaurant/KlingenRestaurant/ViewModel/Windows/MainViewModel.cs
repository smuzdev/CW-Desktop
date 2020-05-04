using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class MainViewModel : ViewModelBase
    { 
        private User user;
        private IFrameNavigationService _navigationService;

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

        private RelayCommand _loginpageCommand;
        public RelayCommand LoginPageCommand
        {
            get
            {
                return _loginpageCommand
                    ?? (_loginpageCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Login");
                    }));
            }
        }

        private RelayCommand _homeCommand;
        public RelayCommand HomeCommand
        {
            get
            {
                return _homeCommand
                    ?? (_homeCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Home");
                    }));
            }
        }

        private RelayCommand _menuCommand;
        public RelayCommand MenuCommand
        {
            get
            {
                return _menuCommand
                    ?? (_menuCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Menu");
                    }));
            }
        }

        private RelayCommand _reservationCommand;
        public RelayCommand ReservationCommand
        {
            get
            {
                return _reservationCommand
                       ?? (_reservationCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Reservation");
                           }));
            }
        }

        private RelayCommand _feedbackCommand;
        public RelayCommand FeedbackCommand
        {
            get
            {
                return _feedbackCommand
                       ?? (_feedbackCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Feedback");
                           }));
            }
        }

        private RelayCommand _accountCommand;
        public RelayCommand AccountCommand
        {
            get
            {
                return _accountCommand
                       ?? (_accountCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Account");
                           }));
            }
        }

        private RelayCommand _settingsCommand;
        public RelayCommand SettingsCommand
        {
            get
            {
                return _settingsCommand
                       ?? (_settingsCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Settings");
                           }));
            }
        }

       

        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
