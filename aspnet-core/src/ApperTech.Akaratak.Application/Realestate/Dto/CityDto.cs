using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(City))]
    public class CityDto
    {
        public int CountryId { get; set; }


        [Required, MinLength(5), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public string NativeName { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public string LatinName { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public float Latitude { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public float Longitude { get; set; }
    }
}