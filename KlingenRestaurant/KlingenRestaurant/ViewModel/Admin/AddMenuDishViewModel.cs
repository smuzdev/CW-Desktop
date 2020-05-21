using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Ioc;

namespace KlingenRestaurant
{
    class AddMenuDishViewModel : ViewModelBase
    {
        #region Private Members 

        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private string menuDishName;
        private string menuDishDescription;
        private double dishCostValue;
        private string dishServingWeight;
        private DishType dishType;
        private byte[] menuDishImage;
        private bool isVisibleProgressBar;

        #endregion

        #region Public Members

        public byte[] MenuDishImage
        {
            get
            {
                return menuDishImage;
            }
            set
            {
                if (menuDishImage == value)
                {
                    return;
                }

                menuDishImage = value;
                RaisePropertyChanged();
            }
        }
        public string MenuDishName
        {
            get
            {
                return menuDishName;
            }
            set
            {
                if (menuDishName == value)
                {
                    return;
                }

                menuDishName = value;
                RaisePropertyChanged();
            }
        }

        public string MenuDishDescription
        {
            get
            {
                return menuDishDescription;
            }
            set
            {
                if (menuDishDescription == value)
                {
                    return;
                }

                menuDishDescription = value;
                RaisePropertyChanged();
            }
        }

        public double DishCostValue
        {
            get
            {
                return dishCostValue;
            }
            set
            {
                if (dishCostValue == value)
                {
                    return;
                }
                dishCostValue = value;
                RaisePropertyChanged();
            }
        }

        public string DishServingWeight
        {
            get
            {
                return dishServingWeight;
            }
            set
            {
                if (dishServingWeight == value)
                {
                    return;
                }
                dishServingWeight = value;
                RaisePropertyChanged();
            }
        }

        public DishType DishType
        {
            get
            {
                return dishType;
            }
            set
            {
                if (dishType == value)
                {
                    return;
                }
                dishType = value;
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
        private RelayCommandParametr _setPathToImageCommand;
        public RelayCommandParametr SetPathToImageCommand
        {
            get
            {

                return _setPathToImageCommand
                    ?? (_setPathToImageCommand = new RelayCommandParametr(
                    (o) =>
                    {
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(this, "ChooseImage"));
                    },
                    (x) => IsVisibleProgressBar == false));
            }
        }

        private RelayCommandParametr addDishCommand;
        public RelayCommandParametr AddDishCommand
        {
            get
            {
                return addDishCommand
                    ?? (addDishCommand = new RelayCommandParametr(
                    (obj) =>
                    {
                        if (!String.IsNullOrWhiteSpace(MenuDishName) && !String.IsNullOrWhiteSpace(MenuDishDescription))
                        {
                            IsVisibleProgressBar = true;
                            ThreadPool.QueueUserWorkItem(
                            (o) =>
                            {
                               
                                MenuDish dish = new MenuDish(menuDishName, dishType, menuDishDescription, menuDishImage, DishCostValue, dishServingWeight);

                                context.Dishes.Add(dish);
                                context.SaveChanges();
                                IsVisibleProgressBar = false;

                                DishCostValue = 0;
                                MenuDishName = MenuDishDescription = DishServingWeight = string.Empty;
                                Image img = System.Drawing.Image.FromFile(new Uri("../../Assets/noPhoto.png", UriKind.RelativeOrAbsolute).OriginalString);
                                MenuDishImage = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));
                            });
                        }
                    },
                    (x) => !String.IsNullOrWhiteSpace(menuDishName)));
            }
        }
        #endregion

        #region ctor
        public AddMenuDishViewModel(IFrameNavigationService navigationService)
        {

            _navigationService = navigationService;
            if (!IsVisibleProgressBar)
            {
                Image img = System.Drawing.Image.FromFile(new Uri("../../Assets/noPhoto.png", UriKind.RelativeOrAbsolute).OriginalString);
                menuDishImage = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));
                
                MenuDishName = String.Empty;
                DishCostValue = 0;
                DishServingWeight = String.Empty;
                MenuDishDescription = String.Empty;
            }

        }
        #endregion
    }
}
