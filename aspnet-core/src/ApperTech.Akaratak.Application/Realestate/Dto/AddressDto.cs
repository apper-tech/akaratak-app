using System.ComponentModel.DataAnnotations;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class AddressDto
    {
        public int City { get; set; }

        [Required, MinLength(10), MaxLength(40)]
        public string Location { get; set; }
        [MaxLength(6)]
        public string ZipCode { get; set; }
        [Required, MinLength(15), MaxLength(60)]
        public string Street { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public float Latitude { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public float Longitude { get; set; }
    }
}