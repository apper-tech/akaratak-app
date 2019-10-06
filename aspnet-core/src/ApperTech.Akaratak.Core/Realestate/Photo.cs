using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppPhoto")]
    public class Photo : FullAuditedEntity<int>
    {
        public Property Property { get; set; }

        [Required, MinLength(20)]
        public string Url { get; set; }
        [MinLength(10), MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public bool IsMain { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string PublicId { get; set; }



    }
}