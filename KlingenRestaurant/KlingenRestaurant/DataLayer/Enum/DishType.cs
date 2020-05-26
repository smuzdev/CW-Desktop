using System.ComponentModel;

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
       
