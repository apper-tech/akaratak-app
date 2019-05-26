using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    [Table("Property")]
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Property_ID { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public Offer Offer { get; set; }
        [ForeignKey("Property_ID")]
        public Features Features { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public int Lister_ID { get; set; }
        public string ExtraData { get; set; }
    }
}