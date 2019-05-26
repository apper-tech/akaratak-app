using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Offer_ID { get; set; }
        public float Sale { get; set; }
        public float Rent { get; set; }
        public float Invest { get; set; }
        public bool Swap { get; set; }
        
        [ForeignKey("CurrencyFK")]
        public int Currency_ID { get; set; }
    }
}