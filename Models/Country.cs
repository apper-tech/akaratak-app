using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Country
    {
        [Key]
        public int Country_ID { get; set; }
        [Required]
        [MinLength(2),MaxLength(2)]
        public string CountryCode { get; set; }
        [Required]
        [MinLength(5),MaxLength(20)]
        public string CountryName { get; set; }
        [Required]
        [MinLength(5),MaxLength(20)]
        public string CountryNativeName { get; set; }
    }
}