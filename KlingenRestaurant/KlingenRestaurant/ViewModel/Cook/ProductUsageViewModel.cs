using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    class ProductUsageViewModel: ViewModelBase
    {
        #region Private members 
        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private string productName;
        private double productCount;

        private bool isVisibleProgressBar;

        #endregion

        #region Public members


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

        public double ProductCount
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

        //private RelayCommandParametr usageProductCommand;
        //public RelayCommandParametr usageProductCommand
        //{
        //    get
        //    {
        //        return orderProductCommand
        //            ?? (orderProductCommand = new RelayCommandParametr(
        //            (obj) =>
        //            {
        //                if (!String.IsNullOrWhiteSpace(ProductName) && ProductCount != 0)
        //                {
        //                    IsVisibleProgressBar = true;
        //                    ThreadPool.QueueUserWorkItem(
        //                    (o) =>
        //                    {

        //                        context.Products.Add(products);
        //                        context.SaveChanges();
        //                        IsVisibleProgressBar = false;

        //                        ProductName = string.Empty;

        //                    });
        //                }
        //            },
        //            (x) => !String.IsNullOrWhiteSpace(ProductName)));
        //    }
        //}
        #endregion

        #region ctor
        public ProductUsageViewModel(IFrameNavigationService navigationService)
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
