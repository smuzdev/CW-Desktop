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
        private bool isAdmin;
        private bool isCook;
        private bool isOpenDialog;
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

        public bool IsOpenDialog
        {
            get
            {
                return isOpenDialog;
            }
            set
            {
                if (isOpenDialog == value)
                {
                    return;
                }
                isOpenDialog = value;
                RaisePropertyChanged();
            }
        }

        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                if (isAdmin == value)
                {
                    return;
                }
                isAdmin = value;
                RaisePropertyChanged();
            }
        }

        public bool IsCook
        {
            get
            {
                return isCook;
            }
            set
            {
                if (isCook == value)
                {
                    return;
                }
                isCook = value;
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

        private RelayCommand _adminCommand;
        public RelayCommand AdminCommand
        {
            get
            {
                return _adminCommand
                       ?? (_adminCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Admin");
                           }));
            }
        }

        private RelayCommand _cookCommand;
        public RelayCommand CookCommand
        {
            get
            {
                return _cookCommand
                       ?? (_cookCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Cook");
                           }));
            }
        }

        private RelayCommand closeDialodCommand;
        public RelayCommand CloseDialodCommand
        {
            get
            {
                return closeDialodCommand
                    ?? (closeDialodCommand = new RelayCommand(
                    () =>
                    {
                        IsOpenDialog = false;
                    }));
            }
        }

        public string Message { get; internal set; }

        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
