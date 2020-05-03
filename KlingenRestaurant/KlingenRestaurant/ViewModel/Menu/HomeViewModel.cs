using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KlingenRestaurant.Helpers;

namespace KlingenRestaurant.ViewModel
{
    public class HomeViewModel: ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _homePageText = "Home Page";
        public string HomePageText
        {
            get
            {
                return _homePageText;
            }

            set
            {
                if (_homePageText == value)
                {
                    return;
                }

                _homePageText = value;
                RaisePropertyChanged();
            }
        }

        public HomeViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
