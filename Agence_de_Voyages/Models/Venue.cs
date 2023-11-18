using System.ComponentModel.DataAnnotations;

namespace Agence_de_Voyages.Models
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Venue Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [EnumDataType(typeof(VenueType), ErrorMessage = "Invalid Venue Type code.")]
        [Display(Name = "Venue Type")]
        public string? Type { get; set; }

        // Common properties for all venue types
        [Display(Name = "Venue Rating")]
        [Range(0,5, ErrorMessage ="Rating must be between 0 and 5")]
        public int Rating { get; set; }

        [Range(1, 4, ErrorMessage = "Cost Indicator must be between 1 and 4.")]
        [Display(Name = "Cost Indicator")]
        public  int CostIndicator { get; set; } // indicates how expensive are this venues prices on a 1-3 scale

        [Display(Name = "Free WiFi Available")]
        public bool HasFreeWiFi { get; set; }

        // Additional properties specific to certain venue types
        [Range(0, double.MaxValue, ErrorMessage = "Price per night must be a non-negative value.")]
        [Display(Name = "Price Per Night")]
        public int? PricePerNight { get; set; }  // For hotels 

        [Display(Name = "Cuisine Type")]
        public string? CuisineType { get; set; }  // For restaurants

        [Display(Name = "Entry Fee")]
        public string? EntryFee { get; set; }  // For museums

       
    }

    public enum VenueType
    {
        [Display(Name = "Hotel")]
        Hotel,

        [Display(Name = "Museum")]
        Museum,

        [Display(Name = "Restaurant")]
        Restaurant,

        [Display(Name = "Cafe")]
        Cafe,
    }


}
