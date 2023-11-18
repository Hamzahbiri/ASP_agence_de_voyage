using System.ComponentModel.DataAnnotations;

namespace Agence_de_Voyages.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }


        [Required(ErrorMessage = "Name field is Required")]
        [MinLength(3, ErrorMessage = "Name contains at least 3 letters")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Name should not contain special characters")]
        public String? Name { get; set; }


        [Required(ErrorMessage = "Location field is Required")]
        [MinLength(3, ErrorMessage = "Location contains at least 3 letters")]

        public String? Location { get; set; }

        [Required(ErrorMessage = "Date_of_departure field is Required")]
        public String? Date_of_departure { get; set; }

        [Required(ErrorMessage = "Days_number field is Required")]
        public int Days_number { get; set; }


        [Required(ErrorMessage = "Destinations field is Required")]
        public String? Destinations { get; set; }


        [Required(ErrorMessage = "Venues field is Required")]
        public String? Venues { get; set; }

        [Required(ErrorMessage = "Price field is Required")]
        public double Price { get; set; }


        [Required(ErrorMessage = "Image field is Required")]
        public String Image { get; set; }

    }
}