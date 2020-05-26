using System.ComponentModel;

namespace KlingenRestaurant
{
    public enum ProductType
        {
            [Description("Овощи и фрукты")]
            FruitsVegetables = 1,
            [Description("Мясо и рыба")]
            MeatFish,
            [Description("Молочные продукты")]
            MilkProducts,
            [Description("Напитки и другое")]
            Drinks
    }
}
