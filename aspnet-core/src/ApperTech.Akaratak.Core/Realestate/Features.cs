using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppFeatures")]
    public class Features : FullAuditedEntity<int>
    {
        public ICollection<FeaturesTag> FeaturesTags { get; set; }

        [JsonIgnore]
        public Property Property { get; set; }

        public Direction Direction { get; set; }

        [Required]
        public bool Cladding { get; set; }
        [Required]
        public bool Empty { get; set; }
        [Required]
        public bool Heating { get; set; }
        [Required]
        public bool GasLine { get; set; }
        [Required]
        public bool Internet { get; set; }
        [Required]
        public bool Elevator { get; set; }
        [Required]
        public bool Parking { get; set; }

        [Required, Range(20, 999)]
        public int Area { get; set; }
        [Required, Range(1, 20)]
        public int Owners { get; set; }
        [Required, Range(1, 20)]
        public int Rooms { get; set; }
        [Required, Range(1, 20)]
        public int Bathrooms { get; set; }
        [Required, Range(1, 20)]
        public int Bedrooms { get; set; }
        [Required, Range(1, 20)]
        public int Balconies { get; set; }

        [Required, Range(0, 600)]
        public int PropertyAge { get; set; }

        [Required, MinLength(10), MaxLength(20)]
        public string Title { get; set; }

        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }



    }
}
