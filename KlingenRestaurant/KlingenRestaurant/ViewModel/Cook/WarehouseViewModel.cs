using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    class WarehouseViewModel : ViewModelBase
    {
        #region Private Fields
        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private ObservableCollection<Product> products;
        private Product selectedProduct;

        #endregion

        #region Public Fields

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                if (products == value)
                {
                    return;
                }

                products = value;
                RaisePropertyChanged();
            }
        }

        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;

            }
            set
            {
                if (selectedProduct == value)
                {
                    return;
                }

                selectedProduct = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        #region Commands

        private RelayCommandParametr deleteProductCommand;
        public RelayCommandParametr DeleteProductCommand
        {
            get
            {
                return deleteProductCommand
                    ?? (deleteProductCommand = new RelayCommandParametr(
                    (o) =>
                    {
                        Product product = context.Products.Find(selectedProduct.ProductId);
                        if (product != null)
                        {
                            context.Products.Remove(product);
                        }
                        context.SaveChanges();
                        Products.Remove(selectedProduct);
                    },
                    x => selectedProduct != null));
            }
        }
        #endregion

        #region ctor

        public WarehouseViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            Products = new ObservableCollection<Product>(context.Products.AsNoTracking().ToList());
        }

        #endregion
    }
}

