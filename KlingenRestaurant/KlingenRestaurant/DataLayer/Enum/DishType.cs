using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace KlingenRestaurant
{
    public enum DishType
    {
        [Description("Горячее")]
        Hot = 1,
        [Description("Холодное")]
        Cold,
        [Description("Напитки")]
        Drinks
    }


}
       
