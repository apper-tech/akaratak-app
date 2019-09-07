using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppPropertyType")]
    public class PropertyType : FullAuditedEntity<int>
    {
        public Category Category { get; set; } 

        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }
    }
}