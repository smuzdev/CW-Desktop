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
    public class AboutDishViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private MenuDish menuDish { get; set; }

        public MenuDish MenuDish
        {
            get
            {
                return menuDish;
            }
            set
            {
                if (menuDish == value)
                {
                    return;
                }
                menuDish = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand _loadedpageCommand;
        public RelayCommand LoadedPageCommand
        {
            get
            {
                return _loadedpageCommand
                ?? (_loadedpageCommand = new RelayCommand(
                () =>
                {
                    MenuDish = _navigationService.Parameter as MenuDish;
                }));
            }
        }

        public AboutDishViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuDish = navigationService.Parameter as MenuDish;
        }

    }
}