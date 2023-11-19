using System.ComponentModel.DataAnnotations;

namespace Agence_de_Voyages.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        public Tour Tour { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SubmissionDate { get; set; }

        public bool IsReviewed { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReviewDate { get; set; }

        [Required(ErrorMessage = "Deposit amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Deposit amount must be greater than or equal to 0.")]
        public decimal DepositAmount { get; set; }

        public bool IsDepositPaid { get; set; }


    }

    public enum ReservationType
    {
        Tour,
        Custom
    }
}
