using System;
using System.Globalization;
using System.Windows.Data;

namespace KlingenRestaurant
{
    class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            if (value is DishType)
            {
                switch ((DishType)value)
                {
                    case DishType.Cold:
                        {
                            return "Холодное";
                        }
                    case DishType.Hot:
                        {
                            return "Горячее";
                        }
                    case DishType.Drinks:
                        {
                            return "Напитки";
                        }
                }
            }
            else
            {
                switch ((ProductType)value)
                {
                    case ProductType.FruitsVegetables:
                        {
                            return "Овощи и фрукты";
                        }
                    case ProductType.MeatFish:
                        {
                            return "Мясо и рыба";
                        }
                    case ProductType.MilkProducts:
                        {
                            return "Молочные продукты";
                        }
                    case ProductType.Drinks:
                        {
                            return "Напитки и другое";
                        }
                }
            }
                return "";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {

            if (value == null) return "";
            switch (value.ToString())
            {
                case "Холодное":
                    {
                        return DishType.Cold;
                    }
                case "Горячее":
                    {
                        return DishType.Hot;
                    }
                case "Напитки":
                    {
                        return DishType.Drinks;
                    }
                case "Овощи и фрукты":
                    {
                        return ProductType.FruitsVegetables;
                    }
                case "Мясо и рыба":
                    {
                        return ProductType.MeatFish;
                    }
                case "Молочные продукты":
                    {
                        return ProductType.MilkProducts;
                    }
                case "Напитки и другое":
                    {
                        return ProductType.Drinks;
                    }
            }
            return null;
        }
    }
}
