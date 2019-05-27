using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace akaratak_app.Models
{
    [Table("Properties")]
    public class Property
    {
        [Key]
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
        [Required]
        public DateTime ListingDate { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        public int Views { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public string ExtraData { get; set; }
    }
}