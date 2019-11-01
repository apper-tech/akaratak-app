using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapTo(typeof(Property))]
    public class UpdatePropertyInput : IEntityDto<int>
    {
        public virtual int Id { get; set; }
        [Required] public UpdateAddressInput Address { get; set; }
        [Required] public UpdateOfferInput Offer { get; set; }
        [Required] public UpdateFeaturesInput Features { get; set; }
        [Required] public int PropertyType { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }
    }
}