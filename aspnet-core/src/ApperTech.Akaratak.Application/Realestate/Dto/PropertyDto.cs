using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Timing;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class PropertyDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public PropertyType PropertyType { get; set; }
        [Required]
        public Offer Offer { get; set; }
        [Required]
        public Features Features { get; set; }
        [Required]
        public ICollection<Photo> Photos { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ListingDate { get; set; } = Clock.Now;

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        public int Views { get; set; }
        public string ExtraData { get; set; }
    }
}