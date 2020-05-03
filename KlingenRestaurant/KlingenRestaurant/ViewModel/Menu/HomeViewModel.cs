using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KlingenRestaurant.Helpers;
using KlingenRestaurant.Model;

namespace KlingenRestaurant.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private ObservableCollection<NewsBlock> newsBlocks = new ObservableCollection<NewsBlock>();

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

        public HomeViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            newsBlocks.Add(new NewsBlock("Попробуй новинку!", 
                                         "Жареное мясо — одно из древнейших блюд в истории" +
                                         " человечества. Вкус к нему заложен в нас генетически. Вероятно, именно поэтому так" +
                                         " много поклонников у аппетитных стейков, шашлыков «с дымком», поджаренных на гриле" +
                                         " куриных крылышек и свиных сосисок. Фантастический вкус — не основная ценность такой пищи" +
                                         ". Она также дает энергию, насыщает организм натуральным белком и витаминами. Мясные блюда" +
                                         " отлично сочетаются с красным вином, хорошим пивом и более крепкими напитками.",
                                         "/Assets/News/1.jpg"));
            newsBlocks.Add(new NewsBlock("Оцени наш фирменный соус Сальса!", "Традиционный соус мексиканской кухни. Чаще всего сальса" +
                                        " изготовляется из отваренных и измельчённых томатов или томатильо и чили, с добавлением кориандра, лука, чеснока и чёрного перца.",
                                        "/Assets/News/2.jpg"));
            newsBlocks.Add(new NewsBlock("Чем полезны овощи?", "Овощи — неотъемлемая часть рациона человека. Они крайне полезны благодаря" +
                " высокому содержанию в них углеводов, различных кислот, витаминов и активных элементов в легкой для усвоения организмом форме." +
                " Разнообразие вышеперечисленных элементов в составе овощей и обусловливает их вкус и питательную ценность.",
                                         "/Assets/News/3.jpg"));

        }
    }
}
