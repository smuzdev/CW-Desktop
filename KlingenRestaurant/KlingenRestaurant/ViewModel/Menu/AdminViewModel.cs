using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class AdminViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private RelayCommandParametr _addMenuDishCommand;
        public RelayCommandParametr AddMenuDishCommand
        {
            get
            {
                return _addMenuDishCommand
                       ?? (_addMenuDishCommand = new RelayCommandParametr(
                           (obj) =>
                           {

                               _navigationService.NavigateTo("AddMenuDish");
                           }));
            }
        }

        private RelayCommandParametr _addNewsBlockCommand;
        public RelayCommandParametr AddNewsBlockCommand
        {
            get
            {
                return _addNewsBlockCommand
                       ?? (_addNewsBlockCommand = new RelayCommandParametr(
                           (obj) =>
                           {

                               _navigationService.NavigateTo("AddNewsBlock");
                           }));
            }
        }

        private RelayCommandParametr _reservedTablesCommand;
        public RelayCommandParametr ReservedTablesCommand
        {
            get
            {
                return _reservedTablesCommand
                       ?? (_reservedTablesCommand = new RelayCommandParametr(
                           (obj) =>
                           {

                               _navigationService.NavigateTo("ReservedTables");
                           }));
            }
        }

        public AdminViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

