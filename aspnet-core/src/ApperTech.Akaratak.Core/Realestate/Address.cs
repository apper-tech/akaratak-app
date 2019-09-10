using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppAddress")]
    public class Address : FullAuditedEntity<int>
    {
        public Property Property { get; set; }
        public City City { get; set; }

        [Required, MinLength(10), MaxLength(40)]
        public string Location { get; set; }
        [MaxLength(6)]
        public string ZipCode { get; set; }
        [Required, MinLength(15), MaxLength(60)]
        public string Street { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public float Latitude { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public float Longitude { get; set; }
    }
}