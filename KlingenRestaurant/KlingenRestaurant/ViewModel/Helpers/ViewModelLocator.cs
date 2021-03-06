﻿using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;


namespace KlingenRestaurant
{

    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<LoginWindowViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AdminViewModel>();
            SimpleIoc.Default.Register<CookViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("Login", new Uri("../Pages/Login/LoginPage.xaml", UriKind.Relative));
            navigationService.Configure("Registration", new Uri("../Pages/Login/RegistrationPage.xaml", UriKind.Relative));
            navigationService.Configure("Home", new Uri("../Pages/Menu/HomePage.xaml", UriKind.Relative));
            navigationService.Configure("Menu", new Uri("../Pages/Menu/MenuPage.xaml", UriKind.Relative));
            navigationService.Configure("AboutDish", new Uri("../Pages/Menu/AboutDishPage.xaml", UriKind.Relative));
            navigationService.Configure("Reservation", new Uri("../Pages/Menu/ReservationPage.xaml", UriKind.Relative));
            navigationService.Configure("Feedback", new Uri("../Pages/Menu/FeedbackPage.xaml", UriKind.Relative));
            navigationService.Configure("Favourites", new Uri("../Pages/Menu/FavouritesPage.xaml", UriKind.Relative));
            navigationService.Configure("Admin", new Uri("../Pages/Menu/AdminPage.xaml", UriKind.Relative));
            navigationService.Configure("Cook", new Uri("../Pages/Menu/CookPage.xaml", UriKind.Relative));
            navigationService.Configure("AddMenuDish", new Uri("../Pages/Admin/AddMenuDishPage.xaml", UriKind.Relative));
            navigationService.Configure("AddNewsBlock", new Uri("../Pages/Admin/AddNewsBlockPage.xaml", UriKind.Relative));
            navigationService.Configure("ReservedTables", new Uri("../Pages/Admin/ReservedTablesPage.xaml", UriKind.Relative));
            navigationService.Configure("OrderingProduct", new Uri("../Pages/Cook/OrderingProductPage.xaml", UriKind.Relative));
            navigationService.Configure("Warehouse", new Uri("../Pages/Cook/WarehousePage.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoginWindowViewModel LoginWindowViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginWindowViewModel>();
            }
        }

        public AdminViewModel AdminViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AdminViewModel>();
            }
        }

        public CookViewModel CookViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CookViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
