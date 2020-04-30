using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KlingenRestaurant.View
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();

            var menuDish = GetMenuDish();
            if (menuDish.Count > 0)
            {
                ListViewMenuDish.ItemsSource = menuDish;
            }
        }

        private List<MenuDish> GetMenuDish()
        {
            return new List<MenuDish>()
            {
                new MenuDish("Ребрышки барбекю","Ребрышки — это мясо считается наиболее мягким, сочным и вкусным, особенно если правильно его приготовить.","/Images/MenuDishes/bbq.jpg", 9.5),
                new MenuDish("Буженина","Буженина — это невероятно сочное и ароматное блюдо из мяса. Приготовленная на гриле по старинному рецепту, которому больше 120 лет.","/Images/MenuDishes/buzhenina.jpg", 9.5),
                new MenuDish("Крылышки","Вкусные куриные крылышки с хрустящей корочкой, да ещё с ароматным томатным соусом, весьма будут кстати в дружеской компании.","/Images/MenuDishes/krilya.jpg", 4),
                new MenuDish("Филе-миньон","Филе-миньон традиционно считается женским стейком: во-первых, это самое нежное и постное мясо.","/Images/MenuDishes/minion.jpg",11),
                new MenuDish("Солянка","Блюдо русской кухни, суп на крутом мясном, рыбном или грибном бульоне с острыми приправами.","/Images/MenuDishes/solyanka.jpg", 12.5),
                new MenuDish("Мясная нарезка","Классический набор будет состоять из: мягкой нарезки, твердых копченых колбас с характером, запеченного цельного куска мяса","/Images/MenuDishes/meat.jpg",5)
            };
        }
    }
}
