﻿using MaterialDesignThemes.Wpf;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KlingenRestaurant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool MenuClosed = false;

        public MainWindow()
        {
            InitializeComponent();

            //List<MenuItem> menu = new List<MenuItem>();

            //menu.Add(new MenuItem("Home", PackIconKind.Home, Brushes.White));
            //menu.Add(new MenuItem("Menu", PackIconKind.FoodRamen, Brushes.White));
            //menu.Add(new MenuItem("Reservation", PackIconKind.TableChair, Brushes.White));
            //menu.Add(new MenuItem("Feedback", PackIconKind.Feedback, Brushes.White));
            //menu.Add(new MenuItem("Account", PackIconKind.Account, Brushes.White));
            //menu.Add(new MenuItem("Settings", PackIconKind.Settings, Brushes.White));

            //ListViewMenu.ItemsSource = menu;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuClosed)
            {
                Storyboard openMenu = (Storyboard)MenuButton.FindResource("OpenMenu");
                openMenu.Begin();
            }
            else
            {
                Storyboard closeMenu = (Storyboard)MenuButton.FindResource("CloseMenu");
                closeMenu.Begin();
            }

            MenuClosed = !MenuClosed;
        }
    }
}
