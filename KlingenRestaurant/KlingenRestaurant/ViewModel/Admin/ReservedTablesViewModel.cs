using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlingenRestaurant
{
    class ReservedTablesViewModel : ViewModelBase
    {
        #region Private Fields
        private IFrameNavigationService _navigationService;
        private RestaurantContext context = new RestaurantContext();
        private ObservableCollection<Reservation> reservations;
        private Reservation selectedReservation;
        private string dateSearch;
        private string tableIdSearch;
        #endregion
        #region Public Fields

        public ObservableCollection<Reservation> Reservations
        {
            get
            {
                return reservations;
            }

            set
            {
                if (reservations == value)
                {
                    return;
                }

                reservations = value;
                RaisePropertyChanged();
            }
        }

        public Reservation SelectedReservation
        {
            get
            {
                return selectedReservation;

            }
            set
            {
                if (selectedReservation == value)
                {
                    return;
                }

                    selectedReservation = value;
                RaisePropertyChanged();
            }
        }
        
        public string DateSearch
        {
            get
            {
                return dateSearch;
            }

            set
            {
                if (dateSearch == value)
                {
                    return;
                }

                dateSearch = value;
                RaisePropertyChanged();
            }
        }

        public string TableIdSearch
        {
            get
            {
                return tableIdSearch;
            }

            set
            {
                if (tableIdSearch == value)
                {
                    return;
                }

                tableIdSearch = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region Commands
        private RelayCommandParametr searchCommand;
        public RelayCommandParametr SearchCommand
        {
            get
            {
                return searchCommand
                    ?? (searchCommand = new RelayCommandParametr(
                    (o) =>
                    {
                        if ( String.IsNullOrWhiteSpace(DateSearch)
                             && String.IsNullOrWhiteSpace(tableIdSearch))
                        { 
                            Reservations = new ObservableCollection<Reservation>(context.Reservations.AsNoTracking().ToList());

                            
                        }
                        else if (!String.IsNullOrWhiteSpace(DateSearch))
                        {
                            DateTime dateSearchFrom =Convert.ToDateTime(DateSearch);
                            DateTime dateSearchTo = dateSearchFrom.AddDays(1);
                            Reservations = new ObservableCollection<Reservation>(context.Reservations.Where(x => x.TableId.ToString().Contains(tableIdSearch)
                                                                                                && x.ReservationDate >= dateSearchFrom && x.ReservationDate < dateSearchTo).ToList());
                        }
                    }));
            }
        }

        private RelayCommandParametr deleteReservationCommand;
        public RelayCommandParametr DeleteReservationCommand
        {
            get
            {
                return deleteReservationCommand
                    ?? (deleteReservationCommand = new RelayCommandParametr(
                    (o) =>
                    {
                        Reservation reservation = context.Reservations.Find(selectedReservation.ReservationId);
                        if (reservation != null)
                        {
                            context.Reservations.Remove(reservation);
                        }
                        context.SaveChanges();
                        Reservations.Remove(selectedReservation);
                    },
                    x => selectedReservation != null));
            }
        }
        #endregion

        #region ctor

        public ReservedTablesViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            Reservations = new ObservableCollection<Reservation>(context.Reservations.AsNoTracking().ToList());

            DateSearch = TableIdSearch = String.Empty;
        }

        #endregion
    }
}
