using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppAddress")]
    public class Address : FullAuditedEntity<int>
    {
        [JsonIgnore]
        public Property Property { get; set; }

        [ForeignKey("CityFK")]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required, MinLength(10), MaxLength(80)]
        public string Location { get; set; }
        [MaxLength(6)]
        public string ZipCode { get; set; }
        [Required, MinLength(15), MaxLength(60)]
        public string Street { get; set; }
        [Required, Range(0, float.MaxValue)]
        public float Latitude { get; set; }
        [Required, Range(0, float.MaxValue)]
        public float Longitude { get; set; }
    }
}