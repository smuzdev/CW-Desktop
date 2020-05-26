using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Linq;
using System.Threading;

namespace KlingenRestaurant
{
    public class AboutDishViewModel : ViewModelBase
    {
        #region Private Fields
        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private bool isFavorite;
        private User user;
        private MenuDish menuDish { get; set; }
        private bool isOpenDialog;
        private string message;
        #endregion

        #region Public Fields
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
        #endregion

        #region Commands

        private RelayCommandParametr addToFavoriteCommand;
        public RelayCommandParametr AddToFavoriteCommand
        {
            get
            {
                return addToFavoriteCommand
                    ?? (addToFavoriteCommand = new RelayCommandParametr(
                    (x) =>
                    {
                        Thread temp;
                        if (!IsFavorite)
                        {
                            FavoriteDish favorite = new FavoriteDish()
                            {
                                UserId = user.UserId,
                                MenuDishId = MenuDish.MenuDishId
                            };
                            temp = new Thread(() =>
                            {

                                context.FavoriteDishes.Add(favorite);
                                context.SaveChanges();
                                IsFavorite = true;
                                Message = "Блюдо добавлено в избранные!";
                                IsOpenDialog = true;
                                
                            });
                        }
                        else
                        {
                            temp = new Thread(() =>
                            {
                                FavoriteDish favdish = context.FavoriteDishes.Where(x1 => x1.UserId == user.UserId && x1.MenuDishId == menuDish.MenuDishId).First();
                                if (favdish != null)
                                {
                                    context.FavoriteDishes.Remove(favdish);
                                }
                                context.SaveChanges();
                                Message = "Блюдо удалено из избранных!";
                                IsOpenDialog = true;
                                IsFavorite = false;
                            });
                        }
                        temp.IsBackground = true;
                        temp.Start();
                    }));
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
                    user = SimpleIoc.Default.GetInstance<MainViewModel>().User;
                    FavoriteDish favdish = context.FavoriteDishes.AsNoTracking().Where(x => x.UserId == user.UserId && x.MenuDishId == menuDish.MenuDishId).FirstOrDefault();
                    IsFavorite = favdish != null ? true : false;
                }));
            }
        }

        private RelayCommand closeDialodCommand;
        public RelayCommand CloseDialodCommand
        {
            get
            {
                return closeDialodCommand
                    ?? (closeDialodCommand = new RelayCommand(
                    () =>
                    {
                        IsOpenDialog = false;
                    }));
            }
        }
        #endregion

        #region ctor
        public AboutDishViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuDish = navigationService.Parameter as MenuDish;
        }
        #endregion
    }
}