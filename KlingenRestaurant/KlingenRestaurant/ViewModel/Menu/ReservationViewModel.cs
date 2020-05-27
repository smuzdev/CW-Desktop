using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Data.Entity;

namespace KlingenRestaurant
{
    public class ReservationViewModel : ViewModelBase
    {
        #region Private Fields

        private RestaurantContext context = new RestaurantContext();
        private User user;
        private string clientName;
        private string phone;
        private string reservationTime;
        private DateTime reservationDate;
        private ObservableCollection<Table> nTable;
        private Table selectedTable;
        private string wishes;
        private bool isVisibleProgressBar;
        private bool isOpenDialog;
        private string message;

        #endregion

        #region Public Fields

        public string ClientName
        {
            get
            {
                return clientName;
            }

            set
            {
                if (clientName == value)
                {
                    return;
                }

                clientName = value;
                RaisePropertyChanged();
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                if (phone == value)
                {
                    return;
                }
                    phone = value;
                    RaisePropertyChanged();
            }
        }

        public string ReservationTime
        {
            get
            {
                return reservationTime;
            }

            set
            {
                if (reservationTime == value)
                {
                    return;
                }

                reservationTime = value;
                NTable = GetFreeTables();
                RaisePropertyChanged();
            }
        }

        public DateTime ReservationDate
        {
            get
            {
                return reservationDate;
            }

            set
            {
                if (reservationDate == value)
                {
                    return;
                }

                reservationDate = value;
                NTable = GetFreeTables();
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Table> NTable
        {
            get
            {
                return nTable;
            }

            set
            {
                if (nTable == value)
                {
                    return;
                }

                nTable = value;
                RaisePropertyChanged();
            }
        }
        public Table SelectedTable
        {
            get
            {
                return selectedTable;
            }

            set
            {
                if (selectedTable == value)
                {
                    return;
                }

                selectedTable = value;
                RaisePropertyChanged();
            }
        }

        public string Wishes
        {
            get
            {
                return wishes;
            }

            set
            {
                if (wishes == value)
                {
                    return;
                }

                wishes = value;
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
        /// <summary>
        /// Is Open Dialog 
        /// </summary>
        public bool IsOpenDialog
        {
            get
            {
                return isOpenDialog;
            }
            set
            {
                if (isOpenDialog == value)
                {
                    return;
                }
                isOpenDialog = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Message for the dialog  
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message == value)
                {
                    return;
                }
                message = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands

        private RelayCommand closeDialodCommand;
        public RelayCommand CloseDialodCommand
        {
            get
            {
                return closeDialodCommand
                    ?? (closeDialodCommand = new RelayCommand(
                    () =>
                    {
                        IsOpenDialog = false;
                    }));
            }
        }

        private RelayCommandParametr _reserveCommand;
        public RelayCommandParametr ReserveCommand
        {
            get
            {
                return _reserveCommand
                    ?? (_reserveCommand = new RelayCommandParametr(
                    (x) =>
                    {
                        IsVisibleProgressBar = true;
                        ThreadPool.QueueUserWorkItem(
                        o =>
                        {
                            if (SelectedTable != null)
                            {
                                var user = SimpleIoc.Default.GetInstance<MainViewModel>().User;

                                DateTime dateTimeReservation = ChosenDate();

                                Reservation reservation = new Reservation()
                                {
                                    TableId = SelectedTable.TableId,
                                    UserId = user.UserId,
                                    ClientName = user.Name,
                                    Phone = Phone,
                                    ReservationDate = dateTimeReservation,
                                    ReservationDateEnd = dateTimeReservation.AddHours(2),
                                    ReservationDateBegin = dateTimeReservation.AddHours(-2),
                                    Wishes = Wishes
                                    
                                };
                                context.Reservations.Add(reservation);
                                context.SaveChanges();
                                Message = "Столик успешно забронирован!";
                                NTable = GetFreeTables();
                                IsOpenDialog = true;
                                Phone = Wishes = String.Empty;
                                SelectedTable = null;
                                IsVisibleProgressBar = false;
                            }
                            else
                            {
                                IsVisibleProgressBar = false;
                                Message = "Укажите столик!";
                                IsOpenDialog = true;
                            }
                        }
                    );
                    },
                    (x1) =>
                    Phone?.Length > 0));
            }
        }
        #endregion

        #region Helper
        public ObservableCollection<Table> GetFreeTables()
        {
            DateTime chosenTime = ChosenDate();
            ObservableCollection<Table> tables = new ObservableCollection<Table>(context.Tables.ToList());

            ObservableCollection<Reservation> reservations =
                                    new ObservableCollection<Reservation>(
                                                                context.Reservations.AsNoTracking().Include(x=> x.Table)
                                                                .Where(x => x.ReservationDateBegin <= chosenTime
                                                                         && x.ReservationDateEnd > chosenTime)
                                                                .ToList());
            foreach (var item in reservations)
            {
                tables.Remove(item.Table);
            }
            SelectedTable = null;
            return tables;
        }

        public DateTime ChosenDate()
        {
            DateTime dateTimeReservation = ReservationDate.Date;
            DateTime time = Convert.ToDateTime(ReservationTime);
            
            dateTimeReservation = dateTimeReservation.AddHours(time.Hour);
            dateTimeReservation = dateTimeReservation.AddMinutes(time.Minute);
            dateTimeReservation = dateTimeReservation.AddSeconds(time.Second);
            return dateTimeReservation;
        }

        public ReservationViewModel()
        {
            user = SimpleIoc.Default.GetInstance<MainViewModel>().User;
            ClientName = user.Name;
            Phone = Wishes = String.Empty;
            SelectedTable = null;
            ReservationDate = DateTime.Now;
            ReservationTime = DateTime.Now.ToShortTimeString();
            NTable = GetFreeTables();
        }

        #endregion
    }
}