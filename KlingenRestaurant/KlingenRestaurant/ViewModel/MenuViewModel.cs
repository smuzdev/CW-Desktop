using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KlingenRestaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.ViewModel
{
   public class MenuViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _menuPageText = "Menu Page";
        public string MenuPageText
        {
            get
            {
                return _menuPageText;
            }

            set
            {
                if (_menuPageText == value)
                {
                    return;
                }

                _menuPageText = value;
                RaisePropertyChanged();
            }
        }
       
        public MenuViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

