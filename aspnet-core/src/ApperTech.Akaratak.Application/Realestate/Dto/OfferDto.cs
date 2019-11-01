using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Offer))]
    public class OfferDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual CurrencyDto Currency { get; set; }
        [Required, Range(0, int.MaxValue)]
        public float Sale { get; set; }
        [Required, Range(0, int.MaxValue)]
        public float Rent { get; set; }
        [Required, Range(0, int.MaxValue)]
        public float Invest { get; set; }
        [Required]
        public bool Swap { get; set; }
    }
    [AutoMapTo(typeof(Offer))]
    public class CreateOfferInput : OfferDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        public new int Currency { get; set; }
    }
    [AutoMapTo(typeof(Offer))]
    public class UpdateOfferInput : OfferDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        public new int Currency { get; set; }
    }
    public class OfferPagedResultInput
    {

        public bool Sale { get; set; }

        public bool Rent { get; set; }

        public bool Invest { get; set; }

        public bool Swap { get; set; }
    }
}