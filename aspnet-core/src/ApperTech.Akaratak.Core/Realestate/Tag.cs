using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppTag")]
    public class Tag : FullAuditedEntity<int>
    {
        public ICollection<FeaturesTag> FeaturesTags { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}