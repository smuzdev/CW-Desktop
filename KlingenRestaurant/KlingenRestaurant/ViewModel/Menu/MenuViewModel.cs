using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace KlingenRestaurant
{
    public class MenuViewModel : ViewModelBase
    {
        #region Private Fields

        private RestaurantContext context = new RestaurantContext();
        private IFrameNavigationService _navigationService;
        private ObservableCollection<MenuDish> menuDishes = new ObservableCollection<MenuDish>();
        private string searchField;
        private bool isVisibleProgressBar;
        private Thread searchedThread;

        #endregion

        #region Public Fields

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


        private RelayCommandParametr searchCommand;
        public RelayCommandParametr SearchCommand
        {
            get
            {
                return searchCommand
                    ?? (searchCommand = new RelayCommandParametr(
                    (obj) =>
                    {
                        IsVisibleProgressBar = true;
                        searchedThread = new Thread(() =>
                        {
                            if (String.IsNullOrWhiteSpace(searchField))
                            {
                                MenuDishes = new ObservableCollection<MenuDish>(context.Dishes.AsNoTracking().ToList());
                            }
                            else if (!String.IsNullOrWhiteSpace(searchField))
                            {
                                MenuDishes = new ObservableCollection<MenuDish>(context.Dishes.Where(x => x.MenuDishName.Contains(searchField)));

                            }
                            SearchField = null;
                            IsVisibleProgressBar = false;
                        });
                        searchedThread.IsBackground = true;
                        searchedThread.Start();
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

