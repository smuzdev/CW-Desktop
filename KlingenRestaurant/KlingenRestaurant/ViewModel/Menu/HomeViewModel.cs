using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace KlingenRestaurant
{
    public class HomeViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private ObservableCollection<NewsBlock> newsBlocks = new ObservableCollection<NewsBlock>();
        private RestaurantContext context = new RestaurantContext();

        public ObservableCollection<NewsBlock> NewsBlocks
        {
            get { return newsBlocks; }
            set
            {
                if (newsBlocks == value)
                {
                    return;
                }
                newsBlocks = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand _loginpageCommand;
        public RelayCommand LoginPageCommand
        {
            get
            {
                return _loginpageCommand
                    ?? (_loginpageCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Login");
                    }));
            }
        }

        private RelayCommandParametr loadedCommand;
        public RelayCommandParametr LoadedCommand
        {
            get
            {
                return loadedCommand
                    ?? (loadedCommand = new RelayCommandParametr(
                    obj =>
                    {
                        NewsBlocks = new ObservableCollection<NewsBlock>(context.News.AsNoTracking().ToList());

                    }));
            }
        }
        public HomeViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
