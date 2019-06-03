using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public float Sale { get; set; }
        public float Rent { get; set; }
        public float Invest { get; set; }
        public bool Swap { get; set; }
        [Required]
        public Currency Currency { get; set; }
    }
}