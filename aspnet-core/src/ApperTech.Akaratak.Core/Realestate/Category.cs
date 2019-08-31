using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppCategory")]
    public class Category : FullAuditedEntity<int>
    {

        public ICollection<PropertyType> PropertyTypes { get; set; }

        [Required, MinLength(5), MaxLength(20)]
        public string Name { get; set; }

        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }

      
    }
}