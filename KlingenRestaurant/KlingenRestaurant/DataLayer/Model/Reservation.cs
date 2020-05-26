using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlingenRestaurant
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int TableId { get; set; }
        public string ClientName { get; set; }
        public int UserId { get; set; }
        [ForeignKey("TableId")]  
        public Table Table { get; set; }
        [ForeignKey("UserId")]
        public User User { get;  set; }
        public string Phone { get;  set; }
        public DateTime ReservationDate { get;  set; }
        public DateTime ReservationDateBegin { get; set; }
        public DateTime ReservationDateEnd { get;  set; }

        public string Wishes { get; set; }
        

        public Reservation() { }

        public Reservation(User user, string phone, DateTime reservationDate, Table table, string wishes)
        {
            UserId = user.UserId;
            ClientName = user.Name;
            Phone = phone;
            ReservationDate = reservationDate;
            TableId = table.TableId;
            Wishes = wishes;
        }

    }
}

