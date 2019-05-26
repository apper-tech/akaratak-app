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
        public int Currency_ID { get; set; }
        [Required]
        [MinLength(5),MaxLength(20)]
        public string CurrencyName { get; set; }
         [Required]
        [MinLength(5),MaxLength(20)]
        public string CurrencySign { get; set; }
    }
}