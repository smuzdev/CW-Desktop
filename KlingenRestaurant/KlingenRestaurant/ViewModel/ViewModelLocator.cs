using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using KlingenRestaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
            SimpleIoc.Default.Register<ReservationViewModel>();
            SimpleIoc.Default.Register<FeedbackViewModel>();
            SimpleIoc.Default.Register<AccountViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("Home", new Uri("../View/HomePage.xaml", UriKind.Relative));
            navigationService.Configure("Menu", new Uri("../View/MenuPage.xaml", UriKind.Relative));
            navigationService.Configure("Reservation", new Uri("../View/ReservationPage.xaml", UriKind.Relative));
            navigationService.Configure("Feedback", new Uri("../View/FeedbackPage.xaml", UriKind.Relative));
            navigationService.Configure("Account", new Uri("../View/AccountPage.xaml", UriKind.Relative));
            navigationService.Configure("Settings", new Uri("../View/SettingsPage.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public HomeViewModel HomeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }
        public MenuViewModel MenuViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuViewModel>();
            }
        }

        public ReservationViewModel ReservationViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReservationViewModel>();
            }
        }

        public FeedbackViewModel FeedbackViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FeedbackViewModel>();
            }
        }

        public AccountViewModel AccountViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccountViewModel>();
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
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
