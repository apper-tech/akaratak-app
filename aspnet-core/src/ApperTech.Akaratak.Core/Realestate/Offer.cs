using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppOffer")]
    public class Offer : FullAuditedEntity<int>
    {
        [ForeignKey("CurrencyFK")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [JsonIgnore]
        public Property Property { get; set; }

        [Required, Range(1, float.MaxValue)]
        public float Sale { get; set; }
        [Required, Range(1, float.MaxValue)]
        public float Rent { get; set; }
        [Required, Range(1, float.MaxValue)]
        public float Invest { get; set; }
        [Required]
        public bool Swap { get; set; }

    }
}
