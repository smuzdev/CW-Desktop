using System.Collections.Generic;

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

        public virtual List<FavoriteDish> FavoriteDishes { get; set; }

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
