using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    class AddNewsBlockViewModel : ViewModelBase
    {
        #region Private members 
        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private string newsBlockName;
        private string newsBlockDescription;
        private byte[] newsBlockImage;
        private bool isVisibleProgressBar;

        #endregion

        #region Public members

        public byte[] NewsBlockImage
        {
            get
            {
                return newsBlockImage;
            }
            set
            {
                if (newsBlockImage == value)
                {
                    return;
                }

                newsBlockImage = value;
                RaisePropertyChanged();
            }
        }
        public string NewsBlockName
        {
            get
            {
                return newsBlockName;
            }
            set
            {
                if (newsBlockName == value)
                {
                    return;
                }

                newsBlockName = value;
                RaisePropertyChanged();
            }
        }

        public string NewsBlockDescription
        {
            get
            {
                return newsBlockDescription;
            }
            set
            {
                if (newsBlockDescription == value)
                {
                    return;
                }

                newsBlockDescription = value;
                RaisePropertyChanged();
            }
        }

        public bool IsVisibleProgressBar
        {
            get
            {
                return isVisibleProgressBar;
            }
            set
            {
                if (isVisibleProgressBar == value)
                {
                    return;
                }
                isVisibleProgressBar = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands
        private RelayCommandParametr _setPathToImageCommand;
        public RelayCommandParametr SetPathToImageCommand
        {
            get
            {

                return _setPathToImageCommand
                    ?? (_setPathToImageCommand = new RelayCommandParametr(
                    (o) =>
                    {
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(this, "ChooseImage"));
                    },
                    (x) => IsVisibleProgressBar == false));
            }
        }

        private RelayCommandParametr addNewsCommand;
        public RelayCommandParametr AddNewsCommand
        {
            get
            {
                return addNewsCommand
                    ?? (addNewsCommand = new RelayCommandParametr(
                    (obj) =>
                    {
                        if (!String.IsNullOrWhiteSpace(NewsBlockName) && !String.IsNullOrWhiteSpace(NewsBlockDescription))
                        {
                            IsVisibleProgressBar = true;
                            ThreadPool.QueueUserWorkItem(
                            (o) =>
                            {

                                NewsBlock news = new NewsBlock(newsBlockName, newsBlockDescription, newsBlockImage);

                                context.News.Add(news);
                                context.SaveChanges();
                                IsVisibleProgressBar = false;

                                NewsBlockName = NewsBlockDescription = string.Empty;
                                Image img = System.Drawing.Image.FromFile(new Uri("../../Assets/noPhoto.png", UriKind.RelativeOrAbsolute).OriginalString);
                                NewsBlockImage = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));
                            });
                        }
                    },
                    (x) => !String.IsNullOrWhiteSpace(newsBlockName)));
            }
        }
        #endregion

        #region ctor
        public AddNewsBlockViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            if (!IsVisibleProgressBar)
            {
                Image img = System.Drawing.Image.FromFile(new Uri("../../Assets/noPhoto.png", UriKind.RelativeOrAbsolute).OriginalString);

                NewsBlockImage = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));

                NewsBlockName = String.Empty;

                NewsBlockDescription = String.Empty;
            }
            #endregion

        }
    }
}
