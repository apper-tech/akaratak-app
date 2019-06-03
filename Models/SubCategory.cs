using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace akaratak_app.Models
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public Category Category { get; set; }
        [ForeignKey("CategoryFK")]
        public int CategoryID { get; set; }
        [Required]
        public Property Property { get; set; }
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(10), MaxLength(50)]
        public string Description { get; set; }
    }
}