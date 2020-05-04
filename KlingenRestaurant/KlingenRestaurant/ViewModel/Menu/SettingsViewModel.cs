using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class SettingsViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _settingsPageText = "Settings Page";
        public string SettingsPageText
        {
            get
            {
                return _settingsPageText;
            }

            set
            {
                if (_settingsPageText == value)
                {
                    return;
                }

                _settingsPageText = value;
                RaisePropertyChanged();
            }
        }

        public SettingsViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

