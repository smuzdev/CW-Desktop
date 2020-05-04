using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    public class MenuViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;

        private ObservableCollection<MenuDish> menuDishes = new ObservableCollection<MenuDish>();

        public ObservableCollection<MenuDish> MenuDishes
        {
            get { return menuDishes; }
            set
            {
                if (menuDishes == value)
                {
                    return;
                }
                menuDishes = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommandParametr _aboutDishCommand;
        public RelayCommandParametr AboutDishCommand
        {
            get
            {
                return _aboutDishCommand
                       ?? (_aboutDishCommand = new RelayCommandParametr(
                           (obj) =>
                           {

                               _navigationService.NavigateTo("AboutDish", obj);
                           }));
            }
        }

        public MenuViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;                                                                                                                                                                                        
            menuDishes.Add(new MenuDish("Ребрышки барбекю",
                                        "Горячее",
                                        "Ребрышки барбекю, румяные, хрустящие, с аппетитной корочкой, готовят на природе, дома на гриле или в духовке," +
                                        " а подают как второе блюдо с овощами и картофелем. Ребрышки представляют собой часть грудинки со слоем мышц, жира" +
                                        " и ребрами — это мясо считается наиболее мягким, сочным и вкусным, особенно если правильно его приготовить.",
                                        "/Assets/MenuDishes/bbq.jpg", 9.5, "300г."));
            menuDishes.Add(new MenuDish("Буженина",
                                        "Горячее",
                                        "Буженина — это невероятно сочное и ароматное блюдо из мяса. Приготовленная на гриле по старинному рецепту, " +
                                        "которому больше 120 лет. Насладитесь ей, пока буженина еще горячая, или ешьте ее охлажденной, нарезав тонкими ломтиками, как колбасу.",
                                        "/Assets/MenuDishes/buzhenina.jpg", 9.5, "300г."));
            menuDishes.Add(new MenuDish("Крылышки",
                                        "Горячее",  
                                        "Вкусные куриные крылышки с хрустящей корочкой, да ещё с ароматным томатным соусом, весьма будут кстати в дружеской компании, например," +
                                        " к бокалу пива. Панированные крылышки, приготовленные по этому рецепту во фритюре не могут не понравиться. Они мягкие и хорошо прожаренные" +
                                        " внутри, а сверху покрыты очень хрустящей, аппетитно поджаристой корочкой.",
                                        "/Assets/MenuDishes/krilya.jpg", 4, "150г."));
            menuDishes.Add(new MenuDish("Филе-миньон",
                                        "Горячее",
                                        "Филе-миньон традиционно считается женским стейком: во-первых, это самое нежное и постное мясо, а во-вторых, оно никогда не бывает «с кровью»." +
                                        " В этом стейке нет специфического мясного вкуса, которым отличается, например, стейк ти-бон, нет и его жирности. Для приготовления филе-миньона " +
                                        "берется поперечный тонкий срез центральной части филейной вырезки.",
                                        "/Assets/MenuDishes/minion.jpg", 11, "350г."));
            menuDishes.Add(new MenuDish("Солянка",
                                        "Горячее",
                                        "Вкусные куриные крылышки с хрустящей корочкой, да ещё с ароматным томатным соусом, весьма будут кстати в дружеской компании," +
                                        " например, к бокалу пива. Панированные крылышки, приготовленные по этому рецепту во фритюре не могут не понравиться. Они мягкие" +
                                        " и хорошо прожаренные внутри, а сверху покрыты очень хрустящей, аппетитно поджаристой корочкой.",
                                        "/Assets/MenuDishes/solyanka.jpg", 12.5, "200г."));
            menuDishes.Add(new MenuDish("Мясная тарелка",
                                        "Горячее",
                                        "Классический набор будет состоять из: мягкой нарезки (вроде итальянской прошутто или мортаделло), твердых копченых колбас" +
                                        " с характером (вроде салями или чоризо), запеченного цельного куска мяса (плотного, например корейки или даже индейки), " +
                                        "сала (очень тонко нарезанного), паштета или риета (паштета грубой текстуры, в котором сохранены волокна мяса), лучше всего из мяса птицы (например, утки), ",
                                        " /Assets/MenuDishes/meat.jpg", 5, "500г."));

        }
    }
}

