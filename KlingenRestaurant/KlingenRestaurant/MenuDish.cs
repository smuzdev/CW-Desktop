using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
   public class MenuDish
    {
        public string MenuDishName { get; private set; }
        public string MenuDishDescription { get; private set; }
        public string MenuDishImage { get; private set; }
        public double  DishCostValue { get; private set; }

        public MenuDish(string menuDishName, string menuDishDescription, string menuDishImage, double dishCostValue)
        {
            MenuDishName = menuDishName;
            MenuDishDescription = menuDishDescription;
            MenuDishImage = menuDishImage;
            DishCostValue = dishCostValue;
        }

    }
}
