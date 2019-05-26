using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace akaratak_app.Models
{
    public class Tags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Tag_ID { get; set; }
         [Required]
        [MinLength(3),MaxLength(20)]
        public string TagName { get; set; }
          [Required]
        [MinLength(10),MaxLength(50)]
        public string TagDescription { get; set; }
    }
}