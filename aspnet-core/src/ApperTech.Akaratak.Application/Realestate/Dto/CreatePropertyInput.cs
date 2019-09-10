using System;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Timing;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapTo(typeof(Property))]
    public class CreatePropertyInput
    {
        [Required] public CreateAddressInput Address { get; set; }
        [Required] public CreateOfferInput Offer { get; set; }
        [Required] public CreateFeaturesInput Features { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        private DateTime ListingDate { get; set; } = Clock.Now;

        [Required] public int PropertyType { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }
    }
}