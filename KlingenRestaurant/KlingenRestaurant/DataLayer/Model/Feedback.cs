using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlingenRestaurant
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        [Required]
        public string FeedbackMessage { get; set; }

        public DateTime PostDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Feedback()
        {

        }

        public string GetShortDate()
        {
            return PostDate.ToShortDateString();
        }
    }
}
