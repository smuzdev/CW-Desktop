using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KlingenRestaurant
{
    public class MenuItem
    {
        public String Name { get; private set; }  
        public PackIconKind Icon { get; private set; }
        public Brush Color { get; private set; }

        public MenuItem(String name, PackIconKind icon, Brush color)
        {
            Name = name;
            Icon = icon;
            Color = color;
        }

    }
}
