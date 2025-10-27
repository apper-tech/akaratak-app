using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace akaratak_app.Models
{
    [Table("Property")]
    public class Property
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public Address Address { get; set; }
        public int AddressID { get; set; }
        [Required]
        public SubCategory SubCategory { get; set; }
        public int SubCategoryID { get; set; }
        [Required]
        public Offer Offer { get; set; }
        [Required]
        public Features Features { get; set; }
        public Listing Listing { get; set; }
        [ForeignKey("ListingFK")]
        public int ListingID { get; set; }
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