using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppDirection")]
    public class Direction : FullAuditedEntity<int>
    {
        public bool West { get; set; }
        public bool East { get; set; }
        public bool North { get; set; }
        public bool South { get; set; }
    }
}