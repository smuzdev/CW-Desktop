using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class RegistrationViewModel : ViewModelBase
    {

        private IFrameNavigationService _navigationService;

        private RestaurantContext context = new RestaurantContext();
        private string name;

        private string login;

        private string password;

        private string message;
        /// <summary>
        /// Is request to DB is send ?
        /// </summary>
        private bool isVisibleProgressBar;

        private bool isOpenDialog;

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

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Is request to DB is send ?
        /// </summary>
        public bool IsVisibleProgressBar
        {
            get
            {
                return isVisibleProgressBar;
            }
            set
            {
                if (isVisibleProgressBar == value)
                {
                    return;
                }
                isVisibleProgressBar = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Is Open Dialog 
        /// </summary>
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
        /// <summary>
        /// Message for the dialog  
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message == value)
                {
                    return;
                }
                message = value;
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


        private RelayCommandParametr _registerCommand;
        public RelayCommandParametr RegisterCommand
        {
            get
            {
                return _registerCommand
                    ?? (_registerCommand = new RelayCommandParametr(
                    (x) =>
                    {
                                if (context.Users.FirstOrDefault(x1 => x1.Login == login) != null)
                                {
                                    IsVisibleProgressBar = false;
                                    Message = "Пользователь с таким логином уже зарегистрирован";
                                    IsOpenDialog = true;
                                }
                                //ADD VALIDATION HERE
                                else if (Login != null && Password != null && Name != null)
                                {
                                    string hashPass = User.getHash(Password);
                                    User user = new User(Name, Login, hashPass);
                                    context.Users.Add(user);
                                    context.SaveChanges();
                                    DispatcherHelper.CheckBeginInvokeOnUI(
                                        () =>
                                        {
                                            Messenger.Default.Send<OpenWindowMessage>(
                                            new OpenWindowMessage() { Type = WindowType.kMain, Argument = user });
                                        }
                                        );
                                }
                                else
                                {
                                    IsVisibleProgressBar = false;
                                    Message = "Incorrect data!";
                                    IsOpenDialog = true;
                                }
                    }
                    ));
            }
        }

        public RegistrationViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
