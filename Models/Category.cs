using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MinLength(5),MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(10),MaxLength(50)]
        public string Description { get; set; }

        public SubCategory SubCategory { get; set; }
    }
}