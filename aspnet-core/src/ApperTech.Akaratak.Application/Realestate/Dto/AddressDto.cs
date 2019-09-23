using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Address))]
    public class AddressDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }

        public CityDto City { get; set; }

        [Required, MinLength(10), MaxLength(40)]
        public string Location { get; set; }
        [MaxLength(6)]
        public string ZipCode { get; set; }
        [Required, MinLength(15), MaxLength(60)]
        public string Street { get; set; }
        [Required, Range(-90f, +90f)]
        public float Latitude { get; set; }
        [Required, Range(-180f, +180f)]
        public float Longitude { get; set; }
    }
    [AutoMapTo(typeof(Address))]
    public class CreateAddressInput : AddressDto
    {
        [JsonIgnore] public override int Id { get; set; }
        public new int City { get; set; }
    }
}