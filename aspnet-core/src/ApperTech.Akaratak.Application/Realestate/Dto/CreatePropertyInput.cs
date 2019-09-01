using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Timing;
using Microsoft.AspNetCore.Http;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapTo(typeof(Property))]
    public class CreatePropertyInput
    {
        [Required] public AddressDto Address { get; set; }
        [Required] public int PropertyType { get; set; }
        [Required] public OfferDto Offer { get; set; }
        [Required] public FeaturesDto Features { get; set; }
        public ICollection<IFormFile> Photos { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        private DateTime ListingDate { get; set; } = Clock.Now;

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }
    }
}