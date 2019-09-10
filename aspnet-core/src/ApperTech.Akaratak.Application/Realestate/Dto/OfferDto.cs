using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class OfferDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }
        [Required]
        public int Currency { get; set; }
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
    }
}