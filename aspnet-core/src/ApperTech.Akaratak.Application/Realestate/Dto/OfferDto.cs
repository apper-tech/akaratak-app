using System.ComponentModel.DataAnnotations;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class OfferDto
    {
        public int Currency { get; set; }

        [Required, MinLength(1)]
        public float Sale { get; set; }
        [Required, MinLength(1)]
        public float Rent { get; set; }
        [Required, MinLength(1)]
        public float Invest { get; set; }
        [Required]
        public bool Swap { get; set; }
    }
}