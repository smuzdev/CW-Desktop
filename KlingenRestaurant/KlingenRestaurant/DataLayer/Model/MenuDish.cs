using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
   public class MenuDish
    {
        public int MenuDishId { get; set; }
        public string MenuDishName { get; private set; }
        public string MenuDishDescription { get; private set; }
        public string MenuDishImage { get; private set; }
        public double  DishCostValue { get; private set; }
        public string DishServingWeight { get; private set; }
        public string  DishType { get; private set; }

        public MenuDish(string menuDishName, string dishType, string menuDishDescription, string menuDishImage, double dishCostValue, string dishServingWeight)
        {
            MenuDishName = menuDishName;
            DishType = dishType;
            MenuDishDescription = menuDishDescription;
            MenuDishImage = menuDishImage;
            DishCostValue = dishCostValue;
            DishServingWeight = dishServingWeight;
        }

    }
}
