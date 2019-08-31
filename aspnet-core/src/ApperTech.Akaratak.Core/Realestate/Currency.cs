using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppCurrency")]
    public class Currency : FullAuditedEntity<int>
    {
        [Required]
        public Country Country { get; set; }


        [Required, MinLength(5), MaxLength(20)]
        public string Name { get; set; }

        [Required, MinLength(5), MaxLength(20)]
        public string Sign { get; set; }

        [Required, MinLength(5), MaxLength(20)]
        public string LocalSign { get; set; }
    }
}