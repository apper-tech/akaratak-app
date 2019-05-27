using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace akaratak_app.Models
{
    [Table("Properties")]
    public class Features
    {
        [Key]
        public int Property_ID { get; set; }
        public Property Property { get; set; }
        [Required]
        public Directon Directon { get; set; }
        [Required]
        public bool Cladding { get; set; }
        [Required]
        public bool Empty { get; set; }
        [Required]
        public bool Heating { get; set; }
        [Required]
        public bool GasLine { get; set; }
        [Required]
        public bool Internet { get; set; }
        [Required]
        public bool Elevator { get; set; }
        [Required]
        public bool Parking { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int Owners { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        [MaxLength(10), MinLength(5)]
        public int Bathrooms { get; set; }
        [Required]
        [MaxLength(10), MinLength(5)]
        public int Balconies { get; set; }
        [Required]
        [MaxLength(10), MinLength(5)]
        public int PropertyAge { get; set; }
        [Required]
        [MinLength(10), MaxLength(50)]
        public string Description { get; set; }



        public ICollection<Tags> Tags { get; set; }

    }
}