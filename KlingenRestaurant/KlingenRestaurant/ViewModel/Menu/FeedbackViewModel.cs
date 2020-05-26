using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace KlingenRestaurant
{
    public class FeedbackViewModel : ViewModelBase
    {
        #region Private Fields

        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private User user;
        private string userName;
        private ObservableCollection<Feedback> feedbacks;
        private string feedback;

        #endregion

        #region Public members

        public ObservableCollection<Feedback> Feedbacks
        {
            get
            {
                return feedbacks;
            }

            set
            {
                if (feedbacks == value)
                {
                    return;
                }

                feedbacks = value;
                RaisePropertyChanged();
            }
        }
        public string Feedback
        {
            get
            {
                return feedback;
            }

            set
            {
                if (feedback == value)
                {
                    return;
                }

                feedback = value;
                RaisePropertyChanged();
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                if (userName == value)
                {
                    return;
                }

                userName = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands 


        /// <summary>
        /// Leave comment
        /// </summary>
        private RelayCommandParametr sendFeedbackCommand;
        public RelayCommandParametr SendFeedbackCommand
        {
            get
            {
                return sendFeedbackCommand
                    ?? (sendFeedbackCommand = new RelayCommandParametr(
                    (x) =>
                    {
                        Feedback feedback = new Feedback()
                        {
                            FeedbackMessage = Feedback,
                            PostDate = DateTime.Now,
                            UserId = user.UserId
                        };
                        context.Feedbacks.Add(feedback);
                        context.SaveChanges();
                        Feedback = String.Empty;
                        Feedbacks = new ObservableCollection<Feedback>(context.Feedbacks.Include(i=>i.User).ToList());
                    },
                    (x) =>
                    !String.IsNullOrWhiteSpace(Feedback)));
            }
        }


        #endregion

        #region ctor
        public FeedbackViewModel(IFrameNavigationService navigationService)
        {
            Feedbacks = new ObservableCollection<Feedback>(context.Feedbacks.Include(i => i.User).ToList());
            user = SimpleIoc.Default.GetInstance<MainViewModel>().User;
            _navigationService = navigationService;
        }
        #endregion
    }
}

