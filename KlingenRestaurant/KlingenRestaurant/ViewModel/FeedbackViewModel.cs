using GalaSoft.MvvmLight;
using KlingenRestaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant.ViewModel
{
    public class FeedbackViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _feedbackPageText = "Feedback Page";
        public string FeedbackPageText
        {
            get
            {
                return _feedbackPageText;
            }

            set
            {
                if (_feedbackPageText == value)
                {
                    return;
                }

                _feedbackPageText = value;
                RaisePropertyChanged();
            }
        }

        public FeedbackViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

