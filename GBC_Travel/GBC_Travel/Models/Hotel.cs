using System.ComponentModel.DataAnnotations;

namespace GBC_Travel.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Hotel Name is required")]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = string.Empty;

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Price Per Night must be greater than zero")]
        [Display(Name = "Price Per Night")]
        [DataType(DataType.Currency)]
        public decimal PricePerNight { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}