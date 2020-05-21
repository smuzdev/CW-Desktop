using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace KlingenRestaurant
{
   public class MenuDish
    {
        public int MenuDishId { get; set; }
        public string MenuDishName { get; private set; }
        public string MenuDishDescription { get; private set; }
        public byte[] MenuDishImage { get; private set; }
        public double DishCostValue { get; private set; }
        public string DishServingWeight { get; private set; }
        public DishType DishType { get; private set; }

        public MenuDish()
        {
           
        }

        public MenuDish(string menuDishName, DishType dishType, string menuDishDescription, byte[] menuDishImage, double dishCostValue, string dishServingWeight)
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
