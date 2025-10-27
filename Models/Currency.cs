using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string Sign { get; set; }
        [Required]
        [MinLength(5), MaxLength(20)]
        public string LocalSign { get; set; }
    }
}