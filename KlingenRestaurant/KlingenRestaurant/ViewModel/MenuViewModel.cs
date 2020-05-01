using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KlingenRestaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.ViewModel
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
            menuDishes.Add(new MenuDish("Ребрышки барбекю", "Ребрышки — это мясо считается наиболее мягким, сочным и вкусным, особенно если правильно его приготовить.", "/Images/MenuDishes/bbq.jpg", 9.5));
            menuDishes.Add(new MenuDish("Буженина", "Буженина — это невероятно сочное и ароматное блюдо из мяса. Приготовленная на гриле по старинному рецепту, которому больше 120 лет.", "/Images/MenuDishes/buzhenina.jpg", 9.5));
            menuDishes.Add(new MenuDish("Крылышки", "Вкусные куриные крылышки с хрустящей корочкой, да ещё с ароматным томатным соусом, весьма будут кстати в дружеской компании.", "/Images/MenuDishes/krilya.jpg", 4));
            menuDishes.Add(new MenuDish("Филе-миньон", "Филе-миньон традиционно считается женским стейком: во-первых, это самое нежное и постное мясо.", "/Images/MenuDishes/minion.jpg", 11));
            menuDishes.Add(new MenuDish("Солянка", "Блюдо русской кухни, суп на крутом мясном, рыбном или грибном бульоне с острыми приправами.", "/Images/MenuDishes/solyanka.jpg", 12.5));
            menuDishes.Add(new MenuDish("Мясная нарезка", "Классический набор будет состоять из: мягкой нарезки, твердых копченых колбас с характером, запеченного цельного куска мяса", "/Images/MenuDishes/meat.jpg", 5));

        }
    }
}

