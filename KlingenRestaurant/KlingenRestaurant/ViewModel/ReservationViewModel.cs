using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KlingenRestaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.ViewModel
{
    public class ReservationViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _reservationPageText = "Reservation Page";
        public string ReservationPageText
        {
            get
            {
                return _reservationPageText;
            }

            set
            {
                if (_reservationPageText == value)
                {
                    return;
                }

                _reservationPageText = value;
                RaisePropertyChanged();
            }
        }
    
        public ReservationViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}