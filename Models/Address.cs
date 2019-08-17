using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public Property Property { get; set; }
        public City City { get; set; }
        [Required]
        public string Location { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public float Latitude { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public float Longitude { get; set; }
    }
}