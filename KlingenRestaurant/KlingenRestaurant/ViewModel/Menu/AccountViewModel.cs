using GalaSoft.MvvmLight;
using KlingenRestaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _accountPageText = "Account Page";
        public string AccountPageText
        {
            get
            {
                return _accountPageText;
            }

            set
            {
                if (_accountPageText == value)
                {
                    return;
                }

                _accountPageText = value;
                RaisePropertyChanged();
            }
        }

        public AccountViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

