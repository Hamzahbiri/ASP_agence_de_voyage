using System.ComponentModel.DataAnnotations;
namespace Agence_de_Voyages.Models
{
   
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        [Required(ErrorMessage = "City name is required.")]
        public string? CityName { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string? Country { get; set; }

        [EnumDataType(typeof(Airport), ErrorMessage = "Invalid airport code.")]
        public string? AirportCode { get; set; }

        [Display(Name = "Additional Local Transport")]
        [EnumDataType(typeof(LocalTransport), ErrorMessage = "Invalid Means of Transport")]
        public string? LocalTransport { get; set; }

        [Required(ErrorMessage = "Price estimate is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price estimate must be a non-negative value.")]
        public decimal PriceEstimate { get; set; }
    }

    public enum Airport
    {
        ATL,
        PEK,
        DXB,
        LHR,
        HND,
        ORD,
        LAX,
        CDG,
        DFW,
        JFK,
        AMS,
        PVG,
        ICN,
        FRA,
        SIN,
        DEN,
        DOH,
        SFO,
        IST,
        CLT,
        LAS,
        PHX,
        MIA,
        YYZ,
        MUC,
        BKK,
        MAD,
        SEA,
        JNB,
        SYD,
        IAH,
        PHL,
        MEX,
        MSP,
        DTW,
        GRU,
        ZRH,
        SVO,
        YYZ2,
        CGK,
        LIM,
        YYC,
        BRU,
        VIE,
        OSL,
        ATH,
        CPH,
        HEL
    }

    public enum LocalTransport
    {
        Ferry,
        Train,
        Bus,
        Taxi,
    }

}
