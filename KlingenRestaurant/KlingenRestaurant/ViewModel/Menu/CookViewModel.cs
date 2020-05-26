namespace KlingenRestaurant
{
    public class CookViewModel
    {
        #region Private Fields
        private IFrameNavigationService _navigationService;
        #endregion

        #region Commands
        private RelayCommandParametr _productUsageCommand;
        public RelayCommandParametr ProductUsageCommand
        {
            get
            {
                return _productUsageCommand
                       ?? (_productUsageCommand = new RelayCommandParametr(
                           (obj) =>
                           {

                               _navigationService.NavigateTo("ProductUsage");
                           }));
            }
        }

        private RelayCommandParametr _orderingProductCommand;
        public RelayCommandParametr OrderingProductCommand
        {
            get
            {
                return _orderingProductCommand
                       ?? (_orderingProductCommand = new RelayCommandParametr(
                           (obj) =>
                           {

                               _navigationService.NavigateTo("OrderingProduct");
                           }));
            }
        }

        private RelayCommandParametr _warehouseCommand;
        public RelayCommandParametr WarehouseCommand
        {
            get
            {
                return _warehouseCommand
                       ?? (_warehouseCommand = new RelayCommandParametr(
                           (obj) =>
                           {

                               _navigationService.NavigateTo("Warehouse");
                           }));
            }
        }
        #endregion

        #region ctor
        public CookViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}

