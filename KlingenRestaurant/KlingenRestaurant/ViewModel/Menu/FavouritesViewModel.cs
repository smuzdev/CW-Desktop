using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Data.Entity;

namespace KlingenRestaurant
{
    public class FavouritesViewModel : ViewModelBase
    {
        #region Private Fields

        private RestaurantContext context = new RestaurantContext();
        private IFrameNavigationService _navigationService;
        private MenuDish menuDish { get; set; }
        private ObservableCollection<MenuDish> menuDishes;
        private User user;
        private string searchField;
        private bool isVisibleProgressBar;
        private Thread searchedThread;
        private Thread loadedThread;
        private bool isFavorite;

        #endregion

        #region Public Fields

        public ObservableCollection<MenuDish> MenuDishes
        {
            get
            {
                return menuDishes;
            }

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

        public string SearchField
        {
            get
            {
                return searchField;
            }
            set
            {
                if (searchField == value)
                {
                    return;
                }

                searchField = value;
                RaisePropertyChanged();
            }
        }

        public bool IsFavorite
        {
            get
            {
                return isFavorite;
            }
            set
            {
                if (isFavorite == value)
                {
                    return;
                }
                isFavorite = value;
                RaisePropertyChanged();
            }
        }

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
                        user = SimpleIoc.Default.GetInstance<MainViewModel>().User;
                        IsVisibleProgressBar = true;
                        SearchField = string.Empty;
                        loadedThread = new Thread(() =>
                        {

                            MenuDishes = new ObservableCollection<MenuDish>(context.FavoriteDishes.Where(x => x.UserId == user.UserId)
                                                                            .Include(x => x.MenuDish).Select(x => x.MenuDish).ToList());
                                                                                                    
                            IsVisibleProgressBar = false;

                        });
                        loadedThread.IsBackground = true;
                        loadedThread.Start();

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
        public FavouritesViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}

