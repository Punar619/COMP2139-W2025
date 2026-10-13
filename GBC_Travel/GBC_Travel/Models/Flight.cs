using System.ComponentModel.DataAnnotations;

namespace GBC_Travel.Models
{
    public class Flight
    {
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Flight Number is required")]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Airline is required")]
        public string Airline { get; set; } = string.Empty;

        [Required(ErrorMessage = "Origin is required")]
        public string Origin { get; set; } = string.Empty;

        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; } = string.Empty;

        [Required(ErrorMessage = "Departure Time is required")]
        [Display(Name = "Departure Time")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival Time is required")]
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Price must be greater than zero")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}