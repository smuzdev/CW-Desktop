using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KlingenRestaurant
{
    public class FavoriteDish
    {
        public int FavoriteDishId { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int MenuDishId { get; set; }
        [ForeignKey("MenuDishId")]
        public MenuDish MenuDish { get; set; }

        public FavoriteDish()
        {

        }
    }
}
