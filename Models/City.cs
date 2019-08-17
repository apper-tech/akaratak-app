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
        [MinLength(5), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string NativeName { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string LatinName { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public float Latitude { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public float Longitude { get; set; }
    }
}