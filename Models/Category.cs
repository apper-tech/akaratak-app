using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_ID { get; set; }
        [Required]
        [MinLength(5),MaxLength(20)]
        public string CategoryName { get; set; }
        [Required]
        [MinLength(10),MaxLength(50)]
        public string CategoryDescription { get; set; }
    }
}