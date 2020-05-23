using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class CookViewModel
    {
        private IFrameNavigationService _navigationService;

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

        public CookViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

