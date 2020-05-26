using GalaSoft.MvvmLight;

namespace KlingenRestaurant
{
    public class AdminViewModel : ViewModelBase
    {

        #region Private Fields
        private IFrameNavigationService _navigationService;
        #endregion

        #region Commands
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
        #endregion

        #region ctor
        public AdminViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion]
    }
}

