using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MinLength(2), MaxLength(2)]
        public string Code { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(5), MaxLength(50)]
        public string NativeName { get; set; }
    }
}