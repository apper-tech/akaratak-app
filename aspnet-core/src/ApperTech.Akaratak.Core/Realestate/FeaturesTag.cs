using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppFeaturesTag")]
    public class FeaturesTag
    {
        [Required]
        public int TagId { get; set; }
        [JsonIgnore]
        public Tag Tag { get; set; }
        [Required]
        public int FeaturesId { get; set; }
        [JsonIgnore]
        public Features Features { get; set; }
    }
}
