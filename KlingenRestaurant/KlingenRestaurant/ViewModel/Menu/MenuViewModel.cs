using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class MenuViewModel : ViewModelBase
    {
        #region Private members
        private RestaurantContext context = new RestaurantContext();
        private IFrameNavigationService _navigationService;
        private ObservableCollection<MenuDish> menuDishes = new ObservableCollection<MenuDish>();
        #endregion

        #region Public members
        public ObservableCollection<MenuDish> MenuDishes
        {
            get { return menuDishes; }
            set
            {
                if (menuDishes == value)
                {
                    return;
                }
                menuDishes = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands

        private RelayCommandParametr loadedCommand;
        public RelayCommandParametr LoadedCommand
        {
            get
            {
                return loadedCommand
                    ?? (loadedCommand = new RelayCommandParametr(
                    obj =>
                    {
                            MenuDishes = new ObservableCollection<MenuDish>(context.Dishes.AsNoTracking().ToList());

                    }));
            }
        }


        private RelayCommandParametr _aboutDishCommand;
        public RelayCommandParametr AboutDishCommand
        {
            get
            {
                return _aboutDishCommand
                       ?? (_aboutDishCommand = new RelayCommandParametr(
                           (obj) =>
                           {

                               _navigationService.NavigateTo("AboutDish", obj);
                           }));
            }
        }

        #endregion

        #region ctor
        public MenuViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}

