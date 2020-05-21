using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KlingenRestaurant
{ 
    /// <summary>
    /// Логика взаимодействия для ReservedTablesPage.xaml
    /// </summary>
    public partial class ReservedTablesPage : Page
    {
        public ReservedTablesPage()
        {
        DataContext = new ReservedTablesViewModel(SimpleIoc.Default.GetInstance<IFrameNavigationService>());
        InitializeComponent();
        }
    }
}
