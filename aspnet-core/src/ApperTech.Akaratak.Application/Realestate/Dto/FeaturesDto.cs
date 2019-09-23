using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Features))]
    public class FeaturesDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }

        [Required, MinLength(10), MaxLength(99)]
        public string Title { get; set; }

        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }

        public ICollection<TagDto> Tags { get; set; }

        [Required]
        public Direction Direction { get; set; } = Direction.East | Direction.North;

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

        [Required, Range(1, 999)]
        public int Area { get; set; }
        [Required, Range(1, 99)]
        public int Owners { get; set; }
        [Required, Range(1, 99)]
        public int Rooms { get; set; }
        [Required, Range(1, 99)]
        public int Bathrooms { get; set; }
        [Required, Range(1, 99)]
        public int Bedrooms { get; set; }
        [Required, Range(1, 99)]
        public int Balconies { get; set; }
        [Required, Range(0, 600)]
        public int PropertyAge { get; set; }
    }
    [AutoMapTo(typeof(Features))]
    public class CreateFeaturesInput : FeaturesDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
        public new ICollection<int> Tags { get; set; }
        [Required]
        public new ICollection<int> Direction { get; set; }
    }
}