using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Timing;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Property))]
    public class PropertyDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }
        [Required]
        public AddressDto Address { get; set; }
        [Required]
        public PropertyTypeDto PropertyType { get; set; }
        [Required]
        public OfferDto Offer { get; set; }
        [Required]
        public FeaturesDto Features { get; set; }
        [Required]
        public ICollection<PhotoDto> Photos { get; set; }

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