using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public Country Country { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string CityName { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string CityNativeName { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string CityLatinName { get; set; }
        [Required]
        [MinLength(5), MaxLength(25)]
        public float Latitude { get; set; }
        [Required]
        [MinLength(5), MaxLength(25)]
        public float Longitude { get; set; }
    }
}