using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
