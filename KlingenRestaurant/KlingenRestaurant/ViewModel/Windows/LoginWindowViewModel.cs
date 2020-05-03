using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KlingenRestaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.ViewModel.Windows
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private RelayCommand _loadedpageCommand;

        public RelayCommand LoadedPageCommand
        {
            get
            {
                return _loadedpageCommand
                    ?? (_loadedpageCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Login");
                    }));
            }
        }

        public LoginWindowViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
