using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Tag))]
    public class TagDto : IEntityDto<int>
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }
    }
}