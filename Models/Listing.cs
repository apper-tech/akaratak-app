using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Listing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Listing_ID { get; set; }
        [ForeignKey("UserFK")]
        [Column(Order = 1)]
        public int User_ID { get; set; }
        [Required]
        public Property Property { get; set; }
    }
}