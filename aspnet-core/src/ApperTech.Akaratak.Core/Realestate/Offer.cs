using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppOffer")]
    public class Offer : FullAuditedEntity<int>
    {
        public Currency Currency { get; set; }

        public Property Property { get; set; }

        [Required, MinLength(1)]
        public float Sale { get; set; }
        [Required, MinLength(1)]
        public float Rent { get; set; }
        [Required, MinLength(1)]
        public float Invest { get; set; }
        [Required]
        public bool Swap { get; set; }

    }
}
