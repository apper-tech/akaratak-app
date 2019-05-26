using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace akaratak_app.Models
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubCategory_ID { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        [MinLength(3),MaxLength(20)]
        public string SubCategoryName { get; set; }
          [Required]
        [MinLength(10),MaxLength(50)]
        public string SubCategoryDescription { get; set; }
    }
}