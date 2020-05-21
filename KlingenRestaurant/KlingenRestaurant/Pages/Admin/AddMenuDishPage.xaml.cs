using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddMenuDishPage.xaml
    /// </summary>
    public partial class AddMenuDishPage : Page
    {
        public AddMenuDishPage()
        {
            DataContext = new AddMenuDishViewModel(SimpleIoc.Default.GetInstance<IFrameNavigationService>());
            InitializeComponent();
            

            Messenger.Default.Register<NotificationMessage>(
              this,
              message =>
              {
                  switch (message.Notification)
                  {
                      case "ChooseImage":
                          {
                              OpenFileDialog openFileDialog = new OpenFileDialog();
                              openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp) | *.jpg; *.jpeg; *.png; *.bmp";
                              if (openFileDialog.ShowDialog() == true)
                                  MenuDishImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                              break;
                          }
                  }
              });
        }
    }
}
