using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppCity")]
    public class City : FullAuditedEntity<int>
    {
        [ForeignKey("CountryFK")]
        public int CountryId { get; set; }
        public Country Country { get; set; }


        [Required, MinLength(5), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public string NativeName { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public string LatinName { get; set; }

        [Required, Range(0, float.MaxValue)]
        public float Latitude { get; set; }

        [Required, Range(0, float.MaxValue)]
        public float Longitude { get; set; }
    }
}