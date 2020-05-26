using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading;

namespace KlingenRestaurant
{
    class OrderingProductViewModel : ViewModelBase
    {
        #region Private Fields 
        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private string productName;
        private ProductType productType;
        private int productCount;
        private bool isOpenDialog;
        private string message;

        private bool isVisibleProgressBar;

        #endregion

        #region Public Fields

        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                if (productName == value)
                {
                    return;
                }

                productName = value;
                RaisePropertyChanged();
            }
        }

        public ProductType ProductType
        {
            get
            {
                return productType;
            }
            set
            {
                if (productType == value)
                {
                    return;
                }

                productType = value;
                RaisePropertyChanged();
            }
        }

        public int ProductCount
        {
            get
            {
                return productCount;
            }
            set
            {
                if (productCount == value)
                {
                    return;
                }

                productCount = value;
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

        private RelayCommandParametr orderProductCommand;
        public RelayCommandParametr OrderProductCommand
        {
            get
            {
                return orderProductCommand
                    ?? (orderProductCommand = new RelayCommandParametr(
                    (obj) =>
                    {

                        if (!String.IsNullOrWhiteSpace(ProductName) && ProductCount != 0)
                        {
                            IsVisibleProgressBar = true;
                            ThreadPool.QueueUserWorkItem(
                            (o) =>
                            {

                                Product products = new Product(productName, productType, productCount);

                                context.Products.Add(products);
                                context.SaveChanges();
                                IsVisibleProgressBar = false;
                                Message = "Продукт заказан!";
                                IsOpenDialog = true;
                                ProductName = string.Empty;

                            });
                        } 
                    },
                    (x) => !String.IsNullOrWhiteSpace(ProductName) && ProductType != 0));
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
        public OrderingProductViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            if (!IsVisibleProgressBar)
            {
                ProductName = String.Empty;
            }
            #endregion

        }
    }
}

