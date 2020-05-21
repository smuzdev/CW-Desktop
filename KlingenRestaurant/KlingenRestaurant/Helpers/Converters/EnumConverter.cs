using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KlingenRestaurant 
{
    class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null) return "";
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
            }
            return null;
        }
    }
}
