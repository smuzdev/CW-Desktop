using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;


namespace KlingenRestaurant
{
    class WarehouseViewModel : ViewModelBase
    {
        #region Private Fields
        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private ObservableCollection<Product> products;
        private Product selectedProduct;
        private int wasteCount;
        private int addCount;
        private bool isVisibleProgressBar;
        private bool isOpenDialog;
        private string message;
        

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
        /// <summary>
        /// Is Open Dialog 
        /// </summary>
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
         public int WasteCount
        {
            get
            {
                return wasteCount;

            }
            set
            {
                if (wasteCount == value)
                {
                    return;
                }

                wasteCount = value;
                RaisePropertyChanged();
            }
        }

        public int AddCount
        {
            get
            {
                return addCount;

            }
            set
            {
                if (addCount == value)
                {
                    return;
                }

                addCount = value;
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
           private RelayCommandParametr wasteProductCommand;
        public RelayCommandParametr WasteProductCommand
        {
            get
            {
                return wasteProductCommand
                    ?? (wasteProductCommand = new RelayCommandParametr(
                    (o) =>
                    {
                        if (WasteCount <= SelectedProduct.ProductCount)
                        {
                            SelectedProduct.ProductCount -= WasteCount;
                            context.Entry(SelectedProduct).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                            WasteCount = 0;
                            Products = new ObservableCollection<Product>(context.Products.ToList());
                        }
                        else
                        {
                            IsVisibleProgressBar = false;
                            Message = "Задано значение больше, чем есть на складе!";
                            IsOpenDialog = true;
                        }
                        
                    },
                    x => selectedProduct != null));
            }
        }

        private RelayCommandParametr addProductCommand;
        public RelayCommandParametr AddProductCommand
        {
            get
            {
                return addProductCommand
                    ?? (addProductCommand = new RelayCommandParametr(
                    (o) =>
                    {
                            SelectedProduct.ProductCount += AddCount;
                            context.Entry(SelectedProduct).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                            AddCount = 0;
                            Products = new ObservableCollection<Product>(context.Products.ToList());
                    },
                    x => selectedProduct != null));
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

        public WarehouseViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            Products = new ObservableCollection<Product>(context.Products.ToList());
        }

        #endregion
    }
}

